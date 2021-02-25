using System.Drawing;

namespace NHSE.WinForms.Zebra
{
    class MapToolContext : MapContext
    {
        public MapToolContext(Rectangle viewRect, int tileSize, Point viewCentre, IMapViewport viewport)
            : base(viewRect, tileSize, viewCentre)
        {
            Viewport = viewport;
        }

        public IMapViewport Viewport { get; }
    }
}