using System;

namespace CLScraper.Common
{
    public class Item
    {
        public string Link { get; set; }
        public double? Price { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }

        public string Value => $"{Date:g}: {Price?.ToString("C") ?? "NO PRICE"} {Location} {Title}";
    }
}
