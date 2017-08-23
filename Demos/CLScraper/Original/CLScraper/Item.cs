using System;
using System.Xml.Linq;

namespace CLScraper
{
    public class Item
    {
        public Item(int Num, string SearchTerm)
        {
            title = "";
            location = "";
            num = Num;
            searchTerm = SearchTerm;
            ID = Num + "," + SearchTerm;
        }

        public XElement elem;

        public int num;
        public string searchTerm;
        public string ID;

        public string link;
        public double? price;
        public DateTime date;
        public string location;
        public string title;

        public string Value
        {
            get
            {
                if (price != null)
                {
                    return "$" + price + ", " + date + ", " + location + ", " + title;
                }

                return "NO PRICE" + date + ", " + location + ", " + title;
            }
        }

        public string formatForCSV()
        {
            return ID + "," + link + "," + price + "," + date + "," + location + "," + title;
        }


    }
}
