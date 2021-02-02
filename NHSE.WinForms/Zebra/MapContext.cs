using System;
using System.Diagnostics;
using System.Drawing;
using NHSE.Core;

namespace NHSE.WinForms.Zebra
{
    class MapContext
    {
        private readonly Point scrollPosition;
        private Point topLeftVisibleTilePosition;
        private Point topLeftVisibleTile;
        private readonly Rectangle worldTileBounds;

        /// <summary>
        /// </summary>
        /// <param name="viewRect">The rectangle (in pixels) to be painted. The
        /// top-left of this rectangle should be aligned with the top-left tile.</param>
        /// <param name="scrollPosition">The scroll position in pixels, positive moving down-right from origin.</param>
        /// <param name="tileSize">The size of each tile in pixels</param>
        public MapContext(
            Rectangle viewRect,
            int tileSize,
            Point scrollPosition)
        {
            this.scrollPosition = scrollPosition;
            ViewRect = viewRect;
            TileSize = tileSize;

            this.topLeftVisibleTile = new Point(
                scrollPosition.X / tileSize, scrollPosition.Y / tileSize);

            this.topLeftVisibleTilePosition = new Point(
                topLeftVisibleTile.X * tileSize - scrollPosition.X,
                topLeftVisibleTile.Y * tileSize - scrollPosition.Y);

            TileRange = new Rectangle(
                topLeftVisibleTile.X,
                topLeftVisibleTile.Y,
                (int)Math.Ceiling((viewRect.Width + this.scrollPosition.X - topLeftVisibleTile.X * tileSize) / (double)tileSize),
                (int)Math.Ceiling((viewRect.Height + this.scrollPosition.Y - topLeftVisibleTile.Y * tileSize) / (double)tileSize));

            // Limit TileRange to valid tiles within the 42 acres (and optimise this later..!)
            worldTileBounds = new Rectangle(0, 0, 7 * 32, 6 * 32);
            TileRange = Rectangle.Intersect(TileRange, worldTileBounds);

            Debug.Assert(TileRange.Top >= 0);
            Debug.Assert(TileRange.Left >= 0);
        }

        public Rectangle ViewRect { get; }

        public Rectangle TileRange { get; }

        public int TileSize { get; }

        public Rectangle ToViewport(int tileX, int tileY)
            => ToViewport(new Rectangle(tileX, tileY, 1, 1));

        public Rectangle ToViewport(Point tilePoint)
            => ToViewport(new Rectangle(tilePoint, new Size(1, 1)));

        public Rectangle ToViewport(Rectangle tileBounds)
            => ToViewport(tileBounds.Left, tileBounds.Top, tileBounds.Width, tileBounds.Height);

        public int GetLeftEdge(int tileX) => topLeftVisibleTilePosition.X + (tileX - topLeftVisibleTile.X) * TileSize;

        public int GetTopEdge(int tileY) => topLeftVisibleTilePosition.Y + (tileY - topLeftVisibleTile.Y) * TileSize;

        public Rectangle ToViewport(int leftTile, int topTile, int width, int height)
        {
            return new Rectangle(
                GetLeftEdge(leftTile),
                GetTopEdge(topTile),
                TileSize * width,
                TileSize * height
            );
        }

        /// <summary>
        /// Determines the bounds of the tiles partially or wholly within a rectangle on the viewport.
        /// </summary>
        /// <param name="viewportBounds">The viewport rectangle.</param>
        /// <param name="limitToValidTiles">Determines if the result is limited to valid world tiles.</param>
        /// <returns>A rectangle defining the tiles within the viewport rectangle.</returns>
        public Rectangle ToTiles(Rectangle viewportBounds, bool limitToValidTiles = true)
        {
            Point topLeftTile = ToTile(viewportBounds.Location);
            Point bottomRightTile = ToTile(viewportBounds.Right, viewportBounds.Bottom);
            // The bottom right tile will lie partially or wholly within the viewport bounds, the
            // result is exclusive of the bottom-right tile so we must offset by one tile.
            bottomRightTile.Offset(1, 1);
            var result = new Rectangle(
                topLeftTile.X, 
                topLeftTile.Y, 
                bottomRightTile.X - topLeftTile.X,
                bottomRightTile.Y - topLeftTile.Y);
            if (limitToValidTiles)
                result = Rectangle.Intersect(result, worldTileBounds);
            return result;
        }

        public Point ToTile(Point viewportPt)
            => ToTile(viewportPt.X, viewportPt.Y);

        public Point ToTile(int viewportX, int viewportY)
        {
            return new Point(
                (viewportX - topLeftVisibleTilePosition.X) / TileSize + topLeftVisibleTile.X,
                (viewportY - topLeftVisibleTilePosition.Y) / TileSize + topLeftVisibleTile.Y);
        }
    }
}