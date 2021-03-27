using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.WinForms.Zebra.Renderers;
using NHSE.WinForms.Zebra.Renderers.RenderStyles;
using NHSE.WinForms.Zebra.Selection;
using NHSE.WinForms.Zebra.Tools;

namespace NHSE.WinForms.Zebra
{
    class MapView : Control, IMapViewport, IItemRenderStyleProvider
    {
        private MapManager? map;
        private readonly List<IMapLayerRenderer> renderers = new List<IMapLayerRenderer>();
        private Point topLeftTile;

        public MapView()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.CurrentTool = new PanTool();
        }

        IItemRenderStyle IItemRenderStyleProvider.GetStyle() => this.ItemRenderStyle;

        public IItemRenderStyle ItemRenderStyle { get; set; }

        public MapManager Map
        {
            get => map;
            set
            {
                if (map != value)
                {
                    ClearRenderers();
                    map = value;

                    this.MapEditingService = new MapEditingService(map);

                    this.SelectionService = new SelectionService(map);

                    AddRenderer(new BackgroundRenderer());
                    AddRenderer(new TerrainRenderer(map));
                    AddRenderer(new GridOverlayRenderer());
                    AddRenderer(new BuildingLayerRenderer(map));
                    AddRenderer(new ItemLayerRenderer(map, this));
                    AddRenderer(SelectionRenderer = new SelectionRenderer(this.SelectionService));
                }
            }
        }

        public void AddRenderer(IMapLayerRenderer renderer)
        {
            this.renderers.Add(renderer);
            renderer.ContentChanged += RendererOnContentChanged;
        }

        public void RemoveRenderer(IMapLayerRenderer renderer)
        {
            if (this.renderers.Remove(renderer))
                renderer.ContentChanged -= RendererOnContentChanged;
        }

        private void RendererOnContentChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ClearRenderers();
                resourceCache.Dispose();
            }

            base.Dispose(disposing);
        }

        private void ClearRenderers()
        {
            foreach (var renderer in this.renderers)
                renderer.Dispose();
            this.renderers.Clear();
        }

        public int TileSize
        {
            get => zoomLevels[ZoomLevel];
        }

        public int ZoomLevel { get; private set; } = 4;

        private readonly int[] zoomLevels = {3, 4, 5, 6, 7, 8, 10, 12, 16, 24, 32};

        public void Zoom(int newZoomLevel, Point zoomCenter)
        {
            newZoomLevel = Math.Min(zoomLevels.Length - 1, Math.Max(0, newZoomLevel));
            int newTileSize = zoomLevels[newZoomLevel];

            if (newTileSize != TileSize)
            {
                this.scrollPosition = new Point(
                    (int) ((scrollPosition.X + zoomCenter.X) / (float)TileSize * newTileSize - zoomCenter.X),
                    (int) ((scrollPosition.Y + zoomCenter.Y) / (float)TileSize * newTileSize - zoomCenter.Y));
                this.ZoomLevel = newZoomLevel;
                Invalidate();
            }
        }

        public Point ScrollPosition
        {
            get => scrollPosition;
            set
            {
                if (scrollPosition != value)
                {
                    scrollPosition = value;
                    Invalidate();
                }
            }
        }

        private readonly GdiResourceCache resourceCache = new GdiResourceCache();
        private IMapTool? currentTool;
        private Point scrollPosition;

        protected override void OnPaint(PaintEventArgs e)
        {
            MapRenderContext context = new MapRenderContext(
                ClientRectangle,
                TileSize,
                this.ScrollPosition,
                this.resourceCache);

            foreach (var renderer in renderers)
            {
                renderer.Paint(e.Graphics, context);
            }

            base.OnPaint(e);
        }

        private MapToolContext CreateMapToolContext() =>
            new MapToolContext(ClientRectangle, TileSize, ScrollPosition, this, new MapEditingService(map));

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            CurrentTool?.OnMouseWheel(e, CreateMapToolContext());
            base.OnMouseWheel(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            CurrentTool?.OnMouseDown(e, ModifierKeys, CreateMapToolContext());
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            CurrentTool?.OnMouseMove(e, CreateMapToolContext());
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            CurrentTool?.OnMouseUp(e, ModifierKeys, CreateMapToolContext());
            base.OnMouseUp(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        public IMapTool? CurrentTool
        {
            get => currentTool;
            set
            {
                if (currentTool != value)
                {
                    currentTool?.OnDeselect(this);
                    currentTool = value;
                    currentTool?.OnSelect(this);
                }
            }
        }

        public ISelectionService SelectionService { get; private set; }
        public SelectionRenderer SelectionRenderer { get; private set; }
        public IMapEditingService MapEditingService { get; private set; }

        public bool ProcessCommandKey(Keys keyData)
        {
            return CurrentTool?.OnKeyDown(keyData, CreateMapToolContext()) ?? false;
        }
    }
}
