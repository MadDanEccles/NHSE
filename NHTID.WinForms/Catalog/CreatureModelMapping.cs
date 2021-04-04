using Newtonsoft.Json;

namespace Nhtid.WinForms.Catalog
{
    public class CreatureModelMapping
    {
        [JsonProperty("C")]
        public ushort CreatureId { get; set; }
        [JsonProperty("M")]
        public ushort ModelId { get; set; }
    }
}