using System;
using NHSE.Core;
using static NHSE.Core.ItemKind;

namespace NHSE.WinForms.Zebra
{
    static class ItemConvertor
    {
        private const int RedsWallDisplayId = 12634;
        public static ushort GetItemId(this Item item)
            => item.IsHung() ? item.Count : item.ItemId;

        public static ushort GetBodyVariant(this Item item) 
            => item.IsHung() ? item.UseCount : item.Count;

        public static ushort GetFabricVariant(this Item item)
            => item.IsHung() ? (ushort) 0 : item.UseCount;


        public static void ApplyPresentation(Item item, PresentationType presentationType)
        {
            switch (presentationType)
            {
                case PresentationType.Hung:
                    if (!CanHangItem(item.ItemId))
                        throw new InvalidOperationException("Item cannot be hung");
                    HangItem(item);
                    break;
                case PresentationType.HungOrPlaced:
                    if (CanHangItem(item.ItemId))
                    {
                        HangItem(item);
                    }
                    else
                    {
                        // Clear buried or dropped flags...
                        item.SystemParam = (byte) (item.SystemParam & ~0x24);
                    }
                    break;
                case PresentationType.Dropped:
                    UnhangItem(item);
                    item.SystemParam = 0x20;
                    break;
                case PresentationType.Placed:
                    if (!CanBePlaced(item.ItemId))
                        throw new InvalidOperationException("Item cannot be placed");
                    // Clear buried or dropped flags...
                    item.SystemParam = (byte)(item.SystemParam & ~0x24);
                    break;
                case PresentationType.Buried:
                    UnhangItem(item);
                    // Apply buried flag
                    item.SystemParam = 0x04;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(presentationType), presentationType, null);
            }
        }

        private static void HangItem(Item item)
        {
            item.UseCount = item.Count;
            item.Count = item.ItemId;
            item.ItemId = RedsWallDisplayId;
            item.SystemParam = 0x00;
        }

        private static void UnhangItem(Item item)
        {
            // Only take action if the item is a red's wall display
            if (item.ItemId == RedsWallDisplayId)
            {
                item.ItemId = item.Count;
                item.Count = item.UseCount;
                item.UseCount = 0;
            }
        }

        public static bool CanHangItem(ushort itemId)
        {
            var itemKind = ItemInfo.GetItemKind(itemId);
            switch (itemKind)
            {
                case Kind_Picture:
                case Kind_PictureFake:
                    return true;
            }

            return MustBeHung(itemId);
        }

        public static bool MustBeHung(ushort itemId)
        {
            var itemKind = ItemInfo.GetItemKind(itemId);

            switch (itemKind)
            {
                case Kind_Poster:
                case Kind_DoorDeco:
                    return true;
            }

            switch (itemId)
            {
                case 12417:
                case 12418:
                case 07040:
                case 12268:
                case 13353:
                case 12242:
                case 05964:
                case 07139:
                case 07145:
                case 12266:
                case 13315:
                case 12257:
                case 05958:
                case 13248:
                case 00929:
                case 03558:
                case 04030:
                case 00682:
                case 00875:
                case 07037:
                case 03967:
                case 12485:
                case 11182:
                case 04012:
                case 06832:
                case 04130:
                case 01783:
                case 00915:
                case 03996:
                case 03340:
                case 04144:
                case 04133:
                case 00955:
                case 12486:
                case 03699:
                case 03583:
                case 04027:
                case 04099:
                case 12484:
                case 07280:
                case 07035:
                case 11261:
                case 11099:
                case 07282:
                case 03775:
                case 03970:
                case 08415:
                case 03399:
                case 03559:
                case 03562:
                case 03275:
                case 03992:
                case 03471:
                case 04037:
                case 04119:
                case 04118:
                case 11098:
                case 12557:
                case 09565:
                case 11127:
                case 11128:
                case 03976:
                case 06818:
                case 04077:
                case 03818:
                case 00928:
                case 03785:
                case 04028:
                case 13930:
                case 04017:
                case 07036:
                case 03817:
                case 13222:
                case 06827:
                case 07190:
                case 03584:
                case 01165:
                case 00704:
                case 04756:
                case 06075:
                case 00957:
                case 01744:
                case 03431:
                case 03986:
                case 03428:
                case 05165:
                case 03987:
                case 08417:
                case 11100:
                case 12407:
                case 03208:
                case 12741:
                case 05636:
                    return true;
            }

            return false;
        }

        public static bool CanBePlaced(ushort itemId)
        {
            if (MustBeHung(itemId))
                return false;

            return true;
        }

        public static bool IsHung(this Item item)
        {
            return item.ItemId == RedsWallDisplayId;
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
        Unknown,
        Placed,
        Dropped,
        Buried,
        Hung,
        HungOrPlaced
    }


}
