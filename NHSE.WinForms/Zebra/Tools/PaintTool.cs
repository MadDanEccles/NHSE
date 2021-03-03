using System.Drawing;
using System.Windows.Forms;
using NHSE.Core;
using static System.Windows.Forms.MouseButtons;

namespace NHSE.WinForms.Zebra.Tools
{
    interface IPickTarget
    {
        void Pick(Item item);
    }


    class PaintTool : IMapTool
    {
        private Point startTile;
        private Item item;
        private Size itemSize;
        private bool isPainting;

        private readonly IPaintOptions options;
        private readonly IHistoryService historyService;
        private IHistoryTransaction transaction;

        public PaintTool(IPaintOptions options, IHistoryService historyService)
        {
            this.options = options;
            this.historyService = historyService;
        }

        public void OnMouseDown(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (e.Button == Left)
            {
                this.startTile = ctx.ToTile(e.Location);
                this.transaction = historyService.BeginTransaction("Item Brush");
                this.isPainting = true;
                item = options.GetItem();
                itemSize = item.GetSize();
                if (ctx.MapEditingService.AddItem(item, this.startTile, this.transaction, CollisionAction.Abort))
                    ctx.Viewport.Invalidate();

            }
        }

        public void OnMouseMove(MouseEventArgs e, MapToolContext ctx)
        {
            if (isPainting)
            {
                if (options.AlignToItemGrid)
                {
                    var tilePt = ctx.ToTile(e.Location);
                    tilePt = new Point(
                        tilePt.X - (tilePt.X - startTile.X) % itemSize.Width,
                        tilePt.Y - (tilePt.Y - startTile.Y) % itemSize.Height);
                    if (ctx.MapEditingService.AddItem(item, tilePt, this.transaction, CollisionAction.Abort))
                        ctx.Viewport.Invalidate();

                }
                else
                {
                    if (ctx.MapEditingService.AddItem(item, this.startTile, this.transaction))
                        ctx.Viewport.Invalidate();
                }
            }
        }

        public void OnMouseUp(MouseEventArgs e, MapToolContext ctx)
        {
            if (e.Button == Left)
            {
                isPainting = false;
                this.transaction.Dispose();
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

        public bool CanDeselect => !isPainting;
    }
}