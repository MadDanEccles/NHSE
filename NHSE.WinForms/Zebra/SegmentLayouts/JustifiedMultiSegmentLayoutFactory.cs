namespace NHSE.WinForms.Zebra.SegmentLayouts
{
    public class JustifiedMultiSegmentLayoutFactory : MultiSegmentLayoutFactoryBase<GridLayoutOptions>
    {
        public JustifiedMultiSegmentLayoutFactory()
        {
            Options = new GridLayoutOptions();
        }

        public override IMultiSegmentLayout Create()
        {
            return new JustifiedMultiSegmentLayout(Options);
        }

        public override string Name => "Justified";
    }
}