using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationSpots.Data;
using VacationSpots.Infrastructure;

namespace VacationSpots.ViewModels
{
    public sealed class VacationViewModel
        : BaseViewModel
    {
        private readonly VacationItem _model;

        public VacationViewModel(VacationItem model)
        {
            this._model = model;
        }

        public string Title
        {
            get
            {
                return _model.Title;
            }

            set
            {
                if (_model.Title != value)
                {
                    _model.Title = value;
                    this.OnPropertyChanged();
                }
            }
        }
        public string Subtitle
        {
            get
            {
                return _model.Subtitle;
            }

            set
            {
                if (_model.Subtitle != value)
                {
                    _model.Subtitle = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public VacationCategory CategoryOwner
        {
            get
            {
                return _model.CategoryOwner;
            }

            set
            {
                if (_model.CategoryOwner != value)
                {
                    _model.CategoryOwner = value;
                    this.OnPropertyChanged();
                }
            }
        }


        public string Description
        {
            get
            {
                return _model.Content;
            }

            set
            {
                if (_model.Content != value)
                {
                    _model.Content = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string Image
        {
            get
            {
                return Environment.CurrentDirectory + _model.Image;
            }
        }
    }
}
