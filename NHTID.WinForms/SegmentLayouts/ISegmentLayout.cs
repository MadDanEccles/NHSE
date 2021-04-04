using System.Drawing;

namespace Nhtid.WinForms.SegmentLayouts
{
    public interface ISegmentLayout
    {
        void CalculateResult(MapToolContext ctx, Rectangle tileRect, ItemFieldFragment fragment);

        Size CalculateMinimumTileSize();

        Size CalculatePreferredTileSize(Size proposedSize);
    }
}