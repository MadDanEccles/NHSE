using System.Drawing;

namespace Nhtid.WinForms
{
    public interface IGdiResourceCache
    {
        public Brush GetSolidBrush(Color color);
    }
}