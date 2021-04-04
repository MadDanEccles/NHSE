using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Nhtid.WinForms.SegmentLayouts;

namespace Nhtid.WinForms.Controls
{
    public partial class MultiSegmentLayoutEditor : UserControl
    {
        public MultiSegmentLayoutEditor()
        {
            InitializeComponent();
        }

        public IMultiSegmentLayoutFactory Factory => (IMultiSegmentLayoutFactory)cbSegmentFactory.SelectedValue;

        public void AutoWire(IEnumerable<IMultiSegmentLayoutFactory> factories)
        {
            iSegmentLayoutFactoryBindingSource.DataSource = factories.ToArray();
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
