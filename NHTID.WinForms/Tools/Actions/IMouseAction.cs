using System;
using System.Windows.Forms;

namespace Nhtid.WinForms.Tools.Actions
{
    public interface IMouseAction : IDisposable
    {
        void OnMouseMove(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx);
        void OnMouseUp(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx);
        void OnMouseDown(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx);

        bool OnKeyDown(Keys e, MapToolContext ctx);

        void BindViewport(IMapViewport viewport);

        void UnbindViewport(IMapViewport viewport);
    }
}