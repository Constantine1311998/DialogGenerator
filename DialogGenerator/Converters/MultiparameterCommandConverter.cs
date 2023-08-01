using System;
using System.Globalization;
using System.Windows.Data;

namespace DialogGenerator.Converters
{
    /// <summary>
    /// Converter that can be used for returning multiple items for the command
    /// </summary>
    public class MultiparameterCommandConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}