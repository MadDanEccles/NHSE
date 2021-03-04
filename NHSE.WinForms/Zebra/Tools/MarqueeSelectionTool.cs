using System;
using System.Drawing;
using System.Linq;
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

    class MarqueeSelectionTool : IMapTool
    {
        private readonly ISelectionService selectionService;
        private readonly SelectionRenderer selectionRenderer;
        private readonly MarqueeRenderer renderer;
        private readonly IHistoryService historyService;
        private IDragAction? dragAction;

        public MarqueeSelectionTool(ISelectionService selectionService, SelectionRenderer selectionRenderer, IHistoryService historyService)
        {
            this.selectionService = selectionService;
            this.selectionRenderer = selectionRenderer;
            this.historyService = historyService;
            this.renderer = new MarqueeRenderer();
        }

        public void OnMouseDown(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point tilePt = ctx.ToTile(e.Location);
                if (selectionService.SelectedItems.Any(i => i.Bounds.Contains(tilePt)))
                {
                    this.dragAction = new MoveDragAction(selectionRenderer, selectionService, historyService);
                }
                else
                {
                    selectionService.ClearSelection();
                    this.dragAction = new MarqueeDragAction(selectionService, renderer);
                }

                this.dragAction.Start(e.Location, ctx);
            }
        }

        public void OnMouseMove(MouseEventArgs e, MapToolContext ctx)
        {
            this.dragAction?.Move(e.Location, ctx);
        }

        public void OnMouseUp(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragAction?.End(e.Location, modifierKeys, ctx);
                dragAction = null;
            }
        }

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

        public bool CanDeselect => dragAction == null;
    }
}