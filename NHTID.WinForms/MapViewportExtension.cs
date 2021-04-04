using System.Drawing;

namespace Nhtid.WinForms
{
    internal static class MapViewportExtension
    {
        public static void ZoomIn(this IMapViewport viewport, Point zoomCentre)
            => viewport.Zoom(viewport.ZoomLevel + 1, zoomCentre);
        public static void ZoomOut(this IMapViewport viewport, Point zoomCentre)
            => viewport.Zoom(viewport.ZoomLevel - 1, zoomCentre);
    }
}