using System.Drawing;

namespace Nhtid.WinForms.Renderers
{
    class GridOverlayRenderer : MapLayerRendererBase
    {
        private readonly Pen majorPen;
        private readonly Pen minorPen;

        /// <summary>
        /// Initialises a new instance of GridOverlayRenderer with a grid color of 50% transparent black.
        /// </summary>
        public GridOverlayRenderer()
            : this(Color.FromArgb(64, 0, 0, 0), Color.FromArgb(32, 0, 0, 0))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color">The color of the grid lines.</param>
        public GridOverlayRenderer(Color colorMajor, Color colorMinor)
        {
            majorPen = new Pen(colorMajor);
            minorPen = new Pen(colorMinor);
        }

        public override void Dispose()
        {
            majorPen.Dispose();
            minorPen.Dispose();
        }

        public override void Paint(Graphics gfx, MapRenderContext context)
        {
            for (int x = context.TileRange.Left; x < context.TileRange.Right; x++)
            {
                var leftEdge = context.GetLeftEdge(x);
                gfx.DrawLine(x % 2 == 0 ? majorPen : minorPen, leftEdge, context.ViewRect.Top, leftEdge, context.ViewRect.Bottom);
            }

            for (int y = context.TileRange.Top; y < context.TileRange.Bottom; y++)
            {
                var topEdge = context.GetTopEdge(y);
                gfx.DrawLine(y % 2 == 0 ? majorPen : minorPen, context.ViewRect.Left, topEdge, context.ViewRect.Right, topEdge);
            }
        }
    }
}