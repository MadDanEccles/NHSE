
namespace NHSE.WinForms.Zebra
{
    partial class MultiItemSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiItemSelector));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddCollection = new System.Windows.Forms.Button();
            this.btnEditCollection = new System.Windows.Forms.Button();
            this.btnDeleteCollection = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkVaryDiy = new System.Windows.Forms.CheckBox();
            this.chkVaryOther = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 52);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(337, 257);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnAddCollection);
            this.flowLayoutPanel1.Controls.Add(this.btnEditCollection);
            this.flowLayoutPanel1.Controls.Add(this.btnDeleteCollection);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 309);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(337, 36);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnAddCollection
            // 
            this.btnAddCollection.AutoSize = true;
            this.btnAddCollection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddCollection.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCollection.Image")));
            this.btnAddCollection.Location = new System.Drawing.Point(3, 3);
            this.btnAddCollection.Name = "btnAddCollection";
            this.btnAddCollection.Size = new System.Drawing.Size(30, 30);
            this.btnAddCollection.TabIndex = 0;
            this.btnAddCollection.UseVisualStyleBackColor = true;
            this.btnAddCollection.Click += new System.EventHandler(this.btnAddCollection_Click);
            // 
            // btnEditCollection
            // 
            this.btnEditCollection.AutoSize = true;
            this.btnEditCollection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditCollection.Enabled = false;
            this.btnEditCollection.Image = ((System.Drawing.Image)(resources.GetObject("btnEditCollection.Image")));
            this.btnEditCollection.Location = new System.Drawing.Point(39, 3);
            this.btnEditCollection.Name = "btnEditCollection";
            this.btnEditCollection.Size = new System.Drawing.Size(30, 30);
            this.btnEditCollection.TabIndex = 1;
            this.btnEditCollection.UseVisualStyleBackColor = true;
            this.btnEditCollection.Click += new System.EventHandler(this.btnEditCollection_Click);
            // 
            // btnDeleteCollection
            // 
            this.btnDeleteCollection.AutoSize = true;
            this.btnDeleteCollection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteCollection.Enabled = false;
            this.btnDeleteCollection.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteCollection.Image")));
            this.btnDeleteCollection.Location = new System.Drawing.Point(75, 3);
            this.btnDeleteCollection.Name = "btnDeleteCollection";
            this.btnDeleteCollection.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteCollection.TabIndex = 2;
            this.btnDeleteCollection.UseVisualStyleBackColor = true;
            this.btnDeleteCollection.Click += new System.EventHandler(this.btnDeleteCollection_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.chkVaryDiy);
            this.flowLayoutPanel2.Controls.Add(this.chkVaryOther);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(337, 52);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // chkVaryDiy
            // 
            this.chkVaryDiy.AutoSize = true;
            this.flowLayoutPanel2.SetFlowBreak(this.chkVaryDiy, true);
            this.chkVaryDiy.Location = new System.Drawing.Point(3, 3);
            this.chkVaryDiy.Name = "chkVaryDiy";
            this.chkVaryDiy.Size = new System.Drawing.Size(194, 20);
            this.chkVaryDiy.TabIndex = 0;
            this.chkVaryDiy.Text = "Include variants of DIY items";
            this.chkVaryDiy.UseVisualStyleBackColor = true;
            // 
            // chkVaryOther
            // 
            this.chkVaryOther.AutoSize = true;
            this.chkVaryOther.Checked = true;
            this.chkVaryOther.CheckState = System.Windows.Forms.CheckState.Checked;
            this.flowLayoutPanel2.SetFlowBreak(this.chkVaryOther, true);
            this.chkVaryOther.Location = new System.Drawing.Point(3, 29);
            this.chkVaryOther.Name = "chkVaryOther";
            this.chkVaryOther.Size = new System.Drawing.Size(202, 20);
            this.chkVaryOther.TabIndex = 1;
            this.chkVaryOther.Text = "Include variants of other items";
            this.chkVaryOther.UseVisualStyleBackColor = true;
            // 
            // MultiItemSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MultiItemSelector";
            this.Size = new System.Drawing.Size(337, 345);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAddCollection;
        private System.Windows.Forms.Button btnEditCollection;
        private System.Windows.Forms.Button btnDeleteCollection;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox chkVaryDiy;
        private System.Windows.Forms.CheckBox chkVaryOther;
    }
}
