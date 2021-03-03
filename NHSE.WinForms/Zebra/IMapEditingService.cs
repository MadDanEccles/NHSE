using System.Drawing;
using NHSE.Core;
using static NHSE.WinForms.Zebra.CollisionAction;

namespace NHSE.WinForms.Zebra
{
    public interface IMapEditingService : IMapQueryService
    {
        bool DeleteTile(Point tilePt, bool resolveExtensions = true);
        bool AddItem(Item item, Point location, CollisionAction collisionAction = ThrowException);
        void DeleteRect(Rectangle tileRect);
    }

    public interface IMapQueryService
    {
        Item? GetItem(Point tilePt, bool resolveExtensions = true);
        bool IsOccupied(Point tilePt);
        bool IsOccupied(Rectangle tileRect);
    }
}