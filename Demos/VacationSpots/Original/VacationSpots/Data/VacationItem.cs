using System;

namespace VacationSpots.Data
{
    public sealed class VacationItem : VacationBase
    {
        public VacationItem(string id, string title = null, string subtitle = null, string imagePath = null, string content = null) 
            : base(id, title, subtitle, imagePath, null)
        {
            Content = (content != null) ? content.Trim() : "";
        }

        public string Content { get; set; }
        public VacationCategory CategoryOwner { get; set; }
    }
}