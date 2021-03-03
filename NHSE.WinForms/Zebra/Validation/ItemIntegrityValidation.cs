using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using NHSE.Core;

namespace NHSE.WinForms.Zebra.Validation
{
    public class ItemIntegrityValidation : IValidation
    {
        private readonly Rectangle worldTileBounds = new Rectangle(0, 0, 7 * 32, 6 * 32);
        private MapManager map;

        public ItemIntegrityValidation(MapManager map)
        {
            this.map = map;
        }

        public void Validate(ValidationResult result)
        {
            for (int x = worldTileBounds.Left; x < worldTileBounds.Right; x++)
            {
                for (int y = worldTileBounds.Top; y < worldTileBounds.Bottom; y++)
                {
                    Point tilePt = new Point(x, y);
                    Item tile = map.CurrentLayer.GetTile(tilePt);
                    if (tile.IsRoot)
                    {
                        ValidateExtensions(result, tile, x, y);
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

        private void ValidateExtensions(ValidationResult result, Item tile, int rootX, int rootY)
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

    public interface IValidation
    {
    }

    public class ValidationResult
    {
        private readonly List<ValidationRow> rows = new List<ValidationRow>();

        public void Error(Point tilePt, string message, Action<MapManager, ValidationRow, StringBuilder>? fixAction = null)
            => rows.Add(new ValidationRow(ValidationLevel.Error, tilePt, message, fixAction));
        public void Warning(Point tilePt, string message, Action<MapManager, ValidationRow, StringBuilder>? fixAction = null)
            => rows.Add(new ValidationRow(ValidationLevel.Warning, tilePt, message, fixAction));

        public bool HasErrors => rows.Any(i => i.Level == ValidationLevel.Error);

        public bool HasFixes => rows.Any(i => i.FixAction != null);

        public string Fix(MapManager mapManager)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var row in rows)
                row.FixAction?.Invoke(mapManager, row, sb);
            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            return string.Join("\r\n", rows);
        }
    }

    public class ValidationRow
    {
        public ValidationRow(ValidationLevel level, Point tileLocation,
            string message, Action<MapManager, ValidationRow, StringBuilder>? fixAction)
        {
            Level = level;
            TileLocation = tileLocation;
            Message = message;
            FixAction = fixAction;
        }

        public ValidationLevel Level { get; }

        public Point TileLocation { get; }

        public string Message { get; }

        public Action<MapManager, ValidationRow, StringBuilder>? FixAction { get; }

        public override string ToString()
            => $"[{Level}] ({TileLocation.X},{TileLocation.Y}): {Message}";
    }

    public enum ValidationLevel
    {
        Warning,
        Error,
    }
}
