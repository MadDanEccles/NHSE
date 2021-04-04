
namespace Nhtid.WinForms.Controls
{
    partial class ItemVariantSelector
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbFabric = new System.Windows.Forms.ComboBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.lblFabric = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.baseItemSelector1 = new BaseItemSelector();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.cbFabric, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.cbColor, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblFabric, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblColor, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.baseItemSelector1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(513, 296);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // cbFabric
            // 
            this.cbFabric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFabric.FormattingEnabled = true;
            this.cbFabric.Location = new System.Drawing.Point(16, 269);
            this.cbFabric.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.cbFabric.Name = "cbFabric";
            this.cbFabric.Size = new System.Drawing.Size(494, 24);
            this.cbFabric.TabIndex = 3;
            // 
            // cbColor
            // 
            this.cbColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(16, 214);
            this.cbColor.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(494, 24);
            this.cbColor.TabIndex = 3;
            // 
            // lblFabric
            // 
            this.lblFabric.AutoSize = true;
            this.lblFabric.Location = new System.Drawing.Point(16, 241);
            this.lblFabric.Margin = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblFabric.Name = "lblFabric";
            this.lblFabric.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblFabric.Size = new System.Drawing.Size(47, 25);
            this.lblFabric.TabIndex = 11;
            this.lblFabric.Text = "Fabric";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(16, 186);
            this.lblColor.Margin = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblColor.Name = "lblColor";
            this.lblColor.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblColor.Size = new System.Drawing.Size(49, 25);
            this.lblColor.TabIndex = 12;
            this.lblColor.Text = "Colour";
            // 
            // baseItemSelector1
            // 
            this.baseItemSelector1.AutoSize = true;
            this.baseItemSelector1.Location = new System.Drawing.Point(4, 4);
            this.baseItemSelector1.Margin = new System.Windows.Forms.Padding(4);
            this.baseItemSelector1.Name = "baseItemSelector1";
            this.baseItemSelector1.Size = new System.Drawing.Size(505, 178);
            this.baseItemSelector1.TabIndex = 13;
            this.baseItemSelector1.ItemChanged += new System.EventHandler(this.baseItemSelector1_ItemChanged);
            // 
            // ItemVariantSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ItemVariantSelector";
            this.Size = new System.Drawing.Size(513, 427);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cbFabric;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.Label lblFabric;
        private System.Windows.Forms.Label lblColor;
        private BaseItemSelector baseItemSelector1;
    }
}
