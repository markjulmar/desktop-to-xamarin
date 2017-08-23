using System.IO;
using VacationSpots.Common.Infrastructure;
using VacationSpots.Data;

namespace VacationSpots.ViewModels
{
    public sealed class VacationViewModel : BaseViewModel
    {
        private readonly VacationItem model;

        public VacationViewModel(VacationItem model)
        {
            this.model = model;
        }

        public string Title
        {
            get => model.Title;

            set
            {
                if (model.Title != value)
                {
                    model.Title = value;
                    this.OnPropertyChanged();
                }
            }
        }
        public string Subtitle
        {
            get => model.Subtitle;

            set
            {
                if (model.Subtitle != value)
                {
                    model.Subtitle = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public VacationCategory CategoryOwner
        {
            get => model.CategoryOwner;

            set
            {
                if (model.CategoryOwner != value)
                {
                    model.CategoryOwner = value;
                    this.OnPropertyChanged();
                }
            }
        }


        public string Description
        {
            get => model.Content;

            set
            {
                if (model.Content != value)
                {
                    model.Content = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public Stream ImageStream => EmbeddedResource.GetStream(ImageName, typeof(VacationViewModel));

        public string ImageName => "VacationSpots.Common." + model.Image;
    }
}
