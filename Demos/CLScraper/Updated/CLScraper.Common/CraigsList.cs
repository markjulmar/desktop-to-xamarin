using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLScraper.Common
{
    public static class CraigsList
    {
        public static string[] Cities => new[]
        {
            "Atlanta",
            "Austin",
            "Boston",
            "Chicago",
            "Dallas",
            "Denver",
            "Detroit",
            "Houston",
            "Las Vegas",
            "Los Angeles",
            "Miami",
            "Minneapolis",
            "New York",
            "Orange County",
            "Philidelphia",
            "Phoenix",
            "Portland",
            "Raleigh",
            "Sacramento",
            "San Diego",
            "Seattle",
            "SF Bay",
            "Washington DC"
        };

        public static async Task<IEnumerable<Item>> Search(string city, string searchTerm)
        {
            if (city == null) throw new ArgumentNullException(nameof(city));
            if (searchTerm == null) throw new ArgumentNullException(nameof(searchTerm));

            string url = $"http://{city.Replace(" ","").ToLower()}.craigslist.org/search/cta?query={searchTerm}&format=rss";

            using (var client = new HttpClient())
            {
                string response = await client.GetStringAsync(new Uri(url))
                                              .ConfigureAwait(false);
                return ParseResponse(response);
            }
        }

        private static IEnumerable<Item> ParseResponse(string response)
        {
            XDocument doc = XDocument.Parse(response);
            XElement topElement = doc.Elements().FirstOrDefault();

            return ParseItems(topElement.Elements()
                .Where(e => e.Name.LocalName == "item")
                .ToList());
        }

        private static IEnumerable<Item> ParseItems(List<XElement> items)
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
