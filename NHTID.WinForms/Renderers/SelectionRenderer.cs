using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Nhtid.WinForms.Selection;

namespace Nhtid.WinForms.Renderers
{
    public class SelectionRenderer : MapLayerRendererBase
    {
        private readonly ISelectionService selectionService;
        private readonly HatchBrush brush;
        private Point tileOffset;

        public SelectionRenderer(ISelectionService selectionService)
        {
            this.selectionService = selectionService;
            this.selectionService.SelectionChanged += SelectionServiceOnSelectionChanged;
            this.brush = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.Gold, Color.Transparent);
        }

        public Point TileOffset
        {
            get => tileOffset;
            set
            {
                if (tileOffset != value)
                {
                    tileOffset = value;
                    OnContentChanged();
                }
            }
        }

        public override void Dispose()
        {
            brush.Dispose();
            base.Dispose();
        }

        private void SelectionServiceOnSelectionChanged(object sender, EventArgs e)
        {
            OnContentChanged();
        }

        public override void Paint(Graphics gfx, MapRenderContext context)
        {
            foreach (var item in selectionService.SelectedItems)
            {
                Rectangle itemBounds = item.Bounds;
                itemBounds.Offset(tileOffset);
                if (itemBounds.IntersectsWith(context.TileRange))
                {
                    Rectangle viewportBounds = context.ToViewport(itemBounds);
                    gfx.FillRectangle(brush, viewportBounds);
                }
            }
        }
    }
}