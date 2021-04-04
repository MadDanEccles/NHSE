namespace Nhtid.WinForms.SegmentLayouts
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