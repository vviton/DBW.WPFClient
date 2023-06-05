using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace DBW.WPFClient.Converters
{
    public class AreaLevelNameToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
                switch (value as string)
                {
                    case "Temat":
                        return Brushes.Green;
                    case "Zakres informacyjny":
                        return Brushes.Red;
                       
                    case "Dziedzina":
                        return Brushes.Yellow;
                        
                    default:
                        return Brushes.Transparent;
                        
                }
            }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
