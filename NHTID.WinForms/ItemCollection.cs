using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Nhtid.WinForms
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
}