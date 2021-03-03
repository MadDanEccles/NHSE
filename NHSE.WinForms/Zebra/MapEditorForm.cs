using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.WinForms.Zebra.Tools;
using static NHSE.WinForms.Zebra.EditorTool;

namespace NHSE.WinForms.Zebra
{
    public partial class MapEditorForm : Form
    {
        private readonly MapManager mapManager;
        private readonly MainSave save;

        public MapEditorForm(MainSave save)
        {
            InitializeComponent();
            this.save = save;
            this.mapManager = new MapManager(save);
            mapView.Map = this.mapManager;

            var data = GameInfo.Strings.ItemDataSource.ToList();
            var field = FieldItemList.Items.Select(z => z.Value).ToList();
            data.Add(field, GameInfo.Strings.InternalNameTranslation);
            itemEditor2.Initialize(data, true);

            SelectTool(PanAndZoom);
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
        private void btnPaint_Click(object sender, EventArgs e) => SelectTool(Brush);
        private void btnPick_Click(object sender, EventArgs e) => SelectTool(Pick);
        private void btnTemplate_Click(object sender, EventArgs e) => SelectTool(Template);
        private void btnEraser_Click(object sender, EventArgs e) => SelectTool(Erase);
        private void btnFillRect_Click(object sender, EventArgs e) => SelectTool(FillRect);

        private void deleteSelectedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var selectedItem in mapView.SelectionService.SelectedItems)
            {
                mapView.MapEditingService.DeleteTile(selectedItem.Bounds.Location);
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
            if (ProcessToolKey(keyData))
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private readonly Dictionary<Keys, EditorTool> toolKeys = new Dictionary<Keys, EditorTool>()
        {
            {Keys.I, Pick},
            {Keys.B, Brush},
            {Keys.X, Erase},
            {Keys.Z, PanAndZoom},
            {Keys.M, Marquee},
            {Keys.V, MoveItems},
            {Keys.R, FillRect},
            {Keys.T, Template}
        };

        private bool ProcessToolKey(Keys keyData)
        {
            bool result = toolKeys.TryGetValue(keyData, out var tool);
            if (result)
                SelectTool(tool);
            return result;
        }

        private EditorTool currentTool;

        private bool SelectTool(EditorTool newTool)
        {
            if (currentTool != newTool && mapView.CurrentTool?.CanDeselect == true)
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
                MoveItems => new MoveTool(mapView.SelectionService, mapView.SelectionRenderer),
                FillRect => new FillRectTool(new ItemSelector(this.itemEditor2)),
                Marquee => new MarqueeSelectionTool(mapView.SelectionService),
                PanAndZoom => new PanTool(),
                Brush => new PaintTool(new PaintOptions(this.itemEditor2)),
                Pick => new PickTool(new PickTarget(this.itemEditor2)),
                Erase => new EraserTool(),
                Template => null,
                None => null,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void CheckToolboxItem(EditorTool editorTool)
        {
            btnFillRect.Checked = editorTool == FillRect;
            btnMarquee.Checked = editorTool == Marquee;
            btnMove.Checked = editorTool == MoveItems;
            btnBrush.Checked = editorTool == Brush;
            btnTemplate.Checked = editorTool == Template;
            btnZoom.Checked = editorTool == PanAndZoom;
            btnEraser.Checked = editorTool == Erase;
            btnPick.Checked = editorTool == Pick;
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
        Template,
        Pick,
    }

    internal class ItemSelector : IItemSelector
    {
        private readonly WinForms.ItemEditor itemEditor;

        public ItemSelector(WinForms.ItemEditor itemEditor)
        {
            this.itemEditor = itemEditor;
        }

        public Item GetItem()
        {
            Item item = new Item();
            return itemEditor.SetItem(item);
        }
    }

    internal class PickTarget : IPickTarget
    {
        private readonly WinForms.ItemEditor itemEditor;

        public PickTarget(WinForms.ItemEditor itemEditor)
        {
            this.itemEditor = itemEditor;
        }

        public void Pick(Item item)
        {
            itemEditor.LoadItem(item);
        }
    }

    internal class PaintOptions : ItemSelector, IPaintOptions
    {
        public PaintOptions(WinForms.ItemEditor itemEditor)
            : base(itemEditor)
        {
        }

        public bool AlignToItemGrid => true;
    }
}
