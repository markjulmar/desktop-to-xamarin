namespace VacationSpots.ViewModels
{
    using System;
    using System.Windows;
    using System.Windows.Input;

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


        //public event EventHandler CanExecuteChanged
        //{
        //    add
        //    {
        //        CommandManager.RequerySuggested += value;
        //    }

        //    remove
        //    {
        //        CommandManager.RequerySuggested -= value;
        //    }
        //}

        public void RaiseCanExecuteChanged()
        {
            var cec = CanExecuteChanged;
            if (cec != null)
            {
                cec(this, EventArgs.Empty);
            }
        }
    }
}