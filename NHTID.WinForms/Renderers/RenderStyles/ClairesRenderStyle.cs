using System.Drawing;
using NHSE.Core;
using Nhtid.WinForms.Renderers.ColorSchemes;

namespace Nhtid.WinForms.Renderers.RenderStyles
{
    public class ClairesRenderStyle : IItemRenderStyle
    {
        private readonly IColorSchemeProvider colorSchemeProvider;

        public ClairesRenderStyle(IColorSchemeProvider colorSchemeProvider)
        {
            this.colorSchemeProvider = colorSchemeProvider;
        }

        public void DrawItem(Graphics gfx, MapRenderContext context, Rectangle itemRect, Item item)
        {
            var colorScheme = colorSchemeProvider.GetColorScheme();
            itemRect = context.ApplyStandardPaddingForTiles(itemRect);

            Brush brush = context.ResourceCache.GetSolidBrush(colorScheme.GetItemColor(item));
            gfx.FillRectangle(brush, itemRect);

            ItemKind kind = ItemInfo.GetItemKind(item);
            if (kind == ItemKind.Kind_DIYRecipe)
            {
                gfx.FillPolygon(Brushes.PaleVioletRed,
                    new Point[]
                    {
                        new Point(itemRect.Left, itemRect.Bottom),
                        new Point(itemRect.Left + itemRect.Width / 2, itemRect.Top + itemRect.Height / 2),
                        new Point(itemRect.Right, itemRect.Bottom), 
                    });
            }
            else if (!item.IsDropped && !item.IsBuried)
            {
                gfx.DrawLine(Pens.Black, itemRect.Left, itemRect.Top, itemRect.Right,itemRect.Bottom);
                gfx.DrawLine(Pens.Black, itemRect.Left, itemRect.Bottom, itemRect.Right, itemRect.Top);
            }
        }
    }
}