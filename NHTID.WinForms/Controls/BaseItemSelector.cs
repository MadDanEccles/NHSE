using System;
using System.Drawing;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Sprites;

namespace Nhtid.WinForms.Controls
{

    public partial class BaseItemSelector : UserControl, IItemPropertiesUi
    {
        private ItemConvertor itemConvertor;
        internal ItemEditorInfo SelectedItemInfo { get; private set; }

        public BaseItemSelector()
        {
            InitializeComponent();

            cbItem.ValueMember = nameof(ComboItem.Value);
            cbItem.DisplayMember = nameof(ComboItem.Text);
        }

        public void AutoWire(ItemConvertor itemConvertor)
        {
            this.itemConvertor = itemConvertor;
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
            cbItem.SelectedValue = (int)itemConvertor.GetItemId(item);
        }


        public void AutoWire(ItemSource itemSource)
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
            SelectedItemInfo = itemConvertor.FromItemId(selectedItemId);
            OnItemChanged();
        }

        public event EventHandler ItemChanged;

        protected virtual void OnItemChanged()
        {
            ItemChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
