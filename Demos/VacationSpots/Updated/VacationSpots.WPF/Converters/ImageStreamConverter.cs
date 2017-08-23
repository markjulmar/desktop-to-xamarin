using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VacationSpots.Converters
{
    public class ImageStreamConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stm = value as Stream;
            if (targetType != typeof(ImageSource) || stm == null)
                return null;

            var imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.StreamSource = stm;
            imageSource.EndInit();

            return imageSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
