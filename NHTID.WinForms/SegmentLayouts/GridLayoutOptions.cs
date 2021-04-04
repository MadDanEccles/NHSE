namespace Nhtid.WinForms.SegmentLayouts
{
    public class GridLayoutOptions
    {
        public int HorizontalGutter { get; set; } = 2;
        public int VerticalGutter { get; set; } = 0;

        public FlowScheme Flow { get; set; } = FlowScheme.LR_RL;
    }
}