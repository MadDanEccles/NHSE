using System.Windows.Forms;
using Nhtid.WinForms.Tools.Actions;

namespace Nhtid.WinForms.Tools
{
    public abstract class MapToolBase : IMapTool
    {
        private IMouseAction? mouseAction;
        private MouseButtons mouseActionButton;

        public virtual void OnMouseDown(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (this.mouseAction == null)
            {
                this.mouseAction = GetMouseAction(e, modifierKeys, ctx);
                if (this.mouseAction != null)
                {
                    mouseAction.BindViewport(ctx.Viewport);
                    this.mouseAction.OnMouseDown(e, modifierKeys, ctx);
                    this.mouseActionButton = e.Button;
                }
            }
        }

        protected abstract IMouseAction GetMouseAction(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx);

        public void OnMouseMove(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            mouseAction?.OnMouseMove(e, modifierKeys, ctx);
        }

        public void OnMouseUp(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (mouseAction != null && e.Button == mouseActionButton)
            {
                mouseAction.OnMouseUp(e, modifierKeys, ctx);
                mouseAction.UnbindViewport(ctx.Viewport);
                mouseAction.Dispose();
                mouseAction = null;
            }
        }

        public virtual void OnDeselect(IMapViewport viewport)
        {
        }

        public virtual void OnSelect(IMapViewport viewport)
        {
        }

        public virtual void OnMouseWheel(MouseEventArgs e, MapToolContext ctx)
        {
        }

        public virtual bool CanDeselect => mouseAction == null;

        public virtual bool OnKeyDown(Keys e, MapToolContext ctx)
        {
            return mouseAction?.OnKeyDown(e, ctx) ?? false;
        }
    }
}