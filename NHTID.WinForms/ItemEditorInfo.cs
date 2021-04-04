using NHSE.Core;

namespace Nhtid.WinForms
{
    public class ItemEditorInfo
    {
        public PresentationType PermittedPresentationTypes { get; set; }

        public bool CanBury => PermittedPresentationTypes.HasFlag(PresentationType.Buried);
        public bool CanDrop => PermittedPresentationTypes.HasFlag(PresentationType.Dropped);
        public bool CanPlace => PermittedPresentationTypes.HasFlag(PresentationType.Placed);
        public bool CanHang => PermittedPresentationTypes.HasFlag(PresentationType.Hung);
        public bool CanRecipe => PermittedPresentationTypes.HasFlag(PresentationType.Recipe);

        public ushort ItemId { get; set; }

        public bool HasVariants { get; set; }

        public ItemVariant[] FabricVariants { get; set; }

        public ItemVariant[] BodyVariants { get; set; }

        public ushort MaxStackSize { get; set; }
        
        public ItemKind Kind { get; set; }
    }
}