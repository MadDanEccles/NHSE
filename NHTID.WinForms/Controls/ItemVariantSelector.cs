﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;

namespace Nhtid.WinForms.Controls
{

    public partial class ItemVariantSelector : UserControl, IItemPropertiesUi
    {
        private ItemConvertor itemConvertor;

        public ItemVariantSelector()
        {
            InitializeComponent();

            cbColor.ValueMember = nameof(ItemVariant.Value);
            cbColor.DisplayMember = nameof(ItemVariant.Caption);

            cbFabric.ValueMember = nameof(ItemVariant.Value);
            cbFabric.DisplayMember = nameof(ItemVariant.Caption);
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
            baseItemSelector1.ApplyToItem(item);
            if (SelectedItemInfo.HasVariants)
            {
                item.Count = SelectedItemInfo.BodyVariants.Any() ? (ushort)cbColor.SelectedValue : (ushort)0;
                item.UseCount = SelectedItemInfo.FabricVariants.Any() ? (ushort)cbFabric.SelectedValue : (ushort)0;
            }
        }

        public void UpdateFromItem(Item item)
        {
            baseItemSelector1.UpdateFromItem(item);
            if (SelectedItemInfo.HasVariants)
            {
                cbColor.SelectedValue = itemConvertor.GetBodyVariant(item);
                cbFabric.SelectedValue = itemConvertor.GetFabricVariant(item);
            }
        }

        public event EventHandler ItemChanged;

        protected virtual void OnItemChanged()
        {
            ItemChanged?.Invoke(this, EventArgs.Empty);
        }

        public ItemEditorInfo SelectedItemInfo => baseItemSelector1.SelectedItemInfo;

        private void baseItemSelector1_ItemChanged(object sender, EventArgs e)
        {
            if (SelectedItemInfo.HasVariants)
            {
                cbColor.DataSource = SelectedItemInfo.BodyVariants;
                cbFabric.DataSource = SelectedItemInfo.FabricVariants;

                cbColor.Visible = lblColor.Visible = SelectedItemInfo.BodyVariants.Any();
                cbFabric.Visible = lblFabric.Visible = SelectedItemInfo.FabricVariants.Any();
            }
            else
            {
                cbColor.Visible = lblColor.Visible =
                    cbFabric.Visible = lblFabric.Visible = false;
            }

            OnSizeChanged(null);

            OnItemChanged();
        }
    }
}
