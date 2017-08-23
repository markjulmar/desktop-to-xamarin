using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CLScraper.Common;

namespace CLScraper
{
    public partial class CLScraper : Form
    {
        List<Item> foundItems;

        public CLScraper()
        {
            InitializeComponent();
            listBox1.MouseDoubleClick += listBox1_MouseDoubleClick;
            cityComboBox.Items.AddRange(CraigsList.Cities);
            cityComboBox.SelectedIndex = 0;
        }

        void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string target = ((sender as ListBox)?.SelectedItem as Item).Link;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            string city = cityComboBox.Text;
            string currentSearchTerm = searchForTextBox.Text;

            if (string.IsNullOrEmpty(city)
                || string.IsNullOrEmpty(currentSearchTerm))
                return;

            try
            {
                foundItems = (await CraigsList.Search(city, currentSearchTerm)).ToList();
                listBox1.DataSource = foundItems;
                listBox1.DisplayMember = "Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to CraigsList: {ex.Message}");
            }
        }
    }
}
