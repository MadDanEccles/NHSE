using System.Drawing;

namespace Nhtid.WinForms
{
    public class MapRenderContext : MapContext
    {
        public MapRenderContext(Rectangle viewRect, int tileSize, Point scrollPosition, 
            IGdiResourceCache resourceCache)
            : base(viewRect, tileSize, scrollPosition)
        {
            ResourceCache = resourceCache;
        }

        public Rectangle ApplyStandardPaddingForTiles(Rectangle viewportRect)
        {
            return TileSize > 7 
                ? viewportRect.Shrink(2, 2, 1, 1)
                : viewportRect.Shrink(1, 1, 0, 0);
        }

        public IGdiResourceCache ResourceCache { get; }

    }
}
