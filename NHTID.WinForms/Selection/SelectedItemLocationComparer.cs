using System.Collections.Generic;

namespace Nhtid.WinForms.Selection
{
    internal class SelectedItemLocationComparer : IEqualityComparer<SelectedItem>
    {
        public bool Equals(SelectedItem x, SelectedItem y) => x.Bounds.Location == y.Bounds.Location;
        public int GetHashCode(SelectedItem obj) => obj.Bounds.GetHashCode();
    }
}