using System.Windows.Forms;

namespace Nhtid.WinForms.Tools
{
    public interface IMapTool
    {
        void OnMouseDown(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx);
        void OnMouseMove(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx);
        void OnMouseUp(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx);
        void OnDeselect(IMapViewport viewport);
        void OnSelect(IMapViewport viewport);
        void OnMouseWheel(MouseEventArgs e, MapToolContext ctx);
        bool CanDeselect { get; }

        bool OnKeyDown(Keys e, MapToolContext ctx);
    }
}