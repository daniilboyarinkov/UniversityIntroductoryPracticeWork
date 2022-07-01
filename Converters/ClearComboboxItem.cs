using System;
using System.Globalization;
using System.Windows.Data;

namespace TodoApp.Converters
{
    internal class ClearComboboxItem : IValueConverter
    {
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.

#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            value.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
    }
}
