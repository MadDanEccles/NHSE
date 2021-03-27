using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms.Zebra
{
    public partial class CollectionEditor : Form
    {
        private readonly ItemCollection collection;
        private readonly Dictionary<int, ComboItem> itemLookup;
        private readonly BindingList<InCollectionView> inCollectionViews;
        private List<ComboItem> allItems;

        public CollectionEditor(ItemCollection collection, ItemSource itemSource)
        {
            this.collection = collection;
            InitializeComponent();

            txtCollectionName.Text = collection.Name;
            allItems = itemSource.GetItemDropdownData();
            itemLookup = allItems.ToDictionary(i => i.Value);

            allItems.Sort((item1, item2) => item1.Text.CompareTo(item2.Text));
            lbAll.DataSource = allItems;
            lbAll.ValueMember = nameof(ComboItem.Value);
            lbAll.DisplayMember = nameof(ComboItem.Text);

            inCollectionViews = new BindingList<InCollectionView>();
            lbInCollection.DataSource = inCollectionViews;
            lbInCollection.DisplayMember = nameof(InCollectionView.Text);

            foreach (ushort itemId in collection.ItemIds)
            {
                inCollectionViews.Add(new InCollectionView(itemId, itemLookup[itemId].Text));
            }

            UpdateCollectionCount();
        }

        private void UpdateCollectionCount()
        {
            lblCollectionCount.Text = $"{inCollectionViews.Count} items in collection";
        }


        private class InCollectionView
        {
            public InCollectionView(ushort itemId, string text)
            {
                ItemId = itemId;
                Text = text;
            }

            public ushort ItemId { get; }

            public string Text { get; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.collection.Name = txtCollectionName.Text;
            this.collection.ItemIds.Clear();
            this.collection.ItemIds.AddRange(inCollectionViews.Select(i => i.ItemId));

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        public static bool EditModal(IWin32Window owner, ItemCollection collection, ItemSource itemSource)
        {
            using (CollectionEditor editor = new CollectionEditor(collection, itemSource))
                return editor.ShowDialog(owner) == DialogResult.OK;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSelectedItem();
        }

        private void AddSelectedItem()
        {
            foreach (int index in lbAll.SelectedIndices)
            {
                var item = allItems[index];
                if (inCollectionViews.All(v => v.ItemId != item.Value))
                    inCollectionViews.Add(new InCollectionView((ushort)item.Value, item.Text));
            }

            UpdateCollectionCount();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbInCollection.SelectedItem is InCollectionView view)
            {
                inCollectionViews.Remove(view);
            }

            UpdateCollectionCount();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            var selectedIndex = lbInCollection.SelectedIndex;
            if (selectedIndex > 0)
            {
                InCollectionView view = inCollectionViews[selectedIndex];
                inCollectionViews[selectedIndex] = inCollectionViews[selectedIndex - 1];
                inCollectionViews[selectedIndex - 1] = view;
                lbInCollection.SelectedIndex = selectedIndex - 1;
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            var selectedIndex = lbInCollection.SelectedIndex;
            if (selectedIndex < inCollectionViews.Count - 1)
            {
                InCollectionView view = inCollectionViews[selectedIndex];
                inCollectionViews[selectedIndex] = inCollectionViews[selectedIndex + 1];
                inCollectionViews[selectedIndex + 1] = view;
                lbInCollection.SelectedIndex = selectedIndex + 1;
            }
        }

        private void lbAll_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    AddSelectedItem();
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var sortedItems = inCollectionViews.OrderBy(i => i.Text).ToArray();
            lbInCollection.BeginUpdate();
            inCollectionViews.Clear();
            foreach (var item in sortedItems)
                inCollectionViews.Add(item);
            lbInCollection.EndUpdate();
        }

        private static String WildCardToRegular(String value)
        {
            return "^" + Regex.Escape(value).Replace("\\?", ".").Replace("\\*", ".*") + "$";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lbAll.BeginUpdate();
            lbAll.ClearSelected();
            if (txtSearch.Text.Length >= 2)
            {
                try
                {
                    Regex regex = new Regex(WildCardToRegular(txtSearch.Text), RegexOptions.IgnoreCase);
                    for (var index = 0; index < allItems.Count; index++)
                    {
                        var item = allItems[index];
                        if (regex.Match(item.Text).Success)
                        {
                            lbAll.SelectedIndices.Add(index);
                        }
                    }

                    txtSearch.BackColor = SystemColors.Window;
                }
                catch
                {
                    txtSearch.BackColor = Color.MistyRose;
                }
            }

            lbAll.EndUpdate();
        }

        private void lbAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblItemCount.Text = $"{lbAll.SelectedIndices.Count} items selected";
        }
    }
}
