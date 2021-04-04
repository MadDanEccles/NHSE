using System.Windows.Forms;
using NHSE.Core;
using Nhtid.WinForms.Tools.Actions;

namespace Nhtid.WinForms.Tools
{
    public class TemplateTool : MapToolBase
    {
        private readonly IHistoryService historyService;
        private readonly IItemSelector options;
        private readonly ItemConvertor itemConvertor;

        public TemplateTool(IHistoryService historyService, IItemSelector options, ItemConvertor itemConvertor)
        {
            this.historyService = historyService;
            this.options = options;
            this.itemConvertor = itemConvertor;
        }

        protected override IMouseAction GetMouseAction(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            Item rawItem = options.GetItem();

            if (!rawItem.IsRoot)
            {
                MessageBox.Show(ctx.Viewport, "Please select a valid item before drawing", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new SingleSegmentTemplateAction(historyService, itemConvertor, rawItem);
        }
    }
}