using System;
using NHSE.Core;

namespace NHSE.WinForms.Zebra.SegmentLayouts
{
    class DiyLoayoutFactory : ISegmentLayoutFactory
    {
        public Type SettingsType => null;
        public object Settings { get; set; }
        public bool IsApplicable(ushort itemId)
        {
            return ItemEditorInfo.FromItemId(itemId).CanRecipe;
        }

        public ISegmentLayout Create(Item rawItem)
        {
            return new DiySegmentLayout(rawItem);
        }

        public string Name => "DIYs Only";
    }
}