using System.Drawing;

namespace NHSE.WinForms.Zebra
{
    public interface IGdiResourceCache
    {
        public Brush GetSolidBrush(Color color);
    }
}