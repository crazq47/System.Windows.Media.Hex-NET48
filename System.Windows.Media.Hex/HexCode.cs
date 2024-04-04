#define NETFRAMEWORK

using System;
using System.Linq;

namespace System.Windows.Media.Hex
{
    /// <summary>
    /// Provides utility methods for working with hexadecimal color codes.
    /// </summary>
    public class HexCode
    {
        /// <summary>
        /// Represents the '#' character used as a prefix in hexadecimal color codes. 
        /// </summary>
        /// <remarks>
        /// ASCII (35), Hex (0x23), Unicode (U+0023).
        /// </remarks>
        public static readonly char Hash = (char)0x23;

        /// <summary>
        /// Gets the alpha (transparency) value of the <see cref="string"/> hexadecimal code.
        /// </summary>
        /// <param name="hexColor">The <see cref="string"/> hexadecimal code to get the alpha value from.</param>
        /// <returns>The alpha value.</returns>
        public static byte GetAlphaValue(string hexColor)
        {
            string code = hexColor.TrimHash();
            if (IsHexColorWithAlpha(hexColor))
                return Convert.ToByte(code.Substring(0, 2), 16);

            return 255;
        }

        /// <summary>
        /// Gets the alpha (transparency) value of the <see cref="HexColor"/>.
        /// </summary>
        /// <param name="hexColor">The <see cref="HexColor"/> to get the alpha value from.</param>
        /// <returns>The alpha value.</returns>
        public static byte GetAlphaValue(HexColor hexColor)
        {
            return GetAlphaValue(hexColor.ToString());
        }

        /// <summary>
        /// Gets the value of a specific color component (R, G, or B) from a hexadecimal color code.
        /// </summary>
        /// <param name="hexColor">The hexadecimal color code to retrieve the color component value from (with or without '#' prefix).</param>
        /// <param name="targetColor">The target color component to retrieve, specified as "R", "G", or "B".</param>
        /// <returns>The value of the specified color component in the hexadecimal color code.</returns>
        /// <exception cref="InvalidHexColorFormatException">
        /// Thrown when the hexadecimal color code is invalid, either not in the expected format or containing an unsupported value.
        /// </exception>
        public static byte GetColorValue(string hexColor, string targetColor)
        {
            if (!IsHexColorCode(hexColor))
                throw new InvalidHexColorFormatException();

            string code = GetLongHexColor(hexColor).TrimHash();

            switch (targetColor.ToUpper())
            {
                case "R":
                    return Convert.ToByte(code.Substring(code.Length - 6, 2), 16);
                case "G":
                    return Convert.ToByte(code.Substring(code.Length - 4, 2), 16);
                case "B":
                    return Convert.ToByte(code.Substring(code.Length - 2, 2), 16);
            }

            return 0;
        }

        /// <summary>
        /// Gets the value of a specific color component (R, G, or B) from a <see cref="HexColor"/> instance.
        /// </summary>
        /// <param name="hexColor">The <see cref="HexColor"/> instance to retrieve the color component value from.</param>
        /// <param name="targetColor">The target color component to retrieve, specified as "R", "G", or "B".</param>
        /// <returns>The value of the specified color component in the <see cref="HexColor"/> instance.</returns>
        public static byte GetColorValue(HexColor hexColor, string targetColor)
        {
            return GetColorValue(hexColor.ToString(), targetColor);
        }

        /// <summary>
        /// Gets the fill (without alfa) value of the <see cref="HexColor"/>.
        /// </summary>
        /// <param name="hexColor">The <see cref="string"/> to get the fill value from.</param>
        /// <returns>The fill value.</returns>
        public static string GetFillColor(string hexColor)
        {
            string code = hexColor.TrimHash();
            if (IsHexColorCode(hexColor))
                return $"{Hash}{code.Substring(code.Length - GetFillColorLenght(hexColor))}";

            return null;
        }

        /// <summary>
        /// Gets the fill color part of a <see cref="HexColor"/> as a <see cref="string"/>.
        /// </summary>
        /// <param name="hexColor">The <see cref="HexColor"/> instance.</param>
        /// <returns>The fill color part of the <see cref="HexColor"/> as a <see cref="string"/>.</returns>
        public static string GetFillColor(HexColor hexColor)
        {
            return GetFillColor(hexColor.ToString());
        }

        /// <summary>
        /// Gets the length of the hexadecimal color code excluding the '#' symbol.
        /// </summary>
        /// <param name="hexColor">The hexadecimal color code.</param>
        /// <returns>The length of the hexadecimal color code, or -1 if the format is invalid.</returns>
        public static int GetHexLenght(string hexColor)
        {
            string code = hexColor.TrimHash();
            if (IsHexColorCode(code))
                return code.Length;

            return -1;
        }

        /// <summary>
        /// Gets the length of the hexadecimal color code of a <see cref="HexColor"/> instance.
        /// </summary>
        /// <param name="hexColor">The <see cref="HexColor"/> instance.</param>
        /// <returns>The length of the hexadecimal color code, or -1 if the format is invalid.</returns>
        public static int GetHexLength(HexColor hexColor)
        {
            return GetHexLenght(hexColor.ToString());
        }

        /// <summary>
        /// Gets the short version of a hexadecimal color code (e.g., #FF00DD to #F0D).
        /// </summary>
        /// <param name="hexColor">The hexadecimal color code.</param>
        /// <returns>The short version of the hexadecimal color code.</returns>
        /// <exception cref="InvalidHexColorFormatException">
        /// Thrown when the hexadecimal color code is invalid, either not in the expected format or containing an unsupported value.
        /// </exception>
        public static string GetShortHexColor(string hexColor)
        {
            if (!IsHexColorCode(hexColor))
                throw new InvalidHexColorFormatException();

            string code = hexColor.TrimHash();

            if (IsHexColorWithAlpha(hexColor))
                code = code.Substring(2);

            string[] pairs = Enumerable.Range(0, code.Length / 2)
                .Select(i => code.Substring(i * 2, 2))
                .ToArray();

            string shortcode = string.Join("", pairs.Select(pair => pair[0] == pair[1] ? pair[0].ToString() : pair));
            
            return shortcode.Length == 3 ? $"{Hash}{shortcode[0]}{shortcode[1]}{shortcode[2]}" : hexColor;
        }

        /// <summary>
        /// Gets the short version of a <see cref="HexColor"/> instance.
        /// </summary>
        /// <param name="hexColor">The <see cref="HexColor"/> instance.</param>
        /// <returns>The short version of the <see cref="HexColor"/>.</returns>
        public static string GetShortHexColor(HexColor hexColor)
        {
            return GetShortHexColor(hexColor.ToString());
        }

        /// <summary>
        /// Gets the long version of a hexadecimal color code (e.g., F0D to FF00DD).
        /// </summary>
        /// <param name="hexColor">The hexadecimal color code.</param>
        /// <returns>The long version of the hexadecimal color code.</returns>
        /// <exception cref="InvalidHexColorFormatException">
        /// Thrown when the hexadecimal color code is invalid, either not in the expected format or containing an unsupported value.
        /// </exception>
        public static string GetLongHexColor(string hexColor)
        {
            if (!IsHexColorCode(hexColor))
                throw new InvalidHexColorFormatException();

            string longcode = new string(hexColor.TrimHash().Select(c => new string(c, 2)).SelectMany(s => s).ToArray());
            return IsShortHexColor(hexColor) ? $"{Hash}{longcode}" : hexColor;
        }

        /// <summary>
        /// Gets the long version of a <see cref="HexColor"/> instance.
        /// </summary>
        /// <param name="hexColor">The <see cref="HexColor"/> instance.</param>
        /// <returns>The long version of the <see cref="HexColor"/>.</returns>
        public static string GetLongHexColor(HexColor hexColor)
        {
            return GetLongHexColor(hexColor.ToString());
        }

        /// <summary>
        /// Sets the alpha (transparency) component of a hexadecimal color code.
        /// </summary>
        /// <param name="alpha">The alpha (transparency) component value.</param>
        /// <param name="hexColor">The hexadecimal color code.</param>
        /// <returns>The hexadecimal color code with the updated alpha component.</returns>
        public static string SetAlphaValue(byte alpha, string hexColor)
        {
            string code = hexColor.TrimHash();
            return $"{Hash}{alpha:X2}{GetFillColor(code).TrimHash()}";
        }

        /// <summary>
        /// Sets the alpha (transparency) component of a <see cref="HexColor"/> instance.
        /// </summary>
        /// <param name="alpha">The alpha (trasparency) component value.</param>
        /// <param name="hexColor">The <see cref="HexColor"/> instance.</param>
        /// <returns>The <see cref="HexColor"/> instance with the updated alpha component.</returns>
        public static string SetAlphaValue(byte alpha, HexColor hexColor)
        {
            return $"{Hash}{alpha:X2}{GetFillColor(hexColor).TrimHash()}";
        }

        /// <summary>
        /// Sets the alpha (transparency) component to the maximum value (255) of a hexadecimal color code.
        /// </summary>
        /// <param name="hexColor">The hexadecimal color code.</param>
        /// <returns>The hexadecimal color code with the alpha component set to the maximum value.</returns>
        public static string SetAlphaValue(string hexColor)
        {
            return SetAlphaValue(255, hexColor);
        }

        /// <summary>
        /// Sets the alpha component to the maximum value (255) of a <see cref="HexColor"/> instance.
        /// </summary>
        /// <param name="hexColor">The <see cref="HexColor"/> instance.</param>
        /// <returns>The <see cref="HexColor"/> instance with the alpha component set to the maximum value.</returns>
        public static string SetAlphaValue(HexColor hexColor)
        {
            return SetAlphaValue(255, hexColor);
        }

        /// <summary>
        /// Sets the value of a specific color component (R, G, or B) in a hexadecimal color code and returns the modified color code.
        /// </summary>
        /// <param name="hexColor">The hexadecimal color code to modify (with or without '#' prefix).</param>
        /// <param name="targetColor">The target color component to set, specified as "R", "G", or "B".</param>
        /// <param name="value">The new value for the target color component.</param>
        /// <returns>A modified hexadecimal color code with the specified color component modified.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="targetColor"/> is not a valid color component ("R", "G", or "B").
        /// </exception>
        public static string SetColorValue(string hexColor, string targetColor, byte value)
        {
            string code = GetLongHexColor(hexColor).TrimHash();

            byte r = Convert.ToByte(code.Substring(0, 2), 16);
            byte g = Convert.ToByte(code.Substring(2, 2), 16);
            byte b = Convert.ToByte(code.Substring(4, 2), 16);

            switch (targetColor.ToUpper())
            {
                case "R":
                    r = value;
                    break;
                case "G":
                    g = value;
                    break;
                case "B":
                    b = value;
                    break;
                default:
                    throw new ArgumentException("Invalid target color. Use 'R', 'G', or 'B'.");
            }

            return GetShortHexColor($"{Hash}{GetAlphaValue(hexColor)}{r:X2}{g:X2}{b:X2}");
        }

        /// <summary>
        /// Sets the value of a specific color component (R, G, or B) in a <see cref="HexColor"/> instance and returns the modified <see cref="HexColor"/>.
        /// </summary>
        /// <param name="hexColor">The <see cref="HexColor"/> instance representing the color to modify.</param>
        /// <param name="targetColor">The target color component to set, specified as "R", "G", or "B".</param>
        /// <param name="value">The new value for the target color component.</param>
        /// <returns>A new <see cref="HexColor"/>  instance with the specified color component modified.</returns>
        public static string SetColorValue(HexColor hexColor, string targetColor, byte value)
        {
            string code = GetLongHexColor(hexColor).TrimHash();

            return SetColorValue(code, targetColor, value);
        }

        /// <summary>
        /// Sets the fill color part of a hexadecimal color code.
        /// </summary>
        /// <param name="hexColor">The hexadecimal color code.</param>
        /// <returns>The hexadecimal color code with the alpha (transparency) component removed (if present).</returns>
        public static string SetFillColor(string hexColor)
        {
            string code = hexColor.TrimHash();

            if (IsHexColorWithAlpha(code))
                return $"{Hash}{code.Substring(2)}";
            
            return $"{Hash}{code}";
        }

        /// <summary>
        /// Sets the fill color part of a <see cref="HexColor"/> instance.
        /// </summary>
        /// <param name="hexColor">The <see cref="HexColor"/> instance.</param>
        /// <returns>The <see cref="HexColor"/> instance with the alpha (transparency) component removed (if present).</returns>
        public static string SetFillColor(HexColor hexColor)
        {
            return SetFillColor(hexColor.ToString());
        }

        /// <summary>
        /// Checks if a <see cref="string"/> is a valid hexadecimal color code.
        /// </summary>
        /// <param name="code">The input <see langword="string"/> to check.</param>
        /// <returns><see langword="true"/> if the <see langword="string"/> is a valid hexadecimal color code; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="NullOrEmptyHexColorException">
        /// Thrown when the input <paramref name="code"/> is <see langword="null"/> or empty.
        /// </exception>
        public static bool IsHexColorCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new NullOrEmptyHexColorException(nameof(code));

            code = code.TrimHash();

            return IsLenghtCorrect(code) && IsHexadecimal(code);
        }

        /// <summary>
        /// Determines whether the specified hexadecimal color code includes an alpha (transparency) component.
        /// </summary>
        /// <param name="code">The hexadecimal color code to check.</param>
        /// <returns><see langword="true"/> if the color code includes an alpha component; otherwise, <see langword="false"/>.</returns>
        public static bool HasAlpha(string code)
        {
            return code.TrimHash().Length == 8;
        }

        /// <summary>
        /// Checks whether a given hexadecimal color code includes an alpha (transparency) component.
        /// </summary>
        /// <param name="code">The hexadecimal color code.</param>
        /// <returns><see langword="true"/> if the color code includes an alpha component; otherwise, <see langword="false"/>.</returns>
        public static bool IsHexColorWithAlpha(string code)
        {
            if (IsHexColorCode(code))
                return HasAlpha(code);

            return false;
        }

        /// <summary>
        /// Checks whether a given hexadecimal color code is in the short form (3 digits).
        /// </summary>
        /// <param name="code">The hexadecimal color code.</param>
        /// <returns><see langword="true"/> if the color code is in the short form; otherwise, <see langword="false"/>.</returns>
        public static bool IsShortHexColor(string code)
        {
            if (IsHexColorCode(code))
                return code.TrimHash().Length == 3;

            return false;
        }

        internal static char[] SearchCharArray()
        {
            return new char[] { Hash, ' ', ',', '.', ';', ':', '-', '\t', '\n', '\r' };
        }

        private static int GetFillColorLenght(string hexColor)
        {
            string code = hexColor.TrimHash();

            if (IsHexColorWithAlpha(code))
                return code.Substring(2).Length;
            else if (IsHexColorCode(code))
                return code.Length;

            return -1;
        }

        private static bool IsLenghtCorrect(string code)
        {
            code = code.TrimHash();
            return code.Length == 6 || code.Length == 8 || code.Length == 3;
        }

        private static bool IsHexadecimal(string value)
        {
            foreach (char c in value)
            {
                if (!IsHexDigit(c))
                    return false;
            }

            return true;
        }

        private static bool IsHexDigit(char c)
        {
            return (c >= '0' && c <= '9') ||
                   (c >= 'A' && c <= 'F') ||
                   (c >= 'a' && c <= 'f');
        }
    }
}
