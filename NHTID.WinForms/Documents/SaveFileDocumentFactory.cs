using System;
using System.IO;
using NHSE.Core;

namespace Nhtid.WinForms.Documents
{
    class SaveFileDocumentFactory : IDocumentFactory
    {
        public string FilePattern { get; } = "ACNH Save Games (main.dat)|main.dat";

        public Document Load(string filePath)
        {
            if (!CanHandleFile(filePath))
            {
                throw new Exception("The map must be saved to a file named 'main.dat'");
            }
            string folderPath = Path.GetDirectoryName(filePath);
            string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            FileExtensions.CopyFilesRecursively(
                new DirectoryInfo(folderPath),
                new DirectoryInfo(tempPath));
            return new Document(filePath, tempPath, Path.GetFileName(folderPath));
        }

        public void Save(Document document, string filePath)
        {
            if (!CanHandleFile(filePath))
            {
                throw new Exception("The map must be saved to a file named 'main.dat'");
            }
            document.SaveToTemp(false);
            string destFolderPath = Path.GetDirectoryName(filePath);
            FileExtensions.CopyFilesRecursively(
                new DirectoryInfo(document.TempFolderPath),
                new DirectoryInfo(destFolderPath),
                true);
            document.Title = Path.GetFileName(destFolderPath);
        }

        public bool IsLossy(Document document)
        {
            return document.PersistentTemplate.IsPopulated;
        }

        public string Name => "ACNH Save Game";
        public bool CanHandleFile(string fileName)
        {
            return "main.dat".Equals(Path.GetFileName(fileName), StringComparison.OrdinalIgnoreCase);
        }
    }
}