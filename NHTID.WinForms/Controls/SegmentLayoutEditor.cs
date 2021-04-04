using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Nhtid.WinForms.SegmentLayouts;

namespace Nhtid.WinForms.Controls
{
    public partial class SegmentLayoutEditor : UserControl
    {
        public SegmentLayoutEditor()
        {
            InitializeComponent();
        }

        public ISegmentLayoutFactory Factory => (ISegmentLayoutFactory)cbSegmentFactory.SelectedValue;

        public void AutoWire(IEnumerable<ISegmentLayoutFactory> factories)
        {
            factoriesBindingSource.DataSource = factories.ToArray();
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
