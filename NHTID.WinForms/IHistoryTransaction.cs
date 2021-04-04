using System;

namespace Nhtid.WinForms
{
    public interface IHistoryTransaction : IDisposable
    {
        void AddStep(IHistoryStep step);
    }
}