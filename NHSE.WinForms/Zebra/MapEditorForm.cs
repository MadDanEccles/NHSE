using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.WinForms.Zebra.Controls;
using NHSE.WinForms.Zebra.Renderers.ColorSchemes;
using NHSE.WinForms.Zebra.Renderers.RenderStyles;
using NHSE.WinForms.Zebra.SegmentLayouts;
using NHSE.WinForms.Zebra.Tools;
using NHSE.WinForms.Zebra.Validation;
using static NHSE.WinForms.Zebra.EditorTool;

namespace NHSE.WinForms.Zebra
{
    public partial class MapEditorForm : Form, IColorSchemeProvider
    {
        private readonly MapManager mapManager;
        private readonly MainSave save;
        private readonly IHistoryService historyService;

        private readonly Dictionary<Keys, EditorTool> toolKeys = new Dictionary<Keys, EditorTool>()
        {
            {Keys.I, Pick},
            {Keys.B, EditorTool.Brush},
            {Keys.X, Erase},
            {Keys.Z, PanAndZoom},
            {Keys.M, Marquee},
            {Keys.V, MoveItems},
            {Keys.R, FillRect},
            {Keys.T, SingleTemplate}
        };

        private EditorTool currentTool;
        private IColorScheme colorScheme = new DefaultColorScheme();
        private ItemCollectionCatalog collectionCatalog;

        public MapEditorForm(MainSave save)
        {
            InitializeComponent();
            this.save = save;
            this.mapManager = new MapManager(save);
            mapView.Map = this.mapManager;
            mapView.ItemRenderStyle = new ClairesRenderStyle(this);

            ItemConvertor.Initialise();

            // Check the map for common issues and allow the user to fix them before proceeding...
            ValidateMap();

            // Set up the history service to provide Undo/Redo functionality
            historyService = new HistoryService();
            historyService.HistoryChanged += HistoryServiceOnHistoryChanged;
            LayoutManager layoutManager = new LayoutManager();
            layoutManager.Register(new DisplaySegmentLayoutFactory());
            layoutManager.Register(new DiyLoayoutFactory());
            layoutManager.Register(new MinWidthMultiSegmentLayoutFactory());
            layoutManager.Register(new JustifiedMultiSegmentLayoutFactory());

            var itemSource = new ItemSource();
            itemEditor.Initialize(itemSource);
            collectionCatalog = ItemCollectionManager.Load();
            multiItemSelector.Initialise(itemSource, collectionCatalog, layoutManager);

            // var itemKind = ItemInfo.GetItemKind(0x27B9);


                var itemDropdownData = itemSource.GetItemDropdownData();
            foreach (var item in itemDropdownData.Where(i => i.Text.StartsWith("fence", StringComparison.OrdinalIgnoreCase)))
                Debug.WriteLine($"{item.Text} => {item.Value}");

                //foreach (var item in itemDropdownData)
                //{
                //    if (ItemInfo.GetItemKind((ushort) item.Value) == ItemKind.Kind_Fish)
                //    {
                //        var model = itemDropdownData.FirstOrDefault(i => i.Text == $"{item.Text} model");
                //        if (model != null)
                //        {
                //            if (ItemInfo.GetItemKind((ushort) model.Value) != ItemKind.Kind_FishToy)
                //                throw new Exception();
                //            Debug.WriteLine($"{{\"C\": {item.Value}, \"M\":{model.Value}}},");
                //        }
                //    }
                //}

                //foreach (var item in itemDropdownData)
                //{
                //    if (ItemInfo.GetItemKind((ushort)item.Value) == ItemKind.Kind_Insect)
                //    {
                //        var model = itemDropdownData.FirstOrDefault(i => i.Text == $"{item.Text} model");
                //        if (model.Text !=  null)
                //        {
                //            if (ItemInfo.GetItemKind((ushort)model.Value) != ItemKind.Kind_InsectToy)
                //                throw new Exception();
                //            Debug.WriteLine($"{{\"C\": {item.Value}, \"M\":{model.Value}}},");
                //        }
                //        else
                //        {
                //            Debug.WriteLine($"{{\"C\": \"{item.Value}\", \"M\":\"{item.Text}\"}},");
                //        }
                //    }
                //}

                // Select the initial tool
                SelectTool(PanAndZoom);
        }

        private void ValidateMap()
        {
            ItemIntegrityValidation val = new ItemIntegrityValidation(mapManager);
            ValidationResult vr = new ValidationResult();
            val.Validate(vr);

            if (vr.HasFixes)
            {
                if (MessageBox.Show(
                    "Errors were detected in the map - do you wish to fix these now? Please ensure that you have a backup of the map before proceeding.",
                    "Validation Errors", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    string summary = vr.Fix(mapManager);
                    MessageBox.Show(summary, "Fixed!");
                }
            }
        }

        /// <summary>
        /// This is a bit of a hack for the time being to get color schemes working...
        /// </summary>
        IColorScheme IColorSchemeProvider.GetColorScheme()
        {
            return this.colorScheme;
        }

        private void HistoryServiceOnHistoryChanged(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = historyService.CanUndo;
            undoToolStripMenuItem.Text = $"Undo {historyService.UndoDescription}";
            redoToolStripMenuItem.Enabled = historyService.CanRedo;
            redoToolStripMenuItem.Text = $"Redo {historyService.RedoDescription}";
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            var choice = MessageBox.Show("Do you wish to save changes?", "Save Changes", MessageBoxButtons.YesNoCancel);
            switch (choice)
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.Yes:
                    SaveChanges();
                    break;
                case DialogResult.No:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            base.OnClosing(e);
        }

        private void SaveChanges()
        {
            var unsupported = mapManager.Items.GetUnsupportedTiles();
            if (unsupported.Count != 0)
            {
                var err = MessageStrings.MsgFieldItemUnsupportedLayer2Tile;
                var ask = MessageStrings.MsgAskContinue;
                var prompt = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, err, ask);
                if (prompt != DialogResult.Yes)
                    return;
            }

            mapManager.Items.Save();
            save.SetTerrainTiles(mapManager.Terrain.Tiles);

            save.SetAcreBytes(mapManager.Terrain.BaseAcres);
            // save.OutsideFieldTemplateUniqueId = (ushort)NUD_MapAcreTemplateOutside.Value;
            // save.MainFieldParamUniqueID = (ushort)NUD_MapAcreTemplateField.Value;

            save.Buildings = mapManager.Buildings;
            save.EventPlazaLeftUpX = mapManager.PlazaX;
            save.EventPlazaLeftUpZ = mapManager.PlazaY;
        }

        private void btnMove_Click(object sender, EventArgs e) => SelectTool(MoveItems);
        private void btnMarquee_Click(object sender, EventArgs e) => SelectTool(Marquee);
        private void btnZoom_Click(object sender, EventArgs e) => SelectTool(PanAndZoom);
        private void btnPaint_Click(object sender, EventArgs e) => SelectTool(EditorTool.Brush);
        private void btnPick_Click(object sender, EventArgs e) => SelectTool(Pick);
        private void btnTemplate_Click(object sender, EventArgs e) => SelectTool(SingleTemplate);
        private void btnEraser_Click(object sender, EventArgs e) => SelectTool(Erase);
        private void btnFillRect_Click(object sender, EventArgs e) => SelectTool(FillRect);

        private void deleteSelectedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var trans = historyService.BeginTransaction("Delete Selection"))
            {
                foreach (var selectedItem in mapView.SelectionService.SelectedItems)
                {
                    mapView.MapEditingService.DeleteTile(selectedItem.Bounds.Location, trans);
                }
            }

            mapView.SelectionService.ClearSelection();
            mapView.Invalidate();
        }

        /// <summary>
        /// The menu strip captures keys such as 'delete' and 'ctrl+x' which would normally
        /// be handled by certain input control like text boxes etc. This override ensures
        /// that command keys are always routed to those controls when they are focused.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Control focusedControl = FindFocusedControl(this);
            if (focusedControl is TextBox
                || focusedControl is NumericUpDown
                || focusedControl is ComboBox)
                return false;
            if (mapView.Focused && mapView.CurrentTool?.CanDeselect == false)
            {
                mapView.ProcessCommandKey(keyData);
                return false;
            }
            if (ProcessToolKey(keyData))
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool ProcessToolKey(Keys keyData)
        {
            bool result = toolKeys.TryGetValue(keyData, out var tool);
            if (result)
                SelectTool(tool);
            return result;
        }

        private bool SelectTool(EditorTool newTool)
        {
            if (currentTool != newTool && mapView.CurrentTool?.CanDeselect != false)
            {
                mapView.CurrentTool = CreateMapTool(newTool);
                currentTool = newTool;
                CheckToolboxItem(newTool);
                return true;
            }

            return false;
        }

        private IMapTool? CreateMapTool(EditorTool tool)
        {
            return tool switch
            {
                MoveItems => new MoveTool(mapView.SelectionService, mapView.SelectionRenderer, historyService),
                FillRect => new FillRectTool(SelectToolPropertiesControl(this.itemEditor), historyService),
                Marquee => new MarqueeSelectionTool(mapView.SelectionService, mapView.SelectionRenderer, historyService),
                PanAndZoom => new PanTool(),
                EditorTool.Brush => new PaintTool(SelectToolPropertiesControl(this.itemEditor), historyService, itemEditor),
                Pick => new PickTool(SelectToolPropertiesControl(this.itemEditor)),
                Erase => new EraserTool(historyService),
                SingleTemplate => new TemplateTool(historyService, SelectToolPropertiesControl(this.itemEditor)),
                MultiTemplate => new MultiTemplateTool(historyService, SelectToolPropertiesControl(this.multiItemSelector)),
                None => null,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private T SelectToolPropertiesControl<T>(T control) where T : Control
        {
            foreach (Control propControl in panel1.Controls)
            {
                propControl.Visible = propControl == control;
            }

            return control;
        }

        private void CheckToolboxItem(EditorTool editorTool)
        {
            btnFillRect.Checked = editorTool == FillRect;
            btnMarquee.Checked = editorTool == Marquee;
            btnMove.Checked = editorTool == MoveItems;
            btnBrush.Checked = editorTool == EditorTool.Brush;
            btnSingleTemplate.Checked = editorTool == SingleTemplate;
            btnZoom.Checked = editorTool == PanAndZoom;
            btnEraser.Checked = editorTool == Erase;
            btnPick.Checked = editorTool == Pick;
            btnMultiTemplate.Checked = editorTool == MultiTemplate;
        }

        public static Control FindFocusedControl(Control control)
        {
            var container = control as IContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as IContainerControl;
            }
            return control;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            historyService.Undo();
            mapView.Invalidate();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            historyService.Redo();
            mapView.Invalidate();
        }

        private void mapView_Click(object sender, EventArgs e)
        {
            mapView.Focus();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void copyIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Item item = new Item();
                itemEditor.ApplyToItem(item);
                if (item != null)
                {
                    Clipboard.SetText(item.ItemId.ToString());
                }
            }
            catch (Exception caught)
            {
                ThreadExceptionDialog dlg = new ThreadExceptionDialog(caught);
                dlg.ShowDialog(this);
            }
        }

        private void btnMultiTemplate_Click(object sender, EventArgs e) => SelectTool(EditorTool.MultiTemplate);

        private void editCollectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CollectionEditorForm.EditModal(this, this.collectionCatalog, new ItemSource());
            multiItemSelector.RefreshCollections();
        }

        private void deleteAllItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure that you wish to clear all items?", "Delete All Items",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                using (var trans = historyService.BeginTransaction("Delete All Items"))
                {
                    mapView.MapEditingService.DeleteAll(trans);
                    mapView.Invalidate();
                }
            }
        }
    }

    internal enum EditorTool
    {
        None,
        PanAndZoom,
        Marquee,
        MoveItems,
        Erase,
        Brush,
        FillRect,
        SingleTemplate,
        Pick,
        MultiTemplate
    }

}
