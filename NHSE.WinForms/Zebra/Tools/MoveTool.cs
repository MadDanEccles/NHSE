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
        private IDragAction? dragAction;

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
                    this.dragAction = new MoveDragAction(
                        selectionRenderer,
                        selectionService,
                        historyService);
                    this.dragAction.Start(e.Location, ctx);
                }
            }
        }

        public void OnMouseMove(MouseEventArgs e, MapToolContext ctx)
        {
            dragAction?.Move(e.Location, ctx);
        }

        public void OnMouseUp(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.dragAction?.End(e.Location, modifierKeys, ctx);
                this.dragAction = null;
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

        public bool CanDeselect => dragAction == null;
    }
}