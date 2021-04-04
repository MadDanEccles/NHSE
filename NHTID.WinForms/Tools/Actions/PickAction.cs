using System.Drawing;
using System.Windows.Forms;
using NHSE.Core;

namespace Nhtid.WinForms.Tools.Actions
{
    public class PickAction : IMouseAction
    {
        private readonly IPickTarget pickTarget;

        public PickAction(IPickTarget pickTarget)
        {
            this.pickTarget = pickTarget;
        }

        public void Dispose()
        {
        }

        public bool OnKeyDown(Keys e, MapToolContext ctx)
        {
            return false;
        }

        public void BindViewport(IMapViewport viewport)
        {
        }

        public void UnbindViewport(IMapViewport viewport)
        {
        }

        public void OnMouseMove(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx)
        {
        }

        public void OnMouseUp(MouseEventArgs mouseEventArgs, Keys modifierKeys, MapToolContext ctx)
        {
        }

        public void OnMouseDown(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
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
    }
}