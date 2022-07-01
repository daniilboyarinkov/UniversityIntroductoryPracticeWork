using System;
using System.Globalization;
using System.Windows.Data;

namespace TodoApp.Converters
{
    internal class CategoryToRussianConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value switch
        {
            "Срочно" => "Срочно",
            "Important" => "Срочно",
            "Работа" => "Работа",
            "Work" => "Работа",
            "Учеба" => "Учеба",
            "Education" => "Учеба",
            "Саморазвитие" => "Саморазвитие",
            "SelfDevelopment" => "Саморазвитие",
            "Домашние дела" => "Домашние дела",
            "HouseWork" => "Домашние дела",
            "Второстепенно" => "Второстепенно",
            "Secondary" => "Второстепенно",
            _ => "Secondary",
        };

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
