using System.Drawing;
using NHSE.Core;
using NHSE.WinForms.Zebra.Renderers.ColorSchemes;

namespace NHSE.WinForms.Zebra.Renderers.RenderStyles
{
    class DefaultRenderStyle : IItemRenderStyle
    {
        private readonly IColorSchemeProvider colorSchemeProvider;

        public DefaultRenderStyle(IColorSchemeProvider colorSchemeProvider)
        {
            this.colorSchemeProvider = colorSchemeProvider;
        }

        public void DrawItem(Graphics gfx, MapRenderContext context, Rectangle itemRect, Item item)
        {
            var colorScheme = colorSchemeProvider.GetColorScheme();

            if (context.TileSize > 7)
                itemRect = itemRect.Shrink(2, 2, 1, 1);
            else
                itemRect = itemRect.Shrink(1, 1, 0, 0);

            Brush brush = context.ResourceCache.GetSolidBrush(colorScheme.GetItemColor(item));
            if (item.IsDropped)
            {
                gfx.FillPolygon(brush,
                    new Point[]
                    {
                        itemRect.Location,
                        new Point(itemRect.Right, itemRect.Top),
                        new Point(itemRect.Right, itemRect.Bottom - itemRect.Width / 2),
                        new Point(itemRect.Left + itemRect.Width / 2, itemRect.Bottom),
                        new Point(itemRect.Left, itemRect.Bottom - itemRect.Width / 2)
                    }
                    );
            }
            else
            {
                gfx.FillRectangle(brush, itemRect);
            }
        }
    }
}
