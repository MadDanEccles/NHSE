using System;

namespace Nhtid.WinForms
{
    public class RecentFileRecord
    {
        public string FileName { get; set; }
        public DateTime LastAccessed { get; set; }
        public string Title { get; set; }

        public override string ToString() => FileName;
    }
}