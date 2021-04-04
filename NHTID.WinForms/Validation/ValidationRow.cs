using System;
using System.Drawing;
using System.Text;
using NHSE.Core;

namespace Nhtid.WinForms.Validation
{
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
}