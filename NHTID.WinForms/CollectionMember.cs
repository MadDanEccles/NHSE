using System;

namespace Nhtid.WinForms
{
    public class CollectionMember
    {
        public CollectionMemberType Type { get; set; }
        public Guid CollectionId { get; set; }
        public ushort ItemId { get; set; }
    }
}