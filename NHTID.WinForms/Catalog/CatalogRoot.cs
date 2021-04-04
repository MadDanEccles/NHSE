using Newtonsoft.Json;

namespace Nhtid.WinForms.Catalog
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
}