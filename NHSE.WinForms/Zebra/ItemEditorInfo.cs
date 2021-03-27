using System.Collections.Generic;
using System.Linq;
using NHSE.Core;

namespace NHSE.WinForms.Zebra
{
    public class ItemEditorInfo
    {
        public static ItemEditorInfo FromItemId(ushort itemId)
        {
            var remake = ItemRemakeUtil.GetRemakeIndex(itemId);
            ItemVariant[] bodyVariants;
            ItemVariant[] fabricVariants;

            if (remake >= 0)
            {
                ItemRemakeInfo info = ItemRemakeInfoData.List[remake];
                bodyVariants = GetBodyVariants(info).ToArray();
                fabricVariants = GetFabricVariants(info).ToArray();
            }
            else
            {
                bodyVariants = null;
                fabricVariants = null;
            }

            if (!ItemInfo.TryGetMaxStackCount(itemId, out var maxStackSize))
                maxStackSize = 1;
            var permittedPresentationTypes = ItemConvertor.Instance.GetPermittedPresentationTypes(itemId);
            return new ItemEditorInfo()
            {
                ItemId = itemId,
                Kind = ItemInfo.GetItemKind(itemId),
                PermittedPresentationTypes =  permittedPresentationTypes,
                HasVariants = remake > 0,
                MaxStackSize = maxStackSize,
                BodyVariants = bodyVariants,
                FabricVariants = fabricVariants,
            };
        }

        public PresentationType PermittedPresentationTypes { get; private set; }

        public bool CanBury => PermittedPresentationTypes.HasFlag(PresentationType.Buried);
        public bool CanDrop => PermittedPresentationTypes.HasFlag(PresentationType.Dropped);
        public bool CanPlace => PermittedPresentationTypes.HasFlag(PresentationType.Placed);
        public bool CanHang => PermittedPresentationTypes.HasFlag(PresentationType.Hung);
        public bool CanRecipe => PermittedPresentationTypes.HasFlag(PresentationType.Recipe);

        public ushort ItemId { get; private set; }

        public bool HasVariants { get; private set; }

        public ItemVariant[] FabricVariants { get; private set; }

        public ItemVariant[] BodyVariants { get; private set; }

        public ushort MaxStackSize { get; private set; }

        private static IEnumerable<ItemVariant> GetBodyVariants(ItemRemakeInfo info)
        {
            for (int i = 0; i < 8; i++)
            {
                var cd = info.GetBodyDescription(i);
                var name = $"{info.ItemUniqueID:00000}_{i}";
                var hasBody = GameInfo.Strings.BodyColor.TryGetValue(name, out var desc);

                if (hasBody && cd != ItemRemakeInfo.Invalid)
                    yield return new ItemVariant((ushort) i, $"{desc} ({cd})");
                else if (hasBody)
                    yield return new ItemVariant((ushort) i, desc);
            }
        }

        private static IEnumerable<ItemVariant> GetFabricVariants(ItemRemakeInfo info)
        {
            for (int i = 0; i < 8; i++)
            {
                var cd = info.GetFabricDescription(i);
                if (cd == ItemRemakeInfo.Invalid)
                    continue;

                var shifted = (i << 5);
                var name = $"{info.ItemUniqueID:00000}_{i}";
                if (GameInfo.Strings.FabricColor.TryGetValue(name, out var desc))
                    yield return new ItemVariant((ushort) shifted, $"{desc} ({cd})");
                else
                    yield return new ItemVariant((ushort) shifted, cd);
            }
        }

        public ItemKind Kind { get; private set; }
    }
}