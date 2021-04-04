using System.Drawing;
using System.Text;
using NHSE.Core;

namespace Nhtid.WinForms.Validation
{
    public class UnsupportedItemMapValidation : IMapValidation
    {
        public void Validate(MapManager map, ValidationResult result)
        {
            for (int x = 0; x < FieldItemLayer.FieldItemWidth; x++)
            {
                for (int y = 0; y < FieldItemLayer.FieldItemHeight; y++)
                {
                    var tile = map.Items.Layer2.GetTile(x, y);
                    if (tile.IsNone)
                        continue;

                    var support = map.Items.Layer1.GetTile(x, y);
                    if (!support.IsNone)
                        continue; // dunno how to check if the tile can actually have an item put on top of it...

                    result.Error(new Point(x, y), "Unsupported tile on layer 2", Fix);
                }
            }
        }

        private void Fix(MapManager map, ValidationRow error, StringBuilder summary)
        {
            Item tile = map.Items.Layer2.GetTile(error.TileLocation);
            summary.AppendLine($"Removed unsupported layer 2 tile from {error.TileLocation}");
            tile.Delete();
        }
    }
}