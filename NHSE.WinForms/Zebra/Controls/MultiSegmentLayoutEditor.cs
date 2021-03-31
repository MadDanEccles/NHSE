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
    public partial class MultiSegmentLayoutEditor : UserControl
    {
        public MultiSegmentLayoutEditor()
        {
            InitializeComponent();
        }

        public IMultiSegmentLayoutFactory Factory => (IMultiSegmentLayoutFactory)cbSegmentFactory.SelectedValue;

        public void Initialise(LayoutManager layoutManager)
        {
            iSegmentLayoutFactoryBindingSource.DataSource = layoutManager.MultiFactories;
        }

        private void cbSegmentFactory_SelectedValueChanged(object sender, EventArgs e)
        {
            IMultiSegmentLayoutFactory? factory = (IMultiSegmentLayoutFactory) cbSegmentFactory.SelectedValue;
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
