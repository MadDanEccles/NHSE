using System.Drawing;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms.Zebra.Tools
{
    public class FillRectTool : FillRectToolBase
    {
        private readonly IItemSelector options;
        private Item item;
        private Size itemSize;

        public FillRectTool(IItemSelector options, IHistoryService historyService) : base(historyService)
        {
            this.options = options;
        }

        protected override bool OnStartDrag(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            item = options.GetItem();
            if (!item.IsRoot)
            {
                MessageBox.Show(ctx.Viewport, "Please select a valid item before drawing", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            itemSize = item.GetSize();
            return true;
        }

        protected override void CalculateResult(MapToolContext ctx, Rectangle marqueeBounds, out ItemFieldFragment fragment, out string hint)
        {
            fragment = new ItemFieldFragment();
            var tileRect = ctx.ToTiles(marqueeBounds);
            for (int x = tileRect.Left; x <= tileRect.Right - itemSize.Width; x += itemSize.Width)
            {
                for (int y = tileRect.Top; y <= tileRect.Bottom - itemSize.Height; y += itemSize.Height)
                {
                    Rectangle itemTileRect = new Rectangle(x, y, itemSize.Width, itemSize.Height);
                    fragment.Add(itemTileRect, item, ctx.MapEditingService.IsOccupied(itemTileRect));
                }
            }

            int itemsX = tileRect.Width / itemSize.Width;
            int itemsY = tileRect.Height / itemSize.Height;
            hint = $"{itemsX} × {itemsY}";
        }
    }
}