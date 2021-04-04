using System.IO;

namespace Nhtid.WinForms.Documents
{
    class SaveFileDocumentFactory : IDocumentFactory
    {
        public string FilePattern { get; } = "ACNH Save Games (main.dat)|main.dat";

        public IDocument Load(string filePath)
        {
            string folderPath = Path.GetDirectoryName(filePath);
            return new SaveFileDocument(folderPath);
        }

        public string Name => "ACNH Save Game";
    }
}