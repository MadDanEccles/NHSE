using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NHSE.WinForms.Zebra.Renderers;
using NHSE.WinForms.Zebra.Selection;

namespace NHSE.WinForms.Zebra.Tools
{
    class MoveTool : IMapTool
    {
        private readonly ISelectionService selectionService;
        private readonly SelectionRenderer selectionRenderer;
        private readonly IHistoryService historyService;
        private bool isDragging;
        private Point dragStart;

        public MoveTool(ISelectionService selectionService, SelectionRenderer selectionRenderer,
            IHistoryService historyService)
        {
            this.selectionService = selectionService;
            this.selectionRenderer = selectionRenderer;
            this.historyService = historyService;
        }

        public void OnMouseDown(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point tilePt = ctx.ToTile(e.Location);

                // If the cursor is not on a selected tile then clear the selection and select
                // the tile directly under the cursor.
                if (!selectionService.SelectedItems.Any(i => i.Bounds.Contains(tilePt)))
                {
                    selectionService.ClearSelection();
                    selectionService.ModifySelection(e.Location, ctx, SelectionAction.Add);
                }

                if (selectionService.SelectedItems.Any())
                {
                    this.isDragging = true;
                    this.dragStart = e.Location;
                }
            }
        }

        public void OnMouseMove(MouseEventArgs e, MapToolContext ctx)
        {
            if (isDragging)
            {
                Point tileOffset = GetTileDelta(e, ctx);
                selectionRenderer.TileOffset = tileOffset;
            }
        }

        private Point GetTileDelta(MouseEventArgs e, MapToolContext ctx)
        {
            return new Point(
                (e.Location.X - dragStart.X) / ctx.TileSize,
                (e.Location.Y - dragStart.Y) / ctx.TileSize);
        }

        private bool IsValidDropPos(Point tileDelta, IMapEditingService mapEditingService)
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
                        if (selectionService.SelectedItems.Any(i => i.Bounds.Contains(x, y)))
                            continue;

                        if (mapEditingService.IsOccupied(new Point(x, y)))
                            return false;
                    }
                }
            }

            return true;
        }

        public void OnMouseUp(MouseEventArgs e, MapToolContext ctx)
        {
            if (isDragging && e.Button == MouseButtons.Left)
            {
                Point tileDelta = GetTileDelta(e, ctx);
                if (IsValidDropPos(tileDelta, ctx.MapEditingService))
                {
                    using (var trans = historyService.BeginTransaction($"Move {selectionService.SelectedItems.Count()} items"))
                    {
                        // The drop location is valid; delete all tiles to be moved then recreate them in their
                        // new location.
                        foreach (var selectedItem in selectionService.SelectedItems)
                            ctx.MapEditingService.DeleteTile(selectedItem.Bounds.Location, trans);

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
                isDragging = false;
                selectionRenderer.TileOffset = Point.Empty;
            }
        }

        public void OnDeselect(IMapViewport viewport)
        {
            selectionRenderer.TileOffset = Point.Empty;
        }

        public void OnSelect(IMapViewport viewport)
        {
        }

        public void OnMouseWheel(MouseEventArgs e, MapToolContext ctx)
        {
        }

        public bool CanDeselect => !isDragging;
    }
}