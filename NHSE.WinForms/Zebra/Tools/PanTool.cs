using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.MouseButtons;

namespace NHSE.WinForms.Zebra.Tools
{
    class PanTool : IMapTool
    {
        private Point panStartScrollPosition;
        private Point panStartLocation;
        private bool isPanning;

        public void OnMouseDown(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (e.Button == Left && modifierKeys.HasFlag(Keys.Alt))
            {
                ctx.Viewport.Zoom(ctx.Viewport.ZoomLevel + 1, e.Location);
            }
            else if (e.Button == Right && modifierKeys.HasFlag(Keys.Alt))
            {
                ctx.Viewport.Zoom(ctx.Viewport.ZoomLevel - 1, e.Location);
            }
            else if (e.Button == Left)
            {
                this.panStartScrollPosition = ctx.Viewport.ScrollPosition;
                this.panStartLocation = e.Location;
                isPanning = true;
            }
        }

        public void OnMouseMove(MouseEventArgs e, MapToolContext ctx)
        {
            if (isPanning)
            {
                Size delta = panStartLocation.Subtract(e.Location);
                ctx.Viewport.ScrollPosition = Point.Add(panStartScrollPosition, delta);
            }
        }

        public void OnMouseUp(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (e.Button == Left)
            {
                isPanning = false;
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
            ctx.Viewport.Zoom(ctx.Viewport.ZoomLevel + e.Delta / 120, e.Location);
        }

        public bool CanDeselect => !isPanning;
    }
}