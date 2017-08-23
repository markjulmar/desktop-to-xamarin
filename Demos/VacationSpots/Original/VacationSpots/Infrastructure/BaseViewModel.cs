using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace VacationSpots.Infrastructure
{
    using System.Runtime.CompilerServices;

    public class BaseViewModel
        : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected bool RaisePropertyChanged<T>(ref T field, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (Object.Equals(field, newValue) == false)
            {
                field = newValue;
                this.OnPropertyChanged(propertyName);
                return true;
            }
            return false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this,
                new PropertyChangedEventArgs(propertyName));
        }

    }
}
