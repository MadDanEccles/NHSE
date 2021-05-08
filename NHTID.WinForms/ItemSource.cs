using System.Collections.Generic;
using System.Linq;
using NHSE.Core;

namespace Nhtid.WinForms
{
    public class ItemSource
    {
        private readonly ItemConvertor itemConvertor;

        private ComboItem[] items;

        public ItemSource(ItemConvertor itemConvertor)
        {
            this.itemConvertor = itemConvertor;
        }

        public ComboItem[] GetItemDropdownData()
        {
            if (items == null)
            {
                var data = GameInfo.Strings.ItemDataSource.Where(
                    i => !i.Text.StartsWith("(Item #")).ToList();
                var field = FieldItemList.Items.Select(z => z.Value).ToList();
                data.Add(field, GameInfo.Strings.InternalNameTranslation);
                items = data.Where(i => itemConvertor.CanListInUi((ushort)i.Value)).OrderBy(i => i.Text).ToArray();
            }
            return items;
        }
    }
}