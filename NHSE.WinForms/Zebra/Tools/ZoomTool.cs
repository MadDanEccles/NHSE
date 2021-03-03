using System.Windows.Forms;

namespace NHSE.WinForms.Zebra.Tools
{
    class ZoomTool : IMapTool
    {
        public void OnMouseDown(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                ctx.Viewport.Zoom(ctx.Viewport.ZoomLevel + 1, e.Location);
            }
            else if (e.Button == MouseButtons.Right)
            {
                ctx.Viewport.Zoom(ctx.Viewport.ZoomLevel - 1, e.Location);
            }
        }

        public void OnMouseMove(MouseEventArgs e, MapToolContext ctx)
        {
        }

        public void OnMouseUp(MouseEventArgs e, MapToolContext ctx)
        {
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

        public bool CanDeselect => true;
    }
}