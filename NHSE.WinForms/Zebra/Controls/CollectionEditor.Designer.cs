
namespace NHSE.WinForms.Zebra.Controls
{
    partial class CollectionEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectionEditor));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCollectionName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.itemsTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbAll = new ListBoxEx();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbCollections = new ListBoxEx();
            this.itemCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.lbInCollection = new ListBoxEx();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblItemCount = new System.Windows.Forms.Label();
            this.lblCollectionCount = new System.Windows.Forms.Label();
            this.searchTimer = new System.Windows.Forms.Timer(this.components);
            this.chkTopLevel = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.itemsTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemCollectionBindingSource)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 4);
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Collection Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Collection Items";
            // 
            // txtCollectionName
            // 
            this.txtCollectionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtCollectionName, 4);
            this.txtCollectionName.Location = new System.Drawing.Point(2, 19);
            this.txtCollectionName.Margin = new System.Windows.Forms.Padding(2);
            this.txtCollectionName.Name = "txtCollectionName";
            this.txtCollectionName.Size = new System.Drawing.Size(639, 20);
            this.txtCollectionName.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbInCollection, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCollectionName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblItemCount, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblCollectionCount, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkTopLevel, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(643, 492);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.itemsTab);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 84);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(277, 395);
            this.tabControl1.TabIndex = 6;
            // 
            // itemsTab
            // 
            this.itemsTab.Controls.Add(this.tableLayoutPanel2);
            this.itemsTab.Location = new System.Drawing.Point(4, 22);
            this.itemsTab.Name = "itemsTab";
            this.itemsTab.Padding = new System.Windows.Forms.Padding(3);
            this.itemsTab.Size = new System.Drawing.Size(269, 369);
            this.itemsTab.TabIndex = 0;
            this.itemsTab.Text = "Items";
            this.itemsTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.txtSearch, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbAll, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(263, 363);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(257, 20);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbAll
            // 
            this.lbAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAll.FormattingEnabled = true;
            this.lbAll.IntegralHeight = false;
            this.lbAll.Location = new System.Drawing.Point(2, 28);
            this.lbAll.Margin = new System.Windows.Forms.Padding(2);
            this.lbAll.Name = "lbAll";
            this.lbAll.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbAll.Size = new System.Drawing.Size(259, 333);
            this.lbAll.TabIndex = 4;
            this.lbAll.SelectedIndexChanged += new System.EventHandler(this.lbAll_SelectedIndexChanged);
            this.lbAll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbAll_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbCollections);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(269, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Collections";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbCollections
            // 
            this.lbCollections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbCollections.DataSource = this.itemCollectionBindingSource;
            this.lbCollections.DisplayMember = "Name";
            this.lbCollections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCollections.FormattingEnabled = true;
            this.lbCollections.Location = new System.Drawing.Point(3, 3);
            this.lbCollections.Name = "lbCollections";
            this.lbCollections.Size = new System.Drawing.Size(263, 386);
            this.lbCollections.TabIndex = 0;
            // 
            // itemCollectionBindingSource
            // 
            this.itemCollectionBindingSource.DataSource = typeof(NHSE.WinForms.Zebra.ItemCollection);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.btnMoveUp);
            this.flowLayoutPanel3.Controls.Add(this.btnMoveDown);
            this.flowLayoutPanel3.Controls.Add(this.btnSort);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(607, 229);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(34, 102);
            this.flowLayoutPanel3.TabIndex = 6;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.AutoSize = true;
            this.btnMoveUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.SetFlowBreak(this.btnMoveUp, true);
            this.btnMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveUp.Image")));
            this.btnMoveUp.Location = new System.Drawing.Point(2, 2);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(30, 30);
            this.btnMoveUp.TabIndex = 0;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.AutoSize = true;
            this.btnMoveDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.SetFlowBreak(this.btnMoveDown, true);
            this.btnMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveDown.Image")));
            this.btnMoveDown.Location = new System.Drawing.Point(2, 36);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(2);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(30, 30);
            this.btnMoveDown.TabIndex = 1;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnSort
            // 
            this.btnSort.AutoSize = true;
            this.btnSort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.SetFlowBreak(this.btnSort, true);
            this.btnSort.Image = ((System.Drawing.Image)(resources.GetObject("btnSort.Image")));
            this.btnSort.Location = new System.Drawing.Point(2, 70);
            this.btnSort.Margin = new System.Windows.Forms.Padding(2);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(30, 30);
            this.btnSort.TabIndex = 2;
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbInCollection
            // 
            this.lbInCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInCollection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbInCollection.FormattingEnabled = true;
            this.lbInCollection.IntegralHeight = false;
            this.lbInCollection.ItemHeight = 18;
            this.lbInCollection.Location = new System.Drawing.Point(325, 84);
            this.lbInCollection.Name = "lbInCollection";
            this.lbInCollection.Size = new System.Drawing.Size(277, 392);
            this.lbInCollection.TabIndex = 0;
            this.lbInCollection.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbInCollection_DrawItem);
            this.lbInCollection.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lbInCollection_MeasureItem);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.btnAdd);
            this.flowLayoutPanel2.Controls.Add(this.btnRemove);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(285, 246);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(34, 68);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.SetFlowBreak(this.btnAdd, true);
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(2, 2);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.AutoSize = true;
            this.btnRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.SetFlowBreak(this.btnRemove, true);
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.Location = new System.Drawing.Point(2, 36);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(30, 30);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblItemCount
            // 
            this.lblItemCount.AutoSize = true;
            this.lblItemCount.Location = new System.Drawing.Point(3, 479);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(0, 13);
            this.lblItemCount.TabIndex = 8;
            // 
            // lblCollectionCount
            // 
            this.lblCollectionCount.AutoSize = true;
            this.lblCollectionCount.Location = new System.Drawing.Point(324, 479);
            this.lblCollectionCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCollectionCount.Name = "lblCollectionCount";
            this.lblCollectionCount.Size = new System.Drawing.Size(0, 13);
            this.lblCollectionCount.TabIndex = 9;
            // 
            // searchTimer
            // 
            this.searchTimer.Interval = 750;
            this.searchTimer.Tick += new System.EventHandler(this.searchTimer_Tick);
            // 
            // chkTopLevel
            // 
            this.chkTopLevel.AutoSize = true;
            this.chkTopLevel.Location = new System.Drawing.Point(3, 44);
            this.chkTopLevel.Name = "chkTopLevel";
            this.chkTopLevel.Size = new System.Drawing.Size(123, 17);
            this.chkTopLevel.TabIndex = 10;
            this.chkTopLevel.Text = "Top Level Collection";
            this.chkTopLevel.UseVisualStyleBackColor = true;
            // 
            // CollectionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CollectionEditor";
            this.Size = new System.Drawing.Size(643, 492);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.itemsTab.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemCollectionBindingSource)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBoxEx lbInCollection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCollectionName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private ListBoxEx lbAll;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblItemCount;
        private System.Windows.Forms.Label lblCollectionCount;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage itemsTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Timer searchTimer;
        private ListBoxEx lbCollections;
        private System.Windows.Forms.BindingSource itemCollectionBindingSource;
        private System.Windows.Forms.CheckBox chkTopLevel;
    }
}