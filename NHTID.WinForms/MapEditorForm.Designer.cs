﻿using Nhtid.WinForms.Controls;
using Nhtid.WinForms.Tools;

namespace Nhtid.WinForms
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
            Nhtid.WinForms.Tools.PanTool panTool1 = new Nhtid.WinForms.Tools.PanTool();
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
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecentFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSelectedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.editCollectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.multiItemSelector = new Nhtid.WinForms.Controls.MultiItemSelector();
            this.itemEditor = new Nhtid.WinForms.Controls.ItemEditor();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.locationLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.itemLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.welcomeScreen1 = new Nhtid.WinForms.WelcomeScreen();
            this.mapView = new Nhtid.WinForms.Controls.MapView();
            this.layerPalette1 = new Nhtid.WinForms.Controls.LayerPalette();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
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
            this.btnMultiTemplate,
            this.toolStripSeparator7,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(37, 458);
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
            this.btnZoom.Size = new System.Drawing.Size(35, 36);
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
            this.btnMarquee.Size = new System.Drawing.Size(35, 36);
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
            this.btnPick.Size = new System.Drawing.Size(35, 36);
            this.btnPick.Text = "Item Picker (I)";
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(35, 6);
            // 
            // btnMove
            // 
            this.btnMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMove.Image = ((System.Drawing.Image)(resources.GetObject("btnMove.Image")));
            this.btnMove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(35, 36);
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
            this.btnBrush.Size = new System.Drawing.Size(35, 36);
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
            this.btnEraser.Size = new System.Drawing.Size(35, 36);
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
            this.btnFillRect.Size = new System.Drawing.Size(35, 36);
            this.btnFillRect.Text = "Fill Rectangle (R)";
            this.btnFillRect.Click += new System.EventHandler(this.btnFillRect_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(35, 6);
            // 
            // btnSingleTemplate
            // 
            this.btnSingleTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSingleTemplate.Image = ((System.Drawing.Image)(resources.GetObject("btnSingleTemplate.Image")));
            this.btnSingleTemplate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSingleTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSingleTemplate.Name = "btnSingleTemplate";
            this.btnSingleTemplate.Size = new System.Drawing.Size(35, 36);
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
            this.btnMultiTemplate.Size = new System.Drawing.Size(35, 36);
            this.btnMultiTemplate.Text = "toolStripButton1";
            this.btnMultiTemplate.Click += new System.EventHandler(this.btnMultiTemplate_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(35, 6);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(35, 36);
            this.toolStripButton1.Text = "Template Area Link";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(35, 36);
            this.toolStripButton2.Text = "Template Link Tool";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.specialToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1119, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.openRecentFileToolStripMenuItem,
            this.toolStripSeparator5,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator6,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.newToolStripMenuItem.Text = "New Project";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openRecentFileToolStripMenuItem
            // 
            this.openRecentFileToolStripMenuItem.Name = "openRecentFileToolStripMenuItem";
            this.openRecentFileToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openRecentFileToolStripMenuItem.Text = "Open Recent File";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(160, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(160, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            // deleteAllItemsToolStripMenuItem
            // 
            this.deleteAllItemsToolStripMenuItem.Name = "deleteAllItemsToolStripMenuItem";
            this.deleteAllItemsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.deleteAllItemsToolStripMenuItem.Text = "Delete All Items";
            this.deleteAllItemsToolStripMenuItem.Click += new System.EventHandler(this.deleteAllItemsToolStripMenuItem_Click);
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
            // specialToolStripMenuItem
            // 
            this.specialToolStripMenuItem.Name = "specialToolStripMenuItem";
            this.specialToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.specialToolStripMenuItem.Text = "Special";
            this.specialToolStripMenuItem.Click += new System.EventHandler(this.specialToolStripMenuItem_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(863, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 532);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.layerPalette1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(865, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 532);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.multiItemSelector);
            this.panel2.Controls.Add(this.itemEditor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 164);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 368);
            this.panel2.TabIndex = 2;
            // 
            // multiItemSelector
            // 
            this.multiItemSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiItemSelector.Location = new System.Drawing.Point(0, 0);
            this.multiItemSelector.Margin = new System.Windows.Forms.Padding(2);
            this.multiItemSelector.Name = "multiItemSelector";
            this.multiItemSelector.Size = new System.Drawing.Size(217, 368);
            this.multiItemSelector.TabIndex = 1;
            this.multiItemSelector.Visible = false;
            // 
            // itemEditor
            // 
            this.itemEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemEditor.Location = new System.Drawing.Point(0, 0);
            this.itemEditor.Margin = new System.Windows.Forms.Padding(4);
            this.itemEditor.Name = "itemEditor";
            this.itemEditor.Size = new System.Drawing.Size(217, 368);
            this.itemEditor.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locationLabel,
            this.itemLabel,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1119, 22);
            this.statusStrip.TabIndex = 9;
            this.statusStrip.Text = "statusStrip1";
            this.statusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // locationLabel
            // 
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(25, 17);
            this.locationLabel.Text = "0, 0";
            // 
            // itemLabel
            // 
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(12, 17);
            this.itemLabel.Text = "-";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1067, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.welcomeScreen1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.mapView);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitter1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1082, 532);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1119, 578);
            this.toolStripContainer1.TabIndex = 10;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // welcomeScreen1
            // 
            this.welcomeScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomeScreen1.Location = new System.Drawing.Point(0, 0);
            this.welcomeScreen1.Name = "welcomeScreen1";
            this.welcomeScreen1.Size = new System.Drawing.Size(863, 532);
            this.welcomeScreen1.TabIndex = 9;
            // 
            // mapView
            // 
            this.mapView.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mapView.CurrentTool = panTool1;
            this.mapView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapView.ItemRenderStyle = null;
            this.mapView.Location = new System.Drawing.Point(0, 0);
            this.mapView.Map = null;
            this.mapView.Name = "mapView";
            this.mapView.ScrollPosition = new System.Drawing.Point(0, 0);
            this.mapView.Size = new System.Drawing.Size(863, 532);
            this.mapView.TabIndex = 1;
            this.mapView.Text = "mapView1";
            this.mapView.ZoomChanged += new System.EventHandler(this.mapView_ZoomChanged);
            this.mapView.Click += new System.EventHandler(this.mapView_Click);
            // 
            // layerPalette1
            // 
            this.layerPalette1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layerPalette1.Location = new System.Drawing.Point(0, 17);
            this.layerPalette1.Name = "layerPalette1";
            this.layerPalette1.Size = new System.Drawing.Size(217, 130);
            this.layerPalette1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Layers";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tool Settings";
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 578);
            this.Controls.Add(this.toolStripContainer1);
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
            this.panel2.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel locationLabel;
        private System.Windows.Forms.ToolStripStatusLabel itemLabel;
        private MultiItemSelector multiItemSelector;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnMultiTemplate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem editCollectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem openRecentFileToolStripMenuItem;
        private WelcomeScreen welcomeScreen1;
        private System.Windows.Forms.ToolStripMenuItem specialToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private LayerPalette layerPalette1;
        private System.Windows.Forms.Label label1;
    }
}