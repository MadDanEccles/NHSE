using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NHSE.Core;

namespace Nhtid.WinForms.Controls
{
    public partial class CollectionEditor : UserControl
    {
        private ItemCollection? collection;
        private Dictionary<int, ComboItem> itemLookup;
        private readonly BindingList<IInCollectionView> inCollectionViews = new BindingList<IInCollectionView>();
        private ComboItem[] allItems;
        private ItemSource itemSource;
        private BindingSource catalog;

        public CollectionEditor()
        {
            InitializeComponent();

            lbAll.ValueMember = nameof(ComboItem.Value);
            lbAll.DisplayMember = nameof(ComboItem.Text);

            lbInCollection.DataSource = inCollectionViews;
            lbInCollection.DisplayMember = nameof(IInCollectionView.Text);

        }

        public void AutoWire(ItemSource ItemSource, ItemConvertor itemConvertor)
        {
            this.itemSource = ItemSource;
            allItems = itemSource.GetItemDropdownData();
            itemLookup = allItems.ToDictionary(i => i.Value);
            lbAll.DataSource = allItems;

            foreach (ItemKind itemKind in Enum.GetValues(typeof(ItemKind)))
            {
                var k = itemKind;
                itemKindViewBindingSource.Add(new ItemKindView($"Kind: {itemKind}", i => ItemInfo.GetItemKind(i) == k));
            }

            itemKindViewBindingSource.Add(new ItemKindView($"Has DIY", i => itemConvertor.FromItemId(i).CanRecipe));
        }

        public ItemCollection? Collection
        {
            get => collection;
            set
            {
                if (collection != value)
                {
                    collection = value;
                    inCollectionViews.Clear();

                    if (collection == null)
                    {
                        this.Enabled = false;
                        txtCollectionName.Text = string.Empty;
                    }
                    else
                    {
                        this.Enabled = true;
                        txtCollectionName.Text = collection.Name;
                        chkTopLevel.Checked = this.collection.IsTopLevel;
                        foreach (var member in collection.Members)
                        {
                            switch (member.Type)
                            {
                                case CollectionMemberType.Item:
                                    if (itemLookup.TryGetValue(member.ItemId, out var item))
                                        inCollectionViews.Add(new InCollectionItemView(member.ItemId, item.Text));
                                    break;
                                case CollectionMemberType.Collection:
                                    inCollectionViews.Add(new InCollectionCollectionView(member.CollectionId, Collections.Cast<ItemCollection>().Single(i => i.Id == member.CollectionId).Name));
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        }
                    }
                }

                UpdateCollectionCount();
            }
        }

        public BindingSource Collections
        {
            get => catalog;
            set
            {
                if (catalog != value)
                {
                    catalog = value;
                    this.itemCollectionBindingSource.DataSource = catalog;
                }
            }
        }

        private void UpdateCollectionCount()
        {
            lblCollectionCount.Text = $"{inCollectionViews.Count} items in collection";
        }

        private class InCollectionCollectionView : IInCollectionView
        {
            public InCollectionCollectionView(Guid collectionId, string text)
            {
                CollectionId = collectionId;
                Text = text;
            }

            public Guid CollectionId { get; }

            public string Text { get; }
        }

        private class InCollectionItemView : IInCollectionView
        {
            public InCollectionItemView(ushort itemId, string text)
            {
                ItemId = itemId;
                Text = text;
            }

            public ushort ItemId { get; }

            public string Text { get; }
        }

        public void CommitChanges()
        {
            if (this.collection != null)
            {
                this.collection.Name = txtCollectionName.Text;
                this.collection.IsTopLevel = chkTopLevel.Checked;
                this.collection.Members.Clear();
                foreach (var member in inCollectionViews)
                {
                    this.collection.Members.Add(
                        member switch
                        {
                            InCollectionCollectionView collView => new CollectionMember
                            { Type = CollectionMemberType.Collection, CollectionId = collView.CollectionId },
                            InCollectionItemView itemView => new CollectionMember
                            { Type = CollectionMemberType.Item, ItemId = itemView.ItemId },
                            _ => throw new Exception("Unsupported member type")
                        });
                }
            }
        }

        /*private void btnOk_Click(object sender, EventArgs e)
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

        */

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSelectedItem(false);
        }

        private void AddSelectedItem(bool selectAll)
        {
            inCollectionViews.RaiseListChangedEvents = false;

            if (tabControl1.SelectedTab == itemsTab)
            {
                foreach (ComboItem item in selectAll ? allItems : (IEnumerable)lbAll.SelectedItems)
                {
                    inCollectionViews.Add(new InCollectionItemView((ushort)item.Value, item.Text));
                }
            }
            else if (tabControl1.SelectedTab == collectionsTab)
            {
                foreach (ItemCollection item in selectAll ? itemCollectionBindingSource : (IEnumerable)lbCollections.SelectedItems)
                {
                    inCollectionViews.Add(new InCollectionCollectionView(item.Id, item.Name));
                }
            }
            else
            {
                foreach (ItemKindView itemKindView in selectAll ? itemKindViewBindingSource : (IEnumerable)lbKinds.SelectedItems)
                {
                    foreach (var item in allItems)
                    {
                        if (itemKindView.IsIncluded((ushort)item.Value))
                        {
                            inCollectionViews.Add(new InCollectionItemView((ushort)item.Value, item.Text));
                        }
                    }
                }
            }

            inCollectionViews.RaiseListChangedEvents = true;
            inCollectionViews.ResetBindings();
            lbInCollection.SelectedIndex = inCollectionViews.Count - 1;

            UpdateCollectionCount();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            inCollectionViews.RaiseListChangedEvents = false;
            foreach (IInCollectionView item in lbInCollection.SelectedItems)
            {
                inCollectionViews.Remove(item);
            }
            inCollectionViews.RaiseListChangedEvents = true;
            inCollectionViews.ResetBindings();

            UpdateCollectionCount();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            lbInCollection.BeginUpdate();
            var selectedIndex = lbInCollection.SelectedIndex;
            if (selectedIndex > 0)
            {
                IInCollectionView view = inCollectionViews[selectedIndex];
                inCollectionViews[selectedIndex] = inCollectionViews[selectedIndex - 1];
                inCollectionViews[selectedIndex - 1] = view;
                lbInCollection.SelectedIndex = selectedIndex - 1;
            }
            lbInCollection.EndUpdate();
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            lbInCollection.BeginUpdate();
            var selectedIndex = lbInCollection.SelectedIndex;
            if (selectedIndex < inCollectionViews.Count - 1)
            {
                IInCollectionView view = inCollectionViews[selectedIndex];
                inCollectionViews[selectedIndex] = inCollectionViews[selectedIndex + 1];
                inCollectionViews[selectedIndex + 1] = view;
                lbInCollection.SelectedIndex = selectedIndex + 1;
            }
            lbInCollection.EndUpdate();
        }

        private void lbAll_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    AddSelectedItem(false);
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
            searchTimer.Stop();
            searchTimer.Start();

        }

        private void lbAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblItemCount.Text = $"{lbAll.SelectedIndices.Count} items selected";
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            lbAll.BeginUpdate();
            lbAll.ClearSelected();
            searchTimer.Stop();

            string searchText = txtSearch.Text;
            if (string.IsNullOrWhiteSpace(searchText))
            {
                lbAll.DataSource = allItems;
            }
            else
            {
                var lbAllDataSource = allItems
                    .Where(i => i.Text.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToArray();
                lbAll.DataSource = lbAllDataSource;
                if (lbAllDataSource.Length < 500)
                    for (int i = 0; i < lbAllDataSource.Length; i++)
                        lbAll.SetSelected(i, true);
            }

            lbAll.EndUpdate();
        }

        private void lbInCollection_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0 && e.Index < inCollectionViews.Count)
            {
                var item = inCollectionViews[e.Index];

                using var backBrush = new SolidBrush(e.BackColor);
                e.Graphics.FillRectangle(backBrush, e.Bounds);

                if (item is InCollectionItemView itemView)
                {
                    Color itemColor = ItemColor.GetItemColor(itemView.ItemId);
                    using var itemBrush = new SolidBrush(itemColor);
                    Rectangle swatchRect = new Rectangle(e.Bounds.Right - 18, e.Bounds.Top + 2, 14, 14);
                    e.Graphics.FillRectangle(itemBrush, swatchRect);
                    e.Graphics.DrawRectangle(Pens.Black, swatchRect);
                }

                Image image = item is InCollectionItemView ? ZebraResources.leaf_16 : ZebraResources.folder_16;

                e.Graphics.DrawImageUnscaled(image, e.Bounds.Location);
                using var foreBrush = new SolidBrush(e.ForeColor);
                e.Graphics.DrawString(item.Text, e.Font, foreBrush, e.Bounds.Left + 18, e.Bounds.Top);
            }
        }

        private void lbInCollection_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            var measureString = Size.Ceiling(e.Graphics.MeasureString(inCollectionViews[e.Index].Text, Font));
            e.ItemHeight = Math.Max(16, measureString.Height);
            e.ItemWidth = 18 + measureString.Width;
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you aure you want to clear this collection?", "Clear Collection",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                inCollectionViews.Clear();
            }
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            AddSelectedItem(true);
        }
    }
}
