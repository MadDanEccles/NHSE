using System.Drawing;
using System.Drawing.Drawing2D;

namespace Nhtid.WinForms.Renderers
{
    class MarqueeRenderer : MapLayerRendererBase
    {
        private readonly Pen pen;
        private Rectangle marqueeBounds;

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

        public MarqueeRenderer()
        {
            pen = new Pen(Color.Black, 1f)
            {
                DashStyle = DashStyle.Custom, 
                DashPattern = new[] {4f, 4f}
            };
        }

        public override void Dispose()
        {
            pen.Dispose();
            base.Dispose();
        }

        public override void Paint(Graphics gfx, MapRenderContext context)
        {
            if (!MarqueeBounds.IsEmpty)
            {
                gfx.DrawRectangle(Pens.White, MarqueeBounds);
                gfx.DrawRectangle(pen, MarqueeBounds);
            }
        }
    }
}