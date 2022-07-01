using System;
using System.Globalization;
using System.Windows.Data;

namespace TodoApp.Converters
{
    internal class CategoryToSvgConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => 
            $"/{ConvertCategoryFromRussian(value.ToString() ?? "Secondary")}.png";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        static string ConvertCategoryFromRussian(string inp) => inp switch
        {
            "Срочно" => "Important",
            "Important" => "Important",
            "Работа" => "Work",
            "Work" => "Work",
            "Учеба" => "Education",
            "Education" => "Education",
            "Саморазвитие" => "SelfDevelopment",
            "SelfDevelopment" => "SelfDevelopment",
            "Домашние дела" => "HouseWork",
            "HouseWork" => "HouseWork",
            "Второстепенно" => "Secondary",
            "Secondary" => "Secondary",
            _ => "Secondary",
        };
    }
}
