using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace NHSE.WinForms.Zebra.Controls
{
    public partial class CollectionEditorForm : Form
    {
        private readonly ItemCollectionCatalog catalog;

        private CollectionEditorForm(ItemCollectionCatalog catalog, ItemSource itemSource)
        {
            ItemCollectionManager.Backup();
            this.catalog = catalog;
            InitializeComponent();
            collectionEditor1.ItemSource = itemSource;
            collectionEditor1.Collections = itemCollectionBindingSource;
            catalog.Collections.Sort(new ItemCollectionComparer());
            itemCollectionBindingSource.DataSource = catalog.Collections;
        }

        public static bool EditModal(IWin32Window owner, ItemCollectionCatalog catalog, ItemSource itemSource)
        {
            using (CollectionEditorForm form = new CollectionEditorForm(catalog, itemSource))
                return form.ShowDialog(owner) == DialogResult.OK;
        }

        private void btnDeleteCollection_Click(object sender, System.EventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            collectionEditor1.CommitChanges();
            catalog.Collections.Sort(new ItemCollectionComparer());
            ItemCollectionManager.Save(catalog);
            base.OnClosing(e);
        }

        private void btnAddCollection_Click(object sender, System.EventArgs e)
        {
            int index = itemCollectionBindingSource.Add(new ItemCollection {Name = "New Collection", Id = Guid.NewGuid()});
            cmbCollections.SelectedIndex = index;
        }

        private void cmbCollections_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }

        private void cmbCollections_SelectedValueChanged(object sender, System.EventArgs e)
        {
            collectionEditor1.CommitChanges();
            ItemCollectionManager.Save(catalog);
            var selectedValue = (ItemCollection?) cmbCollections.SelectedValue;
            collectionEditor1.Collection = selectedValue;
            btnDeleteCollection.Enabled = selectedValue != null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    internal class ItemCollectionComparer : IComparer<ItemCollection>
    {
        public int Compare(ItemCollection x, ItemCollection y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
