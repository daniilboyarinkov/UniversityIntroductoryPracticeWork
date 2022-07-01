using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TodoApp.Converters
{
    internal class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value?.ToString()?.Replace("System.Windows.Controls.ComboBoxItem: ", "") switch
            {
                "Created" => Brushes.Gray,
                "Progressed" => Brushes.Green,
                "Выполняется" => Brushes.Green,
                "Stoped" => Brushes.Red,
                "Приостановлено" => Brushes.Red,
                "Finished" => Brushes.Orange,
                "Завершено" => Brushes.Orange,
                _ => Brushes.Gray,
            };

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
