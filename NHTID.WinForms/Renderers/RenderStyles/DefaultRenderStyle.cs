﻿using System.Drawing;
using NHSE.Core;
using Nhtid.WinForms.Renderers.ColorSchemes;

namespace Nhtid.WinForms.Renderers.RenderStyles
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

            itemRect = context.ApplyStandardPaddingForTiles(itemRect);

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
