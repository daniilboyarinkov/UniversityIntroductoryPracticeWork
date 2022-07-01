using System;
using System.Globalization;
using System.Windows.Data;

namespace TodoApp.Converters
{
    internal class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            ((DateTime)value == DateTime.MinValue) ? "Задача не завершена" : value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
