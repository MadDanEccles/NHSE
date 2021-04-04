using System.Drawing;
using NHSE.Core;
using static Nhtid.WinForms.CollisionAction;

namespace Nhtid.WinForms
{
    public interface IMapEditingService : IMapQueryService
    {
        bool DeleteTile(Point tilePt, IHistoryTransaction historyTransaction, bool resolveExtensions = true);
        bool AddItem(Item item, Point location, IHistoryTransaction historyTransaction,
            CollisionAction collisionAction = ThrowException);
        void DeleteRect(Rectangle tileRect, IHistoryTransaction historyTransaction);

        void DeleteAll(IHistoryTransaction historyTransaction);
    }
}