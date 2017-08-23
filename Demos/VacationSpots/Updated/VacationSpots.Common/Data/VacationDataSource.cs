using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using VacationSpots.Common.Infrastructure;

namespace VacationSpots.Data
{
    using System.Collections.ObjectModel;

    sealed class VacationDataSource
    {
        private static readonly Lazy<VacationDataSource> instance = new Lazy<VacationDataSource>();
        private readonly List<VacationCategory> allCategories = new List<VacationCategory>();
        private readonly ObservableCollection<VacationItem> allVacations = new ObservableCollection<VacationItem>();

        public static VacationDataSource Instance => instance.Value;
        public IList<VacationCategory> AllCategories => allCategories;
        public IList<VacationItem> AllVacations => allVacations;

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
            var data = EmbeddedResource.GetStream("VacationSpots.Common.Data.VacationData.xml");
            XDocument doc = XDocument.Load(data);
            if (doc.Root != null)
            {
                foreach (XElement category in doc.Root.Elements("category"))
                {
                    var vacationCategory = new VacationCategory(
                        category.Attribute("id").Value,
                        category.Attribute("title").Value,
                        category.Attribute("subtitle").Value,
                        category.Attribute("image").Value,
                        category.Attribute("description").Value);
                    
                    allCategories.Add(vacationCategory);

                    foreach (XElement trip in category.Elements("destination"))
                    {
                        var item = new VacationItem(
                            trip.Attribute("id").Value,
                            trip.Attribute("title").Value,
                            trip.Attribute("subtitle").Value,
                            trip.Attribute("image").Value, trip.Value) { CategoryOwner = vacationCategory };
                        vacationCategory.Items.Add(item);
                        allVacations.Add(item);
                    }
                }
            }
        }
    }
}
