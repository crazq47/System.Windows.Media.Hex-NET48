#define NETFRAMEWORK

using System;
using System.Globalization;
using System.Windows.Data;

namespace System.Windows.Media.Hex
{
    /// <summary>
    /// Converts a <see cref="HexColor"/> <see langword="object"/> to a <see cref="Color"/> object and vice versa.
    /// </summary>
    public class HexConverter : IValueConverter
    {
        /// <summary>
        /// Converts a <see cref="HexColor"/> <see langword="object"/> to a <see cref="Color"/> object.
        /// </summary>
        /// <param name="value">The <see cref="HexColor"/> <see langword="object"/> to convert.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A <see cref="Color"/> <see langword="object"/> converted from the <see cref="HexColor"/> object.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is HexColor hexColor)
            {
                return hexColor.ToColor();
            }

            return null;
        }

        /// <summary>
        /// Converts a <see cref="Color"/> <see langword="object"/> to a <see cref="HexColor"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Color"/> <see langword="object"/> to convert.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A <see cref="HexColor"/> <see langword="object"/> converted from the <see cref="Color"/> object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color color)
            {
                return new HexColor(color);
            }

            return null;
        }
    }
}
