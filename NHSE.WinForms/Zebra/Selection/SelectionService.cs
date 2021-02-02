using System;
using System.Collections.Generic;
using System.Drawing;
using NHSE.Core;

namespace NHSE.WinForms.Zebra.Selection
{
    class SelectionService : ISelectionService
    {
        private readonly MapManager map;
        private readonly HashSet<SelectedItem> selectedItems = new HashSet<SelectedItem>(new SelectedItemLocationComparer());

        public SelectionService(MapManager map)
        {
            this.map = map;
        }

        public bool ClearSelection(MapToolContext ctx)
        {
            bool selectionChanged = selectedItems.Count > 0;
            selectedItems.Clear();
            if (selectionChanged)
                OnSelectionChanged();
            return selectionChanged;
        }

        public bool ModifySelection(Rectangle marqueeBounds, MapToolContext ctx, SelectionAction action)
        {
            bool selectionChanged = false;
            var tileBounds = ctx.ToTiles(marqueeBounds);
            for (int tileX = tileBounds.Left; tileX < tileBounds.Right; tileX++)
            {
                for (int tileY = tileBounds.Top; tileY < tileBounds.Bottom; tileY++)
                {
                    if (TryGetItemFromItemPt(new Point(tileX, tileY), out var item, out var itemTileBounds))
                    {
                        SelectedItem selectedItem = new SelectedItem(item, itemTileBounds);
                        switch (action)
                        {
                            case SelectionAction.Add:
                                selectionChanged |= selectedItems.Add(selectedItem);
                                break;
                            case SelectionAction.Remove:
                                selectionChanged |= selectedItems.Remove(selectedItem);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(action), action, null);
                        }
                    }
                }
            }

            if (selectionChanged)
                OnSelectionChanged();

            return selectionChanged;
        }

        public bool ModifySelection(Point controlPt, MapToolContext ctx, SelectionAction action)
        {
            bool selectionChanged;
            if (TryGetItemFromViewportPt(controlPt, ctx, out var item, out var itemTileBounds))
            {
                SelectedItem selectedItem = new SelectedItem(item, itemTileBounds);
                
                switch (action)
                {
                    case SelectionAction.Add:
                        selectionChanged = selectedItems.Add(selectedItem);
                        break;
                    case SelectionAction.Remove:
                        selectionChanged = selectedItems.Remove(selectedItem);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(action), action, null);
                }
                if (selectionChanged)
                    OnSelectionChanged();
            }
            else
            {
                selectionChanged = false;
            }

            return selectionChanged;
        }

        public event EventHandler? SelectionChanged;

        public IEnumerable<SelectedItem> SelectedItems
            => this.selectedItems;

        private bool TryGetItemFromViewportPt(Point controlPt, MapToolContext ctx, out Item? item, out Rectangle itemTileBounds)
        {
            Point tileLocation = ctx.ToTile(controlPt);
            return TryGetItemFromItemPt(tileLocation, out item, out itemTileBounds);
        }

        private bool TryGetItemFromItemPt(Point tileLocation, out Item? item, out Rectangle itemTileBounds)
        {
            item = map.CurrentLayer.GetTile(tileLocation.X, tileLocation.Y);
            bool result = !item.IsNone;
            if (result)
            {
                int w, h;

                if (item.IsExtension)
                {
                    tileLocation.Offset(-item.ExtensionX, -item.ExtensionY);
                    item = map.CurrentLayer.GetTile(tileLocation.X, tileLocation.Y);
                }

                if (item.IsDropped)
                {
                    w = 2;
                    h = 2;
                }
                else
                {
                    var type = ItemInfo.GetItemSize(item);
                    w = type.GetWidth();
                    h = type.GetHeight();
                }

                itemTileBounds = new Rectangle(tileLocation.X, tileLocation.Y, w, h);
            }
            else
            {
                item = default;
                itemTileBounds = default;
            }

            return result;
        }

        protected virtual void OnSelectionChanged()
        {
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
