using System;
using System.Windows.Forms;
using NHSE.Core;
using Nhtid.WinForms.Tools;

namespace Nhtid.WinForms.Controls
{
    public partial class ItemEditor : UserControl, IItemPropertiesUi, IItemSelector, IPickTarget
    {
        private ItemConvertor itemConvertor;

        public ItemEditor()
        {
            InitializeComponent();
        }

        public void AutoWire(ItemConvertor itemConvertor)
        {
            this.itemConvertor = itemConvertor;
        }

        public void ApplyToItem(Item item)
        {
            baseItemSelector.ApplyToItem(item);
            if (radBuried.Checked)
            {
                itemConvertor.ApplyPresentation(item, PresentationType.Buried);
                ApplyStackSize(item);
            }
            else if (radDropped.Checked)
            {
                itemConvertor.ApplyPresentation(item, PresentationType.Dropped);
                ApplyStackSize(item);
            }
            else if (radHung.Checked)
            {
                itemConvertor.ApplyPresentation(item, PresentationType.Hung);
                directionSelector.ApplyToItem(item);
            }
            else if (radRecipe.Checked)
            {
                itemConvertor.ApplyPresentation(item, PresentationType.Recipe);
            }
            else
            {
                directionSelector.ApplyToItem(item);
            }
        }

        void IPickTarget.Pick(Item item)
        {
            this.UpdateFromItem(item);
        }

        Item IItemSelector.GetItem()
        {
            Item item = new Item();
            this.ApplyToItem(item);
            return item;
        }

        private void ApplyStackSize(Item item)
        {
            if (!baseItemSelector.SelectedItemInfo.HasVariants)
            {
                item.Count = (ushort)((int)nudStackSize.Value - 1);
                item.UseCount = 0;
            }
        }

        public void UpdateFromItem(Item item)
        {
            baseItemSelector.UpdateFromItem(item);
            directionSelector.UpdateFromItem(item);
            if (item.IsBuried)
            {
                radBuried.Checked = true;
                if (!baseItemSelector.SelectedItemInfo.HasVariants)
                    nudStackSize.Value = item.Count + 1;
            }
            else if (item.IsDropped)
            {
                radDropped.Checked = true;
                if (!baseItemSelector.SelectedItemInfo.HasVariants)
                    nudStackSize.Value = item.Count + 1;
            }
            else if (itemConvertor.IsHung(item))
                radHung.Checked = true;
            else if (itemConvertor.IsRecipe(item))
                radRecipe.Checked = true;
            else
                radPlaced.Checked = true;
        }

        private void presentationRadioChecked(object sender, EventArgs e)
        {
            switch (PresentationType)
            {
                case PresentationType.Recipe:
                    lblDirection.Hide();
                    nudStackSize.Hide();
                    lblStackSize.Hide();
                    directionSelector.Hide();
                    break;
                case PresentationType.Hung:
                case PresentationType.Placed:
                    lblDirection.Show();
                    directionSelector.Show();
                    nudStackSize.Hide();
                    lblStackSize.Hide();
                    break;
                case PresentationType.Buried:
                case PresentationType.Dropped:
                    lblDirection.Hide();
                    directionSelector.Hide();
                    nudStackSize.Show();
                    lblStackSize.Show();
                    break;
            }
        }

        PresentationType PresentationType
        {
            get
            {
                if (radDropped.Checked)
                    return PresentationType.Dropped;
                if (radBuried.Checked)
                    return PresentationType.Buried;
                if (radHung.Checked)
                    return PresentationType.Hung;
                if (radPlaced.Checked)
                    return PresentationType.Placed;
                if (radRecipe.Checked)
                    return PresentationType.Recipe;
                return PresentationType.None;
            }
            set
            {
                switch (value)
                {
                    case PresentationType.Placed:
                        radPlaced.Checked = true;
                        break;
                    case PresentationType.Dropped:
                        radDropped.Checked = true;
                        break;
                    case PresentationType.Buried:
                        radBuried.Checked = true;
                        break;
                    case PresentationType.Hung:
                        radHung.Checked = true;
                        break;
                    case PresentationType.Recipe:
                        radRecipe.Checked = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }

        private void baseItemSelector_ItemChanged(object sender, EventArgs e)
        {
            var selectedItemInfo = baseItemSelector.SelectedItemInfo;
            radDropped.Enabled = selectedItemInfo.CanDrop;
            radHung.Enabled = selectedItemInfo.CanHang;
            radBuried.Enabled = selectedItemInfo.CanBury;
            radPlaced.Enabled = selectedItemInfo.CanPlace;
            radRecipe.Enabled = selectedItemInfo.CanRecipe;

            if (selectedItemInfo.HasVariants)
            {
                nudStackSize.Enabled = false;
                lblStackSize.Enabled = false;
                nudStackSize.Value = 1;
            }
            else
            {
                nudStackSize.Enabled = true;
                lblStackSize.Enabled = true;
                nudStackSize.Minimum = 1;
                nudStackSize.Maximum = selectedItemInfo.MaxStackSize;
                nudStackSize.Value = selectedItemInfo.MaxStackSize;
            }

            layoutPanel.Controls.EnsureRadioGroupChecked();

            lblInfo.Text =
                $"ID:    {selectedItemInfo.ItemId} (0x{selectedItemInfo.ItemId:X})\r\nKind:  {selectedItemInfo.Kind}\r\nStack: {selectedItemInfo.MaxStackSize}";
        }
    }
}