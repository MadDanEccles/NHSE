﻿
namespace Nhtid.WinForms.Controls
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
            this.radRecipe = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.directionSelector = new ItemDirectionSelector();
            this.baseItemSelector = new ItemVariantSelector();
            ((System.ComponentModel.ISupportInitialize)(this.nudStackSize)).BeginInit();
            this.layoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStackSize
            // 
            this.lblStackSize.AutoSize = true;
            this.layoutPanel.SetColumnSpan(this.lblStackSize, 5);
            this.lblStackSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStackSize.Location = new System.Drawing.Point(0, 318);
            this.lblStackSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblStackSize.Name = "lblStackSize";
            this.lblStackSize.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblStackSize.Size = new System.Drawing.Size(68, 19);
            this.lblStackSize.TabIndex = 12;
            this.lblStackSize.Text = "Stack Size";
            // 
            // nudStackSize
            // 
            this.layoutPanel.SetColumnSpan(this.nudStackSize, 5);
            this.nudStackSize.Location = new System.Drawing.Point(2, 339);
            this.nudStackSize.Margin = new System.Windows.Forms.Padding(2);
            this.nudStackSize.Name = "nudStackSize";
            this.nudStackSize.Size = new System.Drawing.Size(90, 20);
            this.nudStackSize.TabIndex = 13;
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.layoutPanel.SetColumnSpan(this.lblDirection, 5);
            this.lblDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirection.Location = new System.Drawing.Point(0, 361);
            this.lblDirection.Margin = new System.Windows.Forms.Padding(0);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblDirection.Size = new System.Drawing.Size(58, 19);
            this.lblDirection.TabIndex = 10;
            this.lblDirection.Text = "Direction";
            // 
            // radPlaced
            // 
            this.radPlaced.Appearance = System.Windows.Forms.Appearance.Button;
            this.radPlaced.AutoSize = true;
            this.radPlaced.Image = ((System.Drawing.Image)(resources.GetObject("radPlaced.Image")));
            this.radPlaced.Location = new System.Drawing.Point(170, 278);
            this.radPlaced.Margin = new System.Windows.Forms.Padding(2);
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
            this.radBuried.Location = new System.Drawing.Point(44, 278);
            this.radBuried.Margin = new System.Windows.Forms.Padding(2);
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
            this.radHung.Location = new System.Drawing.Point(86, 278);
            this.radHung.Margin = new System.Windows.Forms.Padding(2);
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
            this.radDropped.Location = new System.Drawing.Point(2, 278);
            this.radDropped.Margin = new System.Windows.Forms.Padding(2);
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
            this.layoutPanel.ColumnCount = 5;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.Controls.Add(this.radRecipe, 3, 3);
            this.layoutPanel.Controls.Add(this.label2, 0, 0);
            this.layoutPanel.Controls.Add(this.nudStackSize, 0, 5);
            this.layoutPanel.Controls.Add(this.directionSelector, 0, 7);
            this.layoutPanel.Controls.Add(this.lblStackSize, 0, 4);
            this.layoutPanel.Controls.Add(this.baseItemSelector, 0, 1);
            this.layoutPanel.Controls.Add(this.radDropped, 0, 3);
            this.layoutPanel.Controls.Add(this.radBuried, 1, 3);
            this.layoutPanel.Controls.Add(this.radHung, 2, 3);
            this.layoutPanel.Controls.Add(this.radPlaced, 4, 3);
            this.layoutPanel.Controls.Add(this.lblDirection, 0, 6);
            this.layoutPanel.Controls.Add(this.label1, 0, 2);
            this.layoutPanel.Controls.Add(this.lblInfo, 0, 8);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.RowCount = 9;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.Size = new System.Drawing.Size(221, 591);
            this.layoutPanel.TabIndex = 2;
            // 
            // radRecipe
            // 
            this.radRecipe.Appearance = System.Windows.Forms.Appearance.Button;
            this.radRecipe.AutoSize = true;
            this.radRecipe.Image = ((System.Drawing.Image)(resources.GetObject("radRecipe.Image")));
            this.radRecipe.Location = new System.Drawing.Point(128, 278);
            this.radRecipe.Margin = new System.Windows.Forms.Padding(2);
            this.radRecipe.Name = "radRecipe";
            this.radRecipe.Size = new System.Drawing.Size(38, 38);
            this.radRecipe.TabIndex = 6;
            this.radRecipe.TabStop = true;
            this.toolTip1.SetToolTip(this.radRecipe, "DIY Recipe");
            this.radRecipe.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.layoutPanel.SetColumnSpan(this.label2, 5);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Item";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.layoutPanel.SetColumnSpan(this.label1, 5);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 260);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Placement";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.layoutPanel.SetColumnSpan(this.lblInfo, 5);
            this.lblInfo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(3, 577);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 14);
            this.lblInfo.TabIndex = 18;
            // 
            // directionSelector
            // 
            this.layoutPanel.SetColumnSpan(this.directionSelector, 5);
            this.directionSelector.Location = new System.Drawing.Point(3, 383);
            this.directionSelector.Name = "directionSelector";
            this.directionSelector.Size = new System.Drawing.Size(94, 103);
            this.directionSelector.TabIndex = 14;
            // 
            // baseItemSelector
            // 
            this.baseItemSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baseItemSelector.AutoSize = true;
            this.baseItemSelector.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutPanel.SetColumnSpan(this.baseItemSelector, 5);
            this.baseItemSelector.Location = new System.Drawing.Point(3, 19);
            this.baseItemSelector.Name = "baseItemSelector";
            this.baseItemSelector.Size = new System.Drawing.Size(215, 238);
            this.baseItemSelector.TabIndex = 15;
            this.baseItemSelector.ItemChanged += new System.EventHandler(this.baseItemSelector_ItemChanged);
            // 
            // ItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutPanel);
            this.Name = "ItemEditor";
            this.Size = new System.Drawing.Size(221, 591);
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
        private System.Windows.Forms.RadioButton radRecipe;
        private System.Windows.Forms.Label lblInfo;
    }
}
