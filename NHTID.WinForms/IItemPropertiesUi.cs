using NHSE.Core;

namespace Nhtid.WinForms
{
    public interface IItemPropertiesUi
    {
        void ApplyToItem(Item item);
        void UpdateFromItem(Item item);
    }
}