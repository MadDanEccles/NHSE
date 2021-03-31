using System.Diagnostics;
using System.Drawing;
using System.Linq;
using NHSE.WinForms.Zebra.Tools;

namespace NHSE.WinForms.Zebra.SegmentLayouts
{
    internal class JustifiedMultiSegmentLayout : IMultiSegmentLayout
    {
        private readonly GridLayoutOptions options;

        public JustifiedMultiSegmentLayout(GridLayoutOptions options)
        {
            this.options = options;
        }

        public bool GetSegmentRects(Rectangle tileRect, ISegmentLayout[] segmentLayouts,
            Size[] minSegementSizes, int rowCount, out Rectangle[] segmentRects, out string hint)
        {
            segmentRects = new Rectangle[segmentLayouts.Length];

            int baseSegsPerRow = segmentLayouts.Length / rowCount;
            int rowsWithOneExtraSeg = segmentLayouts.Length % rowCount;
            int rowHeight = (tileRect.Height - options.HorizontalGutter * (rowCount - 1)) / rowCount;

            if (minSegementSizes.Any(i => i.Height > rowHeight))
            {
                hint = $"{rowCount} rows; Not tall enough...";
                return false;
            }

            // Create an array to hold the number of segments in each row; populate it so that each 
            // row holds the same number with any imbalance going to the topmost rows.
            int[] rowSegmentCounts = new int[rowCount];
            for (int i = 0; i < rowCount; i++)
                rowSegmentCounts[i] = baseSegsPerRow + (i < rowsWithOneExtraSeg ? 1 : 0);

            // Now measure the minimum width of the segments in each row (except the last) and push segments
            // down to the rows below until each row fits...
            int rowFirstSegment = 0;
            for (int rowIndex = 0; rowIndex < rowCount - 1; rowIndex++)
            {
                while (CalculateRowWidth(minSegementSizes, rowFirstSegment, rowSegmentCounts[rowIndex]) > tileRect.Width)
                {
                    rowSegmentCounts[rowIndex]--;
                    if (rowSegmentCounts[rowIndex] == 0)
                    {
                        hint = $"{rowCount} rows; Not wide enough...";
                        return false;
                    }

                    rowSegmentCounts[rowIndex + 1]++;
                }

                rowFirstSegment += rowSegmentCounts[rowIndex];
            }

            // Check the final row to ensure that it fits, if not then we simply don't have enough space...
            if (CalculateRowWidth(minSegementSizes, rowFirstSegment, rowSegmentCounts[rowCount - 1]) > tileRect.Width)
            {
                hint = $"{rowCount} rows; Not wide enough...";
                return false;
            }

            // Now draw out each segment, allocating extra space roughly equally...
            rowFirstSegment = 0;
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                int rowSegmentCount = rowSegmentCounts[rowIndex];
                int[] segmentWidths = new int[rowSegmentCount];
                int minRowWidth = CalculateRowWidth(minSegementSizes, rowFirstSegment, rowSegmentCount);
                int surplusWidth = tileRect.Width - minRowWidth;

                for (int segmentOffset = 0; segmentOffset < rowSegmentCount; segmentOffset++)
                    segmentWidths[segmentOffset] = minSegementSizes[rowFirstSegment + segmentOffset].Width;

                for (int x = 0; x < surplusWidth - 2; x += 2)
                {
                    int index = segmentWidths.IndexOfMin();
                    segmentWidths[index] += 2;
                }


                int segmentLeft = tileRect.Left;
                for (int segmentIndex = rowFirstSegment;
                    segmentIndex < rowFirstSegment + rowSegmentCount;
                    segmentIndex++)
                {
                    var segmentWidth = segmentWidths[segmentIndex - rowFirstSegment];
                    segmentRects[segmentIndex] = new Rectangle(
                        segmentLeft,
                        tileRect.Top + (rowHeight + options.HorizontalGutter) * rowIndex,
                        segmentWidth,
                        rowHeight);
                    
                    if(!tileRect.Contains(segmentRects[segmentIndex]))
                        Debugger.Break();
                    segmentLeft += segmentWidth + options.VerticalGutter;
                }

                rowFirstSegment += rowSegmentCounts[rowIndex];
            }

            hint = string.Empty;
            return true;
        }

        private int CalculateRowWidth(Size[] minSegementSizes, int rowFirstSegment, int rowSegmentCount)
        {
            int result = 0;
            for(int i = rowFirstSegment; i < rowFirstSegment + rowSegmentCount; i++)
                result += minSegementSizes[i].Width + options.VerticalGutter * (rowSegmentCount - 1);
            return result;
        }
    }
}