using System;
using System.Windows.Forms;
using NHSE.Core;

namespace Nhtid.WinForms.Controls
{

    public partial class ItemDirectionSelector : UserControl, IItemPropertiesUi
    {
        public ItemDirectionSelector()
        {
            InitializeComponent();
        }

        public void ApplyToItem(Item item)
        {
            byte flags = (byte)(item.SystemParam & ~DirectionFlags.Mask);

            if (radDown.Checked)
                flags |= DirectionFlags.Down;
            else if (radRight.Checked)
                flags |= DirectionFlags.Right;
            else if (radUp.Checked)
                flags |= DirectionFlags.Up;
            else if (radLeft.Checked)
                flags |= DirectionFlags.Left;

            item.SystemParam = flags;
        }

        public void UpdateFromItem(Item item)
        {
            byte directionFlags = (byte) (item.SystemParam & DirectionFlags.Mask);
            var rad = directionFlags switch
            {
                DirectionFlags.Down => radDown,
                DirectionFlags.Right => radRight,
                DirectionFlags.Up => radUp,
                DirectionFlags.Left => radLeft,
                _ => throw new ArgumentOutOfRangeException()
            };
            rad.Checked = true;
        }
    }
}
