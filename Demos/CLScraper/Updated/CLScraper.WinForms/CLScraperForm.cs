using System;
using System.Linq;
using System.Windows.Forms;
using CLScraper.Common;

namespace CLScraper
{
    public partial class CLScraperForm : Form
    {
        public CLScraperForm()
        {
            InitializeComponent();
            cityComboBox.DataSource = CraigsList.Cities;
            cityComboBox.SelectedIndex = 0;
        }

        void OnShowItem(object sender, MouseEventArgs e)
        {
            string target = (ResultListBox.SelectedItem as Item)?.Link;
            if (string.IsNullOrEmpty(target))
                return;

            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private async void OnSearchClicked(object sender, EventArgs e)
        {
            var city = cityComboBox.Text;
            var currentSearchTerm = searchForTextBox.Text;

            if (string.IsNullOrEmpty(city)
                || string.IsNullOrEmpty(currentSearchTerm))
                return;

            ResultListBox.DataSource = (await CraigsList.Search(city, currentSearchTerm)).ToList();
            ResultListBox.DisplayMember = nameof(Item.Value);
        }
    }
}
