using System.Drawing;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms.Zebra.Tools
{
    class TemplateTool : FillRectToolBase
    {
        private Item placedItem;
        private Size placedItemSize;
        private Item droppedItem;
        private Size droppedItemSize;

        private readonly IItemSelector options;

        public TemplateTool(IHistoryService historyService, IItemSelector options) : base(historyService)
        {
            this.options = options;
        }

        protected override bool OnStartDrag(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {

            Item rawItem = options.GetItem();

            if (!rawItem.IsRoot)
            {
                MessageBox.Show(ctx.Viewport, "Please select a valid item before drawing", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            placedItem = new Item();
            placedItem.CopyFrom(rawItem);
            ItemConvertor.ApplyPresentation(placedItem, PresentationType.Placed);
            droppedItem = new Item();
            droppedItem.CopyFrom(rawItem);
            ItemConvertor.ApplyPresentation(droppedItem, PresentationType.Dropped);
            placedItemSize = placedItem.GetSize();
            droppedItemSize = droppedItem.GetSize();
            return true;
        }

        protected override void CalculateResult(MapToolContext ctx, Rectangle marqueeBounds, out ItemFieldFragment fragment, out string hint)
        {
            Rectangle tileRect = ctx.ToTiles(marqueeBounds);
            fragment = new ItemFieldFragment();
            int droppedItemCount = 0;
            if (tileRect.Size.Encompasses(placedItemSize))
            {
                Rectangle placedItemRect = new Rectangle(tileRect.Location, placedItemSize);
                fragment.Add(placedItemRect, placedItem, ctx.MapEditingService.IsOccupied(placedItemRect));

                for (int x = tileRect.Left; x < tileRect.Right; x += droppedItemSize.Width)
                {
                    for (int y = tileRect.Top; y < tileRect.Bottom; y += droppedItemSize.Height)
                    {
                        Rectangle droppedItemRect = new Rectangle(x, y, droppedItemSize.Width, droppedItemSize.Height);
                        if (droppedItemRect.IntersectsWith(placedItemRect))
                            continue;
                        fragment.Add(droppedItemRect, droppedItem, ctx.MapEditingService.IsOccupied(droppedItemRect));
                        droppedItemCount++;
                    }
                }

            }
            hint = droppedItemCount > 0 ? $"{droppedItemCount} Items" : "-";
        }
    }
}