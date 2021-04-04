using Newtonsoft.Json;

namespace Nhtid.WinForms.Catalog
{
    public class ItemPresentationMapping
    {
        [JsonProperty("I")]
        public ushort InventoryId { get; set; }

        [JsonProperty("P")]
        public ushort PlacedId { get; set; }
    }
}