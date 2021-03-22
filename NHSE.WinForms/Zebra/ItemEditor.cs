using System;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms.Zebra
{
    public partial class ItemEditor : UserControl, IItemPropertiesUi
    {
        public ItemEditor()
        {
            InitializeComponent();
        }

        public void ApplyToItem(Item item)
        {
            baseItemSelector.ApplyToItem(item);
            if (radBuried.Checked)
            {
                ItemConvertor.ApplyPresentation(item, PresentationType.Buried);
                ApplyStackSize(item);
            }
            else if (radDropped.Checked)
            {
                ItemConvertor.ApplyPresentation(item, PresentationType.Dropped);
                ApplyStackSize(item);
            }
            else if (radHung.Checked)
            {
                ItemConvertor.ApplyPresentation(item, PresentationType.Hung);
                directionSelector.ApplyToItem(item);
            }
            else
            {
                directionSelector.ApplyToItem(item);
            }
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
            else if (ItemConvertor.IsHung(item))
                radHung.Checked = true;
            else
                radPlaced.Checked = true;
        }

        public void Initialize(ItemSource itemSource)
        {
            baseItemSelector.Initialize(itemSource);
        }

        private void presentationRadioChecked(object sender, EventArgs e)
        {
            switch (PresentationType)
            {
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
                return PresentationType.Unknown;
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
            radBuried.Enabled = selectedItemInfo.CanDrop;
            radPlaced.Enabled = !selectedItemInfo.CanHang;

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
        }
    }

    public static class ControlExtensions
    {
        public static void EnsureRadioGroupChecked(this Control.ControlCollection controls)
        {
            var radioButtons = controls.OfType<RadioButton>().ToArray();
            if (radioButtons.All(r => !r.Checked))
                radioButtons.First(r => r.Enabled).Checked = true;
            else if (radioButtons.Single(r => r.Checked).Enabled == false)
                radioButtons.First(r => r.Enabled).Checked = true;

        }
    }
}