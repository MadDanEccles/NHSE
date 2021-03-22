using System.Drawing;
using NHSE.Core;

namespace NHSE.WinForms.Zebra.Renderers.ColorSchemes
{
    interface IColorScheme
    {
        Color GetItemColor(Item item);
    }
}
