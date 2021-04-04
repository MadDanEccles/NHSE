using System.Drawing;
using System.Windows.Forms;

namespace Nhtid.WinForms.Tools.Actions
{
    class PanZoomMouseAction : DragMouseActionBase
    {
        private Point panStartScrollPosition;

        protected override void OnDragStart(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx)
        {
            this.panStartScrollPosition = ctx.Viewport.ScrollPosition;
        }

        protected override void OnDragMove(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            Size delta = DragStartLocation.Subtract(e.Location);
            ctx.Viewport.ScrollPosition = Point.Add(panStartScrollPosition, delta);
        }

        protected override void OnClick(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
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
    }
}