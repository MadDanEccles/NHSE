using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Nhtid.WinForms.Renderers;
using Nhtid.WinForms.Selection;

namespace Nhtid.WinForms.Tools.Actions
{
    class MoveItemsDragAction : DragMouseActionBase
    {
        private readonly SelectionRenderer selectionRenderer;
        private readonly ISelectionService selectionService;
        private readonly IHistoryService historyService;

        public MoveItemsDragAction(SelectionRenderer selectionRenderer, ISelectionService selectionService,
            IHistoryService historyService)
        {
            this.selectionRenderer = selectionRenderer;
            this.selectionService = selectionService;
            this.historyService = historyService;
        }

        protected override void OnDragEnd(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx)
        {
            bool createCopy = modifierKeys.HasFlag(Keys.Control);
            Point tileDelta = GetTileDelta(DragStartLocation, ctx);
            if (IsValidDropPos(tileDelta, ctx.MapEditingService, createCopy))
            {
                using (var trans = historyService.BeginTransaction($"Move {selectionService.SelectedItems.Count()} items"))
                {
                    if (!createCopy)
                    {
                        // The drop location is valid; delete all tiles to be moved then recreate them in their
                        // new location.
                        foreach (var selectedItem in selectionService.SelectedItems)
                            ctx.MapEditingService.DeleteTile(selectedItem.Bounds.Location, trans);
                    }

                    foreach (var selectedItem in selectionService.SelectedItems)
                    {
                        Point newLocation = selectedItem.Bounds.Location;
                        newLocation.Offset(tileDelta);
                        ctx.MapEditingService.AddItem(selectedItem.Item, newLocation, trans);
                    }
                }

                selectionService.ApplyTileDelta(tileDelta);
            }
            else
            {
                MessageBox.Show(ctx.Viewport, "This space is already occupied", "Unable to Move Items", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            selectionRenderer.TileOffset = Point.Empty;
        }

        protected override void OnDragMove(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx)
        {
            Point tileOffset = GetTileDelta(DragStartLocation, ctx);
            selectionRenderer.TileOffset = tileOffset;
        }

        private Point GetTileDelta(Point location, MapToolContext ctx)
        {
            return new Point(
                (location.X - DragStartLocation.X) / ctx.TileSize,
                (location.Y - DragStartLocation.Y) / ctx.TileSize);
        }

        private bool IsValidDropPos(Point tileDelta, IMapEditingService mapEditingService, bool createCopy)
        {
            // We now need to verify that, given the specified tile delta, the selected items will
            // not drop on any item or building that is not itself currently selected.

            foreach (var selectedItem in selectionService.SelectedItems)
            {
                for (int x = selectedItem.Bounds.X + tileDelta.X; x < selectedItem.Bounds.Right + tileDelta.X; x++)
                {
                    for (int y = selectedItem.Bounds.Y + tileDelta.Y; y < selectedItem.Bounds.Bottom + tileDelta.Y; y++)
                    {
                        // Deal with the case where this tile will drop on an item that is to be
                        // moved...
                        if (!createCopy && selectionService.SelectedItems.Any(i => i.Bounds.Contains(x, y)))
                            continue;

                        if (mapEditingService.IsOccupied(new Point(x, y)))
                            return false;
                    }
                }
            }

            return true;
        }
    }
}