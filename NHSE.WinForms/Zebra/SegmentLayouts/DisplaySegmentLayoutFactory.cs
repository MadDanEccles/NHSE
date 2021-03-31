using System;
using NHSE.Core;

namespace NHSE.WinForms.Zebra.SegmentLayouts
{
    class DisplaySegmentLayoutFactory : SegmentLayoutFactoryBase<DisplaySegmentLayoutOptions>
    {
        public DisplaySegmentLayoutFactory()
        {
            this.Options = new DisplaySegmentLayoutOptions();
        }

        public override bool IsApplicable(ushort itemId)
        {
            return true;
        }

        public override ISegmentLayout Create(Item rawItem)
        {
            return new DisplaySegmentLayout(rawItem, this.Options);
        }

        public override string Name => "Display Stand Layout";
    }

    public class DisplaySegmentLayoutOptions
    {
        public CreatureDisplayStyle CreatureDisplayStyle { get; set; } = CreatureDisplayStyle.AsModel;
        public CreatureDropStyle CreatureDropStyle { get; set; } = CreatureDropStyle.Both;
    }

    public enum CreatureDisplayStyle
    {
        InTank,
        AsModel,
    }

    [Flags]
    public enum CreatureDropStyle
    {
        Creature = 0x01,
        Model = 0x02,
        Both = 0x03
    }
}