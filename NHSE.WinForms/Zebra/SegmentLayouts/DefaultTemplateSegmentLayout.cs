using System;
using System.Drawing;
using NHSE.Core;
using NHSE.WinForms.Zebra.Tools;

namespace NHSE.WinForms.Zebra.SegmentLayouts
{
    class DefaultTemplateSegmentLayout : ITemplateSegmentLayout
    {
        private readonly Item placedItem;
        private readonly Size placedItemSize;
        private readonly Item droppedItem;
        private readonly Size droppedItemSize;
        private readonly Item recipeItem;
        private readonly Size recipeItemSize;
        private ItemEditorInfo itemInfo;

        public DefaultTemplateSegmentLayout(Item rawItem)
        {
            itemInfo = ItemEditorInfo.FromItemId(ItemConvertor.Instance.GetItemId(rawItem));

            placedItem = new Item();
            placedItem.CopyFrom(rawItem);
            ItemConvertor.Instance.ApplyPresentation(placedItem, PresentationType.Hung, PresentationType.Placed, PresentationType.Dropped);
            placedItemSize = placedItem.GetSize();

            droppedItem = new Item();
            droppedItem.CopyFrom(rawItem);
            ItemConvertor.Instance.ApplyPresentation(droppedItem, PresentationType.Dropped);
            droppedItemSize = droppedItem.GetSize();

            if (itemInfo.CanRecipe)
            {
                recipeItem = new Item();
                recipeItem.CopyFrom(rawItem);
                ItemConvertor.Instance.ApplyPresentation(recipeItem, PresentationType.Recipe, PresentationType.Dropped);
                recipeItemSize = recipeItem.GetSize();
            }
            else
            {
                recipeItem = null;
                recipeItemSize = Size.Empty;
            }
        }

        public void CalculateResult(MapToolContext ctx, Rectangle tileRect, ItemFieldFragment fragment)
        {
            if (tileRect.Size.Encompasses(placedItemSize))
            {
                Rectangle placedItemRect = new Rectangle(tileRect.Location, placedItemSize);
                fragment.Add(placedItemRect, placedItem, ctx.MapEditingService.IsOccupied(placedItemRect));

                if (recipeItem != null)
                {
                    for (int y = tileRect.Top; y + recipeItemSize.Height <= tileRect.Bottom; y += recipeItemSize.Height)
                    {
                        Rectangle recipeItemRect =
                            new Rectangle(tileRect.Left, y, recipeItemSize.Width, recipeItemSize.Height);
                        if (recipeItemRect.IntersectsWith(placedItemRect))
                            continue;
                        fragment.Add(recipeItemRect, recipeItem, ctx.MapEditingService.IsOccupied(recipeItemRect));
                    }
                }


                for (int x = tileRect.Left + recipeItemSize.Width; x + droppedItemSize.Width <= tileRect.Right; x += droppedItemSize.Width)
                {
                    for (int y = tileRect.Top; y + droppedItemSize.Height <= tileRect.Bottom; y += droppedItemSize.Height)
                    {
                        Rectangle droppedItemRect = new Rectangle(x, y, droppedItemSize.Width, droppedItemSize.Height);
                        if (droppedItemRect.IntersectsWith(placedItemRect))
                            continue;
                        fragment.Add(droppedItemRect, droppedItem, ctx.MapEditingService.IsOccupied(droppedItemRect));
                    }
                }
            }
        }

        public Size CalculateMinimumTileSize()
        {
            return new Size(
                Math.Max(placedItemSize.Width, droppedItemSize.Width + recipeItemSize.Width),
                placedItemSize.Height + Math.Max(droppedItemSize.Height, recipeItemSize.Height));
        }

        public Size CalculatePreferredTileSize(Size proposedSize)
        {
            return proposedSize;
        }
    }
}