using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Autofac;
using NHSE.Core;
using Nhtid.WinForms.Controls;
using Nhtid.WinForms.Documents;
using Nhtid.WinForms.Renderers.ColorSchemes;
using Nhtid.WinForms.Renderers.RenderStyles;
using Nhtid.WinForms.Tools;
using Nhtid.WinForms.Validation;
using static Nhtid.WinForms.EditorTool;

namespace Nhtid.WinForms
{
    public partial class MapEditorForm : Form, IColorSchemeProvider, IDocumentContainer
    {
        private readonly IEnumerable<IMapValidation> mapValidators;
        private readonly ILifetimeScope scope;
        private MapManager mapManager;
        private MainSave save;
        private readonly IHistoryService historyService;
        private readonly ItemConvertor itemConvertor;
        private readonly IItemCollectionStore collectionStore;
        private readonly IEnumerable<IDocumentFactory> documentFactories;

        private readonly Dictionary<Keys, EditorTool> toolKeys = new()
        {
            { Keys.I, Pick },
            { Keys.B, EditorTool.Brush },
            { Keys.X, Erase },
            { Keys.Z, PanAndZoom },
            { Keys.M, Marquee },
            { Keys.V, MoveItems },
            { Keys.R, FillRect },
            { Keys.T, SingleTemplate }
        };

        private EditorTool currentTool;
        private readonly IColorScheme colorScheme = new DefaultColorScheme();
        private Document document;
        private bool hasPendingChanges;
        private ItemSource itemSource;
        private readonly TrackBar zoomTrackBar;
        private readonly RecentFilesManager recentFileManager;

        public MapEditorForm(
            IEnumerable<IMapValidation> mapValidators,
            ILifetimeScope scope,
            IHistoryService historyService,
            ItemConvertor itemConvertor,
            IItemCollectionStore collectionStore,
            IEnumerable<IDocumentFactory> documentFactories,
            ItemSource itemSource)
        {
            this.itemSource = itemSource;
            this.historyService = historyService;
            this.itemConvertor = itemConvertor;
            this.collectionStore = collectionStore;
            this.documentFactories = documentFactories;
            this.mapValidators = mapValidators;
            this.scope = scope;
            this.recentFileManager = new RecentFilesManager();
            this.recentFileManager.RecentFilesChanged += (s, e) => RefreshRecentFileMenu();
            InitializeComponent();
            RefreshRecentFileMenu();
            mapView.ItemRenderStyle = new ClairesRenderStyle(this);

            zoomTrackBar = new TrackBar();
            zoomTrackBar.Margin = new Padding(0, 0, 0, 3);
            zoomTrackBar.Padding = new Padding(0, 0, 0, 3);
            zoomTrackBar.AutoSize = false;
            zoomTrackBar.Minimum = mapView.MinZoom;
            zoomTrackBar.Maximum = mapView.MaxZoom;
            zoomTrackBar.Value = mapView.ZoomLevel;
            zoomTrackBar.Size = new Size(120, 22);
            zoomTrackBar.ValueChanged += ZoomTrackBarOnValueChanged;

            ToolStripControlHost zoomControlHost = new ToolStripControlHost(zoomTrackBar);
            zoomControlHost.AutoSize = true;
            zoomControlHost.Padding = new Padding(0, 0, 0, 3);
            statusStrip.Items.Add(zoomControlHost);
            
            // Set up the history service to provide Undo/Redo functionality
            historyService.HistoryChanged += HistoryServiceOnHistoryChanged;


            // Select the initial tool
            SelectTool(PanAndZoom);
        }

        protected override void OnLoad(EventArgs e)
        {
            scope.AutoWire(Controls);
            base.OnLoad(e);
        }

        private void RefreshRecentFileMenu()
        {
            var recentFiles = recentFileManager.RecentFiles.ToArray();
            openRecentFileToolStripMenuItem.Enabled = recentFiles.Any();
            openRecentFileToolStripMenuItem.DropDownItems.Clear();
            
            foreach (var recentFile in recentFiles)
            {
                openRecentFileToolStripMenuItem.DropDownItems.Add(recentFile.FileName).Click += (s, e) => 
                    OpenFile(recentFile.FileName);
            }
        }
        
        private void ZoomTrackBarOnValueChanged(object sender, EventArgs e)
        {
            mapView.Zoom( zoomTrackBar.Value);
        }

        private void ValidateMap()
        {
            ValidationResult vr = new ValidationResult();
            foreach (var validator in mapValidators)
                validator.Validate(mapManager, vr);

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
            if (!this.hasPendingChanges)
            {
                this.hasPendingChanges = true;
                OnHasPendingChangesChanged();
            }
            undoToolStripMenuItem.Enabled = historyService.CanUndo;
            undoToolStripMenuItem.Text = $"Undo {historyService.UndoDescription}";
            redoToolStripMenuItem.Enabled = historyService.CanRedo;
            redoToolStripMenuItem.Text = $"Redo {historyService.RedoDescription}";
        }

        private void OnHasPendingChangesChanged()
        {
            this.Text = $"NHTID - {document?.OriginalFileName}" + (hasPendingChanges ? " *" : "");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!CanDiscardChanges())
                e.Cancel = true;
           
            base.OnClosing(e);
        }

        private void SaveAs()
        {
            try
            {
                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    IDocumentFactory[] docFacs = documentFactories.Where(i => !i.IsLossy(document)).ToArray();
                    dlg.Filter = string.Join("|", docFacs.Select(i => i.FilePattern));
                    dlg.Title = "Save As";
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        IDocumentFactory docFac = docFacs[dlg.FilterIndex - 1];
                        SaveDocument(dlg.FileName, docFac);
                    }
                }
            }
            catch (Exception caught)
            {
                MessageBox.Show(this, caught.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveDocument(string fileName, IDocumentFactory docFac)
        {
            docFac.Save(document, fileName);
            document.OriginalFileName = fileName;
            recentFileManager.AddRecentFile(document);
            this.hasPendingChanges = false;
            OnHasPendingChangesChanged();
        }

        private void SaveChanges()
        {
            try
            {
                IDocumentFactory? docFac =
                    documentFactories.FirstOrDefault(i => i.CanHandleFile(document.OriginalFileName));
                if (docFac == null)
                {
                    throw new Exception("There are no document factories that can handle this file type.");
                }

                if (docFac.IsLossy(document))
                {
                    MessageBox.Show(this,
                        "The current file format does not support the features of this map, please choose another file format for this map",
                        "Warning");
                    SaveAs();
                }
                else
                {
                    SaveDocument(document.OriginalFileName, docFac);
                }

            }
            catch (Exception caught)
            {
                MessageBox.Show(this, caught.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                SingleTemplate => new TemplateTool(historyService, SelectToolPropertiesControl(this.itemEditor), itemConvertor),
                MultiTemplate => new MultiTemplateTool(historyService, SelectToolPropertiesControl(this.multiItemSelector)),
                None => null,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private T SelectToolPropertiesControl<T>(T control) where T : Control
        {
            foreach (Control propControl in panel2.Controls)
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
            CollectionEditorForm.EditModal(this, this.collectionStore, this.itemSource, scope);
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewDocumentUi();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOpenDocumentUi();
        }

        private bool CanDiscardChanges()
        {
            if (document != null && hasPendingChanges)
            {
                switch (MessageBox.Show(this, "Do you wish to save the changes you have made to the current map?",
                    "Changes Pending",MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3))
                {
                    case DialogResult.Yes:
                        SaveChanges();
                        return true;
                    case DialogResult.Cancel:
                        return false;
                    default:
                        return true;
                }
            }

            return true;
        }

        private void OpenFile(Document document)
        {
            if (CanDiscardChanges())
            {
                this.document = document;
                historyService.Clear();
                mapView.SelectionService?.ClearSelection();
                mapView.Map = document.GetMapManager();
                recentFileManager.AddRecentFile(document);
                welcomeScreen1.Hide();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mapView_ZoomChanged(object sender, EventArgs e)
        {
            zoomTrackBar.Value = mapView.ZoomLevel;
        }

        private void AttachDocument(Document newDocument)
        {
             this.document = newDocument;
            historyService.Clear();
            mapView.SelectionService?.ClearSelection();
            mapManager = document.GetMapManager();
            mapView.Map = mapManager;
            welcomeScreen1.Hide();
            recentFileManager.AddRecentFile(newDocument);
            // Check the map for common issues and allow the user to fix them before proceeding...
            ValidateMap();
            hasPendingChanges = false;
            OnHasPendingChangesChanged();
        }

        public void ShowOpenDocumentUi()
        {
            if (CanDiscardChanges())
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    var docFactories = documentFactories.ToArray();
                    dlg.Filter = string.Join("|", docFactories.Select(i => i.FilePattern));
                    dlg.Title = "Open";
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        var docFactory = docFactories[dlg.FilterIndex - 1];
                        Document openedDocument = docFactory.Load(dlg.FileName);
                        AttachDocument(openedDocument);
                    }
                }
            }
        }

        public void OpenFile(string fileName)
        {
            foreach (var documentFactory in this.documentFactories)
            {
                if (documentFactory.CanHandleFile(fileName))
                {
                    Document openedDocument = documentFactory.Load(fileName);
                    AttachDocument(openedDocument);
                    return;
                }
            }

            MessageBox.Show(this, "NHTID is unable to open this file.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public void ShowNewDocumentUi()
        {
            
        }

        private void specialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*MapEditingService mse = new MapEditingService(mapManager);
            for (int x = mse.WorldTileBounds.Left; x < mse.WorldTileBounds.Right; x++)
            {
                for (int y = mse.WorldTileBounds.Top; y < mse.WorldTileBounds.Bottom; y++)
                {
                    Item item = mapManager.CurrentLayer.GetTile(x, y);
                    if (item.IsDropped)
                    {
                        Item itemAbove = mapManager.CurrentLayer.GetTile(x, y - 2);
                        mse.GetItem()
                    }
                }
            }*/
        }
    }

    public interface IDocumentContainer
    {
        void ShowOpenDocumentUi();

        void OpenFile(string fileName);

        void ShowNewDocumentUi();
    }
}