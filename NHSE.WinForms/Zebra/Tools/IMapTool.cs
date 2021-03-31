﻿using System.Windows.Forms;

namespace NHSE.WinForms.Zebra.Tools
{
    public interface IMapTool
    {
        void OnMouseDown(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx);
        void OnMouseMove(MouseEventArgs e, MapToolContext ctx);
        void OnMouseUp(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx);
        void OnDeselect(IMapViewport viewport);
        void OnSelect(IMapViewport viewport);
        void OnMouseWheel(MouseEventArgs e, MapToolContext ctx);
        bool CanDeselect { get; }

        bool OnKeyDown(Keys e, MapToolContext ctx);
    }
}