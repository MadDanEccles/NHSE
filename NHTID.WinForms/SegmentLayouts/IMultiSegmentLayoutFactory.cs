using System;

namespace Nhtid.WinForms.SegmentLayouts
{
    public interface IMultiSegmentLayoutFactory
    {
        Type SettingsType { get; }

        object Settings { get; set; }

        IMultiSegmentLayout Create();
        public string Name { get; }
    }
}