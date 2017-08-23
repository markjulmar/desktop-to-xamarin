using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using VacationSpots.Data;

namespace VacationSpots
{
    using System.Linq;

    using VacationSpots.ViewModels;

    public partial class AllVacationsWindow
    {
        public AllVacationsWindow()
        {
            InitializeComponent();
        }

        private MainViewModel ViewModel
        {
            get
            {
                return (MainViewModel)DataContext;
            }
        }

        private void OnShowCurrentVacation(object sender, RoutedEventArgs e)
        {
            var currentVacation = ViewModel.SelectedVacation;
            if (currentVacation != null)
            {
                MessageBox.Show(string.Format("{0} - {1} [{2}]",
                            currentVacation.Title, currentVacation.Subtitle,
                            currentVacation.CategoryOwner.Title));
            }
        }

        //private void OnRemoveVacation(object sender, RoutedEventArgs e)
        //{
        //    ViewModel.RemoveCurrentVacation();
        //}
    }
}
