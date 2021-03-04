using System.Drawing;
using System.Windows.Forms;

namespace NHSE.WinForms.Zebra.Tools
{
    internal interface IDragAction
    {
        void Start(Point startLocation, MapToolContext ctx);
        void Move(Point location, MapToolContext ctx);
        void End(Point location, Keys modifierKeys, MapToolContext ctx);
    }
}