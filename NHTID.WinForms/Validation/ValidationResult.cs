using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using NHSE.Core;

namespace Nhtid.WinForms.Validation
{
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
}