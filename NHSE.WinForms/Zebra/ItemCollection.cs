using System.Collections.Generic;

namespace NHSE.WinForms.Zebra
{
    public class ItemCollection
    {
        public string Name { get; set; }

        public List<ushort> ItemIds { get; set; } = new List<ushort>();
    }
}