﻿using System.Windows.Forms;
using Nhtid.WinForms.Tools.Actions;

namespace Nhtid.WinForms.Tools
{
    public class EraserTool : MapToolBase
    {
        private readonly IHistoryService historyService;

        public EraserTool(IHistoryService historyService)
        {
            this.historyService = historyService;
        }

        protected override IMouseAction GetMouseAction(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (modifierKeys.HasFlag(Keys.Alt))
                return new PanZoomMouseAction();
            return new EraseAction(historyService);
        }
    }
}