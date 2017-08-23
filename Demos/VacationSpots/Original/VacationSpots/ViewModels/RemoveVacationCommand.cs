namespace VacationSpots.ViewModels
{
    using System;
    using System.Windows.Input;

    public class RemoveVacationCommand : ICommand
    {
        private readonly MainViewModel vm;

        public RemoveVacationCommand(MainViewModel vm)
        {
            this.vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.vm.RemoveCurrentVacation();
        }

        public event EventHandler CanExecuteChanged;
    }
}