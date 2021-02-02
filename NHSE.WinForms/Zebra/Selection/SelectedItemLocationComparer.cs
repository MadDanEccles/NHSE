using System.Collections.Generic;

namespace NHSE.WinForms.Zebra.Selection
{
    internal class SelectedItemLocationComparer : IEqualityComparer<SelectedItem>
    {
        public bool Equals(SelectedItem x, SelectedItem y) => x.Bounds.Location == y.Bounds.Location;
        public int GetHashCode(SelectedItem obj) => obj.Bounds.GetHashCode();
    }
}