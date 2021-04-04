namespace Nhtid.WinForms
{
    public interface IItemCollectionStore 
    {
        void Save();
        void Backup();
        ItemCollectionCatalog Root { get; }
    }
}