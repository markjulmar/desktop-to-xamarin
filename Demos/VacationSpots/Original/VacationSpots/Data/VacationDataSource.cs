using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace VacationSpots.Data
{
    using System.Collections.ObjectModel;

    sealed class VacationDataSource
    {
        private static readonly Lazy<VacationDataSource> _instance = 
            new Lazy<VacationDataSource>();

        public static VacationDataSource Instance
        {
            get { return _instance.Value; }
        }

        private readonly List<VacationCategory> _allCategories = new List<VacationCategory>();
        private readonly ObservableCollection<VacationItem> _allVacations = new ObservableCollection<VacationItem>();

        public IList<VacationCategory> AllCategories
        {
            get { return _allCategories; }
        }

        public IList<VacationItem> AllVacations
        {
            get
            {
                return _allVacations;
            }
        }

        public VacationCategory GetCategory(string id)
        {
            return AllCategories
                .FirstOrDefault(group => group.Id.Equals(id));
        }

        public VacationItem GetVacation(string id)
        {
            return AllCategories
                .SelectMany(group => group.Items)
                .FirstOrDefault(item => item.Id.Equals(id));
        }

        public VacationDataSource()
        {
            XDocument doc = XDocument.Load(@"data/VacationData.xml");
            if (doc != null)
            {
                foreach (XElement category in doc.Root.Elements("category"))
                {
                    VacationCategory vacationCategory = new VacationCategory(
                        category.Attribute("id").Value,
                        category.Attribute("title").Value,
                        category.Attribute("subtitle").Value,
                        category.Attribute("image").Value,
                        category.Attribute("description").Value);
                    
                    _allCategories.Add(vacationCategory);

                    foreach (XElement trip in category.Elements("destination"))
                    {
                        VacationItem item = new VacationItem(
                            trip.Attribute("id").Value,
                            trip.Attribute("title").Value,
                            trip.Attribute("subtitle").Value,
                            trip.Attribute("image").Value, trip.Value) { CategoryOwner = vacationCategory };
                        vacationCategory.Items.Add(item);
                        _allVacations.Add(item);
                    }
                }
            }
        }
    }
}
