using System.Drawing;
using System.Windows.Forms;
using Nhtid.WinForms.Renderers;
using Nhtid.WinForms.Tools.Actions;

namespace Nhtid.WinForms.Tools
{
    internal abstract class FillRectActionBase : DragMouseActionBase
    {
        private readonly IHistoryService historyService;
        private readonly FillRectRenderer renderer;
        private ItemFieldFragment? fragment;
        private Rectangle marqueeBounds;

        public FillRectActionBase(IHistoryService historyService)
        {
            this.historyService = historyService;
            this.renderer = new FillRectRenderer();
        }

        public override void BindViewport(IMapViewport viewport)
        {
            viewport.AddRenderer(renderer);
        }

        public override void UnbindViewport(IMapViewport viewport)
        {
            viewport.RemoveRenderer(renderer);
        }

        protected override void OnDragStart(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx)
        {
            this.renderer.Reset();
        }

        protected override void OnDragEnd(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx)
        {
            if (fragment != null)
            {
                using (var trans = historyService.BeginTransaction("Fill Rectangle"))
                {
                    foreach (var entry in fragment)
                        ctx.MapEditingService.AddItem(entry.Item, entry.TileRect.Location, trans, CollisionAction.Abort);
                }
            }
            this.renderer.Reset();
        }

        protected override void OnDragMove(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            marqueeBounds = GetMarqueeBounds(e.Location);
            CalculateResult(ctx, marqueeBounds, out this.fragment, out var hint);
            this.renderer.Update(fragment, hint, marqueeBounds);
        }

        protected void InvalidateFragment(MapToolContext ctx)
        {
            CalculateResult(ctx, marqueeBounds, out this.fragment, out var hint);
            this.renderer.Update(fragment, hint, marqueeBounds);
        }

        protected abstract void CalculateResult(MapToolContext ctx, Rectangle marqueeBounds,
            out ItemFieldFragment fragment,
            out string hint);

        private Rectangle GetMarqueeBounds(Point secondLocation)
            => new Rectangle(this.DragStartLocation, secondLocation.Subtract(this.DragStartLocation));
    }
}