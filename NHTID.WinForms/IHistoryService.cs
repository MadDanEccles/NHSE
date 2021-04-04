using System;

namespace Nhtid.WinForms
{
    public interface IHistoryService
    {
        bool CanRedo { get; }
        bool CanUndo { get; }
        void Redo();
        void Undo();
        string UndoDescription { get; }
        string RedoDescription { get; }
        event EventHandler HistoryChanged;

        IHistoryTransaction BeginTransaction(string description);
        void Clear();
    }
}