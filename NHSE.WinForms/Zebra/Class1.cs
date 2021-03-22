using System.Collections.Generic;
using System.Linq;
using NHSE.Core;

namespace NHSE.WinForms.Zebra
{
    public class ItemVariant
    {
        public ItemVariant(ushort value, string caption)
        {
            Value = value;
            Caption = caption;
        }

        public ushort Value { get; }
        public string Caption { get; }
    }

    public class ItemSource
    {
        public List<ComboItem> GetItemDropdownData()
        {
            var data = GameInfo.Strings.ItemDataSource.ToList();
            var field = FieldItemList.Items.Select(z => z.Value).ToList();
            data.Add(field, GameInfo.Strings.InternalNameTranslation);
            return data;
        }
    }
}
