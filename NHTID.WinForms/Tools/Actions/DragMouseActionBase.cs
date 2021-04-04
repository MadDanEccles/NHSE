using System.Drawing;
using System.Windows.Forms;

namespace Nhtid.WinForms.Tools.Actions
{
    public class DragMouseActionBase : IMouseAction
    {
        private MouseEventArgs? originArgs;
        public bool IsDragging { get; private set; }
        private const double DragThreshold = 5.0;

        protected Point DragStartLocation => originArgs.Location;

        public void OnMouseMove(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx)
        {
            if (IsDragging)
            {
                OnDragMove(mouseEventArgs, modifierKeys, ctx);
            }
            else if (this.originArgs != null && mouseEventArgs.Location.GetDistance(this.originArgs.Location) > DragThreshold)
            {
                IsDragging = true;
                OnDragStart(originArgs, modifierKeys, ctx);
            }
        }

        public virtual bool OnKeyDown(Keys e, MapToolContext ctx)
        {
            return false;
        }

        public virtual void BindViewport(IMapViewport viewport)
        {
        }

        public virtual void UnbindViewport(IMapViewport viewport)
        {
        }

        protected virtual void OnDragStart(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx)
        {
        }

        protected virtual void OnDragEnd(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx)
        {
        }

        protected virtual void OnDragMove(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx)
        {
        }

        public void OnMouseUp(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx)
        {
            if (IsDragging)
            {
                IsDragging = false;
                OnDragEnd(mouseEventArgs, modifierKeys, ctx);
            }
            else
            {
                OnClick(mouseEventArgs, modifierKeys, ctx);
            }

            this.originArgs = null;
        }

        protected virtual void OnClick(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
        }

        public void OnMouseDown(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx)
        {
            this.originArgs = mouseEventArgs;
        }

        public virtual void Dispose()
        {
        }
    }
}