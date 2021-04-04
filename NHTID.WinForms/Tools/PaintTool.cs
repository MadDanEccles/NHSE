using System.Windows.Forms;
using Nhtid.WinForms.Tools.Actions;

namespace Nhtid.WinForms.Tools
{
    public class PaintTool : MapToolBase
    {
        private readonly IItemSelector options;
        private readonly IHistoryService historyService;
        private readonly IPickTarget pickTarget;

        public PaintTool(IItemSelector options, IHistoryService historyService, IPickTarget pickTarget)
        {
            this.options = options;
            this.historyService = historyService;
            this.pickTarget = pickTarget;
        }

        protected override IMouseAction GetMouseAction(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (modifierKeys.HasFlag(Keys.Alt))
            {
                return new PanZoomMouseAction();
            }
            else if (modifierKeys.HasFlag(Keys.Control))
            {
                return new PickAction(pickTarget);
            }
            else
            {
                return new PaintAction(historyService, options.GetItem());
            }
        }
    }
}