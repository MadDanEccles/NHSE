using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace NHSE.WinForms.Zebra.SegmentLayouts
{
    internal class MinWidthMultiSegmentLayout : IMultiSegmentLayout
    {
        private int gutterHorz = 0;
        private int gutterVert = 2;
        private int pathWidth = 2;

        public bool GetSegmentRects(Rectangle tileRect, ITemplateSegmentLayout[] segmentLayouts,
            Size[] minSegementSizes, int pathCount, out Rectangle[] segmentRects, out string hint)
        {
            segmentRects = new Rectangle[segmentLayouts.Length];

            int[] pathX = new int[pathCount];

            for (int i = 0; i < pathCount; i++)
            {
                pathX[i] =( tileRect.Width * (i + 1)) / pathCount - pathWidth / 2;
            }

            List<List<int>> rowSegmentCounts = new List<List<int>>();
            int currentX = 0;
            List<int> currentRow = new();
            foreach (Size minSize in minSegementSizes)
            {
                while (true)
                {
                    AdjustXPos(ref currentX, minSize.Width, pathX);
                    if (currentX + minSize.Width <= tileRect.Width)
                        break;

                    if (currentRow.Count == 0)
                    {
                        hint = "Too Narrow";
                        return false;
                    }

                    rowSegmentCounts.Add(currentRow);
                    currentRow = new List<int>();
                    currentX = 0;
                }

                currentRow.Add(currentX);
                currentX += minSize.Width + gutterHorz;
            }

            if (currentRow.Count > 0)
                rowSegmentCounts.Add(currentRow);

            if (rowSegmentCounts.Sum(i => i.Count) != segmentLayouts.Length)
                Debugger.Break();

            var rowCount = rowSegmentCounts.Count;
            int maxUsableHeight = tileRect.Height - gutterVert * (rowCount - 1);
            int initialRowHeight = maxUsableHeight / rowCount;

            // Adapt row heights...

            int segmentIndex = 0;
            int[] rowHeights = new int[rowCount];
            int[] minRowHeights = new int[rowCount];
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                rowHeights[rowIndex] = initialRowHeight;

                for (int colIndex = 0; colIndex < rowSegmentCounts[rowIndex].Count; colIndex++)
                {
                    minRowHeights[rowIndex] = Math.Max(minRowHeights[rowIndex], minSegementSizes[segmentIndex].Height);
                    segmentIndex++;
                }
            }

            if (!AdaptRowHeights(initialRowHeight, rowCount, minRowHeights, rowHeights, maxUsableHeight))
            {
                hint = "Not enough height";
                return false;
            }


            segmentIndex = 0;
            int y = tileRect.Top;
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int colIndex = 0; colIndex < rowSegmentCounts[rowIndex].Count; colIndex++)
                {
                    var segmentWidth = minSegementSizes[segmentIndex].Width;
                    segmentRects[segmentIndex] = new Rectangle(
                        tileRect.Left + rowSegmentCounts[rowIndex][colIndex],
                        y,
                        segmentWidth,
                        rowHeights[rowIndex]);
                    segmentIndex++;
                }
                y += rowHeights[rowIndex] + gutterVert;
            }

            hint = string.Empty;
            return true;
        }

        private void AdjustXPos(ref int x, int width, int[] pathX)
        {
            for (int i = 0; i < pathX.Length; i++)
            {
                if (x < pathX[i] + pathWidth && x + width >= pathX[i])
                {
                    x = pathX[i] + pathWidth;
                }
            }
        }

        private static bool AdaptRowHeights(int initialRowHeight, int rowCount, int[] minRowHeights,
            int[] rowHeights, int maxUsableHeight)
        {
            int totalHeight = initialRowHeight * rowCount;
            bool rowHeightsValid = false;
            while (!rowHeightsValid)
            {
                rowHeightsValid = true;
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    int missingHeight = minRowHeights[rowIndex] - rowHeights[rowIndex];
                    if (missingHeight > 0)
                    {
                        if (maxUsableHeight - totalHeight >= missingHeight)
                        {
                            rowHeights[rowIndex] += missingHeight;
                            totalHeight += missingHeight;
                        }
                        else
                        {
                            rowHeights[rowIndex] += maxUsableHeight - totalHeight;
                            totalHeight = maxUsableHeight;

                            while (missingHeight > 0)
                            {
                                int rowIndexToTakeFrom = GetRowIndexWithMaxExcessHeight(rowHeights, minRowHeights);
                                if (rowIndexToTakeFrom < 0)
                                    return false;

                                int excessHeight = rowHeights[rowIndexToTakeFrom] - minRowHeights[rowIndexToTakeFrom];
                                if (excessHeight >= missingHeight)
                                {
                                    rowHeights[rowIndexToTakeFrom] -= missingHeight;
                                    rowHeights[rowIndex] += missingHeight;
                                    missingHeight = 0;
                                }
                                else
                                {
                                    rowHeights[rowIndexToTakeFrom] -= excessHeight;
                                    rowHeights[rowIndex] += excessHeight;
                                    missingHeight -= excessHeight;
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }

        private static int GetRowIndexWithMaxExcessHeight(int[] rowHeights, int[] minRowHeights)
        {
            int result = -1;
            int maxExcessHeight = 0;

            for (int i = 0; i < rowHeights.Length; i++)
            {
                int excessHeight = rowHeights[i] - minRowHeights[i];
                if (excessHeight > maxExcessHeight)
                {
                    maxExcessHeight = excessHeight;
                    result = i;
                }
            }

            return result;
        }
    }
}