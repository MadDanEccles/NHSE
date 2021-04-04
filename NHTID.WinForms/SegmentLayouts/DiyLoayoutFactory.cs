using System;
using NHSE.Core;

namespace Nhtid.WinForms.SegmentLayouts
{
    class DiyLoayoutFactory : ISegmentLayoutFactory
    {
        private readonly ItemConvertor itemConvertor;

        public DiyLoayoutFactory(ItemConvertor itemConvertor)
        {
            this.itemConvertor = itemConvertor;
        }

        public Type SettingsType => null;
        public object Settings { get; set; }
        public bool IsApplicable(ushort itemId)
        {
            return itemConvertor.FromItemId(itemId).CanRecipe;
        }

        public ISegmentLayout Create(Item rawItem)
        {
            return new DiySegmentLayout(itemConvertor, rawItem);
        }

        public string Name => "DIYs Only";
    }
}