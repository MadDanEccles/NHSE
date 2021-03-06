﻿using System.Drawing;
using NHSE.Core;

namespace Nhtid.WinForms.Renderers.ColorSchemes
{
    public class DefaultColorScheme : IColorScheme
    {
        public Color GetItemColor(Item item)
            => ItemColor.GetItemColor(item);
    }
}