using System.Drawing;
using NHSE.Core;

namespace NHSE.WinForms.Zebra
{
    static class MapExtensions
    {
        public static Item GetTile(this FieldItemLayer layer, Point itemPt)
            => layer.GetTile(itemPt.X, itemPt.Y);

        public static void DeleteExtensionTiles(this FieldItemLayer layer, Item tile, Point itemPt)
            => layer.DeleteExtensionTiles(tile, itemPt.X, itemPt.Y);

        public static Size GetSize(this Item item)
        {
            var type = ItemInfo.GetItemSize(item);
            if ((item.Rotation & 1) == 1)
                return new Size(type.GetHeight(), type.GetWidth());
            return new Size(type.GetWidth(), type.GetHeight());
        }
    }
}