
using NHSE.WinForms.Zebra.Controls;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapEditorForm));
            NHSE.WinForms.Zebra.Tools.PanTool panTool1 = new NHSE.WinForms.Zebra.Tools.PanTool();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnZoom = new System.Windows.Forms.ToolStripButton();
            this.btnMarquee = new System.Windows.Forms.ToolStripButton();
            this.btnPick = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMove = new System.Windows.Forms.ToolStripButton();
            this.btnBrush = new System.Windows.Forms.ToolStripButton();
            this.btnEraser = new System.Windows.Forms.ToolStripButton();
            this.btnFillRect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSingleTemplate = new System.Windows.Forms.ToolStripButton();
            this.btnMultiTemplate = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSelectedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.editCollectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.locationLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.itemLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.deleteAllItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapView = new NHSE.WinForms.Zebra.Controls.MapView();
            this.multiItemSelector = new NHSE.WinForms.Zebra.Controls.MultiItemSelector();
            this.itemEditor = new NHSE.WinForms.Zebra.Controls.ItemEditor();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnZoom,
            this.btnMarquee,
            this.btnPick,
            this.toolStripSeparator1,
            this.btnMove,
            this.btnBrush,
            this.btnEraser,
            this.btnFillRect,
            this.toolStripSeparator3,
            this.btnSingleTemplate,
            this.btnMultiTemplate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(37, 528);
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
            this.btnZoom.Text = "Zoom and Pan (Z)";
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
            this.btnMarquee.Text = "Marquee Selection (M)";
            this.btnMarquee.Click += new System.EventHandler(this.btnMarquee_Click);
            // 
            // btnPick
            // 
            this.btnPick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPick.Image = ((System.Drawing.Image)(resources.GetObject("btnPick.Image")));
            this.btnPick.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(34, 36);
            this.btnPick.Text = "Item Picker (I)";
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(34, 6);
            // 
            // btnMove
            // 
            this.btnMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMove.Image = ((System.Drawing.Image)(resources.GetObject("btnMove.Image")));
            this.btnMove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(34, 36);
            this.btnMove.Text = "Move Items (V)";
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnBrush
            // 
            this.btnBrush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBrush.Image = ((System.Drawing.Image)(resources.GetObject("btnBrush.Image")));
            this.btnBrush.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBrush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBrush.Name = "btnBrush";
            this.btnBrush.Size = new System.Drawing.Size(34, 36);
            this.btnBrush.Text = "Item Brush (B)";
            this.btnBrush.Click += new System.EventHandler(this.btnPaint_Click);
            // 
            // btnEraser
            // 
            this.btnEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEraser.Image = ((System.Drawing.Image)(resources.GetObject("btnEraser.Image")));
            this.btnEraser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(34, 36);
            this.btnEraser.Text = "Eraser (X)";
            this.btnEraser.Click += new System.EventHandler(this.btnEraser_Click);
            // 
            // btnFillRect
            // 
            this.btnFillRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFillRect.Image = ((System.Drawing.Image)(resources.GetObject("btnFillRect.Image")));
            this.btnFillRect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFillRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFillRect.Name = "btnFillRect";
            this.btnFillRect.Size = new System.Drawing.Size(34, 36);
            this.btnFillRect.Text = "Fill Rectangle (R)";
            this.btnFillRect.Click += new System.EventHandler(this.btnFillRect_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(34, 6);
            // 
            // btnSingleTemplate
            // 
            this.btnSingleTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSingleTemplate.Image = ((System.Drawing.Image)(resources.GetObject("btnSingleTemplate.Image")));
            this.btnSingleTemplate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSingleTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSingleTemplate.Name = "btnSingleTemplate";
            this.btnSingleTemplate.Size = new System.Drawing.Size(34, 36);
            this.btnSingleTemplate.Text = "Template (T)";
            this.btnSingleTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // btnMultiTemplate
            // 
            this.btnMultiTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMultiTemplate.Image = ((System.Drawing.Image)(resources.GetObject("btnMultiTemplate.Image")));
            this.btnMultiTemplate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMultiTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMultiTemplate.Name = "btnMultiTemplate";
            this.btnMultiTemplate.Size = new System.Drawing.Size(34, 36);
            this.btnMultiTemplate.Text = "toolStripButton1";
            this.btnMultiTemplate.Click += new System.EventHandler(this.btnMultiTemplate_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.copyIDToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(790, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteSelectedItemsToolStripMenuItem,
            this.deleteAllItemsToolStripMenuItem,
            this.toolStripSeparator4,
            this.editCollectionsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // deleteSelectedItemsToolStripMenuItem
            // 
            this.deleteSelectedItemsToolStripMenuItem.Name = "deleteSelectedItemsToolStripMenuItem";
            this.deleteSelectedItemsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteSelectedItemsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.deleteSelectedItemsToolStripMenuItem.Text = "Delete Selected Items";
            this.deleteSelectedItemsToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedItemsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(207, 6);
            // 
            // editCollectionsToolStripMenuItem
            // 
            this.editCollectionsToolStripMenuItem.Name = "editCollectionsToolStripMenuItem";
            this.editCollectionsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.editCollectionsToolStripMenuItem.Text = "Edit Collections...";
            this.editCollectionsToolStripMenuItem.Click += new System.EventHandler(this.editCollectionsToolStripMenuItem_Click);
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
            // copyIDToolStripMenuItem
            // 
            this.copyIDToolStripMenuItem.Name = "copyIDToolStripMenuItem";
            this.copyIDToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.copyIDToolStripMenuItem.Text = "Copy ID";
            this.copyIDToolStripMenuItem.Click += new System.EventHandler(this.copyIDToolStripMenuItem_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(571, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 528);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.multiItemSelector);
            this.panel1.Controls.Add(this.itemEditor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(573, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 528);
            this.panel1.TabIndex = 8;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locationLabel,
            this.itemLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 552);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(790, 26);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = false;
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(60, 21);
            this.locationLabel.Text = "0, 0";
            // 
            // itemLabel
            // 
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(12, 21);
            this.itemLabel.Text = "-";
            // 
            // deleteAllItemsToolStripMenuItem
            // 
            this.deleteAllItemsToolStripMenuItem.Name = "deleteAllItemsToolStripMenuItem";
            this.deleteAllItemsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.deleteAllItemsToolStripMenuItem.Text = "Delete All Items";
            this.deleteAllItemsToolStripMenuItem.Click += new System.EventHandler(this.deleteAllItemsToolStripMenuItem_Click);
            // 
            // mapView
            // 
            this.mapView.BackColor = System.Drawing.Color.White;
            this.mapView.CurrentTool = panTool1;
            this.mapView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapView.ItemRenderStyle = null;
            this.mapView.Location = new System.Drawing.Point(37, 24);
            this.mapView.Map = null;
            this.mapView.Name = "mapView";
            this.mapView.ScrollPosition = new System.Drawing.Point(0, 0);
            this.mapView.Size = new System.Drawing.Size(534, 528);
            this.mapView.TabIndex = 1;
            this.mapView.Text = "mapView1";
            this.mapView.Click += new System.EventHandler(this.mapView_Click);
            // 
            // multiItemSelector
            // 
            this.multiItemSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiItemSelector.Location = new System.Drawing.Point(0, 0);
            this.multiItemSelector.Margin = new System.Windows.Forms.Padding(2);
            this.multiItemSelector.Name = "multiItemSelector";
            this.multiItemSelector.Size = new System.Drawing.Size(217, 528);
            this.multiItemSelector.TabIndex = 1;
            this.multiItemSelector.Visible = false;
            // 
            // itemEditor
            // 
            this.itemEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemEditor.Location = new System.Drawing.Point(0, 0);
            this.itemEditor.Margin = new System.Windows.Forms.Padding(4);
            this.itemEditor.Name = "itemEditor";
            this.itemEditor.Size = new System.Drawing.Size(217, 528);
            this.itemEditor.TabIndex = 0;
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 578);
            this.Controls.Add(this.mapView);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MapEditorForm";
            this.Text = "Map Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MapView mapView;
        private Controls.ItemEditor itemEditor;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnZoom;
        private System.Windows.Forms.ToolStripButton btnMarquee;
        private System.Windows.Forms.ToolStripButton btnMove;
        private System.Windows.Forms.ToolStripButton btnBrush;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPick;
        private System.Windows.Forms.ToolStripButton btnSingleTemplate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripButton btnEraser;
        private System.Windows.Forms.ToolStripButton btnFillRect;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedItemsToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel locationLabel;
        private System.Windows.Forms.ToolStripStatusLabel itemLabel;
        private System.Windows.Forms.ToolStripMenuItem copyIDToolStripMenuItem;
        private MultiItemSelector multiItemSelector;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnMultiTemplate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem editCollectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllItemsToolStripMenuItem;
    }
}