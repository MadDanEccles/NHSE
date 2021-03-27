using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NHSE.Core;
using NHSE.WinForms.Zebra.Catalog;

namespace NHSE.WinForms.Zebra
{

    internal class ItemConvertor
    {
        private readonly CatalogRoot catalog;
        private const int RedsWallDisplayId = 12634;
        private readonly Dictionary<ushort, PresentationType> presentationTypesByItemId = new Dictionary<ushort, PresentationType>();
        private readonly Dictionary<ItemKind, PresentationType> presentationTypesByItemKind = new Dictionary<ItemKind, PresentationType>();
        private readonly Dictionary<ushort, ushort> reverseRecipeLookup = new Dictionary<ushort, ushort>();

        public ushort GetItemId(Item item)
        {
            if (IsHung(item))
                return item.Count;
            if (IsRecipe(item))
                return RecipeList.Recipes[item.Count];
            return item.ItemId;
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


        public static ItemConvertor Instance { get; private set; }
        

        public static void Initialise()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "catalog.json");
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new StringEnumConverter());
            using var fileStream = File.OpenRead(filePath);
            using var sr = new StreamReader(fileStream);
            using var reader = new JsonTextReader(sr);
            var catalog = serializer.Deserialize<CatalogRoot>(reader);
            Instance = new ItemConvertor(catalog);

        }

        public ItemConvertor(CatalogRoot catalog)
        {
            this.catalog = catalog;
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

        public void ApplyPresentation(Item item, params PresentationType[] presentationTypes)
        {
            var itemId = GetItemId(item);
            var permittedPresentationTypes = GetPermittedPresentationTypes(itemId);
            foreach (var presentationType in presentationTypes)
            {
                if (!permittedPresentationTypes.HasFlag(presentationType))
                    continue;

                ApplyPresentationInternal(item, presentationType);
                return;
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
                    item.SystemParam = 0x20;
                    break;
                case PresentationType.Placed:
                    // Clear buried or dropped flags...
                    item.SystemParam = (byte) (item.SystemParam & ~0x24);
                    break;
                case PresentationType.Buried:
                    // Apply buried flag
                    item.SystemParam = 0x04;
                    break;
                case PresentationType.Recipe:
                    item.Count = reverseRecipeLookup[item.ItemId];
                    item.ItemId = Item.DIYRecipe;
                    item.SystemParam = 0x00;
                    break;
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
    }
}