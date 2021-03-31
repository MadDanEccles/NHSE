using System.Drawing;
using System.Windows.Forms;
using NHSE.WinForms.Zebra.Renderers;

namespace NHSE.WinForms.Zebra.Tools
{
    public abstract class FillRectToolBase : IMapTool
    {
        protected bool IsDragging { get; private set; }

        private readonly IHistoryService historyService;
        private readonly FillRectRenderer renderer;
        private Point startLocation;
        private ItemFieldFragment? fragment;
        private Rectangle marqueeBounds;

        public FillRectToolBase(IHistoryService historyService)
        {
            this.historyService = historyService;
            this.renderer = new FillRectRenderer();
        }

        public void OnMouseDown(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                fragment = null;
                if (OnStartDrag(e, modifierKeys, ctx))
                {
                    this.startLocation = e.Location;
                    this.IsDragging = true;
                    this.renderer.Reset();
                }
            }
        }

        protected abstract bool OnStartDrag(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx);

        public void OnMouseMove(MouseEventArgs e, MapToolContext ctx)
        {
            if (IsDragging)
            {
                marqueeBounds = GetMarqueeBounds(e.Location);
                CalculateResult(ctx, marqueeBounds, out this.fragment, out var hint);
                this.renderer.Update(fragment, hint, marqueeBounds);
            }
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
            => new Rectangle(startLocation, secondLocation.Subtract(startLocation));

        public void OnMouseUp(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsDragging = false;
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
        }

        public void OnDeselect(IMapViewport viewport)
        {
            viewport.RemoveRenderer(renderer);
        }

        public void OnSelect(IMapViewport viewport)
        {
            viewport.AddRenderer(renderer);
        }

        public void OnMouseWheel(MouseEventArgs e, MapToolContext ctx)
        {
        }

        public bool CanDeselect => !IsDragging;

        public virtual bool OnKeyDown(Keys e, MapToolContext ctx)
        {
            return false;
        }
    }
}