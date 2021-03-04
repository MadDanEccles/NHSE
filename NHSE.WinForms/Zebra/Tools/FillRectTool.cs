using System.Drawing;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.WinForms.Zebra.Renderers;

namespace NHSE.WinForms.Zebra.Tools
{
    class FillRectTool : IMapTool
    {
        private Point startTile;
        private Item item;
        private Size itemSize;
        private bool isDragging;

        private readonly IItemSelector options;
        private readonly IHistoryService historyService;
        private readonly FillRectRenderer renderer;
        private Point startLocation;

        public FillRectTool(IItemSelector options, IHistoryService historyService)
        {
            this.options = options;
            this.historyService = historyService;
            this.renderer = new FillRectRenderer();
        }

        public void OnMouseDown(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                item = options.GetItem();
                if (!item.IsRoot)
                {
                    MessageBox.Show(ctx.Viewport, "Please select a valid item before drawing", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.startTile = ctx.ToTile(e.Location);
                    this.startLocation = e.Location;
                    this.isDragging = true;
                    itemSize = item.GetSize();
                    this.renderer.ItemSize = itemSize;
                    this.renderer.MarqueeBounds = new Rectangle(e.Location, Size.Empty);
                }
            }
        }

        public void OnMouseMove(MouseEventArgs e, MapToolContext ctx)
        {
            if (isDragging)
            {
                this.renderer.MarqueeBounds = GetMarqueeBounds(e.Location);
            }
        }

        private Rectangle GetMarqueeBounds(Point secondLocation)
            => new Rectangle(startLocation, secondLocation.Subtract(startLocation));

        public void OnMouseUp(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                using (var trans = historyService.BeginTransaction("Fill Rectangle"))
                {
                    var tileRect = ctx.ToTiles(GetMarqueeBounds(e.Location));
                    for (int x = tileRect.Left; x <= tileRect.Right - itemSize.Width; x += itemSize.Width)
                    {
                        for (int y = tileRect.Top; y <= tileRect.Bottom - itemSize.Height; y += itemSize.Height)
                        {
                            ctx.MapEditingService.AddItem(item, new Point(x, y), trans, CollisionAction.Abort);
                        }
                    }
                }

                renderer.MarqueeBounds = Rectangle.Empty;
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