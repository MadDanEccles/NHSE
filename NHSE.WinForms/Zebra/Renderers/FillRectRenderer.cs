using System.Drawing;
using System.Drawing.Drawing2D;

namespace NHSE.WinForms.Zebra.Renderers
{
    class FillRectRenderer : MapLayerRendererBase
    {
        private readonly Pen pen;
        private Rectangle marqueeBounds;
        private readonly Font font;
        private ItemFieldFragment? fragment;
        private string? hint;

        public void Reset() => Update(null, null, Rectangle.Empty);

        public void Update(ItemFieldFragment? fragment, string? hint, Rectangle marqueeBounds)
        {
            bool contentChanged = false;
            if (fragment != this.fragment)
            {
                this.fragment = fragment;
                contentChanged = true;
            }
            if (hint != this.hint)
            {
                this.hint = hint;
                contentChanged = true;
            }
            if (marqueeBounds != this.marqueeBounds)
            {
                this.marqueeBounds = marqueeBounds;
                contentChanged = true;
            }
            if (contentChanged)
                OnContentChanged();
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
            if (!marqueeBounds.IsEmpty)
            {
                gfx.DrawRectangle(Pens.White, marqueeBounds);
                gfx.DrawRectangle(pen, marqueeBounds);
            }

            if (fragment != null)
            {
                foreach (var entry in fragment)
                {
                    var itemRect = context.ToViewport(entry.TileRect).Shrink(2, 2, 1, 1);
                    var brush = entry.IsConflicted ? Brushes.Red : Brushes.LawnGreen;
                    gfx.FillRectangle(brush, itemRect);

                }
            }

            if (!string.IsNullOrEmpty(hint))
            {
                Size hintSize = Size.Ceiling(gfx.MeasureString(hint, font));
                Rectangle hintRect = new Rectangle(
                    marqueeBounds.Right - hintSize.Width,
                    marqueeBounds.Bottom - hintSize.Height,
                    hintSize.Width,
                    hintSize.Height);
                gfx.FillRectangle(Brushes.Black, hintRect);
                gfx.DrawString(hint, font, Brushes.White, hintRect);
            }
        }
    }
}