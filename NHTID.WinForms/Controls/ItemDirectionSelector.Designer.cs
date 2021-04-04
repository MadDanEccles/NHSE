
namespace Nhtid.WinForms.Controls
{
    partial class ItemDirectionSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemDirectionSelector));
            this.grpDirection = new System.Windows.Forms.TableLayoutPanel();
            this.radUp = new System.Windows.Forms.RadioButton();
            this.radLeft = new System.Windows.Forms.RadioButton();
            this.radDown = new System.Windows.Forms.RadioButton();
            this.radRight = new System.Windows.Forms.RadioButton();
            this.grpDirection.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDirection
            // 
            this.grpDirection.ColumnCount = 3;
            this.grpDirection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.grpDirection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.grpDirection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.grpDirection.Controls.Add(this.radUp, 1, 0);
            this.grpDirection.Controls.Add(this.radLeft, 0, 1);
            this.grpDirection.Controls.Add(this.radDown, 1, 2);
            this.grpDirection.Controls.Add(this.radRight, 2, 1);
            this.grpDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDirection.Location = new System.Drawing.Point(0, 0);
            this.grpDirection.Margin = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.grpDirection.Name = "grpDirection";
            this.grpDirection.RowCount = 3;
            this.grpDirection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.grpDirection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.grpDirection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.grpDirection.Size = new System.Drawing.Size(109, 112);
            this.grpDirection.TabIndex = 1;
            // 
            // radUp
            // 
            this.radUp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radUp.Appearance = System.Windows.Forms.Appearance.Button;
            this.radUp.AutoSize = true;
            this.radUp.Image = ((System.Drawing.Image)(resources.GetObject("radUp.Image")));
            this.radUp.Location = new System.Drawing.Point(38, 3);
            this.radUp.Name = "radUp";
            this.radUp.Size = new System.Drawing.Size(31, 31);
            this.radUp.TabIndex = 6;
            this.radUp.TabStop = true;
            this.radUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radUp.UseVisualStyleBackColor = true;
            // 
            // radLeft
            // 
            this.radLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.radLeft.AutoSize = true;
            this.radLeft.Image = ((System.Drawing.Image)(resources.GetObject("radLeft.Image")));
            this.radLeft.Location = new System.Drawing.Point(3, 40);
            this.radLeft.Name = "radLeft";
            this.radLeft.Size = new System.Drawing.Size(29, 31);
            this.radLeft.TabIndex = 7;
            this.radLeft.TabStop = true;
            this.radLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radLeft.UseVisualStyleBackColor = true;
            // 
            // radDown
            // 
            this.radDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radDown.Appearance = System.Windows.Forms.Appearance.Button;
            this.radDown.AutoSize = true;
            this.radDown.Image = ((System.Drawing.Image)(resources.GetObject("radDown.Image")));
            this.radDown.Location = new System.Drawing.Point(38, 77);
            this.radDown.Name = "radDown";
            this.radDown.Size = new System.Drawing.Size(31, 32);
            this.radDown.TabIndex = 8;
            this.radDown.TabStop = true;
            this.radDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radDown.UseVisualStyleBackColor = true;
            // 
            // radRight
            // 
            this.radRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.radRight.AutoSize = true;
            this.radRight.Image = ((System.Drawing.Image)(resources.GetObject("radRight.Image")));
            this.radRight.Location = new System.Drawing.Point(75, 40);
            this.radRight.Name = "radRight";
            this.radRight.Size = new System.Drawing.Size(31, 31);
            this.radRight.TabIndex = 9;
            this.radRight.TabStop = true;
            this.radRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radRight.UseVisualStyleBackColor = true;
            // 
            // ItemDirectionSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpDirection);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ItemDirectionSelector";
            this.Size = new System.Drawing.Size(109, 112);
            this.grpDirection.ResumeLayout(false);
            this.grpDirection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel grpDirection;
        private System.Windows.Forms.RadioButton radUp;
        private System.Windows.Forms.RadioButton radLeft;
        private System.Windows.Forms.RadioButton radDown;
        private System.Windows.Forms.RadioButton radRight;
    }
}
