using System.Drawing;
using NHSE.WinForms.Zebra.Renderers;

namespace NHSE.WinForms.Zebra
{
    internal interface IMapViewport
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