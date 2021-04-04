using System.Windows.Forms;
using Nhtid.WinForms.Tools.Actions;

namespace Nhtid.WinForms.Tools
{
    public class FillRectTool : MapToolBase
    {
        private readonly IItemSelector options;
        private readonly IHistoryService historyService;

        public FillRectTool(IItemSelector options, IHistoryService historyService)
        {
            this.options = options;
            this.historyService = historyService;
        }

        protected override IMouseAction GetMouseAction(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (modifierKeys.HasFlag(Keys.Alt))
            {
                return new PanZoomMouseAction();
            }
            else
            {
                var item = options.GetItem();
                if (!item.IsRoot)
                {
                    MessageBox.Show(ctx.Viewport, "Please select a valid item before drawing", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                return new FillRectAction(historyService, item);
            }
        }
    }
}