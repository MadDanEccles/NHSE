using System.Windows.Forms;
using Nhtid.WinForms.Tools.Actions;

namespace Nhtid.WinForms.Tools
{
    public class PanTool : MapToolBase
    {
        protected override IMouseAction GetMouseAction(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            return new PanZoomMouseAction();
        }
    }
}