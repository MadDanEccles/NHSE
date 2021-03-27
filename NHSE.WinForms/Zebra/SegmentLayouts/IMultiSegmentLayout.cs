using System.Drawing;

namespace NHSE.WinForms.Zebra.SegmentLayouts
{
    internal interface IMultiSegmentLayout
    {
        bool GetSegmentRects(Rectangle tileRect, ITemplateSegmentLayout[] segmentLayouts,
            Size[] minSegementSizes, int rowCount, out Rectangle[] segmentRects, out string hint);
    }
}