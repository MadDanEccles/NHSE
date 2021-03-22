namespace NHSE.WinForms.Zebra.Tools
{
    internal interface IPaintOptions : IItemSelector
    {
        public bool AlignToItemGrid { get; }
    }
}