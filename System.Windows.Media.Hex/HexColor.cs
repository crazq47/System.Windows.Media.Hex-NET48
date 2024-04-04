#define NETFRAMEWORK

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace System.Windows.Media.Hex
{
    /// <summary>
    /// Represents a color structure in hexadecimal format with support for ARGB values.
    /// </summary>
    /// <remarks>
    /// This structure is designed to store and manipulate color information using hexadecimal notation.
    /// It supports ARGB values and provides functionality for equality comparison and formatting.
    /// </remarks>
    [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
    [TypeConverter(typeof(ColorConverter))]
    public struct HexColor : IEquatable<HexColor>, IFormattable, IComparable<string>, IEquatable<string>, IComparable<uint>, IEquatable<uint>
    {
        private string Code;

        /// <summary>
        /// Gets or sets the hexadecimal fill color code (without transparency <see langword="value"/>).
        /// </summary>
        public HexColor F
        {
            get => FromString(HexCode.GetFillColor(Code));
            set => Code = HexCode.SetFillColor(Code);
        }

        /// <summary>
        /// Gets or sets the alpha (transparency) component <see langword="value"/> of the <see cref="HexColor"/>.
        /// </summary>
        /// <remarks>
        /// The alpha component ranges from 0 to 255, where 0 represents no alpha and 255 represents full alpha intensity.
        /// </remarks>
        public byte A
        {
            get => HexCode.GetAlphaValue(Code);
            set => Code = HexCode.SetAlphaValue(value, Code);
        }

        /// <summary>
        /// Gets or sets the red color component <see langword="value"/> of the <see cref="HexColor"/>.
        /// </summary>
        /// <remarks>
        /// The red color component ranges from 0 to 255, where 0 represents no red and 255 represents full red intensity.
        /// </remarks>
        public byte R
        {
            get => HexCode.GetColorValue(Code, "R");
            set => Code = HexCode.SetColorValue(Code, "R", value);
        }

        /// <summary>
        /// Gets or sets the green color component <see langword="value"/> of the <see cref="HexColor"/>.
        /// </summary>
        /// <remarks>
        /// The green color component ranges from 0 to 255, where 0 represents no green and 255 represents full green intensity.
        /// </remarks>
        public byte G
        {
            get => HexCode.GetColorValue(Code, "G");
            set => Code = HexCode.SetColorValue(Code, "G", value);
        }

        /// <summary>
        /// Gets or sets the blue color component <see langword="value"/> of the <see cref="HexColor"/>.
        /// </summary>
        /// <remarks>
        /// The blue color component ranges from 0 to 255, where 0 represents no blue and 255 represents full blue intensity.
        /// </remarks>
        public byte B
        {
            get => HexCode.GetColorValue(Code, "B");
            set => Code = HexCode.SetColorValue(Code, "B", value);
        }

        /// <summary>
        /// Represents a <see langword="null"/> or undefined hexadecimal color code.
        /// </summary>
        public static readonly HexColor Null = new HexColor((string)null);
        /// <summary>
        /// Represents empty hexadecimal color code.
        /// </summary>
        public static readonly HexColor Empty;

        /// <summary>
        /// Initializes a <see langword="new"/> instance of the <see cref="HexColor"/> <see langword="struct"/> with the specified hexadecimal color code.
        /// </summary>
        /// <param name="hexValue">The hexadecimal color code (with or without the '#' prefix).</param>
        public HexColor(string hexValue)
        {
            this.Code = hexValue.ToUpper();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HexColor"/> struct with the specified <see cref="Color"/>.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> object used to create the <see cref="HexColor"/>.</param>
        public HexColor(Color color)
        {
            this.Code = color.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HexColor"/> class from alpha and color component values.
        /// </summary>
        /// <param name="alpha">The alpha (transparency) component value, normalized between 0 and 1.</param>
        /// <param name="values">An array containing color component values (red, green, blue), normalized between 0 and 1.</param>
        public HexColor(float alpha, float[] values)
        {
            this.Code = FromAValues(alpha, values).ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HexColor"/> class from color component values.
        /// </summary>
        /// <param name="values">An array containing color component values (red, green, blue), normalized between 0 and 1.</param>
        public HexColor(float[] values)
        {
            this.Code = FromAValues(values).ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HexColor"/> class from a 32-bit ARGB value.
        /// </summary>
        /// <param name="argb">A 32-bit ARGB value representing the color.</param>
        public HexColor(uint argb)
        {
            this.Code = FromUInt32(argb).ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HexColor"/> class from alpha and color component values.
        /// </summary>
        /// <param name="alpha">The alpha (transparency) component value, normalized between 0 and 1.</param>
        /// <param name="red">The red component value, normalized between 0 and 1.</param>
        /// <param name="green">The green component value, normalized between 0 and 1.</param>
        /// <param name="blue">The blue component value, normalized between 0 and 1.</param>
        public HexColor(float alpha, float red, float green, float blue)
        {
            this.Code = FromScRgb(alpha, red, green, blue).ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HexColor"/> class from color component values.
        /// </summary>
        /// <param name="red">The red component value, normalized between 0 and 1.</param>
        /// <param name="green">The green component value, normalized between 0 and 1.</param>
        /// <param name="blue">The blue component value, normalized between 0 and 1.</param>
        public HexColor(float red, float green, float blue)
        {
            this.Code = FromScRgb(1.0f, red, green, blue).ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HexColor"/> class from 8-bit ARGB component values.
        /// </summary>
        /// <param name="alpha">The alpha (transparency) component value, ranging from 0 to 255.</param>
        /// <param name="red">The red component value, ranging from 0 to 255.</param>
        /// <param name="green">The green component value, ranging from 0 to 255.</param>
        /// <param name="blue">The blue component value, ranging from 0 to 255.</param>
        public HexColor(byte alpha, byte red, byte green, byte blue)
        {
            this.Code = FromArgb(alpha, red, green, blue).ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HexColor"/> class from 8-bit RGB component values.
        /// </summary>
        /// <param name="red">The red component value, ranging from 0 to 255.</param>
        /// <param name="green">The green component value, ranging from 0 to 255.</param>
        /// <param name="blue">The blue component value, ranging from 0 to 255.</param>
        public HexColor(byte red, byte green, byte blue)
        {
            this.Code = FromRgb(red, green, blue).ToString();
        }

        /// <summary>
        /// Converts a <see cref="Color"/> object to a <see cref="HexColor"/>.
        /// </summary>
        /// <param name="color">The input <see cref="Color"/> object.</param>
        /// <returns>A <see cref="HexColor"/> representing the same color as the input.</returns>
        public static HexColor FromColor(Color color)
        {
            return new HexColor($"{HexCode.Hash}{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}");
        }

        /// <summary>
        /// Converts an array of <see cref="Color"/> objects to an array of <see cref="HexColor"/> objects.
        /// </summary>
        /// <param name="colors">The array of <see cref="Color"/> objects to convert.</param>
        /// <returns>An array of <see cref="HexColor"/> objects converted from the provided <see cref="Color"/> objects.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input array of <see cref="Color"/> objects is <see langword="null"/>.</exception>
        public static HexColor[] FromColors(Color[] colors)
        {
            if (colors == null)
                throw new ArgumentNullException(nameof(colors));

            return colors.Select(color => (HexColor)color).ToArray();
        }

        /// <summary>
        /// Creates a <see cref="HexColor"/> from an alpha (transparency) value and an array of color component values (R, G, B).
        /// </summary>
        /// <param name="alpha">The alpha (transparency) value.</param>
        /// <param name="values">An array of color component values (R, G, B) in the range [0.0, 1.0].</param>
        /// <returns>A <see cref="HexColor"/> representing the specified alpha and color component values.</returns>
        public static HexColor FromAValues(float alpha, float[] values)
        {
            byte a = (byte)(alpha * 255);
            byte r = (byte)(values.Length > 0 ? values[0] * 255 : 0);
            byte g = (byte)(values.Length > 1 ? values[1] * 255 : 0);
            byte b = (byte)(values.Length > 2 ? values[2] * 255 : 0);

            return new HexColor($"{HexCode.Hash}{a:X2}{r:X2}{g:X2}{b:X2}");
        }

        /// <summary>
        /// Creates a <see cref="HexColor"/> from an array of color component values (A, R, G, B).
        /// </summary>
        /// <param name="values">An array of color component values (A, R, G, B).</param>
        /// <returns>A <see cref="HexColor"/> representing the specified alpha and color component values.</returns>
        public static HexColor FromAValues(float[] values)
        {
            byte a = (byte)(values.Length > 3 ? values[0] * 255 : 0);
            byte r = (byte)(values.Length > 0 ? values[1] * 255 : 0);
            byte g = (byte)(values.Length > 1 ? values[2] * 255 : 0);
            byte b = (byte)(values.Length > 2 ? values[3] * 255 : 0);

            return new HexColor($"{HexCode.Hash}{a:X2}{r:X2}{g:X2}{b:X2}");
        }

        /// <summary>
        /// Creates a <see cref="HexColor"/> from an array of color component values (R, G, B).
        /// </summary>
        /// <param name="values">An array of color component values (R, G, B) in the range [0.0, 1.0].</param>
        /// <returns>A <see cref="HexColor"/> representing the specified color component values.</returns>
        public static HexColor FromValues(float[] values)
        {
            return FromAValues(1f, values);
        }

        /// <summary>
        /// Creates a <see cref="HexColor"/> from a 32-bit ARGB value.
        /// </summary>
        /// <param name="argb">The 32-bit ARGB value.</param>
        /// <returns>A <see cref="HexColor"/> representing the specified ARGB value.</returns>
        internal static HexColor FromUInt32(uint argb)
        {
            byte a = (byte)((argb & 0xFF000000) >> 24);
            byte r = (byte)((argb & 0x00FF0000) >> 16);
            byte g = (byte)((argb & 0x0000FF00) >> 8);
            byte b = (byte)(argb & 0x000000FF);

            return new HexColor($"{HexCode.Hash}{a:X2}{r:X2}{g:X2}{b:X2}");
        }

        /// <summary>
        /// Creates a HexColor instance from ScRGB (scaled RGB) values.
        /// </summary>
        /// <remarks>
        ///   This method allows you to create a <see cref="HexColor"/> instance using ScRGB (scaled RGB) values,
        ///   where each color component is normalized between 0 and 1.
        /// </remarks>
        /// <param name="alpha">The alpha (transparency) component, normalized between 0 and 1.</param>
        /// <param name="red">The red component, normalized between 0 and 1.</param>
        /// <param name="green">The green component, normalized between 0 and 1.</param>
        /// <param name="blue">The blue component, normalized between 0 and 1.</param>
        /// <returns>A HexColor instance representing the specified ScRGB values.</returns>
        public static HexColor FromScRgb(float alpha, float red, float green, float blue)
        {
            float a = (alpha < 0) ? 0 : ((alpha > 1) ? 1 : alpha);
            float r = (red < 0) ? 0 : ((red > 1) ? 1 : red);
            float g = (green < 0) ? 0 : ((green > 1) ? 1 : green);
            float b = (blue < 0) ? 0 : ((blue > 1) ? 1 : blue);

            return FromArgb(ScRgbToSrgb(a), ScRgbToSrgb(r), ScRgbToSrgb(g), ScRgbToSrgb(b));
        }

        /// <summary>
        /// Creates a HexColor instance from sRGB (standart RGB) values.
        /// </summary>
        /// <remarks>
        ///   This method allows you to create a <see cref="HexColor"/> instance using sRGB (standard RGB) values,
        ///   where each color component is normalized between 0 and 255.
        /// </remarks>
        /// <param name="alpha">The alpha (transparency) component, normalized between 0 and 255.</param>
        /// <param name="red">The red component, normalized between 0 and 255.</param>
        /// <param name="green">The green component, normalized between 0 and 255.</param>
        /// <param name="blue">The blue component, normalized between 0 and 255.</param>
        /// <returns>A HexColor instance representing the specified sRGB values.</returns>
        public static HexColor FromSrgb(byte alpha, byte red, byte green, byte blue)
        {
            return FromScRgb(SrgbToScRgb(alpha), SrgbToScRgb(red), SrgbToScRgb(green), SrgbToScRgb(blue));
        }

        /// <summary>
        /// Creates a <see cref="HexColor"/> from ARGB values.
        /// </summary>
        /// <remarks>
        ///   This method allows you to create a <see cref="HexColor"/> instance using ARGB values, where each color component
        ///   is represented by a <see cref="byte"/>, normalized between 0 and 255.
        /// </remarks>
        /// <param name="alpha">The alpha (transparency) value.</param>
        /// <param name="red">The red color component.</param>
        /// <param name="green">The green color component.</param>
        /// <param name="blue">The blue color component.</param>
        /// <returns>A <see cref="HexColor"/> representing the specified ARGB values.</returns>
        public static HexColor FromArgb(byte alpha, byte red, byte green, byte blue)
        {
            return new HexColor($"{HexCode.Hash}{alpha:X2}{red:X2}{green:X2}{blue:X2}");
        }

        /// <summary>
        /// Creates a <see cref="HexColor"/> from RGB values.
        /// </summary>
        /// <remarks>
        ///   This method allows you to create a <see cref="HexColor"/> instance using RGB values (without alpha channel), where each color component
        ///   is represented by a <see cref="byte"/>, normalized between 0 and 255.
        /// </remarks>
        /// <param name="red">The red color component.</param>
        /// <param name="green">The green color component.</param>
        /// <param name="blue">The blue color component.</param>
        /// <returns>A <see cref="HexColor"/> representing the specified RGB values.</returns>
        public static HexColor FromRgb(byte red, byte green, byte blue)
        {
            return new HexColor($"{HexCode.Hash}{red:X2}{green:X2}{blue:X2}");
        }

        /// <summary>
        /// Creates a <see cref="HexColor"/> from a hexadecimal color code represented as a string.
        /// </summary>
        /// <param name="hexCode">The hexadecimal color code string (with or without the '#' prefix).</param>
        /// <returns>A <see cref="HexColor"/> representing the specified hexadecimal color code.</returns>
        public static HexColor FromString(string hexCode)
        {
            return new HexColor(hexCode.ToUpper());
        }

        /// <summary>
        /// Finds and returns the first hexadecimal color code in the given input <see cref="string"/>.
        /// </summary>
        /// <param name="input">The input string to search for hexadecimal color codes.</param>
        /// <returns>The first hexadecimal color code found in the input string, or <see cref="Empty"/> if none is found.</returns>
        /// <exception cref="ArgumentException">Thrown when the input string is <see langword="null"/> or empty.</exception>
        public static HexColor FindHexColor(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input string cannot be null or empty.", nameof(input));

            string[] words = input.Split(HexCode.SearchCharArray(),
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (HexCode.IsHexColorCode(word))
                    return new HexColor(word.ToUpper());
            }

            return Empty;
        }

        /// <summary>
        /// Finds and returns all hexadecimal color codes in the given input <see cref="string"/>.
        /// </summary>
        /// <param name="input">The input string to search for hexadecimal color codes.</param>
        /// <returns>An array containing all hexadecimal color codes found in the input string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input string is <see langword="null"/>.</exception>
        public static HexColor[] FindAllHexColors(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input string cannot be null or empty.", nameof(input));

            List<HexColor> hexColors = new List<HexColor>();
            string[] words = input.Split(HexCode.SearchCharArray(), 
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (HexCode.IsHexColorCode(word))
                    hexColors.Add(new HexColor(word.ToUpper()));
            }

            return hexColors.ToArray();
        }

        /// <summary>
        /// Multiplies each component of the specified <see cref="HexColor"/> by the given coefficient.
        /// </summary>
        /// <param name="color">A <see cref="HexColor"/> to be multiplied.</param>
        /// <param name="coefficient">The coefficient to multiply each component by.</param>
        /// <returns>A new <see cref="HexColor"/> resulting from the multiplication operation.</returns>
        public static HexColor Multiply(HexColor color, float coefficient)
        {
            return color * coefficient;
        }

        /// <summary>
        /// Divides each component of the specified <see cref="HexColor"/> by the given coefficient.
        /// </summary>
        /// <param name="color">A <see cref="HexColor"/> to be divided.</param>
        /// <param name="coefficient">The coefficient to divide each component by.</param>
        /// <returns>A new <see cref="HexColor"/> resulting from the division operation.</returns>
        public static HexColor Divide(HexColor color, float coefficient)
        {
            return color / coefficient;
        }

        /// <summary>
        /// Adds corresponding components of two <see cref="HexColor"/> values.
        /// </summary>
        /// <param name="color1">The first <see cref="HexColor"/>.</param>
        /// <param name="color2">The second <see cref="HexColor"/>.</param>
        /// <returns>A new <see cref="HexColor"/> resulting from the addition operation.</returns>
        public static HexColor Add(HexColor color1, HexColor color2)
        {
            return color1 + color2;
        }

        /// <summary>
        /// Subtracts corresponding components of the second <see cref="HexColor"/> from the first <see cref="HexColor"/>.
        /// </summary>
        /// <param name="color1">A <see cref="HexColor"/> to subtract from.</param>
        /// <param name="color2">A <see cref="HexColor"/> to subtract.</param>
        /// <returns>A new <see cref="HexColor"/> resulting from the subtraction operation.</returns>
        public static HexColor Subtract(HexColor color1, HexColor color2)
        {
            return color1 - color2;
        }

        /// <summary>
        /// Determines whether the specified <see cref="HexColor"/> is equal to the current <see cref="HexColor"/>.
        /// </summary>
        /// <param name="other">The <see cref="HexColor"/> to compare with the current <see cref="HexColor"/>.</param>
        /// <returns><see langword="false"/> if the specified <see cref="HexColor"/> is equal to the current <see cref="HexColor"/>; otherwise, <see langword="false"/>.</returns>
        public bool Equals(HexColor other)
        {
            return A == other.A && R == other.R && G == other.G && B == other.B;
        }

        /// <summary>
        /// Determines whether the specified string representation of a hexadecimal color is equal to the current <see cref="HexColor"/>.
        /// </summary>
        /// <param name="other">A string representation of a hexadecimal color (#RRGGBB format) to compare with the current <see cref="HexColor"/>.</param>
        /// <returns><see langword="true"/> if the specified string represents the same color as the current <see cref="HexColor"/>; otherwise, <see langword="false"/>.</returns>
        public bool Equals(string other)
        {
            return Equals((HexColor)other);
        }

        /// <summary>
        /// Determines whether the specified <see cref="UInt32"/> representation of a hexadecimal color is equal to the current <see cref="HexColor"/>.
        /// </summary>
        /// <param name="other">A <see cref="UInt32"/> representation of a hexadecimal color (#RRGGBB format) to compare with the current <see cref="HexColor"/>.</param>
        /// <returns><see langword="true"/> if the specified <see cref="UInt32"/> represents the same color as the current <see cref="HexColor"/>; otherwise, <see langword="false"/>.</returns>
        public bool Equals(uint other)
        {
            return Code.Equals(FromUInt32(other));
        }

        /// <summary>
        /// Determines whether two <see cref="HexColor"/> instances are equal by comparing their hexadecimal color codes and alpha values.
        /// </summary>
        /// <param name="color1">The first <see cref="HexColor"/> instance to compare.</param>
        /// <param name="color2">The second <see cref="HexColor"/> instance to compare.</param>
        /// <returns><see langword="true"/> if the hexadecimal color codes and alpha values of the two <see cref="HexColor"/> instances are equal; otherwise, <see langword="false"/>.</returns>
        public static bool Equals(HexColor color1, HexColor color2)
        {
            return color1 == color2;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="HexColor"/>.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="HexColor"/>.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current <see cref="HexColor"/>; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is HexColor hex)
            {
                return Equals(hex);
            }
            return false;
        }

        /// <summary>
        /// Determines if two <see cref="HexColor"/> instances are close in color.
        /// </summary>
        /// <param name="color1">The first <see cref="HexColor"/> instance to compare.</param>
        /// <param name="color2">The second <see cref="HexColor"/> instance to compare.</param>
        /// <returns><see langword="true"/> if the <see cref="HexColor"/> instances are close; otherwise, <see langword="false"/>.</returns>
        public static bool AreClose(HexColor color1, HexColor color2)
        {
            return color1.IsClose(color2);
        }

        /// <summary>
        /// Clamps the color values to the valid range [0.0, 1.0] and updates the <see cref="HexColor"/> instance.
        /// </summary>
        public void Clamp()
        {
            float a = ((A < 0f) ? 0f : ((A > 1f) ? 1f : A));
            float r = ((R < 0f) ? 0f : ((R > 1f) ? 1f : R));
            float g = ((G < 0f) ? 0f : ((G > 1f) ? 1f : G));
            float b = ((B < 0f) ? 0f : ((B > 1f) ? 1f : B));

            Code = FromScRgb(a, r, g, b).ToString();
        }

        /// <summary>
        /// Gets the color values (ScARGB) in the range [0.0, 1.0].
        /// </summary>
        /// <returns>An array containing the color values [A, R, G, B].</returns>
        public float[] GetColorValues()
        {
            return new float[4] { SrgbToScRgb(A), SrgbToScRgb(R), SrgbToScRgb(G), SrgbToScRgb(B) };
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current <see cref="HexColor"/>.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + F.ToString()?.GetHashCode() ?? 0;
                hash = hash * 23 + A.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Compares the current hexadecimal color code with <see cref="string"/>.
        /// </summary>
        /// <param name="strB">The <see cref="string"/> to compare with the current hexadecimal color code.</param>
        /// <returns>
        /// A value indicating the relative order of the hexadecimal color code and the specified string.
        /// </returns>
        public int CompareTo(string strB)
        {
            return Code.CompareTo(strB);
        }

        /// <summary>
        /// Compares the current hexadecimal color code with <see cref="UInt32"/>.
        /// </summary>
        /// <param name="other">The <see cref="UInt32"/> to compare with the current hexadecimal color code.</param>
        /// <returns>
        /// A value indicating the relative order of the hexadecimal color code and the specified <see cref="UInt32"/>.
        /// </returns>
        public int CompareTo(uint other)
        {
            return Code.CompareTo(other);
        }

        /// <summary>
        /// Converts the <see cref="HexColor"/> instance to a string representation without any formatting.
        /// </summary>
        /// <returns>A <see cref="string"/> representation of the current <see cref="HexColor"/>.</returns>
        public override string ToString()
        {
            return Code;
        }

        /// <summary>
        /// Converts the <see cref="HexColor"/> to its equivalent <see cref="string"/> representation using the specified format.
        /// </summary>
        /// <param name="format">A format <see cref="string"/>. If <c>null</c> or an empty <see cref="string"/>, the default format is used.</param>
        /// <returns>A <see cref="string"/> representation of the current <see cref="HexColor"/>.</returns>
        public string ToString(string format)
        {
            return ToString(format, null);
        }

        /// <summary>
        /// Converts the <see cref="HexColor"/> to its equivalent string representation using the specified format and formatting provider.
        /// </summary>
        /// <param name="format">A format <see cref="string"/>. If <see langword="null"/> or an empty <see cref="string"/>, the default format is used.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A <see cref="string"/> representation of the current <see cref="HexColor"/>.</returns>
        public string ToString(string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
            {
                return Code;
            }

            StringBuilder result = new StringBuilder();

            switch (format.ToUpper())
            {
                case "ARGB":
                    result.AppendFormat(provider, $"{HexCode.Hash}{0:X2}{1}", A, HexCode.GetFillColor(F));
                    break;
                case "RGB":
                    result.AppendFormat(provider, F.ToString());
                    break;
                case "SHEX":
                    result.AppendFormat(provider, HexCode.GetShortHexColor(F));
                    break;
                default:
                    result.AppendFormat(provider, F.ToString());
                    break;
            }

            return result.ToString();
        }

        /// <summary>
        /// Implements the <see cref="IFormattable"/> interface, providing a custom <see cref="string"/> representation of the object based on the specified format and format provider.
        /// </summary>
        /// <param name="format">A format string that defines the formatting of the object's string representation.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A <see cref="string"/> representation of the object based on the specified format and format provider.</returns>
        string IFormattable.ToString(string format, IFormatProvider provider)
        {
            return ToString(format, provider);
        }

        /// <summary>
        /// Converts the <see cref="HexColor"/> to a <see cref="Color"/>.
        /// </summary>
        /// <returns>A <see cref="Color"/> representing the same color as the current <see cref="HexColor"/>.</returns>
        /// <exception cref="InvalidHexColorFormatException">
        /// Thrown when the hexadecimal color code is invalid, either not in the expected format or containing an unsupported value.
        /// </exception>
        public Color ToColor()
        {
            if (!HexCode.IsHexColorCode(Code))
                throw new InvalidHexColorFormatException();

            string code = Code.TrimHash();
            
            byte a = (byte)(HexCode.IsHexColorWithAlpha(code) ? Convert.ToByte(code.Substring(0, 2), 16) : 255);
            byte r = Convert.ToByte(code.Substring(code.Length - 6, 2), 16);
            byte g = Convert.ToByte(code.Substring(code.Length - 4, 2), 16);
            byte b = Convert.ToByte(code.Substring(code.Length - 2, 2), 16);

            if (HexCode.IsShortHexColor(code))
            {
                r = Convert.ToByte(code.Substring(0, 1) + code.Substring(0, 1), 16);
                g = Convert.ToByte(code.Substring(1, 1) + code.Substring(1, 1), 16);
                b = Convert.ToByte(code.Substring(2, 1) + code.Substring(2, 1), 16);
            }

            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// Converts an array of <see cref="HexColor"/> values to an array of <see cref="Color"/> values.
        /// </summary>
        /// <param name="colors">The array of <see cref="HexColor"/> values to convert.</param>
        /// <returns>An array of <see cref="Color"/> values.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input array of <see cref="HexColor"/> values is <see langword="null"/>.</exception>
        public static Color[] ToColors(HexColor[] colors)
        {
            if (colors == null)
                throw new ArgumentNullException(nameof(colors));

            return colors.Select(color => (Color)color).ToArray();
        }

        /// <summary>
        /// Converts a <see cref="HexColor"/> object to a 32-bit unsigned integer representation of ARGB color.
        /// </summary>
        /// <param name="hexColor">The <see cref="HexColor"/> object to convert.</param>
        /// <returns>A 32-bit unsigned integer representing the ARGB color.</returns>
        public static uint ToUInt32(HexColor hexColor)
        {
            byte a = hexColor.A;
            byte r = hexColor.R;
            byte g = hexColor.G;
            byte b = hexColor.B;

            uint argb = ((uint)a << 24) | ((uint)r << 16) | ((uint)g << 8) | b;

            return argb;
        }

        /// <summary>
        /// Converts the <see cref="HexColor"/> to an array of floating-point values representing the color components.
        /// </summary>
        /// <returns>
        /// An array of floating-point values representing the color components in the order of alpha (if present), red, green, and blue.
        /// </returns>
        /// <remarks>
        /// This method converts the hexadecimal color code to the sRGB color space and then to the scRGB color space.
        /// </remarks>
        public float[] ToValues()
        {
            if (HexCode.IsHexColorWithAlpha(Code))
                return new float[4] { SrgbToScRgb(A), SrgbToScRgb(R), SrgbToScRgb(G), SrgbToScRgb(B) };

            return new float[3] { SrgbToScRgb(R), SrgbToScRgb(G), SrgbToScRgb(B) };
        }

        /// <summary>
        /// Converts the <see cref="HexColor"/> to an array of <see cref="byte"/> representing the color components.
        /// </summary>
        /// <returns>
        /// An array of <see cref="byte"/> representing the color components in the order of alpha (if present), red, green, and blue.
        /// </returns>
        /// <remarks>
        /// This method converts the hexadecimal color code to the sRGB color space and then to the sRGB color space.
        /// </remarks>
        public byte[] ToBytes()
        {
            if (HexCode.IsHexColorWithAlpha(Code))
                return new byte[4] { ScRgbToSrgb(A), ScRgbToSrgb(R), ScRgbToSrgb(G), ScRgbToSrgb(B) };

            return new byte[3] { ScRgbToSrgb(R), ScRgbToSrgb(G), ScRgbToSrgb(B) };
        }

        /// <summary>
        /// Converts the current <see cref="HexColor"/> to a shorter representation, if applicable.
        /// </summary>
        /// <remarks>
        ///   This method is an alternative to <see cref="ToShorter"/> and provides a potentially shorter representation
        ///   of the current <see cref="HexColor"/>. If the current color already has a short representation, the returned
        ///   <see cref="HexColor"/> will have the same representation.
        /// </remarks>
        /// <returns>A <see langword="new"/> <see cref="HexColor"/> with a potentially shorter representation.</returns>
        public HexColor ToShortCode()
        {
            return new HexColor(HexCode.GetShortHexColor(Code));
        }
        /// <summary>
        /// Converts the current <see cref="HexColor"/> to a shorter representation, if applicable.
        /// </summary>
        /// <remarks>
        ///   This method is an alternative to <see cref="ToShortCode"/> and provides a potentially shorter representation
        ///   of the current <see cref="HexColor"/>. If the current color already has a short representation, the returned
        ///   <see cref="HexColor"/> will have the same representation.
        /// </remarks>
        /// <returns>A <see langword="new"/> <see cref="HexColor"/> with a potentially shorter representation.</returns>
        public HexColor ToShorter()
        {
            return new HexColor(HexCode.GetShortHexColor(Code));
        }

        /// <summary>
        /// Converts the current <see cref="HexColor"/> to a shorter representation, if applicable.
        /// </summary>
        /// <remarks>
        ///   This method is an alternative to <see cref="ToLonger"/> and provides a potentially longer representation
        ///   of the current <see cref="HexColor"/>. If the current color already has a long representation, the returned
        ///   <see cref="HexColor"/> will have the same representation.
        /// </remarks>
        /// <returns>A <see langword="new"/> <see cref="HexColor"/> with a potentially shorter representation.</returns>
        public HexColor ToLongCode()
        {
            return new HexColor(HexCode.GetLongHexColor(Code));
        }
        /// <summary>
        /// Converts the current <see cref="HexColor"/> to a shorter representation, if applicable.
        /// </summary>
        /// <remarks>
        ///   This method is an alternative to <see cref="ToLongCode"/> and provides a potentially longer representation
        ///   of the current <see cref="HexColor"/>. If the current color already has a long representation, the returned
        ///   <see cref="HexColor"/> will have the same representation.
        /// </remarks>
        /// <returns>A <see langword="new"/> <see cref="HexColor"/> with a potentially shorter representation.</returns>
        public HexColor ToLonger()
        {
            return new HexColor(HexCode.GetLongHexColor(Code));
        }

        /// <summary>
        /// Sets the alpha (transparency) component of the current <see cref="HexColor"/> to the specified value.
        /// </summary>
        /// <param name="alpha">The alpha (transparency) component value to set, specified as a floating-point number
        /// ranging from 0.0 (completely transparent) to 1.0 (completely opaque).</param>
        /// <remarks>
        ///   This method provides an alternative solution to set the alpha channel. You can use the <see langword="byte"/> 
        ///   <see cref="HexColor.A"/> { <see langword="get"/>; <see langword="set"/>; } property, which directly represents the alpha channel.
        /// </remarks>
        /// <returns>A <see langword="new"/> <see cref="HexColor"/> with the updated alpha component.</returns>
        public HexColor SetAlpha(float alpha)
        {
            string code = Code.TrimHash();
            return new HexColor($"{HexCode.Hash}{ScRgbToSrgb(alpha):X2}{HexCode.GetFillColor(code)}");
        }
        /// <summary>
        /// Gets the alpha (transparency) component value from the current <see cref="HexColor"/>.
        /// </summary>
        /// <remarks>
        ///   This method provides an alternative solution to get the alpha channel. You can use the <see langword="byte"/> 
        ///   <see cref="HexColor.A"/> { <see langword="get"/>; <see langword="set"/>; } property, which directly represents the alpha channel.
        /// </remarks>
        /// <returns>The alpha (transparency) component value as a floating-point number, ranging from 0.0
        /// (completely transparent) to 1.0 (completely opaque).</returns>
        public float GetAlpha()
        {
            return SrgbToScRgb(HexCode.GetAlphaValue(Code));
        }
        /// <summary>
        /// Removes the alpha (transparency) component from the current <see cref="HexColor"/>, if present.
        /// </summary>
        /// <remarks>
        ///   This method provides an alternative solution to removing the alpha channel. You can use the 
        ///   <see cref="HexColor.F"/> property, which directly represents the color without the alpha channel.
        /// </remarks>
        /// <returns>A <see langword="new"/> <see cref="HexColor"/> without the alpha component.</returns>
        public HexColor RemoveAlpha()
        {
            string code = Code.TrimHash();

            if (HexCode.IsHexColorWithAlpha(code))
                return new HexColor($"{HexCode.Hash}{code.Substring(0, code.Length - 6)}");

            return new HexColor($"{HexCode.Hash}{code}");
        }

        /// <summary>
        /// Sets the value of a specific color component (R, G, or B) in the current <see cref="HexColor"/>.
        /// </summary>
        /// <param name="targetColor">The target color component to set, specified as "R", "G", or "B".</param>
        /// <param name="value">The new value for the target color component, specified as a floating-point number
        /// ranging from 0.0 to 1.0.</param>
        /// <returns>A <see langword="new"/> <see cref="HexColor"/> with the specified color component modified.</returns>
        public HexColor SetColor(string targetColor, float value)
        {
            return new HexColor(HexCode.SetColorValue(Code, targetColor, ScRgbToSrgb(value)));
        }

        /// <summary>
        /// Sets the value of the red color component in the current <see cref="HexColor"/>.
        /// </summary>
        /// <param name="value">The new value for the red color component, specified as a floating-point number
        /// ranging from 0.0 to 1.0.</param>
        /// <remarks>
        ///   This method provides an alternative solution to set the red channel. You can use the <see langword="byte"/> 
        ///   <see cref="HexColor.R"/> { <see langword="get"/>; <see langword="set"/>; } property, which directly represents the red channel of color in bytes.
        /// </remarks>
        /// <returns>A <see langword="new"/> <see cref="HexColor"/> with the red color component modified.</returns>
        public HexColor SetRed(float value)
        {
            return SetColor("R", value);
        }
        /// <summary>
        /// Sets the value of the green color component in the current <see cref="HexColor"/>.
        /// </summary>
        /// <param name="value">The new value for the green color component, specified as a floating-point number
        /// ranging from 0.0 to 1.0.</param>
        /// <remarks>
        ///   This method provides an alternative solution to set the green channel. You can use the <see langword="byte"/> 
        ///   <see cref="HexColor.G"/> { <see langword="get"/>; <see langword="set"/>; } property, which directly represents the green channel of color in bytes.
        /// </remarks>
        /// <returns>A <see langword="new"/> <see cref="HexColor"/> with the green color component modified.</returns>
        public HexColor SetGreen(float value)
        {
            return SetColor("G", value);
        }
        /// <summary>
        /// Sets the value of the blue color component in the current <see cref="HexColor"/>.
        /// </summary>
        /// <param name="value">The new value for the blue color component, specified as a floating-point number
        /// ranging from 0.0 to 1.0.</param>
        /// <remarks>
        ///   This method provides an alternative solution to set the blue channel. You can use the <see langword="byte"/> 
        ///   <see cref="HexColor.B"/> { <see langword="get"/>; <see langword="set"/>; } property, which directly represents the blue channel of color in bytes.
        /// </remarks>
        /// <returns>A <see langword="new"/> <see cref="HexColor"/> with the blue color component modified.</returns>
        public HexColor SetBlue(float value)
        {
            return SetColor("B", value);
        }

        /// <summary>
        /// Gets the value of a specific color component (R, G, or B) from the current <see cref="HexColor"/>.
        /// </summary>
        /// <param name="targetColor">The target color component to retrieve, specified as "R", "G", or "B".</param>
        /// <returns>The value of the specified color component as a floating-point number ranging from 0.0 to 1.0.</returns>
        public float GetColor(string targetColor)
        {
            return SrgbToScRgb(HexCode.GetColorValue(Code, targetColor));
        }

        /// <summary>
        /// Gets the value of the red color component (R) from the current <see cref="HexColor"/>.
        /// </summary>
        /// <remarks>
        ///   This method provides an alternative solution to get the red channel. You can use the <see langword="byte"/> 
        ///   <see cref="HexColor.R"/> { <see langword="get"/>; <see langword="set"/>; } property, which directly represents the red channel of color in bytes.
        /// </remarks>
        /// <returns>The value of the red color component as a floating-point number ranging from 0.0 to 1.0.</returns>
        public float GetRed()
        {
            return GetColor("R");
        }
        /// <summary>
        /// Gets the value of the green color component (G) from the current <see cref="HexColor"/>.
        /// </summary>
        /// <remarks>
        ///   This method provides an alternative solution to get the green channel. You can use the <see langword="byte"/> 
        ///   <see cref="HexColor.G"/> { <see langword="get"/>; <see langword="set"/>; } property, which directly represents the green channel of color in bytes.
        /// </remarks>
        /// <returns>The value of the green color component as a floating-point number ranging from 0.0 to 1.0.</returns>
        public float GetGreen()
        {
            return GetColor("G");
        }
        /// <summary>
        /// Gets the value of the blue color component from the current <see cref="HexColor"/>.
        /// </summary>
        /// <remarks>
        ///   This method provides an alternative solution to get the blue channel. You can use the <see langword="byte"/> 
        ///   <see cref="HexColor.B"/> { <see langword="get"/>; <see langword="set"/>; } property, which directly represents the blue channel of color in bytes.
        /// </remarks>
        /// <returns>The value of the blue color component as a floating-point number ranging from 0.0 to 1.0.</returns>
        public float GetBlue()
        {
            return GetColor("B");
        }

        /// <summary>
        /// Converts a <see cref="HexColor"/> object to a <see cref="System.String"/>.
        /// </summary>
        /// <param name="hexColor">The <see cref="HexColor"/> object to convert.</param>
        /// <returns>A <see cref="System.String"/> representation of the <paramref name="hexColor"/>.</returns>
        public static implicit operator string(HexColor hexColor)
        {
            return hexColor.ToString();
        }
        /// <summary>
        /// Converts a <see cref="System.String"/> representation of a color to a <see cref="HexColor"/> object.
        /// </summary>
        /// <param name="color">The <see cref="System.String"/> representation of a color to convert.</param>
        /// <returns>A <see cref="HexColor"/> object representing the color specified by <paramref name="color"/>.</returns>
        public static implicit operator HexColor(string color)
        {
            return FromString(color);
        }

        /// <summary>
        /// Defines an <see langword="explicit"/> conversion from a <see cref="HexColor"/> to <see cref="Color"/>.
        /// </summary>
        /// <param name="hexColor">The <see cref="HexColor"/> to convert to a <see cref="Color"/> <see langword="structure"/>.</param>
        /// <returns>A <see cref="Color"/> equivalent to the specified <see cref="HexColor"/> <see langword="structure"/>.</returns>
        public static implicit operator Color(HexColor hexColor)
        {
            return hexColor.ToColor();
        }
        /// <summary>
        /// Defines an <see langword="implicit"/> conversion from a <see cref="Color"/> to <see cref="HexColor"/>.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> to convert to a <see cref="HexColor"/> <see langword="structure"/>.</param>
        /// <returns>A <see cref="HexColor"/> equivalent to the specified <see cref="Color"/> <see langword="structure"/>.</returns>
        public static implicit operator HexColor(Color color)
        {
            return FromColor(color);
        }

        /// <summary>
        /// Implicitly converts a <see cref="HexColor"/> object to a 32-bit unsigned integer representation of ARGB color.
        /// </summary>
        /// <param name="hexColor">The <see cref="HexColor"/> object to convert.</param>
        /// <returns>A 32-bit unsigned integer representing the ARGB color.</returns>
        public static implicit operator uint(HexColor hexColor)
        {
            return ToUInt32(hexColor);
        }
        /// <summary>
        /// Implicitly converts a 32-bit unsigned integer representation of ARGB color to a <see cref="HexColor"/> object.
        /// </summary>
        /// <param name="color">The 32-bit unsigned integer representing the ARGB color to convert.</param>
        /// <returns>A <see cref="HexColor"/> object representing the color specified by the 32-bit unsigned integer.</returns>
        public static implicit operator HexColor(uint color)
        {
            return FromUInt32(color);
        }

        /// <summary>
        /// Implicitly converts an array of floating-point values representing color components to a <see cref="HexColor"/> instance.
        /// </summary>
        /// <param name="values">The array of floating-point values representing the color components.</param>
        /// <returns>A <see cref="HexColor"/> instance representing the color.</returns>
        /// <remarks>
        /// This conversion assumes the values are in the order of alpha (if present), red, green, and blue.
        /// </remarks>
        public static implicit operator HexColor(float[] values)
        {
            return FromValues(values);
        }

        /// <summary>
        /// Implicitly converts an array of <see cref="byte"/> to a <see cref="HexColor"/>.
        /// </summary>
        /// <param name="values">The array of <see cref="byte"/> representing the color components.</param>
        /// <returns>A <see cref="HexColor"/> instance initialized with the provided color components.</returns>
        /// <remarks>
        /// If the length of the array is 3, the method assumes that the color is in RGB format.
        /// If the length of the array is 4, the method assumes that the color is in sRGB format.
        /// </remarks>
        public static implicit operator HexColor(byte[] values)
        {
            if (values.Length == 3)
                return FromRgb(values[0], values[1], values[2]);

            return FromSrgb(values[0], values[1], values[2], values[3]);
        }

        /// <summary>
        /// Implicitly converts a <see cref="HexColor"/> instance to an array of floating-point values representing color components.
        /// </summary>
        /// <param name="hexColor">The <see cref="HexColor"/> instance to convert.</param>
        /// <returns>An array of floating-point values representing the color components.</returns>
        /// <remarks>
        /// The returned array will contain values in the order of alpha (if present), red, green, and blue.
        /// </remarks>
        public static implicit operator float[](HexColor hexColor)
        {
            return hexColor.ToValues();
        }

        /// <summary>
        /// Checks whether two <see cref="HexColor"/> instances are equal in terms of their underlying <see cref="Color"/> values.
        /// </summary>
        /// <param name="left">The first <see cref="HexColor"/> to compare.</param>
        /// <param name="right">The second <see cref="HexColor"/> to compare.</param>
        /// <returns><see langword="true"/> if the <see cref="HexColor"/> instances are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(HexColor left, HexColor right)
        {
            var l = left.ToColor();
            var r = right.ToColor();

            return l.Equals(r);
        }
        /// <summary>
        /// Checks whether two <see cref="HexColor"/> instances are not equal in terms of their underlying <see cref="Color"/> values.
        /// </summary>
        /// <param name="left">The first <see cref="HexColor"/> to compare.</param>
        /// <param name="right">The second <see cref="HexColor"/> to compare.</param>
        /// <returns><see langword="true"/> if the <see cref="HexColor"/> instances are not equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(HexColor left, HexColor right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Adds corresponding components of two <see cref="HexColor"/>.
        /// </summary>
        /// <param name="color1">The first <see cref="HexColor"/>.</param>
        /// <param name="color2">The second <see cref="HexColor"/>.</param>
        /// <returns>A <see langword="new"/> <see cref="HexColor"/> resulting from the addition operation.</returns>
        public static HexColor operator +(HexColor color1, HexColor color2)
        {
            var c1 = color1.ToColor();
            var c2 = color2.ToColor();

            return FromColor(c1 + c2);
        }
        /// <summary>
        /// Subtracts corresponding components of the second <see cref="HexColor"/> from the first <see cref="HexColor"/>.
        /// </summary>
        /// <param name="color1">The <see cref="HexColor"/> to subtract from.</param>
        /// <param name="color2">The <see cref="HexColor"/> to subtract.</param>
        /// <returns>A <see langword="new"/> <see cref="HexColor"/> resulting from the subtraction operation.</returns>
        public static HexColor operator -(HexColor color1, HexColor color2)
        {
            var c1 = color1.ToColor();
            var c2 = color2.ToColor();

            return FromColor(c1 - c2);
        }
        /// <summary>
        /// Multiplies each component of the <see cref="HexColor"/> by the specified coefficient.
        /// </summary>
        /// <param name="color">The <see cref="HexColor"/> to be multiplied.</param>
        /// <param name="coefficient">The coefficient to multiply each component by.</param>
        /// <returns>A <see langword="new"/> <see cref="HexColor"/> resulting from the multiplication operation.</returns>
        public static HexColor operator *(HexColor color, float coefficient)
        {
            var c = color.ToColor();

            return FromColor(c * coefficient);
        }
        /// <summary>
        /// Divides each component of the <see cref="HexColor"/> by the specified coefficient.
        /// </summary>
        /// <param name="color">The <see cref="HexColor"/> to be divided.</param>
        /// <param name="coefficient">The coefficient to divide each component by.</param>
        /// <returns>A <see langword="new"/> <see cref="HexColor"/> resulting from the division operation.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when attempting to divide by zero (<paramref name="coefficient"/> is zero).
        /// </exception>
        public static HexColor operator /(HexColor color, float coefficient)
        {
            if (coefficient == 0)
                throw new ArgumentException("Division by zero is not allowed.");

            float a = color.A / coefficient;
            float r = color.R / coefficient;
            float g = color.G / coefficient;
            float b = color.B / coefficient;

            return FromScRgb(a, r, g, b);
        }

        private static float SrgbToScRgb(byte bval)
        {
            float num = (float)(int)bval / 255f;
            if (!((double)num > 0.0))
            {
                return 0f;
            }

            if ((double)num <= 0.04045)
            {
                return num / 12.92f;
            }

            if (num < 1f)
            {
                return (float)Math.Pow(((double)num + 0.055) / 1.055, 2.4);
            }

            return 1f;
        }

        private static byte ScRgbToSrgb(float val)
        {
            if (!((double)val > 0.0))
            {
                return 0;
            }

            if ((double)val <= 0.0031308)
            {
                return (byte)(255f * val * 12.92f + 0.5f);
            }

            if ((double)val < 1.0)
            {
                return (byte)(255f * (1.055f * (float)Math.Pow(val, 5.0 / 12.0) - 0.055f) + 0.5f);
            }

            return byte.MaxValue;
        }

        private bool IsClose(HexColor color)
        {
            return Color.AreClose(FromString(Code).ToColor(), color.ToColor());
        }
    }
}
