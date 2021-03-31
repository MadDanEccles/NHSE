
namespace NHSE.WinForms.Zebra.Controls
{
    partial class CollectionEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectionEditorForm));
            this.collectionEditor1 = new CollectionEditor();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteCollection = new System.Windows.Forms.Button();
            this.cmbCollections = new System.Windows.Forms.ComboBox();
            this.itemCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddCollection = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemCollectionBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // collectionEditor1
            // 
            this.collectionEditor1.Collection = null;
            this.collectionEditor1.Collections = null;
            this.collectionEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collectionEditor1.ItemSource = null;
            this.collectionEditor1.Location = new System.Drawing.Point(0, 34);
            this.collectionEditor1.Margin = new System.Windows.Forms.Padding(2);
            this.collectionEditor1.Name = "collectionEditor1";
            this.collectionEditor1.Padding = new System.Windows.Forms.Padding(16, 8, 16, 0);
            this.collectionEditor1.Size = new System.Drawing.Size(800, 381);
            this.collectionEditor1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteCollection, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbCollections, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddCollection, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 34);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnDeleteCollection
            // 
            this.btnDeleteCollection.AutoSize = true;
            this.btnDeleteCollection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteCollection.Enabled = false;
            this.btnDeleteCollection.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteCollection.Image")));
            this.btnDeleteCollection.Location = new System.Drawing.Point(307, 2);
            this.btnDeleteCollection.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteCollection.Name = "btnDeleteCollection";
            this.btnDeleteCollection.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteCollection.TabIndex = 4;
            this.btnDeleteCollection.UseVisualStyleBackColor = true;
            this.btnDeleteCollection.Click += new System.EventHandler(this.btnDeleteCollection_Click);
            // 
            // cmbCollections
            // 
            this.cmbCollections.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCollections.DataSource = this.itemCollectionBindingSource;
            this.cmbCollections.DisplayMember = "Name";
            this.cmbCollections.FormattingEnabled = true;
            this.cmbCollections.Location = new System.Drawing.Point(7, 6);
            this.cmbCollections.Name = "cmbCollections";
            this.cmbCollections.Size = new System.Drawing.Size(261, 21);
            this.cmbCollections.TabIndex = 0;
            this.cmbCollections.SelectedIndexChanged += new System.EventHandler(this.cmbCollections_SelectedIndexChanged);
            this.cmbCollections.SelectedValueChanged += new System.EventHandler(this.cmbCollections_SelectedValueChanged);
            // 
            // itemCollectionBindingSource
            // 
            this.itemCollectionBindingSource.DataSource = typeof(NHSE.WinForms.Zebra.ItemCollection);
            // 
            // btnAddCollection
            // 
            this.btnAddCollection.AutoSize = true;
            this.btnAddCollection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddCollection.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCollection.Image")));
            this.btnAddCollection.Location = new System.Drawing.Point(273, 2);
            this.btnAddCollection.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddCollection.Name = "btnAddCollection";
            this.btnAddCollection.Size = new System.Drawing.Size(30, 30);
            this.btnAddCollection.TabIndex = 3;
            this.btnAddCollection.UseVisualStyleBackColor = true;
            this.btnAddCollection.Click += new System.EventHandler(this.btnAddCollection_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 415);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 35);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(719, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CollectionEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.collectionEditor1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CollectionEditorForm";
            this.Text = "CollectionEditorForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemCollectionBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CollectionEditor collectionEditor1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbCollections;
        private System.Windows.Forms.Button btnAddCollection;
        private System.Windows.Forms.Button btnDeleteCollection;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource itemCollectionBindingSource;
    }
}