namespace Nhtid.WinForms
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
}
