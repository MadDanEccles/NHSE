using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHSE.Core;

namespace NHSE.WinForms.Zebra
{
    class ItemFieldFragment : IEnumerable<ItemFieldFragmentEntry>
    {
        private readonly List<ItemFieldFragmentEntry> entries = new List<ItemFieldFragmentEntry>();

        public ItemFieldFragment(IEnumerable<ItemFieldFragmentEntry> entries)
        {
            this.entries.AddRange(entries);
        }

        public ItemFieldFragment()
        {
        }

        public void Add(Rectangle tileRect, Item item, bool isConflicted)
        {
            this.entries.Add(new ItemFieldFragmentEntry(tileRect, item, isConflicted));
        }

        public void Add(Point tilePt, Item item, bool isConflicted)
        {
            var size = item.GetSize();
            Add(new Rectangle(tilePt, size), item, isConflicted);
        }

        public IEnumerator<ItemFieldFragmentEntry> GetEnumerator() => this.entries.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.entries.GetEnumerator();
    }

    class ItemFieldFragmentEntry
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
