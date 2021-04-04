using System.Drawing;
using NHSE.Core;
using Nhtid.WinForms.SegmentLayouts;

namespace Nhtid.WinForms.Tools.Actions
{
    internal class SingleSegmentTemplateAction : FillRectActionBase
    {
        private readonly ISegmentLayout segmentLayout;

        public SingleSegmentTemplateAction(IHistoryService historyService, ItemConvertor itemConvertor, Item item) : base(historyService)
        {
            segmentLayout = new DisplaySegmentLayout(itemConvertor, item, new DisplaySegmentLayoutOptions());
        }

        protected override void CalculateResult(MapToolContext ctx, Rectangle marqueeBounds, out ItemFieldFragment fragment, out string hint)
        {
            Rectangle tileRect = ctx.ToTiles(marqueeBounds);
            fragment = new ItemFieldFragment();
            segmentLayout.CalculateResult(ctx, tileRect, fragment);
            hint = "";  //droppedItemCount > 0 ? $"{droppedItemCount} Items" : "-";
        }
    }
}