using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net.Http;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace CLScraper
{
    public partial class CLScraperForm : Form
    {
        public CLScraperForm()
        {
            InitializeComponent();
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

            string url = $"http://{city}.craigslist.org/search/cta?query={currentSearchTerm}&format=rss";
            using (var client = new HttpClient())
            {
                string results = await client.GetStringAsync(new Uri(url));
                ResultListBox.DataSource = ParseResponse(results).ToList();
                ResultListBox.DisplayMember = nameof(Item.Value);
            }
        }

        private IEnumerable<Item> ParseResponse(string response)
        {
            XDocument doc = XDocument.Parse(response);
            XElement topElement = doc.Elements().FirstOrDefault();
            return topElement == null
                ? Enumerable.Empty<Item>()
                : ParseItems(topElement.Elements()
                    .Where(e => e.Name.LocalName == "item")
                    .ToList());
        }

        private IEnumerable<Item> ParseItems(List<XElement> items)
        {
            foreach (XElement item in items)
            {
                var currentItem = new Item();
                List<XElement> itemElements = item.Elements().ToList();

                string rawDate = itemElements[3].Value;
                currentItem.Date = DateTime.Parse(rawDate);

                currentItem.Link = itemElements[1].Value;

                string title = itemElements[0].Value;
                int start = title.IndexOf('(');
                int end = title.LastIndexOf(')');
                if (start >= 0 && end > start)
                {
                    int len = end - start;
                    currentItem.Location = title.Substring(start + 1, len - 1);
                }

                const string pricePattern = @"\;[0-9]+";
                Match m = Regex.Match(title, pricePattern);
                if (m.Success)
                {
                    var price = m.Value;
                    price = price.Substring(1, price.Length - 1);
                    if (Double.TryParse(price, out double dprice))
                    {
                        currentItem.Price = dprice;
                    }
                }

                const string descriptionPattern = @"[^\(]+";
                m = Regex.Match(title, descriptionPattern);
                if (m.Success)
                {
                    currentItem.Title = m.Value;
                }

                yield return currentItem;
            }
        }
    }
}
