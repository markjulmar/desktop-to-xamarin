using System;
using System.Linq;
using CLScraper.Common;
using Xamarin.Forms;

namespace MobileCLScraper
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSearchButtonPressed(object sender, EventArgs e)
        {
            string city = SearchCity.SelectedItem?.ToString();
            string searchFor = SearchFor.Text;
            if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(searchFor))
                return;

            try
            {
                Results.ItemsSource = (await CraigsList.Search(city, searchFor)).ToList();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to connect to CraigsList: {ex.Message}.", "OK");
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            string url = ((Item) e.Item).Link;
            if (!string.IsNullOrEmpty(url))
            {
                Device.OpenUri(new Uri(url));
            }
        }
    }
}
