using System.Drawing;
using NHSE.Core;

namespace Nhtid.WinForms
{
    public interface IMapQueryService
    {
        Item? GetItem(Point tilePt, bool resolveExtensions = true);
        bool IsOccupied(Point tilePt);
        bool IsOccupied(Rectangle tileRect);
    }
}