using System;
using System.Diagnostics;
using System.Drawing;
using NHSE.Core;

namespace Nhtid.WinForms
{
    public class MapEditingService : IMapEditingService
    {
        private readonly Rectangle worldTileBounds = new Rectangle(0, 0, 7 * 32, 6 * 32);
        private readonly MapManager mapManager;

        public MapEditingService(MapManager mapManager)
        {
            this.mapManager = mapManager;
        }

        public bool IsOccupied(Point tilePt) => !mapManager.CurrentLayer.GetTile(tilePt).IsNone;

        public bool IsOccupied(Rectangle tileRect)
        {
            for (int x = tileRect.Left; x < tileRect.Right; x++)
            {
                for (int y = tileRect.Top; y < tileRect.Bottom; y++)
                {
                    if (!IsInWorldBounds(new Point(x, y)))
                        continue;

                    if (!mapManager.CurrentLayer.GetTile(x, y).IsNone)
                        return true;
                }
            }

            return false;
        }

        private bool IsInWorldBounds(Rectangle tileRect)
            => Rectangle.Intersect(tileRect, worldTileBounds) == tileRect;

        private bool IsInWorldBounds(Point tilePt)
            => worldTileBounds.Contains(tilePt);

        public bool AddItem(Item item, Point location, IHistoryTransaction trans,
            CollisionAction collisionAction = CollisionAction.ThrowException)
        {
            if (!item.IsRoot)
                throw new InvalidOperationException("Only root items may be added to the field.");
            Size size = item.GetSize();
            var l = mapManager.CurrentLayer;

            var itemRect = new Rectangle(location, size);
            if (IsOccupied(itemRect))
            {
                switch (collisionAction)
                {
                    case CollisionAction.ThrowException:
                        throw new InvalidOperationException("The specified location is already occupied.");
                    case CollisionAction.Abort:
                        return false;
                    case CollisionAction.Overwrite:
                        DeleteRect(itemRect, trans);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(collisionAction), collisionAction, null);
                }
            }

            if (!IsInWorldBounds(itemRect))
            {
                switch (collisionAction)
                {
                    case CollisionAction.ThrowException:
                        throw new InvalidOperationException("The specified location is outside of the world.");
                    case CollisionAction.Abort:
                        return false;
                    case CollisionAction.Overwrite:
                        return false;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(collisionAction), collisionAction, null);
                }

            }

            trans?.AddStep(new AddItemStep(item, location, this));
            Item tile = l.GetTile(location);
            l.SetExtensionTiles(item, location.X, location.Y);
            tile.CopyFrom(item);
            return true;
        }

        /// <summary>
        /// Deletes any items wholly or partially in the specified rectangle.
        /// </summary>
        /// <param name="tileRect"></param>
        public void DeleteRect(Rectangle tileRect, IHistoryTransaction? trans)
        {
            for (int x = tileRect.Left; x < tileRect.Right; x++)
            {
                for (int y = tileRect.Top; y < tileRect.Bottom; y++)
                {
                    DeleteTile(new Point(x, y), trans, true);
                }
            }
        }

        public void DeleteAll(IHistoryTransaction trans)
        {
            DeleteRect(worldTileBounds, trans);
        }

        public Item? GetItem(Point tilePt, bool resolveExtensions)
        {
            if (!IsInWorldBounds(tilePt))
                return null;

            Item tile = mapManager.CurrentLayer.GetTile(tilePt);

            if (tile.IsNone)
                return null;

            if (resolveExtensions && tile.IsExtension)
            {
                tilePt.Offset(-tile.ExtensionX, -tile.ExtensionY);
                return mapManager.CurrentLayer.GetTile(tilePt);
            }

            return tile;

        }

        public bool DeleteTile(Point tilePt, IHistoryTransaction? trans, bool resolveExtensions = false)
        {
            if (!IsInWorldBounds(tilePt))
                return false;

            Item tile = mapManager.CurrentLayer.GetTile(tilePt);

            if (tile.IsNone)
                return false;

            if (!tile.IsRoot)
            {
                if (resolveExtensions)
                {
                    if (tile.IsExtension)
                    {
                        tilePt.Offset(-tile.ExtensionX, -tile.ExtensionY);
                        tile = mapManager.CurrentLayer.GetTile(tilePt);
                    }
                    else
                    {
                        throw new InvalidOperationException("Specified location is not a root or extension tile.");
                    }

                }
                else
                {
                    throw new InvalidOperationException("Specified location is not a root tile.");
                }
            }

            Debug.Assert(tile.IsRoot);

            trans?.AddStep(new DeleteItemStep(tile, tilePt, this));
            mapManager.CurrentLayer.DeleteExtensionTiles(tile, tilePt);
            tile.Delete();
            return true;
        }

        private class AddItemStep : IHistoryStep
        {
            private Item item;
            private Point location;
            private readonly IMapEditingService service;

            public AddItemStep(Item item, Point location, IMapEditingService service)
            {
                this.item = new Item();
                this.item.CopyFrom(item);
                this.location = location;
                this.service = service;
            }

            public void Undo()
            {
                service.DeleteTile(location, null, false);
            }

            public void Redo()
            {
                service.AddItem(item, location, null);
            }
        }

        private class DeleteItemStep : IHistoryStep
        {
            private Item item;
            private Point location;
            private readonly IMapEditingService service;

            public DeleteItemStep(Item item, Point location, IMapEditingService service)
            {
                this.item = new Item();
                this.item.CopyFrom(item);
                this.location = location;
                this.service = service;
            }

            public void Undo()
            {
                service.AddItem(item, location, null);
            }

            public void Redo()
            {
                service.DeleteTile(location, null, false);
            }
        }
    }
}