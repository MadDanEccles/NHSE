using System;

namespace NHSE.WinForms.Zebra.SegmentLayouts
{
    public static class LayoutExtensions
    {
        public static FlowDirection Reverse(this FlowDirection value, FlowScheme scheme)
        {
            return value switch
            {
                FlowDirection.LeftToRight => scheme == FlowScheme.LR_LR ? FlowDirection.LeftToRight : FlowDirection.RightToLeft,
                FlowDirection.RightToLeft => FlowDirection.LeftToRight,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}