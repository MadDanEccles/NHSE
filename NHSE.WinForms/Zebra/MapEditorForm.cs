using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using NHSE.Core;
using NHSE.WinForms.Zebra.Tools;

namespace NHSE.WinForms.Zebra
{
    public partial class MapEditorForm : XtraForm
    {
        private readonly MapManager mapManager;
        private readonly MainSave save;
        private readonly ToolStripButton[] toolButtons;

        public MapEditorForm(MainSave save)
        {
            InitializeComponent();
            this.save = save;
            this.mapManager = new MapManager(save);
            mapView.Map = this.mapManager;

           toolButtons = new[]{btnMarquee, btnMove, btnZoom, btnPaint, btnPick, btnTemplate, btnEraser, btnFillRect};

           var data = GameInfo.Strings.ItemDataSource.ToList();
           var field = FieldItemList.Items.Select(z => z.Value).ToList();
           data.Add(field, GameInfo.Strings.InternalNameTranslation);
           itemEditor2.Initialize(data, true);
        }

        private void SetToolButton(ToolStripButton selectedButton)
        {
            foreach (var button in toolButtons)
                button.Checked = button == selectedButton;
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

        private void btnMove_ItemClick(object sender, EventArgs e)
        {
            SetToolButton(btnMove);
            mapView.CurrentTool = new MoveTool(mapView.SelectionService, mapView.SelectionRenderer, mapView.MapEditingService);

        }

        private void btnMarquee_ItemClick(object sender, EventArgs e)
        {
            SetToolButton(btnMarquee);
            mapView.CurrentTool = new MarqueeSelectionTool(mapView.SelectionService);
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            SetToolButton(btnZoom);
            mapView.CurrentTool = new PanTool();
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
            SetToolButton(btnPaint);
            mapView.CurrentTool = new PaintTool(new PaintOptions(this.itemEditor2));
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            SetToolButton(btnPick);
            mapView.CurrentTool = new PickTool( new PickTarget(this.itemEditor2));
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            SetToolButton(btnTemplate);
            mapView.CurrentTool = null;
        }

        private void btnEraser_Click(object sender, EventArgs e)
        {
            SetToolButton(btnEraser);
            mapView.CurrentTool = new EraserTool();

        }

        private void MapEditorForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void mapView_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'I':
                case 'i':
                    btnPick_Click(null, null);
                    break;
                case 'B':
                case 'b':
                    btnPaint_Click(null, null);
                    break;
                case 'X':
                case 'x':
                    btnEraser_Click(null, null);
                    break;
                case 'Z':
                case 'z':
                    btnZoom_Click(null, null);
                    break;
                case 'M':
                case 'm':
                    btnMarquee_ItemClick(null, null);
                    break;
            }
        }

        private void btnFillRect_Click(object sender, EventArgs e)
        {
            SetToolButton(btnFillRect);
            mapView.CurrentTool = new FillRectTool(new ItemSelector(this.itemEditor2));
        }
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
