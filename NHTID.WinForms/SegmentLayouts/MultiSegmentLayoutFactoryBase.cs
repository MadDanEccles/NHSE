using System;

namespace Nhtid.WinForms.SegmentLayouts
{
    public abstract class MultiSegmentLayoutFactoryBase<TSettings> : IMultiSegmentLayoutFactory
        where TSettings : class
    {
        public Type SettingsType => typeof(TSettings);

        object? IMultiSegmentLayoutFactory.Settings
        {
            get => Options;
            set
            {
                TSettings? newSettings = (TSettings?)value;
                if (newSettings != Options)
                {
                    Options = newSettings;
                    OnSettingsChanged();
                }
            }
        }

        protected TSettings? Options { get; set; }

        protected virtual void OnSettingsChanged()
        {
        }

        public abstract IMultiSegmentLayout Create();
        public abstract string Name { get; }
    }
}