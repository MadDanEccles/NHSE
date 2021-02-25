
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
            NHSE.WinForms.Zebra.Tools.PanTool panTool2 = new NHSE.WinForms.Zebra.Tools.PanTool();
            this.mapView = new NHSE.WinForms.Zebra.MapView();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.btnPan = new DevExpress.XtraBars.BarButtonItem();
            this.btnMarquee = new DevExpress.XtraBars.BarButtonItem();
            this.btnMove = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemBrush = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemPicker = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemFill = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.rpgCompatability = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.toggleEasterEgg = new DevExpress.XtraBars.BarToggleSwitchItem();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapView
            // 
            this.mapView.BackColor = System.Drawing.Color.White;
            this.mapView.CurrentTool = panTool2;
            this.mapView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapView.Location = new System.Drawing.Point(0, 141);
            this.mapView.Map = null;
            this.mapView.Name = "mapView";
            this.mapView.ScrollPosition = new System.Drawing.Point(0, 0);
            this.mapView.Size = new System.Drawing.Size(704, 388);
            this.mapView.TabIndex = 1;
            this.mapView.Text = "mapView1";
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.barAndDockingController1.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.ribbonControl1;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.Controller = this.barAndDockingController1;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonGroup1,
            this.barButtonItem4,
            this.btnPan,
            this.btnMarquee,
            this.btnMove,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.btnItemBrush,
            this.btnItemPicker,
            this.btnItemFill,
            this.barCheckItem1,
            this.toggleEasterEgg});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 14;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbonControl1.Size = new System.Drawing.Size(904, 141);
            // 
            // barButtonGroup1
            // 
            this.barButtonGroup1.Caption = "barButtonGroup1";
            this.barButtonGroup1.Id = 1;
            this.barButtonGroup1.ItemLinks.Add(this.barButtonItem4);
            this.barButtonGroup1.Name = "barButtonGroup1";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 2;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // btnPan
            // 
            this.btnPan.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.btnPan.Caption = "Pan && Zoom";
            this.btnPan.Down = true;
            this.btnPan.Glyph = global::NHSE.WinForms.Zebra.ZebraResources.magnifying_glass_16;
            this.btnPan.Id = 3;
            this.btnPan.LargeGlyph = global::NHSE.WinForms.Zebra.ZebraResources.magnifying_glass_32;
            this.btnPan.Name = "btnPan";
            this.btnPan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPan_ItemClick);
            // 
            // btnMarquee
            // 
            this.btnMarquee.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.btnMarquee.Caption = "Marquee";
            this.btnMarquee.Glyph = global::NHSE.WinForms.Zebra.ZebraResources.selection_16;
            this.btnMarquee.Id = 4;
            this.btnMarquee.LargeGlyph = global::NHSE.WinForms.Zebra.ZebraResources.selection_32;
            this.btnMarquee.Name = "btnMarquee";
            this.btnMarquee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMarquee_ItemClick);
            // 
            // btnMove
            // 
            this.btnMove.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.btnMove.Caption = "Move";
            this.btnMove.Glyph = global::NHSE.WinForms.Zebra.ZebraResources.arrow_cross_16;
            this.btnMove.Id = 5;
            this.btnMove.LargeGlyph = global::NHSE.WinForms.Zebra.ZebraResources.arrow_cross_32;
            this.btnMove.Name = "btnMove";
            this.btnMove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMove_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Item Type";
            this.barButtonItem1.Id = 6;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Status";
            this.barButtonItem2.Id = 7;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Validity";
            this.barButtonItem3.Id = 8;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // btnItemBrush
            // 
            this.btnItemBrush.Caption = "Brush";
            this.btnItemBrush.Glyph = global::NHSE.WinForms.Zebra.ZebraResources.brush_16;
            this.btnItemBrush.Id = 9;
            this.btnItemBrush.LargeGlyph = global::NHSE.WinForms.Zebra.ZebraResources.brush_32;
            this.btnItemBrush.Name = "btnItemBrush";
            // 
            // btnItemPicker
            // 
            this.btnItemPicker.Caption = "Picker";
            this.btnItemPicker.Glyph = global::NHSE.WinForms.Zebra.ZebraResources.pipette_16;
            this.btnItemPicker.Id = 10;
            this.btnItemPicker.LargeGlyph = global::NHSE.WinForms.Zebra.ZebraResources.pipette_32;
            this.btnItemPicker.Name = "btnItemPicker";
            // 
            // btnItemFill
            // 
            this.btnItemFill.Caption = "Fill";
            this.btnItemFill.Glyph = global::NHSE.WinForms.Zebra.ZebraResources.paint_roller_16;
            this.btnItemFill.Id = 11;
            this.btnItemFill.LargeGlyph = global::NHSE.WinForms.Zebra.ZebraResources.paint_roller_32;
            this.btnItemFill.Name = "btnItemFill";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.rpgCompatability});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Items";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPan, true, "", "", true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMarquee, true, "", "", true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMove, false, "", "", true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnItemBrush, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnItemFill);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnItemPicker);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tools";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Colours";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Terrain";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Templates";
            // 
            // dockManager1
            // 
            this.dockManager1.Controller = this.barAndDockingController1;
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
            this.panelContainer1.ActiveChild = this.dockPanel1;
            this.panelContainer1.Controls.Add(this.dockPanel2);
            this.panelContainer1.Controls.Add(this.dockPanel1);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.panelContainer1.ID = new System.Guid("6a0973e5-0a4a-4bea-8cd2-a15722f614c7");
            this.panelContainer1.Location = new System.Drawing.Point(704, 141);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(200, 200);
            this.panelContainer1.Size = new System.Drawing.Size(200, 388);
            this.panelContainer1.Tabbed = true;
            this.panelContainer1.Text = "panelContainer1";
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel1.ID = new System.Guid("0c6777ee-89f3-4b3f-909f-a6b5f4d99c4a");
            this.dockPanel1.Location = new System.Drawing.Point(5, 23);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(191, 262);
            this.dockPanel1.Size = new System.Drawing.Size(191, 334);
            this.dockPanel1.Text = "dockPanel1";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(191, 334);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.ID = new System.Guid("f7a0dd9f-3265-42d2-9119-f9bf7047bb0e");
            this.dockPanel2.Location = new System.Drawing.Point(5, 23);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(191, 262);
            this.dockPanel2.Size = new System.Drawing.Size(191, 334);
            this.dockPanel2.Text = "Item";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(191, 334);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // rpgCompatability
            // 
            this.rpgCompatability.ItemLinks.Add(this.toggleEasterEgg);
            this.rpgCompatability.Name = "rpgCompatability";
            this.rpgCompatability.Text = "Options";
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "barCheckItem1";
            this.barCheckItem1.Id = 12;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // toggleEasterEgg
            // 
            this.toggleEasterEgg.Caption = "ACNH Compatability Mode";
            this.toggleEasterEgg.Id = 13;
            this.toggleEasterEgg.Name = "toggleEasterEgg";
            this.toggleEasterEgg.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.toggleEasterEgg_CheckedChanged);
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 529);
            this.Controls.Add(this.mapView);
            this.Controls.Add(this.panelContainer1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "MapEditorForm";
            this.Text = "Map Editor";
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.panelContainer1.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MapView mapView;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem btnPan;
        private DevExpress.XtraBars.BarButtonItem btnMarquee;
        private DevExpress.XtraBars.BarButtonItem btnMove;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnItemBrush;
        private DevExpress.XtraBars.BarButtonItem btnItemPicker;
        private DevExpress.XtraBars.BarButtonItem btnItemFill;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarToggleSwitchItem toggleEasterEgg;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgCompatability;
    }
}