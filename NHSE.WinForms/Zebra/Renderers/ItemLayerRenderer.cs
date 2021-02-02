using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms.Zebra.Renderers
{
    class ItemLayerRenderer : MapLayerRendererBase
    {
        private readonly MapManager map;

        public ItemLayerRenderer(MapManager map)
        {
            this.map = map;
        }

        public override void Paint(Graphics gfx, MapRenderContext context)
        {
            var layer = map.CurrentLayer;

            bool[,] drawn = new bool[context.TileRange.Width, context.TileRange.Height];

            for (int x = context.TileRange.Left; x < context.TileRange.Right; x++)
            {
                for (int y = context.TileRange.Top; y < context.TileRange.Bottom; y++)
                {
                    if (drawn[x - context.TileRange.Left, y - context.TileRange.Top])
                        continue;

                    var tile = layer.GetTile(x, y);
                    if (tile.IsNone)
                        continue;
                    /*if (tile.IsBuried)
                    {
                        // DrawX(data, (x - x0) * scale, (y - y0) * scale, scale, w);
                    }
                    else if (tile.IsDropped)
                    {
                        //Rectangle itemRect = context.GetTileRectangle(x, y, 1, 1).Shrink(2, 2, 1, 1);
                        //gfx.FillRectangle(Brushes.DeepPink, itemRect);
                        //  DrawPlus(data, (x - x0) * scale, (y - y0) * scale, scale, w);
                    }*/

                    Item? root = null;
                    Point rootLocation = Point.Empty;

                    if (tile.IsRoot)
                    {
                        root = tile;
                        rootLocation = new Point(x, y);
                    }
                    else if (tile.IsExtension)
                    {
                        rootLocation = new Point(x - tile.ExtensionX, y - tile.ExtensionY);
                        root = layer.GetTile(rootLocation.X, rootLocation.Y);

                        //Debug.Assert(root.IsRoot);
                        //Rectangle itemRect = context.GetTileRectangle(x, y, 1, 1).Shrink(2, 2, 1, 1);
                        //gfx.FillRectangle(Brushes.BlueViolet, itemRect);
                    }


                    if (root != null)
                    {
                        var type = ItemInfo.GetItemSize(root);
                        var w = type.GetWidth();
                        var h = type.GetHeight();
                        Rectangle itemRect = context.ToViewport(rootLocation.X, rootLocation.Y, w, h).Shrink(2, 2, 1, 1);
                        gfx.FillRectangle(context.ResourceCache.GetSolidBrush(ItemColor.GetItemColor(root)), itemRect);

                        for (int ix = 0; ix < w; ix++)
                        {
                            int drawnX = rootLocation.X + ix - context.TileRange.Left;
                            if (drawnX < 0)
                                continue;
                            if (drawnX >= context.TileRange.Width)
                                break;

                            for (int iy = 0; iy < h; iy++)
                            {
                                int drawnY = rootLocation.Y + iy - context.TileRange.Top;

                                if (drawnY < 0)
                                    continue;
                                if (drawnY >= context.TileRange.Height)
                                    break;

                                drawn[drawnX, drawnY] = true;
                            }
                        }
                    }
                }

            }
        }
    }
}