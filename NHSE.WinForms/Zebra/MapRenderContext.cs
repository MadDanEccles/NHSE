using System.Drawing;

namespace NHSE.WinForms.Zebra
{
    class MapRenderContext : MapContext
    {
        public MapRenderContext(Rectangle viewRect, int tileSize, Point scrollPosition, 
            IGdiResourceCache resourceCache)
            : base(viewRect, tileSize, scrollPosition)
        {
            ResourceCache = resourceCache;
        }

        public IGdiResourceCache ResourceCache { get; }

    }
}
