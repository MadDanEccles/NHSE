using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace NHSE.WinForms.Zebra.Selection
{
    internal interface ISelectionService
    {
        /// <summary>
        /// Clears the current selection and invalidates the viewport if required.
        /// </summary>
        /// <returns>True if the selection has been modified, else false.</returns>
        bool ClearSelection();

        bool ModifySelection(Rectangle marqueeBounds, MapToolContext ctx, SelectionAction action);

        /// <summary>
        /// Modifies the current selection and invalidates the viewport if required.
        /// </summary>
        /// <param name="controlPt">The location, in pixels from the top-left of the viewport,
        /// of the item to add or remove.</param>
        /// <param name="ctx">The map tool context for this operation.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>True if the selection has been modified, else false.</returns>
        bool ModifySelection(Point controlPt, MapToolContext ctx, SelectionAction action);

        event EventHandler? SelectionChanged;

        IEnumerable<SelectedItem> SelectedItems { get; }

        /// <summary>
        /// Offsets all selection bounds by the specified number of tiles - for example after a selection has been moved.
        /// </summary>
        /// <param name="tileDelta"></param>
        void ApplyTileDelta(Point tileDelta);
    }
}