#define NETFRAMEWORK

using System;

namespace System.Windows.Media.Hex
{
    /// <summary>
    /// A <see langword="static"/> <see langword="class"/> providing extension methods for <see cref="string"/> manipulation.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Removes the leading '#' <see langword="char"/> from the input <see cref="string"/> if present.
        /// </summary>
        /// <param name="input">The input string to process.</param>
        /// <returns>A <see langword="new"/> <see langword="string"/> with the leading '#' <see langword="char"/> removed, or the original <see langword="string"/> if it is <see langword="null"/> or empty.</returns>
        public static string TrimHash(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return input.TrimStart(HexCode.Hash);
        }
    }

    /// <summary>
    /// Extension methods for the <see cref="Color"/> <see langword="class"/> to handle conversion from hexadecimal color codes.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts a hexadecimal color code to a <see cref="Color"/> object.
        /// </summary>
        /// <param name="color">The original <see cref="Color"/> object (used for extension methods).</param>
        /// <param name="hexCode">The hexadecimal color code to convert.</param>
        /// <returns>A <see cref="Color"/> object representing the specified hexadecimal color code, or the original color if the conversion fails.</returns>
        public static Color FromString(this Color color, string hexCode)
        {
            if (!HexCode.IsHexColorCode(hexCode))
                return color;

            byte a = HexCode.GetAlphaValue(hexCode);
            byte r = HexCode.GetColorValue(hexCode, "R");
            byte g = HexCode.GetColorValue(hexCode, "G");
            byte b = HexCode.GetColorValue(hexCode, "B");

            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// Converts a <see cref="HexColor"/> object to a <see cref="Color"/> object.
        /// </summary>
        /// <param name="color">The original <see cref="Color"/> object (used for extension methods).</param>
        /// <param name="hexColor">The <see cref="HexColor"/> object to convert.</param>
        /// <returns>A <see cref="Color"/> object representing the specified <see cref="HexColor"/> object.</returns>
        public static Color FromHexColor(this Color color, HexColor hexColor)
        {
            if (!HexCode.IsHexColorCode(hexColor.ToString()))
                return color;

            return Color.FromArgb(hexColor.A, hexColor.R, hexColor.G, hexColor.B);
        }

        /// <summary>
        /// Converts a <see cref="System.Windows.Media.Color"/> to a <see cref="HexColor"/>.
        /// </summary>
        /// <remarks>
        ///   This extension method allows you to convert a <see cref="System.Windows.Media.Color"/>
        ///   to its equivalent <see cref="HexColor"/> representation.
        /// </remarks>
        /// <param name="color">The <see cref="System.Windows.Media.Color"/> to convert.</param>
        /// <returns>A <see cref="HexColor"/> instance representing the specified color.</returns>
        public static HexColor ToHexColor(this Color color)
        {
            return HexColor.FromColor(color);
        }

        /// <summary>
        /// Gets an array of color values representing the <see cref="System.Windows.Media.Color"/>.
        /// </summary>
        /// <remarks>
        ///   This extension method is an alternative to <see cref="System.Windows.Media.Color.GetNativeColorValues()"/> to retrieve an array of color values (A, R, G, B)
        ///   representing the <see cref="System.Windows.Media.Color"/>.<br/><br/>
        ///   
        ///   Removes the error with a <see langword="null"/> input color context that is present in the original method.
        /// </remarks>
        /// <param name="color">The <see cref="System.Windows.Media.Color"/> to extract values from.</param>
        /// <returns>An array of color values (A, R, G, B) normalized between 0 and 1.</returns>
        public static float[] GetColorValues(this Color color)
        {
            HexColor hexColor = new HexColor(color);
            return hexColor.GetColorValues();
        }
    }
}
