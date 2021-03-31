using System;
using System.Drawing;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.WinForms.Zebra.SegmentLayouts;

namespace NHSE.WinForms.Zebra.Tools
{
    public class TemplateTool : FillRectToolBase
    {
        private Item placedItem;
        private Size placedItemSize;
        private Item droppedItem;
        private Size droppedItemSize;

        private readonly IItemSelector options;
        private ISegmentLayout segmentLayout;

        public TemplateTool(IHistoryService historyService, IItemSelector options) : base(historyService)
        {
            this.options = options;
        }

        protected override bool OnStartDrag(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {

            Item rawItem = options.GetItem();

            if (!rawItem.IsRoot)
            {
                MessageBox.Show(ctx.Viewport, "Please select a valid item before drawing", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ushort itemId = ItemConvertor.Instance.GetItemId(rawItem);
            ItemEditorInfo info = ItemEditorInfo.FromItemId(itemId);
           /* if (info.HasVariants)
                segmentLayout = new DisplaySegmentLayout(new Item(itemId) {Count = 0});
            else
                segmentLayout = new DisplaySegmentLayout(new Item(itemId) {Count = (ushort) (info.MaxStackSize - 1)});
           */
           throw new Exception("TODO");
            return true;
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