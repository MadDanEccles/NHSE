using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using NHSE.Core;

namespace NHSE.WinForms.Zebra
{
    public partial class MultiItemSelector : UserControl
    {
        private ItemCollectionManager itemCollectionManager;
        private ItemSource itemSource;
        private TreeNode collectionsNode;
        private TreeNode itemsNode;

        public MultiItemSelector()
        {
            InitializeComponent();
        }

        public void Initialise(ItemSource itemSource, ItemCollectionManager itemCollectionManager)
        {
            this.itemSource = itemSource;
            this.itemCollectionManager = itemCollectionManager;

            this.treeView1.Nodes.Clear();

            itemsNode = this.treeView1.Nodes.Add("folder:items", "Items");
            foreach (var item in itemSource.GetItemDropdownData())
            {
                itemsNode.Nodes.Add($"item:{item.Value}", item.Text).Tag = (ushort)item.Value;
            }

            this.collectionsNode = this.treeView1.Nodes.Add("folder:collections", "Collections");
            collectionsNode.HideCheckBox();
            foreach (var collection in itemCollectionManager)
            {
                AddCollectionNode(collection);
            }

            itemsNode.HideCheckBox();
            itemsNode.HideCheckBox();
            collectionsNode.HideCheckBox();
        }

        private object AddCollectionNode(ItemCollection collection)
        {
            return this.collectionsNode.Nodes.Add(collection.Name).Tag = collection;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool isCollectionSelected = e.Node?.Tag is ItemCollection;
            btnDeleteCollection.Enabled = isCollectionSelected;
            btnEditCollection.Enabled = isCollectionSelected;
        }

        private void btnAddCollection_Click(object sender, EventArgs e)
        {
            ItemCollection collection = new ItemCollection {Name = "New Collection"};
            if (CollectionEditor.EditModal(this, collection, itemSource))
            {
                this.itemCollectionManager.Add(collection);
                AddCollectionNode(collection);
                itemCollectionManager.Save();
            }
        }

        private void btnEditCollection_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode?.Tag is ItemCollection collection)
            {
                if (CollectionEditor.EditModal(this, collection, itemSource))
                {
                    treeView1.SelectedNode.Text = collection.Name;
                    itemCollectionManager.Save();
                }
            }
        }

        private void btnDeleteCollection_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode?.Tag is ItemCollection collection)
            {
                if (MessageBox.Show(this, $"Are you sure you wish to delete the collection '{collection.Name}'?",
                        "Delete Collection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2)
                    == DialogResult.Yes)
                {
                    itemCollectionManager.Remove(collection);
                    itemCollectionManager.Save();
                    treeView1.SelectedNode.Remove();
                }
            }
        }

        public IEnumerable<Item> ResolveItems()
        {
            List<ushort> itemIds = new List<ushort>();

            foreach (TreeNode collectionNode in collectionsNode.Nodes)
            {
                if (collectionNode.Checked)
                {
                    foreach (ushort itemId in ((ItemCollection) collectionNode.Tag).ItemIds)
                    {
                        itemIds.Add(itemId);
                    }
                }
            }

            foreach (TreeNode itemNode in itemsNode.Nodes)
            {
                if (itemNode.Checked)
                {
                    var itemId = (ushort) itemNode.Tag;
                    itemIds.Add(itemId);
                }
            }

            foreach (ushort itemId in itemIds.Distinct())
            {
                ItemEditorInfo info = ItemEditorInfo.FromItemId(itemId);

                bool includeVariants =
                    info.HasVariants &&
                    ((chkVaryDiy.Checked && info.CanRecipe) ||
                     (chkVaryOther.Checked && !info.CanRecipe));

                if (includeVariants)
                {
                    foreach (var bodyVariant in info.BodyVariants)
                    {
                        if (info.FabricVariants != null && info.FabricVariants.Length > 0)
                        {
                            foreach (var fabricVariant in info.FabricVariants)
                            {
                                Item item = new Item(itemId);
                                item.Count = bodyVariant.Value;
                                item.UseCount = fabricVariant.Value;
                                yield return item;
                            }
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
                else
                {
                    Item item = new Item(itemId);
                    item.Count = (ushort)(info.MaxStackSize - 1);
                    yield return item;
                }
            }
        }
    }

    public class ItemCollectionManager : IEnumerable<ItemCollection>
    {
        public string FilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "collections.json");

        public void Save()
        {
            var serializer = new JsonSerializer();
            using var fileStream = File.Create(FilePath);
            using var sw = new StreamWriter(fileStream);
            using var writer = new JsonTextWriter(sw);
            serializer.Serialize(writer, catalog);
        }

        public void Load()
        {
            if (File.Exists(FilePath))
            {
                var serializer = new JsonSerializer();
                using var fileStream = File.OpenRead(FilePath);
                using var sr = new StreamReader(fileStream);
                using var reader = new JsonTextReader(sr);
                this.catalog = serializer.Deserialize<ItemCollectionCatalog>(reader);
            }
            else
            {
                this.catalog = new ItemCollectionCatalog();
            }
        }

        private ItemCollectionCatalog catalog = new ItemCollectionCatalog();


        public IEnumerator<ItemCollection> GetEnumerator() => this.catalog.Collections.AsReadOnly().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.catalog.Collections.AsReadOnly().GetEnumerator();

        public void Add(ItemCollection collection)
        {
            if (this.catalog.Collections.Contains(collection))
                throw new InvalidOperationException("Collection already exists in this catalog");
            this.catalog.Collections.Add(collection);
        }

        public void Remove(ItemCollection collection)
        {
            this.catalog.Collections.Remove(collection);
        }

        public void Backup()
        {
            if (File.Exists(FilePath))
            {
                string backupFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"collections_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.json");
                File.Copy(FilePath, backupFilePath);
            }
        }
    }
}