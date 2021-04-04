using System.Drawing;
using NHSE.Core;

namespace Nhtid.WinForms.Selection
{
    public class SelectedItem
    {
        public SelectedItem(Item item, Rectangle bounds)
        {
            Item = item;
            Bounds = bounds;
        }

        public Item Item { get; }

        public Rectangle Bounds { get; }
    }
}