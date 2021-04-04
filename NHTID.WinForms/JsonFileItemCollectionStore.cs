using System;
using System.IO;
using Newtonsoft.Json;
using Nhtid.WinForms.Controls;

namespace Nhtid.WinForms
{
    public class JsonFileItemCollectionStore : IItemCollectionStore
    {
        public static string FilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "collections.json");

        private readonly Lazy<ItemCollectionCatalog> root;
        public ItemCollectionCatalog Root => root.Value;

        public JsonFileItemCollectionStore()
        {
            root = new Lazy<ItemCollectionCatalog>(Load);
        }

        public void Save()
        {
            var serializer = new JsonSerializer();
            using var fileStream = File.Create(FilePath);
            using var sw = new StreamWriter(fileStream);
            using var writer = new JsonTextWriter(sw);
            serializer.Serialize(writer, Root);
        }

        private static ItemCollectionCatalog Load()
        {
            if (File.Exists(FilePath))
            {
                var serializer = new JsonSerializer();
                using var fileStream = File.OpenRead(FilePath);
                using var sr = new StreamReader(fileStream);
                using var reader = new JsonTextReader(sr);
                var result = serializer.Deserialize<ItemCollectionCatalog>(reader);
                Fix(result);
                result.Collections.Sort(new ItemCollectionComparer());
                return result;
            }
            else
            {
                return new ItemCollectionCatalog();
            }
        }

        private static void Fix(ItemCollectionCatalog result)
        {
            foreach (var collection in result.Collections)
            {
                if (collection.Id == Guid.Empty)
                    collection.Id = Guid.NewGuid();
                foreach (var itemId in collection.ItemIds)
                {
                    collection.Members.Add(new CollectionMember{Type = CollectionMemberType.Item, ItemId = itemId});
                }
                collection.ItemIds.Clear();
            }
        }

        public void Backup()
        {
            if (File.Exists(FilePath))
            {
                string backupFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"collections_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.json");
                File.Copy(FilePath, backupFilePath);
            }
        }

        public void Start()
        {
            Load();
        }
    }
}