using System.Diagnostics;
using System.Drawing;
using System.Text;
using NHSE.Core;

namespace Nhtid.WinForms.Validation
{
    public class ItemIntegrityMapValidation : IMapValidation
    {
        private readonly Rectangle worldTileBounds = new Rectangle(0, 0, 7 * 32, 6 * 32);

        public void Validate(MapManager map, ValidationResult result)
        {
            for (int x = worldTileBounds.Left; x < worldTileBounds.Right; x++)
            {
                for (int y = worldTileBounds.Top; y < worldTileBounds.Bottom; y++)
                {
                    Point tilePt = new Point(x, y);
                    Item tile = map.CurrentLayer.GetTile(tilePt);
                    if (tile.IsRoot)
                    {
                        ValidateExtensions(map, result, tile, x, y);
                    }
                    else if (tile.IsExtension)
                    {
                        Point rootPt = new Point(x - tile.ExtensionX, y - tile.ExtensionY);
                        Item root = map.CurrentLayer.GetTile(rootPt);
                        if (!root.IsRoot)
                            result.Error(tilePt, "Orphaned extension tile", RemoveOrphanedTile);
                    }
                    else if (!tile.IsNone)
                    {
                        result.Error(tilePt, "Unknown item type");
                    }
                }
            }
        }

        private void RemoveOrphanedTile(MapManager map, ValidationRow row, StringBuilder summary)
        {
            Item tile = map.CurrentLayer.GetTile(row.TileLocation);
            summary.AppendLine($"Removed orphaned extension tile from {row.TileLocation}");
            tile.Delete();
        }

        private void ValidateExtensions(MapManager map, ValidationResult result, Item tile, int rootX, int rootY)
        {
            bool isComplete = true;
            Size size = tile.GetSize();
            for (int x = 0; x < size.Width; x++)
            {
                for (int y = 0; y < size.Height; y++)
                {
                    if (x == 0 && y == 0)
                        continue;
                    Point tilePt = new Point(rootX + x, rootY + y);
                    Item extension = map.CurrentLayer.GetTile(tilePt);
                    if (!extension.IsExtension || extension.ExtensionX != x || extension.ExtensionY != y)
                        isComplete = false;
                }
            }

            if (!isComplete)
                result.Error(new Point(rootX, rootY), "Incomplete item", RemoveIncompleteItem);
        }

        private void RemoveIncompleteItem(MapManager map, ValidationRow row, StringBuilder summary)
        {
            Item root = map.CurrentLayer.GetTile(row.TileLocation);
            Debug.Assert(root.IsRoot);
            Size size = root.GetSize();
            for (int x = 0; x < size.Width; x++)
            {
                for (int y = 0; y < size.Height; y++)
                {
                    Point extLoc = new Point(row.TileLocation.X + x, row.TileLocation.Y + y);
                    Item extension = map.CurrentLayer.GetTile(extLoc);
                    if (extension.ExtensionX == x && extension.ExtensionY == y)
                    {
                        extension.Delete();
                        summary.AppendLine($"incomplete item extension removed from {extLoc}");
                    }
                }
            }

            root.Delete();
            summary.AppendLine($"incomplete item root removed from {row.TileLocation}");
        }
    }
}
