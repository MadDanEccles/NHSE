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
        private readonly BarButtonItem[] toolButtons;

        public MapEditorForm(MainSave save)
        {
            InitializeComponent();
            this.save = save;
            this.mapManager = new MapManager(save);
            mapView.Map = this.mapManager;

           toolButtons = new[]{btnMarquee, btnMove, btnPan};
        }

        private void SetToolButton(BarButtonItem selectedButton)
        {
            foreach (var button in toolButtons)
                button.Down = button == selectedButton;
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
           /* var unsupported = Map.Items.GetUnsupportedTiles();
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
            save.OutsideFieldTemplateUniqueId = (ushort)NUD_MapAcreTemplateOutside.Value;
            save.MainFieldParamUniqueID = (ushort)NUD_MapAcreTemplateField.Value;

            save.Buildings = mapManager.Buildings;
            save.EventPlazaLeftUpX = mapManager.PlazaX;
            save.EventPlazaLeftUpZ = mapManager.PlazaY;*/
        }

        private void btnMove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetToolButton(btnMove);
            mapView.CurrentTool = new MoveTool(mapView.SelectionService, mapView.SelectionRenderer, mapView.MapService);

        }

        private void btnMarquee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetToolButton(btnMarquee);
            mapView.CurrentTool = new MarqueeSelectionTool(mapView.SelectionService);
        }

        private void btnPan_ItemClick(object sender, ItemClickEventArgs e)
        {
            SetToolButton(btnPan);
            mapView.CurrentTool = new PanTool();
        }

        private void toggleEasterEgg_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (toggleEasterEgg.Checked)
            {
                MessageBox.Show("Hmmm... There really isn't any news to speak of today", "Isabelle",
                    MessageBoxButtons.OK);
                MessageBox.Show("I'm sure we're in for a great day ... just stay happy!", "Isabelle",
                    MessageBoxButtons.OK);
            }
        }
    }
}
