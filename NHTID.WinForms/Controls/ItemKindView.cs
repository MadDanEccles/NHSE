using System;

namespace Nhtid.WinForms.Controls
{
    public class ItemKindView
    {
        private readonly Predicate<ushort> funcInclude;

        public ItemKindView(string name, Predicate<ushort> funcInclude)
        {
            this.Text = name;
            this.funcInclude = funcInclude;
        }

        public string Text { get; }


        public bool IsIncluded(ushort itemId) => funcInclude(itemId);
    }
}