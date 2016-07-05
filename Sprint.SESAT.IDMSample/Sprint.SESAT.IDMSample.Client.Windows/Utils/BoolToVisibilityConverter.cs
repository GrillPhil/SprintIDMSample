using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Sprint.SESAT.IDMSample.Client.Windows.Utils
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter != null)
                return (bool) value ? Visibility.Collapsed : Visibility.Visible;

            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
