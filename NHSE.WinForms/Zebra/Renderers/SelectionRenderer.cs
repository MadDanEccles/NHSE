using System;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using NHSE.WinForms.Zebra.Selection;

namespace NHSE.WinForms.Zebra.Renderers
{
    class SelectionRenderer : MapLayerRendererBase
    {
        private readonly ISelectionService selectionService;
        private readonly HatchBrush brush;

        public SelectionRenderer(ISelectionService selectionService)
        {
            this.selectionService = selectionService;
            this.selectionService.SelectionChanged += SelectionServiceOnSelectionChanged;
            this.brush = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.Gold, Color.Transparent);
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
                if (item.Bounds.IntersectsWith(context.TileRange))
                {
                    Rectangle viewportBounds = context.ToViewport(item.Bounds);
                    gfx.FillRectangle(brush, viewportBounds);
                }
            }
        }
    }
}