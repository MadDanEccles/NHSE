using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHSE.Core;
using static NHSE.Core.ItemKind;

namespace NHSE.WinForms.Zebra.Renderers.RenderStyles
{
    interface IItemRenderStyle
    {
        void DrawItem(Graphics gfx, MapRenderContext context, Rectangle itemRect, Item item);
    }

    class DefaultRenderStyle : IItemRenderStyle
    {
        public void DrawItem(Graphics gfx, MapRenderContext context, Rectangle itemRect, Item item)
        {
            if (context.TileSize > 7)
                itemRect = itemRect.Shrink(2, 2, 1, 1);
            else
                itemRect = itemRect.Shrink(1, 1, 0, 0);

            Brush brush = context.ResourceCache.GetSolidBrush(ItemColor.GetItemColor(item));
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

    class ClairesRenderStyle : IItemRenderStyle
    {
        public void DrawItem(Graphics gfx, MapRenderContext context, Rectangle itemRect, Item item)
        {
            if (context.TileSize > 7)
                itemRect = itemRect.Shrink(2, 2, 1, 1);
            else
                itemRect = itemRect.Shrink(1, 1, 0, 0);

            Brush brush = context.ResourceCache.GetSolidBrush(ItemColor.GetItemColor(item));
            gfx.FillRectangle(brush, itemRect);

            ItemKind kind = ItemInfo.GetItemKind(item);
            if (kind == Kind_DIYRecipe)
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
