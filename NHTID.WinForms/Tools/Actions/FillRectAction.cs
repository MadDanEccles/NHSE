using System.Drawing;
using NHSE.Core;

namespace Nhtid.WinForms.Tools.Actions
{
    internal class FillRectAction : FillRectActionBase
    {
        private Item item;
        private Size itemSize;

        public FillRectAction(IHistoryService historyService, Item item) : base(historyService)
        {
            this.item = item;
            this.itemSize = item.GetSize();
        }

        protected override void CalculateResult(MapToolContext ctx, Rectangle marqueeBounds, out ItemFieldFragment fragment, out string hint)
        {
            fragment = new ItemFieldFragment();
            var tileRect = ctx.ToTiles(marqueeBounds);
            for (int x = tileRect.Left; x <= tileRect.Right - itemSize.Width; x += itemSize.Width)
            {
                for (int y = tileRect.Top; y <= tileRect.Bottom - itemSize.Height; y += itemSize.Height)
                {
                    Rectangle itemTileRect = new Rectangle(x, y, itemSize.Width, itemSize.Height);
                    fragment.Add(itemTileRect, item, ctx.MapEditingService.IsOccupied(itemTileRect));
                }
            }

            int itemsX = tileRect.Width / itemSize.Width;
            int itemsY = tileRect.Height / itemSize.Height;
            hint = $"{itemsX} × {itemsY}";
        }
    }
}