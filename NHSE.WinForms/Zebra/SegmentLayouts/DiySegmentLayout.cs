using System.Drawing;
using NHSE.Core;

namespace NHSE.WinForms.Zebra.SegmentLayouts
{
    internal class DiySegmentLayout : ISegmentLayout
    {
        private readonly Item item;

        public DiySegmentLayout(Item rawItem)
        {
            this.item = new Item();
            item.CopyFrom(rawItem);
            ItemConvertor.Instance.ApplyPresentation(item, PresentationType.Recipe);
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