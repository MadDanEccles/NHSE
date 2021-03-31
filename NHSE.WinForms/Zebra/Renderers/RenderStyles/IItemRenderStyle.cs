using System.Drawing;
using NHSE.Core;

namespace NHSE.WinForms.Zebra.Renderers.RenderStyles
{
    public interface IItemRenderStyle
    {
        void DrawItem(Graphics gfx, MapRenderContext context, Rectangle itemRect, Item item);
    }
}