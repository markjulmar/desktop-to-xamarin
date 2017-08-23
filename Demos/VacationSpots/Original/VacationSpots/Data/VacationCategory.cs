using System.Collections.Generic;

namespace VacationSpots.Data
{
    public sealed class VacationCategory : VacationBase
    {
        public IList<VacationItem> Items { get; private set; }

        public VacationCategory(string id, string title, string subtitle, string imagePath, string description) 
            : base(id, title, subtitle, imagePath, description)
        {
            Items = new List<VacationItem>();
        }
    }
}