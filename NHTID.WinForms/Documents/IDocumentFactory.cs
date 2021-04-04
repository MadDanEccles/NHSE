namespace Nhtid.WinForms.Documents
{
    public interface IDocumentFactory
    {
        string FilePattern { get; }

        IDocument Load(string filePath);

        string Name { get; }
    }
}