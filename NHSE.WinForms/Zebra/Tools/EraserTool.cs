using System.Drawing;
using System.Windows.Forms;

namespace NHSE.WinForms.Zebra.Tools
{
    class EraserTool : IMapTool
    {
        private bool isErasing;
        private Point lastTile;

        public void OnMouseDown(MouseEventArgs e, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.isErasing = true;
                lastTile = ctx.ToTile(e.Location);
                if (ctx.MapEditingService.DeleteTile(lastTile, true))
                    ctx.Viewport.Invalidate();
            }
        }

        public void OnMouseMove(MouseEventArgs e, MapToolContext ctx)
        {
            if (this.isErasing)
            {
                var tilePt = ctx.ToTile(e.Location);
                if (tilePt != lastTile)
                {
                    lastTile = tilePt;
                    if (ctx.MapEditingService.DeleteTile(lastTile, true))
                        ctx.Viewport.Invalidate();
                }
            }
        }

        public void OnMouseUp(MouseEventArgs e, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                isErasing = false;
            }
        }

        public void OnDeselect(IMapViewport viewport)
        {
        }

        public void OnSelect(IMapViewport viewport)
        {
        }

        public void OnMouseWheel(MouseEventArgs e, MapToolContext ctx)
        {
        }
    }
}