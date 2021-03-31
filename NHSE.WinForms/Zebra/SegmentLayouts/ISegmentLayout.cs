using System.Drawing;

namespace NHSE.WinForms.Zebra.SegmentLayouts
{
    public interface ISegmentLayout
    {
        void CalculateResult(MapToolContext ctx, Rectangle tileRect, ItemFieldFragment fragment);

        Size CalculateMinimumTileSize();

        Size CalculatePreferredTileSize(Size proposedSize);
    }
}