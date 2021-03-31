using System.Drawing;
using System.Windows.Forms;
using NHSE.WinForms.Zebra.Renderers;

namespace NHSE.WinForms.Zebra
{
    public interface IMapViewport : IWin32Window
    {
        Point ScrollPosition { get; set; }
        int TileSize { get;  }

        int ZoomLevel { get; }

        void Zoom(int newZoomLevel, Point zoomCenter);

        void Invalidate();
        void AddRenderer(IMapLayerRenderer renderer);
        void RemoveRenderer(IMapLayerRenderer renderer);
    }

    internal static class MapViewportExtension
    {
        public static void ZoomIn(this IMapViewport viewport, Point zoomCentre)
            => viewport.Zoom(viewport.ZoomLevel + 1, zoomCentre);
        public static void ZoomOut(this IMapViewport viewport, Point zoomCentre)
            => viewport.Zoom(viewport.ZoomLevel - 1, zoomCentre);
    }
}