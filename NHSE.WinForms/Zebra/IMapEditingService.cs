using System.Drawing;
using NHSE.Core;
using static NHSE.WinForms.Zebra.CollisionAction;

namespace NHSE.WinForms.Zebra
{
    public interface IMapEditingService
    {
        bool DeleteTile(Point tilePt, bool resolveExtensions = false);
        bool IsOccupied(Point tilePt);
        bool AddItem(Item item, Point location, CollisionAction collisionAction = ThrowException);
        void DeleteRect(Rectangle tileRect);
        Item? GetItem(Point tilePt, bool resolveExtensions);
    }
}