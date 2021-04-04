using NHSE.Core;

namespace Nhtid.WinForms.SegmentLayouts
{
    class DisplaySegmentLayoutFactory : SegmentLayoutFactoryBase<DisplaySegmentLayoutOptions>
    {
        private readonly ItemConvertor itemConvertor;

        public DisplaySegmentLayoutFactory(ItemConvertor itemConvertor)
        {
            this.itemConvertor = itemConvertor;
            this.Options = new DisplaySegmentLayoutOptions();
        }

        public override bool IsApplicable(ushort itemId)
        {
            return true;
        }

        public override ISegmentLayout Create(Item rawItem)
        {
            return new DisplaySegmentLayout(itemConvertor, rawItem, this.Options);
        }

        public override string Name => "Display Stand Layout";
    }
}