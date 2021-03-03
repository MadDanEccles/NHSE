using System.Drawing;
using System.Drawing.Drawing2D;

namespace NHSE.WinForms.Zebra.Renderers
{
    class FillRectRenderer : MapLayerRendererBase
    {
        private readonly Pen pen;
        private Rectangle marqueeBounds;
        private Size itemSize;
        private Font font;

        public Rectangle MarqueeBounds
        {
            get => marqueeBounds;
            set
            {
                if (marqueeBounds != value)
                {
                    marqueeBounds = value;
                    OnContentChanged();
                }
            }
        }

        public Size ItemSize
        {
            get => itemSize;
            set
            {
                if (itemSize != value)
                {
                    itemSize = value;
                    OnContentChanged();
                }
            }
        }

        public FillRectRenderer()
        {
            pen = new Pen(Color.Black, 1f)
            {
                DashStyle = DashStyle.Custom,
                DashPattern = new[] { 4f, 4f }
            };
            this.font = new Font("Calibri", 9.25f);
        }

        public override void Dispose()
        {
            font.Dispose();
            pen.Dispose();
            base.Dispose();
        }

        public override void Paint(Graphics gfx, MapRenderContext context)
        {
            if (!MarqueeBounds.IsEmpty)
            {
                gfx.DrawRectangle(Pens.White, MarqueeBounds);
                gfx.DrawRectangle(pen, MarqueeBounds);

                var tileRect = context.ToTiles(MarqueeBounds);
                for (int x = tileRect.Left; x <= tileRect.Right - itemSize.Width; x += itemSize.Width)
                {
                    for (int y = tileRect.Top; y <= tileRect.Bottom - itemSize.Height; y += itemSize.Height)
                    {
                        var itemRect = context.ToViewport(x, y, itemSize.Width, itemSize.Height);
                        itemRect = itemRect.Shrink(2, 2, 1, 1);
                        gfx.FillRectangle(Brushes.Red, itemRect);
                    }
                }

                int itemsX = tileRect.Width / itemSize.Width;
                int itemsY = tileRect.Height / itemSize.Height;

                string hint = $"{itemsX} × {itemsY}";
                Size hintSize = Size.Ceiling(gfx.MeasureString(hint, font));
                Rectangle hintRect = new Rectangle(
                    MarqueeBounds.Right - hintSize.Width,
                    MarqueeBounds.Bottom - hintSize.Height,
                    hintSize.Width,
                    hintSize.Height);
                gfx.FillRectangle(Brushes.Black, hintRect);
                gfx.DrawString(hint, font, Brushes.White, hintRect);

            }
        }
    }
}