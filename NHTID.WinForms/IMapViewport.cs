using System;
using System.Drawing;
using System.Windows.Forms;
using Nhtid.WinForms.Renderers;

namespace Nhtid.WinForms
{
    public interface IMapViewport : IWin32Window
    {
        Point ScrollPosition { get; set; }
        int TileSize { get;  }

        int ZoomLevel { get; }
        int MinZoom { get; }
        int MaxZoom { get; }

        void Zoom(int newZoomLevel, Point zoomCenter);

        event EventHandler ZoomChanged;

        void Invalidate();
        void AddRenderer(IMapLayerRenderer renderer);
        void RemoveRenderer(IMapLayerRenderer renderer);
    }
}