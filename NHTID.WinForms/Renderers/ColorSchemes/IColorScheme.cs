using System.Drawing;
using NHSE.Core;

namespace Nhtid.WinForms.Renderers.ColorSchemes
{
    public interface IColorScheme
    {
        Color GetItemColor(Item item);
    }
}
