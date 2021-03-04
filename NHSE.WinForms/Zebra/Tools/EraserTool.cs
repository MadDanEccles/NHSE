using System.Drawing;
using System.Windows.Forms;

namespace NHSE.WinForms.Zebra.Tools
{
    class EraserTool : IMapTool
    {
        private readonly IHistoryService historyService;
        private bool isErasing;
        private Point lastTile;
        private IHistoryTransaction transaction;

        public EraserTool(IHistoryService historyService)
        {
            this.historyService = historyService;
        }

        public void OnMouseDown(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.isErasing = true;
                this.transaction = historyService.BeginTransaction("Eraser");
                lastTile = ctx.ToTile(e.Location);
                if (ctx.MapEditingService.DeleteTile(lastTile, transaction, true))
                    ctx.Viewport.Invalidate();
            }
        }

        public void OnMouseMove(MouseEventArgs e, MapToolContext ctx)
        {
            if (this.isErasing)
            {
                var tilePt = ctx.ToTile(e.Location);
                if (tilePt != lastTile)
                {
                    lastTile = tilePt;
                    if (ctx.MapEditingService.DeleteTile(lastTile, transaction, true))
                        ctx.Viewport.Invalidate();
                }
            }
        }

        public void OnMouseUp(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                isErasing = false;
                transaction.Dispose();
            }
        }

        public void OnDeselect(IMapViewport viewport)
        {
        }

        public void OnSelect(IMapViewport viewport)
        {
        }

        public void OnMouseWheel(MouseEventArgs e, MapToolContext ctx)
        {
        }

        public bool CanDeselect => !isErasing;
    }
}