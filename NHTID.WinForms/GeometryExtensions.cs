using System;
using System.Drawing;

namespace Nhtid.WinForms
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

        public static int Quantize(this int value, int unit)
        {
            return value - (value % unit);
        }

        public static Rectangle Quantize(this Rectangle value, int unit)
        {
            int leftErr = value.Left % unit;
            int topErr = value.Top % unit;
            int left = leftErr == 0 ? value.Left : value.Left + unit - leftErr;
            int top = topErr == 0 ? value.Top : value.Top + unit - topErr;
            return new Rectangle(
                left,
                top,
                Quantize(value.Right - left, unit),
                Quantize(value.Bottom - top, unit));
        }

        public static double GetDistance(this Point pt1, Point pt2)
        {
            return Math.Sqrt(Math.Pow(pt1.X - pt2.X, 2) + Math.Pow(pt1.Y - pt2.Y, 2));
        }

        public static bool Encompasses(this Size a, Size b) => a.Width >= b.Width && a.Height >= b.Height;
    }

    
}