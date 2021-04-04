namespace Nhtid.WinForms.SegmentLayouts
{
    public class MinWidthMultiSegmentLayoutFactory : MultiSegmentLayoutFactoryBase<GridLayoutOptions>
    {
        public MinWidthMultiSegmentLayoutFactory()
        {
            Options = new GridLayoutOptions();
        }

        public override IMultiSegmentLayout Create()
        {
            return new MinWidthMultiSegmentLayout(Options);
        }

        public override string Name => "Minimum Segment Width";
    }
}