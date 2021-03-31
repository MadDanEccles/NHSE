using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NHSE.WinForms.Zebra
{
    public class ItemCollection : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<ushort> ItemIds { get; set; } = new List<ushort>();
        public List<CollectionMember> Members { get; set; } = new List<CollectionMember>();
        public Guid Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsTopLevel { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CollectionMember
    {
        public CollectionMemberType Type { get; set; }
        public Guid CollectionId { get; set; }
        public ushort ItemId { get; set; }
    }

    public enum CollectionMemberType
    {
        Item = 0,
        Collection = 1,
    }
}