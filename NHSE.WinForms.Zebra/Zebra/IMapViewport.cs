using System.Drawing;
using System.Windows.Forms;
using NHSE.WinForms.Zebra.Renderers;

namespace NHSE.WinForms.Zebra
{
    internal interface IMapViewport : IWin32Window
    {
        Point ScrollPosition { get; set; }
        int TileSize { get;  }

        int ZoomLevel { get; }

        void Zoom(int newZoomLevel, Point zoomCenter);
        void Invalidate();
        void AddRenderer(IMapLayerRenderer renderer);
        void RemoveRenderer(IMapLayerRenderer renderer);
    }
}