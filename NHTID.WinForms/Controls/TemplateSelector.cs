using System.Windows.Forms;
using NHSE.Core;

namespace Nhtid.WinForms.Controls
{
    public partial class TemplateSelector : UserControl
    {
        public TemplateSelector()
        {
            InitializeComponent();
        }

        public void Initialise(ItemSource itemSource)
        {
            lbItems.DataSource = itemSource.GetItemDropdownData();
            lbItems.DisplayMember = nameof(ComboItem.Text);
            lbItems.ValueMember = nameof(ComboItem.Value);

        }
    }
}
