﻿using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NHSE.WinForms.Zebra.Controls;

namespace NHSE.WinForms.Zebra
{
    public static class ItemCollectionManager
    {
        public static string FilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "collections.json");

        public static void Save(ItemCollectionCatalog catalog)
        {
            var serializer = new JsonSerializer();
            using var fileStream = File.Create(FilePath);
            using var sw = new StreamWriter(fileStream);
            using var writer = new JsonTextWriter(sw);
            serializer.Serialize(writer, catalog);
        }

        public static ItemCollectionCatalog Load()
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

        public static void Backup()
        {
            if (File.Exists(FilePath))
            {
                string backupFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"collections_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.json");
                File.Copy(FilePath, backupFilePath);
            }
        }
    }
}