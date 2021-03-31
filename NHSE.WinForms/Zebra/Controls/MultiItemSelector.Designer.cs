
namespace NHSE.WinForms.Zebra.Controls
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkVaryDiy = new System.Windows.Forms.CheckBox();
            this.chkVaryOther = new System.Windows.Forms.CheckBox();
            this.segmentLayoutEditor = new NHSE.WinForms.Zebra.Controls.SegmentLayoutEditor();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 42);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(253, 151);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.chkVaryDiy);
            this.flowLayoutPanel2.Controls.Add(this.chkVaryOther);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(253, 42);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // chkVaryDiy
            // 
            this.chkVaryDiy.AutoSize = true;
            this.flowLayoutPanel2.SetFlowBreak(this.chkVaryDiy, true);
            this.chkVaryDiy.Location = new System.Drawing.Point(2, 2);
            this.chkVaryDiy.Margin = new System.Windows.Forms.Padding(2);
            this.chkVaryDiy.Name = "chkVaryDiy";
            this.chkVaryDiy.Size = new System.Drawing.Size(161, 17);
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
            this.chkVaryOther.Location = new System.Drawing.Point(2, 23);
            this.chkVaryOther.Margin = new System.Windows.Forms.Padding(2);
            this.chkVaryOther.Name = "chkVaryOther";
            this.chkVaryOther.Size = new System.Drawing.Size(167, 17);
            this.chkVaryOther.TabIndex = 1;
            this.chkVaryOther.Text = "Include variants of other items";
            this.chkVaryOther.UseVisualStyleBackColor = true;
            // 
            // segmentLayoutEditor
            // 
            this.segmentLayoutEditor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.segmentLayoutEditor.Location = new System.Drawing.Point(0, 193);
            this.segmentLayoutEditor.Name = "segmentLayoutEditor";
            this.segmentLayoutEditor.Size = new System.Drawing.Size(253, 210);
            this.segmentLayoutEditor.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 190);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(253, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // MultiItemSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.segmentLayoutEditor);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MultiItemSelector";
            this.Size = new System.Drawing.Size(253, 403);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox chkVaryDiy;
        private System.Windows.Forms.CheckBox chkVaryOther;
        private SegmentLayoutEditor segmentLayoutEditor;
        private System.Windows.Forms.Splitter splitter1;
    }
}
