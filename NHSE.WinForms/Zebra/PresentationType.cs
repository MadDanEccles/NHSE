using System;
using Newtonsoft.Json;

namespace NHSE.WinForms.Zebra
{
    [Flags]
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum PresentationType
    {
        None = 0x00,
        Placed = 0x01,
        Dropped = 0x02,
        Buried = 0x04,
        Hung = 0x08,
        Recipe = 0x10
    }
}