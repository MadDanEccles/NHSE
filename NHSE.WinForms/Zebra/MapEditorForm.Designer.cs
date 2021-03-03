
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
            this.components = new System.ComponentModel.Container();
            NHSE.WinForms.Zebra.Tools.PanTool panTool1 = new NHSE.WinForms.Zebra.Tools.PanTool();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapEditorForm));
            this.mapView = new NHSE.WinForms.Zebra.MapView();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.itemEditor2 = new NHSE.WinForms.ItemEditor();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnZoom = new System.Windows.Forms.ToolStripButton();
            this.btnMarquee = new System.Windows.Forms.ToolStripButton();
            this.btnMove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPaint = new System.Windows.Forms.ToolStripButton();
            this.btnPick = new System.Windows.Forms.ToolStripButton();
            this.btnTemplate = new System.Windows.Forms.ToolStripButton();
            this.btnEraser = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFillRect = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapView
            // 
            this.mapView.BackColor = System.Drawing.Color.White;
            this.mapView.CurrentTool = panTool1;
            this.mapView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapView.Location = new System.Drawing.Point(37, 24);
            this.mapView.Map = null;
            this.mapView.Name = "mapView";
            this.mapView.ScrollPosition = new System.Drawing.Point(0, 0);
            this.mapView.Size = new System.Drawing.Size(811, 657);
            this.mapView.TabIndex = 1;
            this.mapView.Text = "mapView1";
            this.mapView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mapView_KeyPress);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelContainer1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // panelContainer1
            // 
            this.panelContainer1.ActiveChild = this.dockPanel2;
            this.panelContainer1.Controls.Add(this.dockPanel2);
            this.panelContainer1.Controls.Add(this.dockPanel1);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.panelContainer1.ID = new System.Guid("72508660-0e23-45c9-880f-984ec81434b4");
            this.panelContainer1.Location = new System.Drawing.Point(848, 24);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(200, 200);
            this.panelContainer1.Size = new System.Drawing.Size(200, 657);
            this.panelContainer1.Tabbed = true;
            this.panelContainer1.Text = "panelContainer1";
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.FloatVertical = true;
            this.dockPanel2.ID = new System.Guid("f7a0dd9f-3265-42d2-9119-f9bf7047bb0e");
            this.dockPanel2.Location = new System.Drawing.Point(5, 23);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(191, 486);
            this.dockPanel2.Size = new System.Drawing.Size(191, 603);
            this.dockPanel2.Text = "Tool Settings";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.itemEditor2);
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(191, 603);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // itemEditor2
            // 
            this.itemEditor2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemEditor2.Location = new System.Drawing.Point(0, 0);
            this.itemEditor2.Name = "itemEditor2";
            this.itemEditor2.Size = new System.Drawing.Size(191, 603);
            this.itemEditor2.TabIndex = 0;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel1.ID = new System.Guid("0c6777ee-89f3-4b3f-909f-a6b5f4d99c4a");
            this.dockPanel1.Location = new System.Drawing.Point(5, 23);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(191, 486);
            this.dockPanel1.Size = new System.Drawing.Size(191, 603);
            this.dockPanel1.Text = "dockPanel1";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(191, 603);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnZoom,
            this.btnMarquee,
            this.btnMove,
            this.toolStripSeparator1,
            this.btnPaint,
            this.btnPick,
            this.btnTemplate,
            this.btnEraser,
            this.btnFillRect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(37, 657);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnZoom
            // 
            this.btnZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoom.Image = ((System.Drawing.Image)(resources.GetObject("btnZoom.Image")));
            this.btnZoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(34, 36);
            this.btnZoom.Text = "Zoom and Pan";
            this.btnZoom.ToolTipText = "Zoom / Pan";
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // btnMarquee
            // 
            this.btnMarquee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMarquee.Image = ((System.Drawing.Image)(resources.GetObject("btnMarquee.Image")));
            this.btnMarquee.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMarquee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMarquee.Name = "btnMarquee";
            this.btnMarquee.Size = new System.Drawing.Size(34, 36);
            this.btnMarquee.Text = "Rectangular Selection";
            this.btnMarquee.Click += new System.EventHandler(this.btnMarquee_ItemClick);
            // 
            // btnMove
            // 
            this.btnMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMove.Image = ((System.Drawing.Image)(resources.GetObject("btnMove.Image")));
            this.btnMove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(34, 36);
            this.btnMove.Text = "Item Mover";
            this.btnMove.Click += new System.EventHandler(this.btnMove_ItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(34, 6);
            // 
            // btnPaint
            // 
            this.btnPaint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaint.Image = ((System.Drawing.Image)(resources.GetObject("btnPaint.Image")));
            this.btnPaint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPaint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaint.Name = "btnPaint";
            this.btnPaint.Size = new System.Drawing.Size(34, 36);
            this.btnPaint.Text = "Item Painter";
            this.btnPaint.Click += new System.EventHandler(this.btnPaint_Click);
            // 
            // btnPick
            // 
            this.btnPick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPick.Image = ((System.Drawing.Image)(resources.GetObject("btnPick.Image")));
            this.btnPick.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(34, 36);
            this.btnPick.Text = "Item Picker";
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTemplate.Image = ((System.Drawing.Image)(resources.GetObject("btnTemplate.Image")));
            this.btnTemplate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(34, 36);
            this.btnTemplate.Text = "Template";
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // btnEraser
            // 
            this.btnEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEraser.Image = ((System.Drawing.Image)(resources.GetObject("btnEraser.Image")));
            this.btnEraser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(34, 36);
            this.btnEraser.Text = "Eraser";
            this.btnEraser.Click += new System.EventHandler(this.btnEraser_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1048, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.categoriesToolStripMenuItem.Text = "Categories...";
            // 
            // btnFillRect
            // 
            this.btnFillRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFillRect.Image = ((System.Drawing.Image)(resources.GetObject("btnFillRect.Image")));
            this.btnFillRect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFillRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFillRect.Name = "btnFillRect";
            this.btnFillRect.Size = new System.Drawing.Size(34, 36);
            this.btnFillRect.Text = "Fill Rectangle";
            this.btnFillRect.Click += new System.EventHandler(this.btnFillRect_Click);
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 681);
            this.Controls.Add(this.mapView);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panelContainer1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MapEditorForm";
            this.Text = "Map Editor";
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MapEditorForm_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.panelContainer1.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MapView mapView;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private WinForms.ItemEditor itemEditor2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnZoom;
        private System.Windows.Forms.ToolStripButton btnMarquee;
        private System.Windows.Forms.ToolStripButton btnMove;
        private System.Windows.Forms.ToolStripButton btnPaint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPick;
        private System.Windows.Forms.ToolStripButton btnTemplate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripButton btnEraser;
        private System.Windows.Forms.ToolStripButton btnFillRect;
    }
}