using System.Collections.Generic;
using System.Linq;
using NHSE.Core;

namespace Nhtid.WinForms
{
    public class ItemSource
    {
        public List<ComboItem> GetItemDropdownData()
        {

            var data = GameInfo.Strings.ItemDataSource.Where(i => !i.Text.StartsWith("(Item #")).ToList();
            var field = FieldItemList.Items.Select(z => z.Value).ToList();
            data.Add(field, GameInfo.Strings.InternalNameTranslation);
            return data;
        }
    }
}