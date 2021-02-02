using System;
using System.Collections.Generic;
using System.Drawing;

namespace NHSE.WinForms.Zebra
{
    class GdiResourceCache : IGdiResourceCache, IDisposable
    {
        private readonly Dictionary<Color, Brush> brushCache = new Dictionary<Color, Brush>();

        public Brush GetSolidBrush(Color color)
        {
            if (!brushCache.TryGetValue(color, out Brush result))
            {
                result = new SolidBrush(color);
                brushCache.Add(color, result);
            }

            return result;
        }

        public void Dispose()
        {
            foreach (var brush in brushCache.Values)
                brush.Dispose();
        }
    }
}