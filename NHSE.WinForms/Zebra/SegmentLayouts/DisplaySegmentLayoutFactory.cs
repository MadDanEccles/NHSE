using NHSE.Core;

namespace NHSE.WinForms.Zebra.SegmentLayouts
{
    class DisplaySegmentLayoutFactory : SegmentLayoutFactoryBase<DisplaySegmentLayoutOptions>
    {
        public DisplaySegmentLayoutFactory()
        {
            this.Options = new DisplaySegmentLayoutOptions();
        }

        public override bool IsApplicable(ushort itemId)
        {
            return true;
        }

        public override ISegmentLayout Create(Item rawItem)
        {
            return new DisplaySegmentLayout(rawItem, this.Options);
        }

        public override string Name => "Display Stand Layout";
    }
}