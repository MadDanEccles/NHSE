using NHSE.Core;

namespace Nhtid.WinForms
{
    public class ItemEditorInfo
    {
        public ItemEditorInfo(PresentationType permittedPresentationTypes, ushort itemId, bool hasVariants,
            ItemVariant[]? fabricVariants, ItemVariant[]? bodyVariants, ushort maxStackSize, ItemKind kind)
        {
            PermittedPresentationTypes = permittedPresentationTypes;
            ItemId = itemId;
            HasVariants = hasVariants;
            FabricVariants = fabricVariants;
            BodyVariants = bodyVariants;
            MaxStackSize = maxStackSize;
            Kind = kind;
        }

        public PresentationType PermittedPresentationTypes { get; }

        public bool CanBury => PermittedPresentationTypes.HasFlag(PresentationType.Buried);
        public bool CanDrop => PermittedPresentationTypes.HasFlag(PresentationType.Dropped);
        public bool CanPlace => PermittedPresentationTypes.HasFlag(PresentationType.Placed);
        public bool CanHang => PermittedPresentationTypes.HasFlag(PresentationType.Hung);
        public bool CanRecipe => PermittedPresentationTypes.HasFlag(PresentationType.Recipe);

        public ushort ItemId { get; }

        public bool HasVariants { get; }

        public ItemVariant[]? FabricVariants { get; }

        public ItemVariant[]? BodyVariants { get; }

        public ushort MaxStackSize { get; }
        
        public ItemKind Kind { get; }
    }
}