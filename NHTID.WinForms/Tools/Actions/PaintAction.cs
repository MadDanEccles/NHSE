using System.Drawing;
using System.Windows.Forms;
using NHSE.Core;

namespace Nhtid.WinForms.Tools.Actions
{
    public class PaintAction : DragMouseActionBase
    {
        private readonly IHistoryTransaction transaction;
        private readonly Item item;
        private readonly Size itemSize;
        private Point startTile;

        public PaintAction(IHistoryService historyService, Item item)
        {
            this.transaction = historyService.BeginTransaction("Paint");
            this.item = item;
            this.itemSize = item.GetSize();
        }

        protected override void OnDragStart(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            startTile = ctx.ToTile(e.Location);
            if (ctx.MapEditingService.AddItem(item, startTile, this.transaction,
                CollisionAction.Abort))
                ctx.Viewport.Invalidate();
        }

        protected override void OnDragMove(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (ctx.MapEditingService.AddItem(item, GetItemPoint(ctx, e.Location), this.transaction,
                CollisionAction.Abort))
                ctx.Viewport.Invalidate();
        }

        protected override void OnClick(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (ctx.MapEditingService.AddItem(item, ctx.ToTile(e.Location), this.transaction,
                CollisionAction.Abort))
                ctx.Viewport.Invalidate();
        }

        private Point GetItemPoint(MapToolContext ctx, Point clientPt)
        {
            var tilePt = ctx.ToTile(clientPt);
            tilePt = new Point(
                tilePt.X - (tilePt.X - startTile.X) % itemSize.Width,
                tilePt.Y - (tilePt.Y - startTile.Y) % itemSize.Height);
            return tilePt;
        }

        public override void Dispose()
        {
            this.transaction.Dispose();
            base.Dispose();
        }
    }
}