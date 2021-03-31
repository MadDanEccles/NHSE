using System;
using System.Collections.Generic;
using System.Linq;

namespace NHSE.WinForms.Zebra
{
    public class HistoryService : IHistoryService
    {
        private readonly List<Transaction> history = new List<Transaction>();

        private int position = 0;

        public bool CanRedo => position < history.Count;
        public bool CanUndo => position > 0;
        public void Redo()
        {
            if (CanRedo)
            {
                var step = history[position];
                step.Redo();
                position++;
                OnHistoryChanged();
            }
        }

        public void Undo()
        {
            if (CanUndo)
            {
                var step = history[position - 1];
                step.Undo();
                position--;
                OnHistoryChanged();
            }
        }

        public string UndoDescription => CanUndo ? history[position - 1].Description : string.Empty;

        public string RedoDescription => CanRedo ? history[position].Description : string.Empty;

        public event EventHandler HistoryChanged;

        private Transaction? transaction;

        public IHistoryTransaction BeginTransaction(string description)
        {
            if (transaction != null)
                throw new InvalidOperationException("Transaction already in progress");
            transaction = new Transaction(this, description);
            return transaction;
        }

        protected virtual void OnHistoryChanged()
        {
            HistoryChanged?.Invoke(this, EventArgs.Empty);
        }

        private class Transaction : IHistoryTransaction
        {
            public string Description { get; }
            private readonly HistoryService service;
            private readonly List<IHistoryStep> steps = new List<IHistoryStep>();
            private bool isFinalised;

            public Transaction(HistoryService service, string description)
            {
                Description = description;
                this.service = service;
            }

            public void AddStep(IHistoryStep step)
            {
                if (isFinalised)
                    throw new InvalidOperationException("Transaction has been finalised");
                this.steps.Add(step);
            }

            public void Dispose()
            {
                if (isFinalised)
                    throw new InvalidOperationException("Transaction has already been finalised");
                isFinalised = true;
                service.CommitTransaction();
            }

            public void Redo()
            {
                if (!isFinalised)
                    throw new InvalidOperationException("Transaction has not been finalised");
                foreach (var step in steps)
                    step.Redo();
            }

            public void Undo()
            {
                if (!isFinalised)
                    throw new InvalidOperationException("Transaction has not been finalised");
                for (var index = steps.Count - 1; index >= 0; index--)
                {
                    var step = steps[index];
                    step.Undo();
                }
            }
        }

        private void CommitTransaction()
        {
            if (history.Count > position)
            {
                history.RemoveRange(position, history.Count - position);
            }

            history.Add(transaction);
            transaction = null;
            position++;
            OnHistoryChanged();
        }
    }

    public interface IHistoryTransaction : IDisposable
    {
        void AddStep(IHistoryStep step);
    }
}