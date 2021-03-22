using NHSE.Core;

namespace NHSE.WinForms.Zebra
{
    public interface IItemPropertiesUi
    {
        void ApplyToItem(Item item);
        void UpdateFromItem(Item item);
    }
}