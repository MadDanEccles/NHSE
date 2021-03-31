using System.Drawing;
using NHSE.Core;

namespace NHSE.WinForms.Zebra.Renderers.ColorSchemes
{
    public class DefaultColorScheme : IColorScheme
    {
        public Color GetItemColor(Item item)
            => ItemColor.GetItemColor(item);
    }
}