using System;
using System.IO;
using System.IO.Compression;

namespace Nhtid.WinForms.Documents
{
    class NhtidProjectDocumentFactory : IDocumentFactory
    {
        public string FilePattern { get; } = "NHTID Projects (*.nhtid)|*.nhtid";

        public Document Load(string filePath)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            ZipFile.ExtractToDirectory(filePath, tempPath);
            return new Document(filePath, tempPath, Path.GetFileNameWithoutExtension(filePath));
        }

        public void Save(Document document, string filePath)
        {
            document.SaveToTemp(true);
            ZipFile.CreateFromDirectory(document.TempFolderPath, filePath);
            document.Title = Path.GetFileNameWithoutExtension(filePath);
        }

        public bool IsLossy(Document document)
        {
            return false;
        }

        public string Name => "NHTID Project";
        public bool CanHandleFile(string fileName)
        {
            return Path.GetExtension(fileName).Equals(".nhtid", StringComparison.OrdinalIgnoreCase);
        }
    }
}