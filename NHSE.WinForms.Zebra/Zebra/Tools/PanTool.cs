﻿using System.Drawing;
using System.Windows.Forms;

namespace NHSE.WinForms.Zebra.Tools
{
    class PanTool : IMapTool
    {
        private Point panStartScrollPosition;
        private Point panStartLocation;
        private bool isPanning;

        public void OnMouseDown(MouseEventArgs e, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.panStartScrollPosition = ctx.Viewport.ScrollPosition;
                this.panStartLocation = e.Location;
                isPanning = true;
            }
        }

        public void OnMouseMove(MouseEventArgs e, MapToolContext ctx)
        {
            if (isPanning)
            {
                Size delta = panStartLocation.Subtract(e.Location);
                ctx.Viewport.ScrollPosition = Point.Add(panStartScrollPosition, delta);
            }
        }

        public void OnMouseUp(MouseEventArgs e, MapToolContext ctx)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPanning = false;
            }
        }

        public void OnDeselect(IMapViewport viewport)
        {
        }

        public void OnSelect(IMapViewport viewport)
        {
        }

        public void OnMouseWheel(MouseEventArgs e, MapToolContext ctx)
        {
            ctx.Viewport.Zoom(ctx.Viewport.ZoomLevel + e.Delta / 120, e.Location);
        }
    }
}