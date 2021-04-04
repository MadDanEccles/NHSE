
using Nhtid.WinForms.SegmentLayouts;

namespace Nhtid.WinForms.Controls
{
    partial class MultiSegmentLayoutEditor
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbSegmentFactory = new System.Windows.Forms.ComboBox();
            this.iSegmentLayoutFactoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iSegmentLayoutFactoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cbSegmentFactory, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.propertyGrid, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(371, 251);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbSegmentFactory
            // 
            this.cbSegmentFactory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSegmentFactory.DataSource = this.iSegmentLayoutFactoryBindingSource;
            this.cbSegmentFactory.DisplayMember = "Name";
            this.cbSegmentFactory.FormattingEnabled = true;
            this.cbSegmentFactory.Location = new System.Drawing.Point(3, 3);
            this.cbSegmentFactory.Name = "cbSegmentFactory";
            this.cbSegmentFactory.Size = new System.Drawing.Size(365, 21);
            this.cbSegmentFactory.TabIndex = 0;
            this.cbSegmentFactory.SelectedValueChanged += new System.EventHandler(this.cbSegmentFactory_SelectedValueChanged);
            // 
            // iSegmentLayoutFactoryBindingSource
            // 
            this.iSegmentLayoutFactoryBindingSource.DataSource = typeof(ISegmentLayoutFactory);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.Location = new System.Drawing.Point(3, 30);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(365, 218);
            this.propertyGrid.TabIndex = 1;
            this.propertyGrid.ToolbarVisible = false;
            // 
            // MultiSegmentLayoutEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MultiSegmentLayoutEditor";
            this.Size = new System.Drawing.Size(371, 251);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iSegmentLayoutFactoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbSegmentFactory;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.BindingSource iSegmentLayoutFactoryBindingSource;
    }
}
