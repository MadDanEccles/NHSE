using System.Drawing;
using NHSE.Core;

namespace NHSE.WinForms.Zebra.Renderers.ColorSchemes
{
    public interface IColorScheme
    {
        Color GetItemColor(Item item);
    }
}
