using System.Drawing;
using NHSE.Core;

namespace Nhtid.WinForms
{
    public class ItemFieldFragmentEntry
    {
        public ItemFieldFragmentEntry(Rectangle tileRect, Item item, bool isConflicted)
        {
            TileRect = tileRect;
            Item = item;
            IsConflicted = isConflicted;
        }

        public Rectangle TileRect { get; }

        public Item Item { get; }

        public bool IsConflicted { get; }
    }
}