using System.Drawing;
using NHSE.Core;

namespace Nhtid.WinForms.SegmentLayouts
{
    internal class DiySegmentLayout : ISegmentLayout
    {
        private readonly ItemConvertor itemConvertor;
        private readonly Item item;

        public DiySegmentLayout(ItemConvertor itemConvertor, Item rawItem)
        {
            this.itemConvertor = itemConvertor;
            this.item = new Item();
            item.CopyFrom(rawItem);
            itemConvertor.ApplyPresentation(item, PresentationType.Recipe);
        }

        public void CalculateResult(MapToolContext ctx, Rectangle tileRect, ItemFieldFragment fragment)
        {
            Rectangle itemRect = new Rectangle(tileRect.Location, new Size(2, 2));
            fragment.Add(itemRect, item, ctx.MapEditingService.IsOccupied(itemRect));
        }

        public Size CalculateMinimumTileSize()
        {
            return new Size(2, 2);
        }

        public Size CalculatePreferredTileSize(Size proposedSize)
        {
            return new Size(2, 2);
        }
    }
}