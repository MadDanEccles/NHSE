using System;
using System.Drawing;

namespace Nhtid.WinForms.Renderers
{
    public abstract class MapLayerRendererBase : IMapLayerRenderer
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