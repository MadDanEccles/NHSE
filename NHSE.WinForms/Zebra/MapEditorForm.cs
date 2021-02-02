using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.WinForms.Zebra.Tools;

namespace NHSE.WinForms.Zebra
{
    public partial class MapEditorForm : Form
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

            toolButtons = new[]{tsbMarquee, tsbMove, tsbPan};
        }

        private void tsbPan_Click(object sender, EventArgs e)
        {
            SetToolButton(tsbPan);
            mapView.CurrentTool = new PanTool();
        }

        private void SetToolButton(ToolStripButton selectedButton)
        {
            foreach (var button in toolButtons)
                button.Checked = button == selectedButton;
        }

        private void tsbMarquee_Click(object sender, EventArgs e)
        {
            SetToolButton(tsbMarquee);
            mapView.CurrentTool = new MarqueeSelectionTool(mapView.SelectionService);
        }

        private void tsbMove_Click(object sender, EventArgs e)
        {
            SetToolButton(tsbMove);
            mapView.CurrentTool = new MoveTool();

        }
    }
}
