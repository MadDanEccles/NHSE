using System.Drawing;
using System.Windows.Forms;

namespace Nhtid.WinForms.Tools.Actions
{
    public class EraseAction : DragMouseActionBase
    {
        private Point lastTile;
        private readonly IHistoryTransaction transaction;

        public EraseAction(IHistoryService historyService)
        {
            this.transaction = historyService.BeginTransaction("Eraser");
        }

        public override void Dispose()
        {
            transaction.Dispose();
            base.Dispose();
        }

        protected override void OnDragStart(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            lastTile = ctx.ToTile(e.Location);
            if (ctx.MapEditingService.DeleteTile(lastTile, transaction, true))
                ctx.Viewport.Invalidate();

            base.OnDragStart(e, modifierKeys, ctx);
        }

        protected override void OnDragMove(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            var tilePt = ctx.ToTile(e.Location);
            if (tilePt != lastTile)
            {
                lastTile = tilePt;
                if (ctx.MapEditingService.DeleteTile(lastTile, transaction, true))
                    ctx.Viewport.Invalidate();
            }
        }

        protected override void OnClick(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            lastTile = ctx.ToTile(e.Location);
            if (ctx.MapEditingService.DeleteTile(lastTile, transaction, true))
                ctx.Viewport.Invalidate();
        }
    }
}