
namespace NHSE.WinForms.Zebra
{
    partial class ItemEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemEditor));
            this.lblStackSize = new System.Windows.Forms.Label();
            this.nudStackSize = new System.Windows.Forms.NumericUpDown();
            this.lblDirection = new System.Windows.Forms.Label();
            this.radPlaced = new System.Windows.Forms.RadioButton();
            this.radBuried = new System.Windows.Forms.RadioButton();
            this.radHung = new System.Windows.Forms.RadioButton();
            this.radDropped = new System.Windows.Forms.RadioButton();
            this.layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.directionSelector = new NHSE.WinForms.Zebra.ItemDirectionSelector();
            this.baseItemSelector = new NHSE.WinForms.Zebra.ItemVariantSelector();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudStackSize)).BeginInit();
            this.layoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStackSize
            // 
            this.lblStackSize.AutoSize = true;
            this.layoutPanel.SetColumnSpan(this.lblStackSize, 4);
            this.lblStackSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStackSize.Location = new System.Drawing.Point(0, 391);
            this.lblStackSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblStackSize.Name = "lblStackSize";
            this.lblStackSize.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblStackSize.Size = new System.Drawing.Size(84, 25);
            this.lblStackSize.TabIndex = 12;
            this.lblStackSize.Text = "Stack Size";
            // 
            // nudStackSize
            // 
            this.layoutPanel.SetColumnSpan(this.nudStackSize, 4);
            this.nudStackSize.Location = new System.Drawing.Point(3, 419);
            this.nudStackSize.Name = "nudStackSize";
            this.nudStackSize.Size = new System.Drawing.Size(120, 22);
            this.nudStackSize.TabIndex = 13;
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.layoutPanel.SetColumnSpan(this.lblDirection, 4);
            this.lblDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirection.Location = new System.Drawing.Point(0, 444);
            this.lblDirection.Margin = new System.Windows.Forms.Padding(0);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblDirection.Size = new System.Drawing.Size(73, 25);
            this.lblDirection.TabIndex = 10;
            this.lblDirection.Text = "Direction";
            // 
            // radPlaced
            // 
            this.radPlaced.Appearance = System.Windows.Forms.Appearance.Button;
            this.radPlaced.AutoSize = true;
            this.radPlaced.Image = ((System.Drawing.Image)(resources.GetObject("radPlaced.Image")));
            this.radPlaced.Location = new System.Drawing.Point(135, 350);
            this.radPlaced.Name = "radPlaced";
            this.radPlaced.Size = new System.Drawing.Size(38, 38);
            this.radPlaced.TabIndex = 5;
            this.radPlaced.TabStop = true;
            this.toolTip1.SetToolTip(this.radPlaced, "Normal Placed Item");
            this.radPlaced.UseVisualStyleBackColor = true;
            this.radPlaced.CheckedChanged += new System.EventHandler(this.presentationRadioChecked);
            // 
            // radBuried
            // 
            this.radBuried.Appearance = System.Windows.Forms.Appearance.Button;
            this.radBuried.AutoSize = true;
            this.radBuried.Image = ((System.Drawing.Image)(resources.GetObject("radBuried.Image")));
            this.radBuried.Location = new System.Drawing.Point(47, 350);
            this.radBuried.Name = "radBuried";
            this.radBuried.Size = new System.Drawing.Size(38, 38);
            this.radBuried.TabIndex = 4;
            this.radBuried.TabStop = true;
            this.toolTip1.SetToolTip(this.radBuried, "Buried Item");
            this.radBuried.UseVisualStyleBackColor = true;
            this.radBuried.CheckedChanged += new System.EventHandler(this.presentationRadioChecked);
            // 
            // radHung
            // 
            this.radHung.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHung.AutoSize = true;
            this.radHung.Image = ((System.Drawing.Image)(resources.GetObject("radHung.Image")));
            this.radHung.Location = new System.Drawing.Point(91, 350);
            this.radHung.Name = "radHung";
            this.radHung.Size = new System.Drawing.Size(38, 38);
            this.radHung.TabIndex = 3;
            this.radHung.TabStop = true;
            this.toolTip1.SetToolTip(this.radHung, "Hung on Display Rack");
            this.radHung.UseVisualStyleBackColor = true;
            this.radHung.CheckedChanged += new System.EventHandler(this.presentationRadioChecked);
            // 
            // radDropped
            // 
            this.radDropped.Appearance = System.Windows.Forms.Appearance.Button;
            this.radDropped.AutoSize = true;
            this.radDropped.Image = ((System.Drawing.Image)(resources.GetObject("radDropped.Image")));
            this.radDropped.Location = new System.Drawing.Point(3, 350);
            this.radDropped.Name = "radDropped";
            this.radDropped.Size = new System.Drawing.Size(38, 38);
            this.radDropped.TabIndex = 2;
            this.radDropped.TabStop = true;
            this.toolTip1.SetToolTip(this.radDropped, "Dropped Item");
            this.radDropped.UseVisualStyleBackColor = true;
            this.radDropped.CheckedChanged += new System.EventHandler(this.presentationRadioChecked);
            // 
            // layoutPanel
            // 
            this.layoutPanel.ColumnCount = 4;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.Controls.Add(this.label2, 0, 0);
            this.layoutPanel.Controls.Add(this.nudStackSize, 0, 5);
            this.layoutPanel.Controls.Add(this.directionSelector, 0, 7);
            this.layoutPanel.Controls.Add(this.lblStackSize, 0, 4);
            this.layoutPanel.Controls.Add(this.baseItemSelector, 0, 1);
            this.layoutPanel.Controls.Add(this.radDropped, 0, 3);
            this.layoutPanel.Controls.Add(this.radBuried, 1, 3);
            this.layoutPanel.Controls.Add(this.radHung, 2, 3);
            this.layoutPanel.Controls.Add(this.radPlaced, 3, 3);
            this.layoutPanel.Controls.Add(this.lblDirection, 0, 6);
            this.layoutPanel.Controls.Add(this.label1, 0, 2);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.RowCount = 8;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.Size = new System.Drawing.Size(231, 662);
            this.layoutPanel.TabIndex = 2;
            // 
            // directionSelector
            // 
            this.layoutPanel.SetColumnSpan(this.directionSelector, 4);
            this.directionSelector.Location = new System.Drawing.Point(4, 473);
            this.directionSelector.Margin = new System.Windows.Forms.Padding(4);
            this.directionSelector.Name = "directionSelector";
            this.directionSelector.Size = new System.Drawing.Size(125, 127);
            this.directionSelector.TabIndex = 14;
            // 
            // baseItemSelector
            // 
            this.baseItemSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baseItemSelector.AutoSize = true;
            this.baseItemSelector.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutPanel.SetColumnSpan(this.baseItemSelector, 4);
            this.baseItemSelector.Location = new System.Drawing.Point(4, 24);
            this.baseItemSelector.Margin = new System.Windows.Forms.Padding(4);
            this.baseItemSelector.Name = "baseItemSelector";
            this.baseItemSelector.Size = new System.Drawing.Size(223, 299);
            this.baseItemSelector.TabIndex = 15;
            this.baseItemSelector.ItemChanged += new System.EventHandler(this.baseItemSelector_ItemChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.layoutPanel.SetColumnSpan(this.label1, 4);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Placement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.layoutPanel.SetColumnSpan(this.label2, 4);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Item";
            // 
            // ItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ItemEditor";
            this.Size = new System.Drawing.Size(231, 662);
            ((System.ComponentModel.ISupportInitialize)(this.nudStackSize)).EndInit();
            this.layoutPanel.ResumeLayout(false);
            this.layoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStackSize;
        private ItemDirectionSelector directionSelector;
        private System.Windows.Forms.NumericUpDown nudStackSize;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.RadioButton radPlaced;
        private System.Windows.Forms.RadioButton radBuried;
        private System.Windows.Forms.RadioButton radHung;
        private System.Windows.Forms.RadioButton radDropped;
        private System.Windows.Forms.TableLayoutPanel layoutPanel;
        private ItemVariantSelector baseItemSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
