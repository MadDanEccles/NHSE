using System;
using System.Drawing;
using System.Windows.Forms;
using NHSE.WinForms.Zebra.Renderers;
using NHSE.WinForms.Zebra.Selection;

namespace NHSE.WinForms.Zebra.Tools
{
    class MarqueeDragAction : IDragAction
    {
        private readonly ISelectionService selectionService;
        private readonly MarqueeRenderer renderer;
        private Point dragStart;
        private Point dragEnd;

        public MarqueeDragAction(ISelectionService selectionService, MarqueeRenderer renderer)
        {
            this.selectionService = selectionService;
            this.renderer = renderer;
        }

        public void Start(Point startLocation, MapToolContext ctx)
        {
            this.dragStart = startLocation;
            this.dragEnd = startLocation;
        }

        public void Move(Point location, MapToolContext ctx)
        {
            this.dragEnd = location;
            var marqueeBounds = GetMarqueeBounds();
            this.renderer.MarqueeBounds = marqueeBounds;
            this.selectionService.ClearSelection();
            this.selectionService.ModifySelection(marqueeBounds, ctx, SelectionAction.Add);
        }

        public void End(Point location, Keys modifierKeys, MapToolContext ctx)
        {
            this.renderer.MarqueeBounds = Rectangle.Empty;
        }

        private Rectangle GetMarqueeBounds() =>
            new Rectangle(
                Math.Min(dragStart.X, dragEnd.X),
                Math.Min(dragStart.Y, dragEnd.Y),
                Math.Abs(dragEnd.X - dragStart.X),
                Math.Abs(dragEnd.Y - dragStart.Y));

    }
}