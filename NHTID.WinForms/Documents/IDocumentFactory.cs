namespace Nhtid.WinForms.Documents
{
    public interface IDocumentFactory
    {
        string FilePattern { get; }

        Document Load(string filePath);

        string Name { get; }
        bool CanHandleFile(string fileName);
        void Save(Document document, string filePath);
        bool IsLossy(Document document);
    }
}