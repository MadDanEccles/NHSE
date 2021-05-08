using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NHSE.Core;
using Nhtid.WinForms.Catalog;

namespace Nhtid.WinForms
{
    public class ItemConvertor
    {
        private const int RedsWallDisplayId = 12634;

        private readonly CatalogRoot catalog;
        private readonly Dictionary<ushort, PresentationType> presentationTypesByItemId = new Dictionary<ushort, PresentationType>();
        private readonly Dictionary<ItemKind, PresentationType> presentationTypesByItemKind = new Dictionary<ItemKind, PresentationType>();
        private readonly Dictionary<ushort, ushort> reverseRecipeLookup = new Dictionary<ushort, ushort>();
        private readonly Dictionary<ushort, ushort> creatureModelLookup = new Dictionary<ushort, ushort>(); // Creature => Creature Model
        private readonly Dictionary<ushort, ushort> placedItemLookup = new Dictionary<ushort, ushort>(); // DropID => PlacedID
        private readonly Dictionary<ushort, ushort> reversePlacedItemLookup = new Dictionary<ushort, ushort>(); // PlacedID => DropID
        private readonly ConcurrentDictionary<ushort, ItemEditorInfo> itemEditorInfos = new();

        internal bool CanListInUi(ushort value)
        {
            if (value == 5794)
                return false; // DIY
            if (value == 65534)
                return false; // None
            if (value == 13821)
                return false; // ? Block
            return !reversePlacedItemLookup.ContainsKey(value);
        }



        public ItemConvertor()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "catalog.json");
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new StringEnumConverter());
            using var fileStream = File.OpenRead(filePath);
            using var sr = new StreamReader(fileStream);
            using var reader = new JsonTextReader(sr);
            catalog = serializer.Deserialize<CatalogRoot>(reader);

            foreach (var group in catalog.Groups)
            {
                if (group.ItemIds != null)
                {
                    foreach (var itemId in group.ItemIds)
                    {
                        if (presentationTypesByItemId.ContainsKey(itemId))
                            throw new InvalidOperationException($"Catalog contains duplicate Item ID {itemId}");
                        presentationTypesByItemId.Add(itemId, group.PresentationType);
                    }
                }

                if (group.ItemKinds != null)
                {
                    foreach (var itemKind in group.ItemKinds)
                    {
                        presentationTypesByItemKind.Add(itemKind, group.PresentationType);
                    }
                }
            }

            foreach (var recipe in RecipeList.Recipes)
                reverseRecipeLookup.Add(recipe.Value, recipe.Key);

            foreach (CreatureModelMapping mapping in catalog.CreatureModelMappings)
                this.creatureModelLookup.Add(mapping.CreatureId, mapping.ModelId);

            foreach (var mapping in catalog.ItemPresentationMappings)
            {
                this.placedItemLookup.Add(mapping.InventoryId, mapping.PlacedId);
                this.reversePlacedItemLookup.Add(mapping.PlacedId, mapping.InventoryId);
            }

            using var fs = File.OpenRead(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FgMainParam.json"));
            using var fgStreamReader = new StreamReader(fs);
            using var jr = new JsonTextReader(fgStreamReader);
            JsonSerializer fgMainParamSerializer = new JsonSerializer();
            FgMainParam[] fgMainParams = fgMainParamSerializer.Deserialize<FgMainParam[]>(jr);

            foreach (var fgMainParam in fgMainParams)
            {
                if (fgMainParam.Grow == 3 && ItemInfo.GetItemKind(fgMainParam.DigItem) == ItemKind.Kind_FlowerBud)
                {
                    this.placedItemLookup.Add(fgMainParam.DigItem, fgMainParam.UniqueID);
                    this.reversePlacedItemLookup.Add(fgMainParam.UniqueID, fgMainParam.DigItem);
                }
            }
        }

        public ushort GetItemId(Item item)
        {
            if (IsHung(item))
                return item.Count;
            if (IsRecipe(item))
                return RecipeList.Recipes[item.Count];
            if (IsPlaced(item) && reversePlacedItemLookup.TryGetValue(item.ItemId, out var mappedId))
                return mappedId;
            return item.ItemId;
        }

        private bool IsPlaced(Item item)
        {
            return (item.SystemParam & ~0x03) == 0;
        }

        public ushort GetBodyVariant(Item item)
        {
            if (IsHung(item))
                return item.UseCount;
            if (IsRecipe(item))
                return 0;
            return item.Count;
        }

        public ushort GetFabricVariant(Item item)
        {
            if (IsHung(item))
                return 0;
            if (IsRecipe(item))
                return 0;
            return item.UseCount;
        }

        private static IEnumerable<ItemVariant> GetBodyVariants(ItemRemakeInfo info)
        {
            for (int i = 0; i < 8; i++)
            {
                var cd = info.GetBodyDescription(i);
                var name = $"{info.ItemUniqueID:00000}_{i}";
                var hasBody = GameInfo.Strings.BodyColor.TryGetValue(name, out var desc);

                if (hasBody && cd != ItemRemakeInfo.Invalid)
                    yield return new ItemVariant((ushort)i, $"{desc} ({cd})");
                else if (hasBody)
                    yield return new ItemVariant((ushort)i, desc);
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
                    yield return new ItemVariant((ushort)shifted, $"{desc} ({cd})");
                else
                    yield return new ItemVariant((ushort)shifted, cd);
            }
        }

        public ItemEditorInfo FromItemId(ushort itemId)
        {
            return itemEditorInfos.GetOrAdd(itemId, CreateItemEditorInfo);

        }

        private ItemEditorInfo CreateItemEditorInfo(ushort itemId)
        {
            var remake = ItemRemakeUtil.GetRemakeIndex(itemId);
            ItemVariant[]? bodyVariants;
            ItemVariant[]? fabricVariants;

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
            var permittedPresentationTypes = GetPermittedPresentationTypes(itemId);
            return new ItemEditorInfo(
                permittedPresentationTypes,
                itemId,
                remake > 0,
                fabricVariants,
                bodyVariants,
                maxStackSize,
                ItemInfo.GetItemKind(itemId));
        }


        public PresentationType GetPermittedPresentationTypes(ushort itemId)
        {
            PresentationType result;
            if (!presentationTypesByItemId.TryGetValue(itemId, out result))
            {
                ItemKind itemKind = ItemInfo.GetItemKind(itemId);
                if (!presentationTypesByItemKind.TryGetValue(itemKind, out result))
                    result = catalog.DefaultPresentationType;
            }

            if (reverseRecipeLookup.ContainsKey(itemId))
                result |= PresentationType.Recipe;

            return result;
        }

        public bool IsPermitted(ushort itemId, PresentationType presentationType)
        {
            return GetPermittedPresentationTypes(itemId).HasFlag(presentationType);
        }

        public Item ApplyPresentation(Item item, params PresentationType[] presentationTypes)
        {
            var itemId = GetItemId(item);
            var permittedPresentationTypes = GetPermittedPresentationTypes(itemId);
            foreach (var presentationType in presentationTypes)
            {
                if (!permittedPresentationTypes.HasFlag(presentationType))
                    continue;

                ApplyPresentationInternal(item, presentationType);
                return item;
            }

            throw new Exception("Presentation not permitted for item");
        }

        private void ApplyPresentationInternal(Item item, PresentationType presentationType)
        {
            RevertItem(item);
            switch (presentationType)
            {
                case PresentationType.Hung:
                    item.UseCount = item.Count;
                    item.Count = item.ItemId;
                    item.ItemId = RedsWallDisplayId;
                    item.SystemParam = 0x00;
                    break;
                case PresentationType.Dropped:
                    {
                        if (reversePlacedItemLookup.TryGetValue(item.ItemId, out var mappedValue))
                            item.ItemId = mappedValue;
                        item.SystemParam = 0x20;
                        break;
                    }
                case PresentationType.Placed:
                    {
                        // Clear buried or dropped flags...
                        if (placedItemLookup.TryGetValue(item.ItemId, out var mappedValue))
                            item.ItemId = mappedValue;
                        item.SystemParam = (byte)(item.SystemParam & ~0x24);
                        var kind = ItemInfo.GetItemKind(item.ItemId);
                        // When placing a fence, default it to facing forward.
                        if (kind == ItemKind.Kind_Fence)
                            item.SystemParam |= 0x01;
                        break;
                    }
                case PresentationType.Buried:
                    {
                        // Apply buried flag
                        if (reversePlacedItemLookup.TryGetValue(item.ItemId, out var mappedValue))
                            item.ItemId = mappedValue;
                        item.SystemParam = 0x04;
                        break;
                    }
                case PresentationType.Recipe:
                    {
                        if (reversePlacedItemLookup.TryGetValue(item.ItemId, out var mappedValue))
                            item.ItemId = mappedValue;
                        item.Count = reverseRecipeLookup[item.ItemId];
                        item.ItemId = Item.DIYRecipe;
                        item.SystemParam = 0x00;
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(presentationType), presentationType, null);
            }
        }

        /// <summary>
        /// Reverts an item from a hung display or recipe into its base item.
        /// </summary>
        /// <param name="item"></param>
        private void RevertItem(Item item)
        {
            // Only take action if the item is a red's wall display
            if (IsHung(item))
            {
                item.ItemId = item.Count;
                item.Count = item.UseCount;
                item.UseCount = 0;
            }
            else if (IsRecipe(item))
            {
                if (!RecipeList.Recipes.TryGetValue(item.Count, out var itemId))
                    throw new InvalidOperationException("Unrecognised recipe");
                item.ItemId = itemId;
                item.Count = 1;
            }
        }

        public bool IsRecipe(Item item) => item.ItemId == Item.DIYRecipe;

        public bool IsHung(Item item) => item.ItemId == RedsWallDisplayId;

        public ushort GetCreatureModel(ushort itemId)
        {
            return this.creatureModelLookup[itemId];
        }
    }

    public class FgMainParam
    {
        public ushort UniqueID { get; set; }
        public int Grow { get; set; }
        public ushort DigItem { get; set; }
    }
}