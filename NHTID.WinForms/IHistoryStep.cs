namespace Nhtid.WinForms
{
    public interface IHistoryStep
    {
        void Undo();

        void Redo();
    }
}