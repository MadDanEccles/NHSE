using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Sprites;

namespace NHSE.WinForms.Zebra
{

    public partial class BaseItemSelector : UserControl, IItemPropertiesUi
    {
        public ItemEditorInfo SelectedItemInfo { get; private set; }

        public BaseItemSelector()
        {
            InitializeComponent();

            cbItem.ValueMember = nameof(ComboItem.Value);
            cbItem.DisplayMember = nameof(ComboItem.Text);
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            var result = tableLayoutPanel2.GetPreferredSize(proposedSize);
            result.Width = proposedSize.Width;
            return result;
        }

        public void ApplyToItem(Item item)
        {
            item.ItemId = SelectedItemInfo.ItemId;
        }

        public void UpdateFromItem(Item item)
        {
            cbItem.SelectedValue = (int)item.GetItemId();
        }

        public void Initialize(ItemSource itemSource)
        {
            cbItem.DataSource = itemSource.GetItemDropdownData();
            cbItem.DisplayMember = nameof(ComboItem.Text);
            cbItem.ValueMember = nameof(ComboItem.Value);
        }

        private void cbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItemId = (ushort)(int)cbItem.SelectedValue;
            var itemCount = (ushort)0;
            pbItem.BackColor = ItemColor.GetItemColor(selectedItemId);
            pbItem.Image = ItemSprite.GetItemSprite(selectedItemId, itemCount);
            SelectedItemInfo = ItemEditorInfo.FromItemId(selectedItemId);
            OnItemChanged();
        }

        public event EventHandler ItemChanged;

        protected virtual void OnItemChanged()
        {
            ItemChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
