using System.Drawing;

namespace Nhtid.WinForms.Renderers
{
    internal class BackgroundRenderer : MapLayerRendererBase
    {
        private readonly Brush brush  = new SolidBrush(Color.Black);

        public override void Dispose()
        {
            brush.Dispose();
        }

        public override void Paint(Graphics gfx, MapRenderContext context)
        {
            gfx.FillRectangle(brush, context.ViewRect);
        }
    }
}