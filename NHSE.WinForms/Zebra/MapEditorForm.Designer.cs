
using NHSE.WinForms.Zebra.Tools;

namespace NHSE.WinForms.Zebra
{
    partial class MapEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapEditorForm));
            NHSE.WinForms.Zebra.Tools.PanTool panTool3 = new NHSE.WinForms.Zebra.Tools.PanTool();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbPan = new System.Windows.Forms.ToolStripButton();
            this.tsbMarquee = new System.Windows.Forms.ToolStripButton();
            this.tsbMove = new System.Windows.Forms.ToolStripButton();
            this.mapView = new NHSE.WinForms.Zebra.MapView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPan,
            this.tsbMarquee,
            this.tsbMove});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(37, 458);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbPan
            // 
            this.tsbPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPan.Image = ((System.Drawing.Image)(resources.GetObject("tsbPan.Image")));
            this.tsbPan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPan.Name = "tsbPan";
            this.tsbPan.Size = new System.Drawing.Size(34, 36);
            this.tsbPan.Text = "Pan/Zoom";
            this.tsbPan.Click += new System.EventHandler(this.tsbPan_Click);
            // 
            // tsbMarquee
            // 
            this.tsbMarquee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMarquee.Image = ((System.Drawing.Image)(resources.GetObject("tsbMarquee.Image")));
            this.tsbMarquee.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMarquee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMarquee.Name = "tsbMarquee";
            this.tsbMarquee.Size = new System.Drawing.Size(34, 36);
            this.tsbMarquee.Text = "Select";
            this.tsbMarquee.Click += new System.EventHandler(this.tsbMarquee_Click);
            // 
            // tsbMove
            // 
            this.tsbMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMove.Image = ((System.Drawing.Image)(resources.GetObject("tsbMove.Image")));
            this.tsbMove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMove.Name = "tsbMove";
            this.tsbMove.Size = new System.Drawing.Size(34, 36);
            this.tsbMove.Text = "Move Items";
            this.tsbMove.Click += new System.EventHandler(this.tsbMove_Click);
            // 
            // mapView
            // 
            this.mapView.CurrentTool = panTool3;
            this.mapView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapView.Location = new System.Drawing.Point(37, 0);
            this.mapView.Map = null;
            this.mapView.Name = "mapView";
            this.mapView.ScrollPosition = new System.Drawing.Point(0, 0);
            this.mapView.Size = new System.Drawing.Size(577, 458);
            this.mapView.TabIndex = 1;
            this.mapView.Text = "mapView1";
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 458);
            this.Controls.Add(this.mapView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MapEditorForm";
            this.Text = "Map Editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbPan;
        private System.Windows.Forms.ToolStripButton tsbMarquee;
        private System.Windows.Forms.ToolStripButton tsbMove;
        private MapView mapView;
    }
}