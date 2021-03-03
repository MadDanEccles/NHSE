using System.Windows.Forms;

namespace NHSE.WinForms.Zebra.Tools
{
    interface IMapTool
    {
        void OnMouseDown(MouseEventArgs e, MapToolContext ctx);
        void OnMouseMove(MouseEventArgs e, MapToolContext ctx);
        void OnMouseUp(MouseEventArgs e, MapToolContext ctx);
        void OnDeselect(IMapViewport viewport);
        void OnSelect(IMapViewport viewport);
        void OnMouseWheel(MouseEventArgs e, MapToolContext ctx);
        bool CanDeselect { get; }
    }
}