using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using Nhtid.WinForms.Controls;
using Nhtid.WinForms.SegmentLayouts;
using Nhtid.WinForms.Tools.Actions;

namespace Nhtid.WinForms.Tools
{
    public class MultiTemplateTool : MapToolBase
    {
        private readonly IHistoryService historyService;
        private readonly MultiItemSelector multiItemSelector;
        private ISegmentLayout[] segmentLayouts;
        private Size[] minSegementSizes;

        public MultiTemplateTool(IHistoryService historyService, MultiItemSelector multiItemSelector)
        {
            this.historyService = historyService;
            this.multiItemSelector = multiItemSelector;
        }

        protected override IMouseAction GetMouseAction(MouseEventArgs e, Keys modifierKeys, MapToolContext ctx)
        {
            if (modifierKeys.HasFlag(Keys.Alt))
            {
                return new PanZoomMouseAction();
            }
            else
            {
                var layout = multiItemSelector.GetMultiFactory().Create();
                var factory = multiItemSelector.GetFactory();
                Item[] items = multiItemSelector.ResolveItems().Where(i => factory.IsApplicable(i.ItemId)).ToArray();
                if (items.Length == 0)
                {
                    MessageBox.Show(ctx.Viewport, "Please select one or more items before using the template", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                return new MultiSegmentTemplateAction(this.historyService, items, factory, layout);
            }
        }
    }
}