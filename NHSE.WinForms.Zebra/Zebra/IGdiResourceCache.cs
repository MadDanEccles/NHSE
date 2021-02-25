using System.Drawing;

namespace NHSE.WinForms.Zebra
{
    internal interface IGdiResourceCache
    {
        public Brush GetSolidBrush(Color color);
    }
}