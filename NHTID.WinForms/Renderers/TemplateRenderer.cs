using Nhtid.WinForms.Documents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhtid.WinForms.Renderers
{
    class TemplateRenderer : MapLayerRendererBase
    {
        private Document document;
        private Font font;
        private SolidBrush brush;
        private StringFormat format;

        public TemplateRenderer(Document document)
        {
            this.document = document;
            this.font = new Font("Verdana", 10, FontStyle.Bold);
            this.brush = new SolidBrush(Color.FromArgb(64, 255, 255, 255));
            this.format = new StringFormat
            { 
                Alignment = StringAlignment.Center, 
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter
            };
        }

        public override void Paint(Graphics gfx, MapRenderContext context)
        {
            foreach(var area in document.PersistentTemplate.Areas)
            {
                var viewportBounds = context.ToViewport(area.TileBounds);
                viewportBounds = context.ApplyStandardPaddingForTiles(viewportBounds);
                gfx.FillRectangle(brush, viewportBounds);
                gfx.DrawRectangle(Pens.White, viewportBounds);
                gfx.DrawString(area.TemplateConfig?.Name, this.font, this.brush, viewportBounds, format);
            }
        }
    }
}
