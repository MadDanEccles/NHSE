
namespace Nhtid.WinForms.Controls
{
    partial class TemplateSelector
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
            this.lbItems = new System.Windows.Forms.CheckedListBox();
            this.chkIncludeVariants = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(18, 26);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(259, 276);
            this.lbItems.TabIndex = 0;
            // 
            // chkIncludeVariants
            // 
            this.chkIncludeVariants.AutoSize = true;
            this.chkIncludeVariants.Location = new System.Drawing.Point(18, 309);
            this.chkIncludeVariants.Name = "chkIncludeVariants";
            this.chkIncludeVariants.Size = new System.Drawing.Size(131, 21);
            this.chkIncludeVariants.TabIndex = 1;
            this.chkIncludeVariants.Text = "Include Variants";
            this.chkIncludeVariants.UseVisualStyleBackColor = true;
            // 
            // TemplateSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkIncludeVariants);
            this.Controls.Add(this.lbItems);
            this.Name = "TemplateSelector";
            this.Size = new System.Drawing.Size(291, 557);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lbItems;
        private System.Windows.Forms.CheckBox chkIncludeVariants;
    }
}
