using System.Drawing;
using System.Windows.Forms;
using NHSE.Core;
using Nhtid.WinForms.SegmentLayouts;

namespace Nhtid.WinForms.Tools.Actions
{
    internal class MultiSegmentTemplateAction : FillRectActionBase
    {
        private Item[] items;
        private ISegmentLayout[] segmentLayouts;
        private Size[] minSegementSizes;
        private IMultiSegmentLayout layout;
        private int rowCount = 1;

        public MultiSegmentTemplateAction(IHistoryService historyService, Item[] items,
            ISegmentLayoutFactory factory, IMultiSegmentLayout multiSegmentLayout)
            : base(historyService)
        {
            this.items = items;
            segmentLayouts = new ISegmentLayout[items.Length];
            minSegementSizes = new Size[items.Length];
            this.layout = multiSegmentLayout;

            for (var index = 0; index < items.Length; index++)
            {
                var item = items[index];
                segmentLayouts[index] = factory.Create(item);
                minSegementSizes[index] = segmentLayouts[index].CalculateMinimumTileSize();
            }

        }

        protected override void CalculateResult(MapToolContext ctx, Rectangle marqueeBounds,
            out ItemFieldFragment fragment, out string hint)
        {
            var tileRect = ctx.ToTiles(marqueeBounds).Quantize(2);
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
}