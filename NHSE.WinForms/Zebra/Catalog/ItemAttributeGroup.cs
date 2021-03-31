using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NHSE.Core;

namespace NHSE.WinForms.Zebra.Catalog
{
    public class ItemAttributeGroup
    {
        public string Name { get; set; }
        public PresentationType PresentationType { get; set; }
        public ushort[] ItemIds { get; set; }
        public ItemKind[] ItemKinds { get; set; }
    }
}
