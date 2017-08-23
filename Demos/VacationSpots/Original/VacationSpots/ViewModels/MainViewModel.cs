using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using VacationSpots.Data;
using VacationSpots.Infrastructure;

namespace VacationSpots.ViewModels
{
    public sealed class MainViewModel : BaseViewModel
    {
        private VacationViewModel selectedVacation;

        public IDelegateCommand RemoveCommand { get; private set; }

        public IList<VacationViewModel> AllVacations { get; private set; }

        public VacationViewModel SelectedVacation
        {
            get
            {
                return this.selectedVacation;
            }
            set
            {
                if (this.RaisePropertyChanged(ref this.selectedVacation, value))
                {
                    // Selection changed - force command
                    // to query.
                    RemoveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public IList<VacationCategory> AllCategories { get; private set; }

        public MainViewModel()
        {
            AllVacations = new ObservableCollection<VacationViewModel>(
                VacationDataSource.Instance.AllVacations
                    .Select(vi => new VacationViewModel(vi)));

            //SelectedVacation = AllVacations.First();
            RemoveCommand = new DelegateCommand(this.RemoveCurrentVacation, () => SelectedVacation != null);

            AllCategories = VacationDataSource.Instance.AllCategories;
        }

        public void RemoveCurrentVacation()
        {
            var currentVacation = SelectedVacation;
            if (currentVacation != null)
            {
                AllVacations.Remove(currentVacation);
                //SelectedVacation = AllVacations.First();
            }
        }
    }
}
