using System;
using System.Collections.Generic;
using System.Drawing;
using NHSE.Core;

namespace Nhtid.WinForms.SegmentLayouts
{
    class DisplaySegmentLayout : ISegmentLayout
    {
        private readonly DisplaySegmentLayoutOptions options;
        private readonly Item placedItem;
        private readonly Size placedItemSize;
        private readonly List<Item> droppedItems = new List<Item>(2);
        private readonly Size droppedItemSize = new Size(2, 2);
        private readonly Item recipeItem;
        private readonly Size recipeItemSize;
        private ItemEditorInfo itemInfo;

        public DisplaySegmentLayout(ItemConvertor itemConvertor, Item rawItem, DisplaySegmentLayoutOptions options)
        {
            this.options = options;
            itemInfo = itemConvertor.FromItemId(itemConvertor.GetItemId(rawItem));

            ushort displayItemId;
            if (this.itemInfo.Kind == ItemKind.Kind_Fish || this.itemInfo.Kind == ItemKind.Kind_Insect)
            {
                ushort modelId = itemConvertor.GetCreatureModel(itemInfo.ItemId);
                switch (options.CreatureDisplayStyle)
                {
                    case CreatureDisplayStyle.AsModel:
                        displayItemId = modelId;
                        break;
                    case CreatureDisplayStyle.InTank:
                        displayItemId = itemInfo.ItemId;
                        break;
                    default:
                        throw new Exception("Unsupported creature display type");
                }

                if(options.CreatureDropStyle.HasFlag(CreatureDropStyle.Creature))
                    droppedItems.Add(itemConvertor.ApplyPresentation(new Item(itemInfo.ItemId), PresentationType.Dropped));
                if (options.CreatureDropStyle.HasFlag(CreatureDropStyle.Model))
                    droppedItems.Add(itemConvertor.ApplyPresentation(new Item(modelId), PresentationType.Dropped));
            }
            else
            {
                displayItemId = itemInfo.ItemId;
                var item = new Item(itemInfo.ItemId);
                if (!itemInfo.HasVariants)
                    item.Count = (ushort) (itemInfo.MaxStackSize - 1);
                droppedItems.Add(itemConvertor.ApplyPresentation(item, PresentationType.Dropped));
            }

            placedItem = new Item(displayItemId);
            itemConvertor.ApplyPresentation(placedItem, PresentationType.Hung, PresentationType.Placed, PresentationType.Dropped);
            placedItemSize = placedItem.GetSize();

            if (itemInfo.CanRecipe)
            {
                recipeItem = new Item();
                recipeItem.CopyFrom(rawItem);
                itemConvertor.ApplyPresentation(recipeItem, PresentationType.Recipe, PresentationType.Dropped);
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

                int droppedItemTop =
                    placedItemRect.Top + droppedItemSize.Height - (placedItemRect.Height % droppedItemSize.Height);
                int doppedItemsPerColumn =
                    (tileRect.Bottom - droppedItemTop) / droppedItemSize.Height;

                if (droppedItems.Count > 0)
                {
                    for (int x = tileRect.Left + recipeItemSize.Width;
                        x + droppedItemSize.Width <= tileRect.Right;
                        x += droppedItemSize.Width)
                    {
                        for (int y = 0; y < doppedItemsPerColumn; y++)
                        {
                            Rectangle droppedItemRect = new Rectangle(x, droppedItemTop + y * droppedItemSize.Height,
                                droppedItemSize.Width, droppedItemSize.Height);
                            if (droppedItemRect.IntersectsWith(placedItemRect))
                                continue;
                            var droppedItemIndex = (int) (y / ((float) doppedItemsPerColumn / droppedItems.Count));
                            var droppedItem = droppedItems[droppedItemIndex];
                            fragment.Add(droppedItemRect, droppedItem,
                                ctx.MapEditingService.IsOccupied(droppedItemRect));
                        }
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