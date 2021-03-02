using System.Drawing;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms.Zebra.Tools
{
    class PickTool : IMapTool
    {
        private readonly IPickTarget pickTarget;

        public PickTool(IPickTarget pickTarget)
        {
            this.pickTarget = pickTarget;
        }

        public void OnMouseDown(MouseEventArgs e, MapToolContext ctx)
        {
            Point tilePt = ctx.ToTile(e.Location);
            Item item = ctx.MapEditingService.GetItem(tilePt, true);
            if (item != null)
            {
                Item itemCopy = new Item();
                itemCopy.CopyFrom(item);
                pickTarget.Pick(itemCopy);
            }
        }

        public void OnMouseMove(MouseEventArgs e, MapToolContext ctx)
        {
        }

        public void OnMouseUp(MouseEventArgs e, MapToolContext ctx)
        {
        }

        public void OnDeselect(IMapViewport viewport)
        {
        }

        public void OnSelect(IMapViewport viewport)
        {
        }

        public void OnMouseWheel(MouseEventArgs e, MapToolContext ctx)
        {
        }
    }
}