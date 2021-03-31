using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.WinForms.Zebra.Controls;
using NHSE.WinForms.Zebra.SegmentLayouts;

namespace NHSE.WinForms.Zebra.Tools
{
    public class MultiTemplateTool : FillRectToolBase
    {
        private readonly MultiItemSelector multiItemSelector;
        private Item[] items;
        private ISegmentLayout[] segmentLayouts;
        private Size[] minSegementSizes;

        private int rowCount = 1;

        private IMultiSegmentLayout layout;

        public MultiTemplateTool(IHistoryService historyService, MultiItemSelector multiItemSelector)
            : base(historyService)
        {
            this.multiItemSelector = multiItemSelector;
        }

        protected override bool OnStartDrag(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            this.layout = multiItemSelector.GetMultiFactory().Create();
            var factory = multiItemSelector.GetFactory();
            this.items = multiItemSelector.ResolveItems().Where(i => factory.IsApplicable(i.ItemId)).ToArray();
            if (this.items.Length == 0)
            {
                MessageBox.Show(ctx.Viewport, "Please select one or more items before using the template", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            segmentLayouts = new ISegmentLayout[items.Length];
            minSegementSizes = new Size[items.Length];

            for (var index = 0; index < items.Length; index++)
            {
                var item = items[index];
                segmentLayouts[index] = factory.Create(item);
                minSegementSizes[index] = segmentLayouts[index].CalculateMinimumTileSize();
            }

            return true;
        }

        protected override void CalculateResult(MapToolContext ctx, Rectangle marqueeBounds,
            out ItemFieldFragment fragment, out string hint)
        {
            var tileRect = ctx.ToTiles(marqueeBounds);
            fragment = new ItemFieldFragment();
            hint = $"{segmentLayouts.Length} Item(s)";
            if (layout.GetSegmentRects(tileRect, segmentLayouts, minSegementSizes, rowCount, out var segmentRects,
                out var templateHint))
            {
                for (int segmentIndex = 0;
                    segmentIndex < segmentLayouts.Length;
                    segmentIndex++)
                {
                    segmentLayouts[segmentIndex].CalculateResult(ctx, segmentRects[segmentIndex], fragment);
                }
            }

            if (!string.IsNullOrWhiteSpace(templateHint))
                hint = $"{hint} - {templateHint}";
        }

        public override bool OnKeyDown(Keys e, MapToolContext ctx)
        {
            if (IsDragging)
            {
                if (e == Keys.Up)
                {
                    if (rowCount < 50)
                    {
                        rowCount++;
                        InvalidateFragment(ctx);
                    }
                }
                else if (e == Keys.Down)
                {
                    if (rowCount > 1)
                    {
                        rowCount--;
                        InvalidateFragment(ctx);
                    }
                }
            }

            return true;
        }
    }

    public static class CollectionExtensions
    {
        public static int IndexOfMin<T>(this T[] collection) where T : IComparable<T>
        {
            T min = collection[0];
            int result = 0;
            for (int x = 1; x < collection.Length; x++)
            {
                if (collection[x].CompareTo(min) < 0)
                {
                    min = collection[x];
                    result = x;
                }
            }

            return result;
        }
    }
}