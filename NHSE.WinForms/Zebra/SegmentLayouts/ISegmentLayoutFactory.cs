using System;
using NHSE.Core;

namespace NHSE.WinForms.Zebra.SegmentLayouts
{
    public interface ISegmentLayoutFactory
    {
        Type SettingsType { get; }

        object Settings { get; set; }

        bool IsApplicable(ushort itemId);

        ISegmentLayout Create(Item rawItem);
        public string Name { get; }
    }
}