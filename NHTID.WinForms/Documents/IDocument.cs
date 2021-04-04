using NHSE.Core;

namespace Nhtid.WinForms.Documents
{
    public interface IDocument
    {
        void Save();

        string Title { get; }

        MapManager GetMapManager();
    }
}