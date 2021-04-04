using System;
using System.Drawing;
using System.Windows.Forms;
using Nhtid.WinForms.Renderers;
using Nhtid.WinForms.Selection;

namespace Nhtid.WinForms.Tools.Actions
{
    class MarqueeSelectAction : DragMouseActionBase
    {
        private readonly ISelectionService selectionService;
        private readonly MarqueeRenderer renderer;
        private Point dragStart;
        private Point dragEnd;

        public MarqueeSelectAction(ISelectionService selectionService)
        {
            this.selectionService = selectionService;
            this.renderer = new MarqueeRenderer();
        }

        public override void BindViewport(IMapViewport viewport)
        {
            viewport.AddRenderer(renderer);
            base.BindViewport(viewport);
        }

        public override void UnbindViewport(IMapViewport viewport)
        {
            viewport.RemoveRenderer(renderer);
            base.UnbindViewport(viewport);
        }

        protected override void OnDragStart(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            this.dragStart = e.Location;
            this.dragEnd = e.Location;
            base.OnDragStart(e, modifierKeys, ctx);
        }

        protected override void OnDragEnd(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx)
        {
            this.renderer.MarqueeBounds = Rectangle.Empty;
            base.OnDragEnd(mouseEventArgs, modifierKeys, ctx);
        }

        protected override void OnDragMove(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx)
        {
            this.dragEnd = mouseEventArgs.Location;
            var marqueeBounds = GetMarqueeBounds();
            this.renderer.MarqueeBounds = marqueeBounds;
            this.selectionService.ClearSelection();
            this.selectionService.ModifySelection(marqueeBounds, ctx, SelectionAction.Add);
            base.OnDragMove(mouseEventArgs, modifierKeys, ctx);
        }

        private Rectangle GetMarqueeBounds() =>
            new Rectangle(
                Math.Min(dragStart.X, dragEnd.X),
                Math.Min(dragStart.Y, dragEnd.Y),
                Math.Abs(dragEnd.X - dragStart.X),
                Math.Abs(dragEnd.Y - dragStart.Y));

    }
}