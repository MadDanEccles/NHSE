using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.WinForms.Zebra.SegmentLayouts;

namespace NHSE.WinForms.Zebra.Controls
{
    public partial class MultiItemSelector : UserControl
    {
        private ItemCollectionCatalog itemCollectionManager;
        private ItemSource itemSource;
        private TreeNode collectionsNode;
        private TreeNode itemsNode;
        private ItemCollectionCatalog catalog;

        public MultiItemSelector()
        {
            InitializeComponent();
        }

        public void Initialise(ItemSource itemSource, ItemCollectionCatalog catalog, LayoutManager layoutManager)
        {
            this.catalog = catalog;
            this.itemSource = itemSource;
            this.itemCollectionManager = catalog;

            this.treeView1.Nodes.Clear();

            itemsNode = this.treeView1.Nodes.Add("folder:items", "Items");
            foreach (var item in itemSource.GetItemDropdownData())
            {
                itemsNode.Nodes.Add($"item:{item.Value}", item.Text).Tag = (ushort)item.Value;
            }

            this.collectionsNode = this.treeView1.Nodes.Add("folder:collections", "Collections");
            collectionsNode.HideCheckBox();
            RefreshCollections();

            itemsNode.HideCheckBox();
            itemsNode.HideCheckBox();
            collectionsNode.HideCheckBox();

            segmentLayoutEditor.Initialise(layoutManager);
        }

        private Dictionary<Guid, ItemCollection> collectionLookup = new Dictionary<Guid, ItemCollection>();

        public void RefreshCollections()
        {
            this.collectionsNode.Nodes.Clear();
            collectionLookup.Clear();

            foreach (var collection in catalog.Collections)
                collectionLookup.Add(collection.Id, collection);

            foreach (var collection in catalog.Collections.Where(i => i.IsTopLevel).OrderBy(i => i.Name))
                this.collectionsNode.Nodes.Add(collection.Name).Tag = collection;
        }
        
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool isCollectionSelected = e.Node?.Tag is ItemCollection;
        }


        public IEnumerable<Item> ResolveItems()
        {
            List<ushort> itemIds = new List<ushort>();
            HashSet<ushort> visitedItemIds = new HashSet<ushort>();
            HashSet<Guid> visitedCollectionIds = new HashSet<Guid>();
            
            void AddCollection(ItemCollection collection)
            {
                if (visitedCollectionIds.Contains(collection.Id))
                    return;

                foreach (var member in collection.Members)
                {
                    switch (member.Type)
                    {
                        case CollectionMemberType.Collection:
                            if (collectionLookup.TryGetValue(member.CollectionId, out var childCollection))
                                AddCollection(childCollection);
                            break;
                        case CollectionMemberType.Item:
                            AddItem(member.ItemId);
                            break;
                    }
                }
            }

            void AddItem(ushort itemId)
            {
                if (visitedItemIds.Contains(itemId))
                    return;
                itemIds.Add(itemId);
                visitedItemIds.Add(itemId);
            }


            foreach (TreeNode itemNode in itemsNode.Nodes)
            {
                if (itemNode.Checked)
                {
                    var itemId = (ushort)itemNode.Tag;
                    AddItem(itemId);
                }
            }

            foreach (TreeNode collectionNode in collectionsNode.Nodes)
            {
                if (collectionNode.Checked)
                {
                    var collection = (ItemCollection)collectionNode.Tag;
                    AddCollection(collection);
                }
            }


            foreach (ushort itemId in itemIds)
            {
                ItemEditorInfo info = ItemEditorInfo.FromItemId(itemId);

                bool includeVariants =
                    info.HasVariants &&
                    ((chkVaryDiy.Checked && info.CanRecipe) ||
                     (chkVaryOther.Checked && !info.CanRecipe));

                if (includeVariants)
                {
                    if (info.BodyVariants?.Length > 0)
                    {
                        foreach (var bodyVariant in info.BodyVariants)
                        {
                            if (info.FabricVariants?.Length > 0)
                            {

                                Item item = new Item(itemId);
                                item.Count = bodyVariant.Value;
                                item.UseCount = info.FabricVariants[0].Value;
                                yield return item;
                            }
                            else
                            {
                                Item item = new Item(itemId);
                                item.Count = bodyVariant.Value;
                                item.UseCount = 0;
                                yield return item;

                            }
                        }
                    }
                    else if (info.FabricVariants?.Length > 0)
                    {
                        foreach (var fabricVariant in info.FabricVariants)
                        {

                            Item item = new Item(itemId);
                            item.Count = 0;
                            item.UseCount = fabricVariant.Value;
                            yield return item;
                        }
                    }
                    else
                    {
                        Item item = new Item(itemId);
                        item.Count = 0;
                        item.UseCount = 0;
                        yield return item;
                    }
                }
                else
                {
                    Item item = new Item(itemId);
                    item.Count = (ushort)(info.MaxStackSize - 1);
                    yield return item;
                }
            }
        }

        public ISegmentLayoutFactory GetFactory()
        {
            return segmentLayoutEditor.Factory;
        }
    }
}