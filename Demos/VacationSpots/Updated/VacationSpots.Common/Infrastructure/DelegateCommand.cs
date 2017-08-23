using System;
using System.Windows.Input;

namespace VacationSpots.Common.Infrastructure
{
    public interface IDelegateCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }

    public class DelegateCommand : IDelegateCommand
    {
        private readonly Action work;

        private readonly Func<bool> canDoWork;

        public DelegateCommand(Action work, Func<bool> canDoWork = null)
        {
            this.work = work;
            this.canDoWork = canDoWork;
        }

        public bool CanExecute(object parameter)
        {
            return canDoWork == null || canDoWork();
        }

        public void Execute(object parameter)
        {
            work();
        }

        public event EventHandler CanExecuteChanged;


        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}