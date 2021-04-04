using System.Windows.Forms;
using Nhtid.WinForms.Tools.Actions;

namespace Nhtid.WinForms.Tools
{
    public class PickTool : MapToolBase
    {
        private readonly IPickTarget pickTarget;

        public PickTool(IPickTarget pickTarget)
        {
            this.pickTarget = pickTarget;
        }

        protected override IMouseAction GetMouseAction(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (modifierKeys.HasFlag(Keys.Alt))
            {
                return new PanZoomMouseAction();
            }
            else
            {
                return new PickAction(pickTarget);
            }
        }
    }
}