using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Nhtid.WinForms.Renderers;
using Nhtid.WinForms.Selection;
using Nhtid.WinForms.Tools.Actions;

namespace Nhtid.WinForms.Tools
{
    public class MoveTool : MapToolBase
    {
        private readonly ISelectionService selectionService;
        private readonly SelectionRenderer selectionRenderer;
        private readonly IHistoryService historyService;

        public MoveTool(ISelectionService selectionService, SelectionRenderer selectionRenderer,
            IHistoryService historyService)
        {
            this.selectionService = selectionService;
            this.selectionRenderer = selectionRenderer;
            this.historyService = historyService;
        }

        protected override IMouseAction GetMouseAction(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (modifierKeys.HasFlag(Keys.Alt))
            {
                return new PanZoomMouseAction();
            }
            else
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
                    return new MoveItemsDragAction(
                        selectionRenderer,
                        selectionService,
                        historyService);
                }

                return null;
            }
        }
    }
}