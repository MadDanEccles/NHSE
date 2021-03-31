﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHSE.WinForms.Zebra.SegmentLayouts
{
    public class LayoutManager
    {
        private readonly List<ISegmentLayoutFactory> segmentLayoutFactories = new List<ISegmentLayoutFactory>();

        public void Register(ISegmentLayoutFactory factory)
            => segmentLayoutFactories.Add(factory);

        public IEnumerable<ISegmentLayoutFactory> Factories => segmentLayoutFactories;

    }
}
