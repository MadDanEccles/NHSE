using System;
using System.Drawing;
using System.Windows.Forms;
using NHSE.WinForms.Zebra.Renderers;
using NHSE.WinForms.Zebra.Selection;

namespace NHSE.WinForms.Zebra.Tools
{
    class MarqueeSelectionTool : IMapTool
    {
        private bool isDragging;
        private Point dragStart;
        private Point dragEnd;

        private readonly ISelectionService selectionService;
        private readonly MarqueeRenderer renderer;

        public MarqueeSelectionTool(ISelectionService selectionService)
        {
            this.selectionService = selectionService;
            this.renderer = new MarqueeRenderer();
        }

        public void OnMouseDown(MouseEventArgs e, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.dragStart = e.Location;
                this.dragEnd = e.Location;
                this.isDragging = true;
            }
        }

        public void OnMouseMove(MouseEventArgs e, MapToolContext ctx)
        {
            if (this.isDragging)
            {
                this.dragEnd = e.Location;
                var marqueeBounds = GetMarqueeBounds();
                this.renderer.MarqueeBounds = marqueeBounds;
                this.selectionService.ClearSelection();
                this.selectionService.ModifySelection(marqueeBounds, ctx, SelectionAction.Add);
            }
        }

        public void OnMouseUp(MouseEventArgs e, MapToolContext ctx)
        {
            if (this.isDragging && e.Button == MouseButtons.Left)
            {
                this.isDragging = false;
                this.renderer.MarqueeBounds = Rectangle.Empty;
            }
        }

        private Rectangle GetMarqueeBounds() =>
            isDragging
                ? new Rectangle(
                    Math.Min(dragStart.X, dragEnd.X),
                    Math.Min(dragStart.Y, dragEnd.Y),
                    Math.Abs(dragEnd.X - dragStart.X),
                    Math.Abs(dragEnd.Y - dragStart.Y))
                : Rectangle.Empty;

        public void OnDeselect(IMapViewport viewport)
        {
            viewport.RemoveRenderer(this.renderer);
        }

        public void OnSelect(IMapViewport viewport)
        {
            viewport.AddRenderer(this.renderer);
        }

        public void OnMouseWheel(MouseEventArgs e, MapToolContext ctx)
        {
        }

        public bool CanDeselect => !isDragging;
    }
}