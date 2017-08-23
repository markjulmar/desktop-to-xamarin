using System;

namespace VacationSpots.Data
{
    public class VacationBase
    {
        public VacationBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        public VacationBase(string id, string title, string subtitle, string imagePath, string description)
        {
            Id = id;
            Title = title;
            Subtitle = subtitle;
            Description = description;
            Image = imagePath;
        }

        public string Id { get; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}