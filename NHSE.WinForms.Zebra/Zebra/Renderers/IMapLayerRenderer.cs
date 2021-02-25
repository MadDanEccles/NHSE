using System;
using System.Drawing;

namespace NHSE.WinForms.Zebra.Renderers
{
    interface IMapLayerRenderer : IDisposable
    {
        /// <summary>
        /// Paints a portion of the layer to a graphics object.
        /// </summary>
        /// <param name="gfx">The graphics object to draw to.</param>
        /// <param name="context"> The painting context for this operation. </param>
        void Paint(Graphics gfx, MapRenderContext context);

        event EventHandler ContentChanged;
    }

    abstract class MapLayerRendererBase : IMapLayerRenderer
    {
        public virtual void Dispose()
        {
        }

        public abstract void Paint(Graphics gfx, MapRenderContext context);

        public event EventHandler? ContentChanged;
        
        protected virtual void OnContentChanged()
        {
            ContentChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}