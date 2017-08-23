using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using VacationSpots.Common.Infrastructure;
using VacationSpots.Data;

namespace VacationSpots.ViewModels
{
    public sealed class MainViewModel : BaseViewModel
    {
        private VacationViewModel selectedVacation;
        public IDelegateCommand RemoveCommand { get; }

        public IList<VacationViewModel> AllVacations { get; }

        public VacationViewModel SelectedVacation
        {
            get => this.selectedVacation;
            set
            {
                if (this.SetProperty(ref this.selectedVacation, value))
                {
                    RemoveCommand?.RaiseCanExecuteChanged();
                }
            }
        }

        public IList<VacationCategory> AllCategories { get; }

        public MainViewModel()
        {
            AllVacations = new ObservableCollection<VacationViewModel>(
                VacationDataSource.Instance.AllVacations
                    .Select(vi => new VacationViewModel(vi)));
            AllCategories = VacationDataSource.Instance.AllCategories;

            SelectedVacation = AllVacations.First();
            RemoveCommand = new DelegateCommand(this.RemoveCurrentVacation, () => SelectedVacation != null);
        }

        public void RemoveCurrentVacation()
        {
            var currentVacation = SelectedVacation;
            if (currentVacation != null)
            {
                AllVacations.Remove(currentVacation);
                SelectedVacation = AllVacations.First();
            }
        }
    }
}
