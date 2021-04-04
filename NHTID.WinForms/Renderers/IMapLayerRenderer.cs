using System;
using System.Drawing;

namespace Nhtid.WinForms.Renderers
{
    public interface IMapLayerRenderer : IDisposable
    {
        /// <summary>
        /// Paints a portion of the layer to a graphics object.
        /// </summary>
        /// <param name="gfx">The graphics object to draw to.</param>
        /// <param name="context"> The painting context for this operation. </param>
        void Paint(Graphics gfx, MapRenderContext context);

        event EventHandler ContentChanged;
    }
}