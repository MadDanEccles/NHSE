using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHSE.WinForms.Zebra.SegmentLayouts;

namespace NHSE.WinForms.Zebra.Controls
{
    public partial class SegmentLayoutEditor : UserControl
    {
        public SegmentLayoutEditor()
        {
            InitializeComponent();
        }

        public ISegmentLayoutFactory Factory => (ISegmentLayoutFactory)cbSegmentFactory.SelectedValue;

        public void Initialise(LayoutManager layoutManager)
        {
            iSegmentLayoutFactoryBindingSource.DataSource = layoutManager.Factories;
        }

        private void cbSegmentFactory_SelectedValueChanged(object sender, EventArgs e)
        {
            ISegmentLayoutFactory? factory = (ISegmentLayoutFactory) cbSegmentFactory.SelectedValue;
            if (factory?.Settings == null)
            {
                propertyGrid.SelectedObject = null;
                propertyGrid.Enabled = false;
            }
            else
            {
                propertyGrid.SelectedObject = factory.Settings;
                propertyGrid.Enabled = true;
            }
        }
    }
}
