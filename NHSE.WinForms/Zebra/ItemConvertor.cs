using NHSE.Core;
using static NHSE.Core.ItemKind;

namespace NHSE.WinForms.Zebra
{
    class ItemConvertor
    {
        public Item ApplyPresentation(Item item, PresentationType presentationType)
        {
            return null;
        }
    }

    public static class ItemExtensions
    {
        public static bool CanBeHung(this ItemKind kind) => kind == Kind_Picture || kind == Kind_PictureFake || kind == Kind_Poster;

        public static bool CanBePlaced(this ItemKind kind) =>
            kind switch
            {
                Kind_Poster => false,
                
                _ => true
            };
    }

    internal enum PresentationType
    {
        Placed,
        Dropped,
        Buried,
        Hung
    }

    
}
