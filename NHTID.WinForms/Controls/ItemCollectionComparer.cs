using System.Collections.Generic;

namespace Nhtid.WinForms.Controls
{
    internal class ItemCollectionComparer : IComparer<ItemCollection>
    {
        public int Compare(ItemCollection x, ItemCollection y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}