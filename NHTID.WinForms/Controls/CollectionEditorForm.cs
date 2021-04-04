using System;
using System.ComponentModel;
using System.Windows.Forms;
using Autofac;

namespace Nhtid.WinForms.Controls
{
    public partial class CollectionEditorForm : Form
    {
        private IItemCollectionStore store;

        private CollectionEditorForm(
            IItemCollectionStore store,
            ItemSource itemSource,
            ILifetimeScope scope)
        {

            store.Backup();
            this.store = store;
            InitializeComponent();
            scope.AutoWire(Controls);
            collectionEditor1.Collections = itemCollectionBindingSource;
            store.Root.Collections.Sort(new ItemCollectionComparer());
            itemCollectionBindingSource.DataSource = store.Root.Collections;

        }

        public static bool EditModal(IWin32Window owner, IItemCollectionStore store, ItemSource itemSource, ILifetimeScope scope)
        {
            using (CollectionEditorForm form = new CollectionEditorForm(store, itemSource, scope))
                return form.ShowDialog(owner) == DialogResult.OK;
        }

        private void btnDeleteCollection_Click(object sender, System.EventArgs e)
        {
            var selectedValue = (ItemCollection?)cmbCollections.SelectedValue;
            if (selectedValue != null)
                itemCollectionBindingSource.Remove(selectedValue);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            collectionEditor1.CommitChanges();
            store.Root.Collections.Sort(new ItemCollectionComparer());
            store.Save();
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
            store.Save();
            var selectedValue = (ItemCollection?) cmbCollections.SelectedValue;
            collectionEditor1.Collection = selectedValue;
            btnDeleteCollection.Enabled = selectedValue != null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
