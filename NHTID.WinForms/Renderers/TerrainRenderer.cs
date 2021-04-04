using System.Drawing;
using NHSE.Core;

namespace Nhtid.WinForms.Renderers
{
    /// <summary>
    /// Renders the 'Terrain' layer of a map.
    /// </summary>
    class TerrainRenderer : MapLayerRendererBase
    {
        private readonly MapManager map;

        public TerrainRenderer(MapManager map)
        {
            this.map = map;
        }

        public override void Paint(Graphics gfx, MapRenderContext context)
        {
            // Each terrain tile occupies 4 map tiles (i.e. 2x2) so we need to cope with partial
            // terrain tiles...
            for (int tileX = context.TileRange.Left - context.TileRange.Left % 2; tileX < context.TileRange.Right; tileX += 2)
            {
                for (int tileY = context.TileRange.Top - context.TileRange.Top % 2; tileY < context.TileRange.Bottom; tileY += 2)
                {
                    Color color = Color.FromArgb(map.Terrain.GetTileColor(tileX / 2, tileY / 2));
                    gfx.FillRectangle(context.ResourceCache.GetSolidBrush(color),
                        context.ToViewport(tileX, tileY, 2, 2));
                }
            }
        }
    }
}