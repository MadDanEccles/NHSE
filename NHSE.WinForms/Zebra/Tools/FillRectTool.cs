using System.Drawing;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.WinForms.Zebra.Renderers;

namespace NHSE.WinForms.Zebra.Tools
{
    class FillRectTool : FillRectToolBase
    {
        private readonly IItemSelector options;
        private Item item;
        private Size itemSize;

        public FillRectTool(IItemSelector options, IHistoryService historyService) : base(historyService)
        {
            this.options = options;
        }

        protected override bool OnStartDrag(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            item = options.GetItem();
            if (!item.IsRoot)
            {
                MessageBox.Show(ctx.Viewport, "Please select a valid item before drawing", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            itemSize = item.GetSize();
            return true;
        }

        protected override void CalculateResult(MapToolContext ctx, Rectangle marqueeBounds, out ItemFieldFragment fragment, out string hint)
        {
            fragment = new ItemFieldFragment();
            var tileRect = ctx.ToTiles(marqueeBounds);
            for (int x = tileRect.Left; x <= tileRect.Right - itemSize.Width; x += itemSize.Width)
            {
                for (int y = tileRect.Top; y <= tileRect.Bottom - itemSize.Height; y += itemSize.Height)
                {
                    Rectangle itemTileRect = new Rectangle(x, y, itemSize.Width, itemSize.Height);
                    fragment.Add(itemTileRect, item, ctx.MapEditingService.IsOccupied(itemTileRect));
                }
            }

            int itemsX = tileRect.Width / itemSize.Width;
            int itemsY = tileRect.Height / itemSize.Height;
            hint = $"{itemsX} × {itemsY}";
        }
    }

    abstract class FillRectToolBase : IMapTool
    {
        private bool isDragging;

        private readonly IHistoryService historyService;
        private readonly FillRectRenderer renderer;
        private Point startLocation;
        private ItemFieldFragment? fragment;

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
                    this.isDragging = true;
                    this.renderer.Reset();
                }
            }
        }

        protected abstract bool OnStartDrag(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx);

        public void OnMouseMove(MouseEventArgs e, MapToolContext ctx)
        {
            if (isDragging)
            {
                var marqueeBounds = GetMarqueeBounds(e.Location);
                CalculateResult(ctx, marqueeBounds, out this.fragment, out var hint);
                this.renderer.Update(fragment, hint, marqueeBounds);
            }
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
                isDragging = false;
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

        public bool CanDeselect => !isDragging;
    }
}