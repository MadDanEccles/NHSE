﻿using System.Drawing;

namespace Nhtid.WinForms
{
    public class MapToolContext : MapContext
    {
        public IMapEditingService MapEditingService { get; }

        public MapToolContext(Rectangle viewRect, int tileSize, Point viewCentre, IMapViewport viewport,
            IMapEditingService mapEditingService)
            : base(viewRect, tileSize, viewCentre)
        {
            this.MapEditingService = mapEditingService;
            Viewport = viewport;
        }

        public IMapViewport Viewport { get; }
    }
}