using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Nhtid.WinForms.Renderers;
using Nhtid.WinForms.Selection;
using Nhtid.WinForms.Tools.Actions;

namespace Nhtid.WinForms.Tools
{
    public class MarqueeSelectionTool : MapToolBase
    {
        private readonly ISelectionService selectionService;
        private readonly SelectionRenderer selectionRenderer;
        private readonly IHistoryService historyService;

        public MarqueeSelectionTool(ISelectionService selectionService, SelectionRenderer selectionRenderer, IHistoryService historyService)
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
            else if (e.Button == MouseButtons.Left)
            {
                Point tilePt = ctx.ToTile(e.Location);
                if (selectionService.SelectedItems.Any(i => i.Bounds.Contains(tilePt)))
                {
                    return new MoveItemsDragAction(selectionRenderer, selectionService, historyService);
                }
                else
                {
                    selectionService.ClearSelection();
                    return new MarqueeSelectAction(selectionService);
                }
            }

            return null;
        }

    }
}