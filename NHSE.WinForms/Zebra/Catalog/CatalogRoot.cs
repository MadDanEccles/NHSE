using Newtonsoft.Json;

namespace NHSE.WinForms.Zebra.Catalog
{
    public class CatalogRoot
    {
        public PresentationType DefaultPresentationType { get; set; }
        public ItemAttributeGroup[] Groups { get; set; }

        [JsonProperty("CreatureMap")]
        public CreatureModelMapping[] CreatureModelMappings { get; set; }

        [JsonProperty("PresentationMap")]
        public ItemPresentationMapping[] ItemPresentationMappings { get; set; }

    }

    public class ItemPresentationMapping
    {
        [JsonProperty("I")]
        public ushort InventoryId { get; set; }

        [JsonProperty("P")]
        public ushort PlacedId { get; set; }
    }

    public class CreatureModelMapping
    {
        [JsonProperty("C")]
        public ushort CreatureId { get; set; }
        [JsonProperty("M")]
        public ushort ModelId { get; set; }
    }
}