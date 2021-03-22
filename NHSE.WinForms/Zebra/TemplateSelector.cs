using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms.Zebra
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
