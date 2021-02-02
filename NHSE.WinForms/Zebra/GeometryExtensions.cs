using System.Drawing;

namespace NHSE.WinForms.Zebra
{
    static class GeometryExtensions
    {
        public static Size Subtract(this Point p1, Point p2)
            => new Size(p1.X - p2.X, p1.Y - p2.Y);

        public static Rectangle Shrink(this Rectangle value, int left, int top, int right, int bottom)
        {
            return new Rectangle(value.Left + left,
                value.Top + top,
                value.Width - left - right,
                value.Height - top - bottom);
        }
    }
}