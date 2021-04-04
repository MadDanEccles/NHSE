using NHSE.Core;

namespace Nhtid.WinForms.Catalog
{
    public class ItemAttributeGroup
    {
        public string Name { get; set; }
        public PresentationType PresentationType { get; set; }
        public ushort[] ItemIds { get; set; }
        public ItemKind[] ItemKinds { get; set; }
    }
}
