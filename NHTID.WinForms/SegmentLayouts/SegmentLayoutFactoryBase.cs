using System;
using NHSE.Core;

namespace Nhtid.WinForms.SegmentLayouts
{
    abstract class SegmentLayoutFactoryBase<TSettings> : ISegmentLayoutFactory
        where TSettings : class
    {
        public Type SettingsType => typeof(TSettings);

        object? ISegmentLayoutFactory.Settings
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

        public virtual bool IsApplicable(ushort itemId)
        {
            return true;
        }

        public abstract ISegmentLayout Create(Item rawItem);
        public abstract string Name { get; }
    }
}