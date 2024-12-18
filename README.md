﻿

# 🌈Windows.Media.Hex (Outdated)

🇬🇧 **`System.Windows.Media.Hex`**  is a **.NET Framework** library for **Windows Presentation Foundation** (WPF) that provides enhanced functionality for working with hexadecimal color codes.

> This library complements and extends the functionality of the standard
> [`System.Windows.Media.Color`](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.color?view=windowsdesktop-6.0) structure, fixing some shortcomings and
> adding new features.

 🇺🇦 **`System.Windows.Media.Hex`** — це **.NET Framework** бібліотека розроблена для **Windows Presentation Foundation** (WPF) і дозволяє повноцінно керувати шістнадцятирядковими записами кольорів.

> Ця бібліотека реалізує наявні можливості стандартної структури
> [`System.Windows.Media.Color`](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.color?view=windowsdesktop-6.0) , усуваючи її недоліки та додаючи нові функції.

## Update history🧪

🥥 **Current version of the library:** **`1.0.2.0`**

The change history is located on [this page](https://github.com/crazq47/System.Windows.Media.Hex-NET48/blob/master/UPDATES.md).

## Work intricacies! 🔬

🇬🇧 **Library Components:**

-   **HexColor:** Base structure for managing HEX color representations.
-   **HexColors:** Class that stores a collection of predefined colors (analogous to **Colors**).
-   **HexCode:** Class that facilitates interaction with other color representation formats.

🇬🇧  **External Interaction Tools:**

-   **HexConverter:** Implements external conversion methods to and from **HexColor**.
-  Group **HexException:** Handles errors related to hexadecimal code processing.
-  Group **HexExtension:** Extends basic structures and classes to provide support.
---
 🇺🇦 **Бібліотека складається з трьох основних компонентів:** 
 
 - Базова структура **HexColor** — керує представленнями HEX кольору;
 - Клас **HexColors** — зберігає колекцію готових кольорів (аналог **Colors**);
 - Клас **HexCode** — забезпечує взаємодію з рядковими форматами представлення.

 🇺🇦  **Після них ідуть окремі засоби для зовнішньої взаємодії:**

- Клас **HexConverter** — впроваджує зовнішні методи конвертації у **HexColor** і навпаки.
- Група класів **HexException** — оброблює помилки пов'язані з обробкою шістнадцятирядкового коду.
- Група класів **HexExtension** — розширює базові структури та класи, впроваджуючи підтримку.

# 🧠How to use it?

🇬🇧 Unlike the standard `System.Windows.Media.Color` structure, **HexColor** is much more flexible in terms of code implementation.

🇺🇦 Навідміну від стандартної структури `System.Windows.Media.Color`, **HexColor** набагато гнучкіший у плані реалізації коду.

```C#
Color color1 = new Color();
color1 = Color.FromRGB(255, 0, 255);
```

> 🇬🇧 Declaring **Color** and setting the color values to the variable `color1`.

> 🇺🇦 Оголошення **Color** та занесення значень кольору у змінну `color1`.

```C#
HexColor hex1 = color1; // Сonversion Color to HexColor
Color color2 = hex1; // Reverse conversion
```
> 🇬🇧 Now you can simply equate **Color** to **HexColor** or vice versa.

> 🇺🇦 Тепер можна просто прирівняти **Color** до **HexColor** і навпаки.

**Interaction with other data types:**

```C#
HexColor hex1 = 0xFF00FF; // Сonversion uint to HexColor
HexColor hex2 = "#FF00FF"; // Сonversion string to HexColor
HexColor hex3 = new float[] { 1.0f, 0.0f, 1.0f }; // Сonversion a float array to HexColor
```
🇬🇧 Due to the presence of undefined operators, **HexColor** converts very well to **Color**, `uint`, `float`, and `string` or vice versa.

🇺🇦 Завдяки наявності невизначених операторів, **HexColor** дуже добре конвертується у **Color**, `uint`, `float` та `string` і навпаки.
```C#
this.Foreground = hex2; // Converts the value for Foreground to Color directly.
```
🇬🇧 Thus, **HexColor** is more convenient to use, because it avoids unnecessary conversion, and it also provides the ability to reverse conversion, which **Color** does not.

🇺🇦 Таким чином **HexColor** зручніший у використанні, адже дозволяє уникати зайвої конвертації, а крім цього він надає можливість для оберненої конвертації, якої не має у **Color**.

## Why HexColor better? 🍌

🇬🇧 **HexColor** has significant advantages over **Color** :

- Implements the broken **Color** code.
- Reproduces all the existing **Color** functionality.
- Extends methods and operators for conversion and interaction.
- Provides the ability to manage individual color ranges.
- Allows you to control the recording of hexadecimal code.

The **HexColor** structure implements code for managing records, this includes support for abbreviated records (`#FF00FF` → `#F0F` and vice versa), methods for setting ranges, Boolean expressions, and much more.

---

🇺🇦 **HexColor** має значні переваги над **Color** :

- Реалізує не працюючий код **Color**.
- Відтворює весь наявний функціонал **Color**.
- Розширує методи і оператори для конвертації та взаємодії.
- Надає можливість керувати окремими діапазонами кольору.
- Дозволяє керувати записом шістнадцятирядкового коду.

Структура **HexColor** реалізує код для керування записами, це включає в себе підтримку скороченого запиcу (`#FF00FF` → `#F0F` і навпаки), методи устаткування діапазонів, булеві вираження та багато іншого.

---

**This table compares the main functionality of the structures:**

|                |Color             |HexColor         |🇬🇧 About Color                                                                                     |🇺🇦 Про Color                                                                                               |
|----------------|------------------|-----------------|----------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------|
|To string       |✅                |✅              |The proper `ToString()` method is available in both structures.                         |Належний метод `ToString()` є в обох структурах.                                                 |
|From string     |❌                |✅              |To convert a string to **Color**, you need to use third-party converters.               |Для перетворення рядка у **Color**, потрібно використовувати сторонні конвертери.                |
|Get color values |❌                |✅              | The `GetColorValues()` method of **Color** does not work properly and causes errors.   | Метод `GetColorValues()` у **Color** не працює належним чином і можуть спричиняти помилки.   |
|From values     |✅                |✅              |Not all `FromValues()` ​​methods in **Color** work properly and may cause errors.         | Не всі методи `FromValues()` у **Color** працюють належним чином і можуть спричиняти помилки.   |
|Boolean methods |❌                |✅              |**Color** does not have Boolean methods to perform checks.                              |**Color** не має булевих методів для здійснення перевірок.                                       |
|Short code      |❌                |✅              |**Color** does not support HEX color abbreviations.                                     |**Color** не підтримує скорочений запис HEX кольорів.                                            |
|None color      |❌                |✅              |**Color** does not support `none` color from CSS.                                     |**Color** не підтримує `none` колір для CSS.                                            |

# Extra Features! 🌱

🍂 Features of the **HexColor** class:

🇬🇧 Let's look at the features of the **HexColor** class using examples, first declare the `hexColor` variable using HEX code.

🇺🇦 Давайте розглянемо особливості класу **HexColor** на прикладах, спочатку оголосимо змінну `hexColor`, використовуючи HEX код.

```C#
HexColor hexColor = 0xFF00FF; // Declaring the variable hexColor
```
🇬🇧 As shown in the line above, you don't need to use any additional methods or operators to set a value to **HexColor**. However, you can use other options that you prefer.

🇺🇦 Як показано у рядку вище, для занесення значення до **HexColor** не обов'язково використовувати додаткові методи та оператори конвертації. Однак ви можете використовувати й інші варіанти, які вам довподоби.
```C#
HexColor hexColor1 = new HexColor(0xFF00FF);
HexColor hexColor2 = HexColor.FromUInt32(0xFF00FF);
```
> 🇬🇧 You can either create a new instance or use a method.

> 🇺🇦 Ви можете створити новий екземпляр, або викликати методи.

```C#
HexColor hexColor3 = new HexColor(); // Declares an empty HexColor
hexColor3.F = 0xFF00FF; // Introducing HexColor without an alpha channel
hexColor3.R = 255; hexColor3.G = 255; hexColor3.B = 255;
hexColor3.SetColor("R", 255); hexColor3.SetColor("G", 255); hexColor3.SetColor("B", 255);
hexColor3.SetRed(255); hexColor3.SetGreen(255); hexColor3.SetBlue(255);
```

> 🇬🇧 As shown in the example, you can control individual parts of a Hex color. 

> 🇺🇦 Як показано у прикладі, ви можете керувати окремими частинами Hex кольору.

🇬🇧 Let's look at how else you can set an empty value in **HexColor**.

🇺🇦 Давайте розглянемо, як ще можна задати порожнє значення у **HexColor**.
```C#
HexColor hexColor1 = HexColor.Empty;
HexColor hexColor2 = HexColor.None;
HexColor hexColor2 = HexColor.Null;
```
🇬🇧 These two variables return an empty **HexColor**, but they are arranged in a different way. **`HexColor.Empty`** returns an empty instance of `new HexColor()`, when as **`HexColor.None`** — a transparent instance of `HexColors.Transparent`, **`HexColor.Null`** returns **HexColor** with an empty string reference: `new HexColor((string)null)`.

🇺🇦 Ці дві змінні повертають порожний **HexColor**, однак вони влаштовані різним чином. **`HexColor.Empty`** — повертає порожній екземпляр `new HexColor()`, коли як **`HexColor.None`** — прозорий екземпляр `HexColors.Transparent`, **`HexColor.Null`**, в свою чергу, повертає **HexColor** із порожнім рядковим посиланням: `new HexColor((string)null)`.

*Let's take a look at other features* 🥝
```C#
hexColor.ToShortCode(); // Converts HEX code to short format
hexColor.ToShorter(); // Analog of the previous method
```

> 🇬🇧 The **`ToShortCode()`** and **`ToShorter()`** methods shorten HEX code that has the same pairs in all ranges: `#FF00FF` → `#F0F`.

> 🇺🇦 Методи **`ToShortCode()`** та **`ToShorter()`** скорочують HEX код, який має одноманітні пари у всіх діапазонах: `#FF00FF` → `#F0F`.
```C#
hexColor.ToLongCode(); // Converts HEX code to a long format
hexColor.ToLonger(); // Analog of the previous method
```
> 🇬🇧 The **`ToLongCode()`** and **`ToLonger()`** methods work the other way around - they lengthen the short HEX code: `#F0F` → `#FF00FF`.

> 🇺🇦 Методи **`ToLongCode()`** та **`ToLonger()`** працюють навпаки — подовжують скорочений запис HEX коду: `#F0F` → `#FF00FF`.

🇬🇧 However, it should be noted that due to the peculiarities of recording, these methods do not take into account the `Alpha` channel, i.e. after conversion, the color opacity will be equal to the maximum value of `255` bytes.

🇺🇦 Однак слід зазначити, що через особливості запису, ці методи не враховують `альфа` канал, тобто після конвертації непрозорість кольору буде дорівнювати максимальному значенню у `255` байт.

```C#
hexColor.CompareTo(String); // Compares HexColor with a string
```
🇬🇧 The `CompareTo(String)` method compares **HexColor** to a string by by their value. It returns an integer indicating the relative order of the of the objects in the comparison. This value can have the following meanings: 

> - Negative: The **HexColor** is less than the string it is compared to.
> - Zero: The current **HexColor** is equal to the string being compared.
> - Positive: The current **HexColor** is greater than the string it is compared to.

🇺🇦 Метод `CompareTo(String)` порівнює **HexColor** з рядком за їх значенням. Він повертає ціле число, що вказує на відносний порядок об'єктів у порівнянні. Це значення може мати такі означення:

> -   Від'ємне число: **HexColor** менший, ніж рядок, з яким порівнюється.
> -   Нуль: поточний **HexColor** рівний рядку, з яким порівнюється.
> -   Додатнє число: **HexColor** більший, ніж рядок, з яким порівнюється.

```C#
hexColor.RemoveAlpha(); // Removes alpha channel
```

🇬🇧 Removes the alpha channel from the HEX code, so the color opacity will be `255` bytes.

🇺🇦 Видаляє альфа канал з HEX коду, таким чином непрозорість кольору буде дорівнювати `255` байтам.

```C#
static HexColor.FindHexColor(text); // Returns the first occurrence of a HEX color in the string.
static HexColor.FindAllHexColors(text); // Returns all HEX colors in the string
```
🇬🇧 The `HexColor.FindHexColor(text)` and `HexColor.FindAllHexColors(text)` methods search for HEX colors in strings and return **HexColor**. This can be useful if you need to extract colors from text or an uploaded document.

🇺🇦 Методи `HexColor.FindHexColor(text)` та `HexColor.FindAllHexColors(text)` шукають HEX кольори у рядках і повертають **HexColor**. Це може бути корисним, якщо вам треба витягти кольори з тексту або завантаженого документу.

---
🍒 Features of the **HexCode** class:
```C#
static bool IsHexColor(String); // Returns true if the string is a HEX code
static bool IsHexColorWithAlpha(String); // Analog of the previous one with alpha channel check
```
🇬🇧 These methods are designed to check Hex code strings for correctness.

- **`IsHexColorCode(String)`** is a basic tool for working with Hex code. It checks whether the string is really a HEX code and whether each of its channels is correctly written, and if both conditions are met, it returns `true`, otherwise — `false`.
- **`IsHexColorWithAlpha(String)`** — works similarly to the previous one, but in addition, it performs an additional check for the presence of an alpha channel, and if all conditions are met, it returns `true`, otherwise — `false`.

🇺🇦 Ці методи призначені для перевірки рядків Hex коду на коректність.

- **`IsHexColorCode(String)`** — базовий інструмент для роботи з Hex кодом. Він перевіряє чи дійсно рядок є HEX кодом і чи коректно записаний кожен з його каналів, і якщо виконуються обидві умови, то повертає `true`, в іншому ж випадку — `false`.
- **`IsHexColorWithAlpha(String)`** — працює аналогічно з попереднім, але крім цього здійснює додаткову перевірку на наявність альфа каналу, і якщо виконуються усі умови, то повертає `true`, в іншому ж випадку — `false`.

```C#
static bool HasAlpha(String); // Only checking for alpha channel
static bool HasColor(String);
```
🇬🇧 These methods are designed to check the `alpha` channel:

- **`HasAlpha(String)`** is a basic tool that works similarly to `IsHexColorWithAlpha(String)`, but does not check for Hex code.
- **`HasColor(String)`** - another basic tool that checks whether the Hex code has a color.

> Unlike `HasAlpha(String)`, **`HasColor(String)`** checks the channel's
> `alpha` value against **0**. It returns `false` if `alpha` is equal to
> **0**, otherwise it returns `true`.
> 
> This means that if the channel `alpha` value is **0**, the color is not displayed, but it has a value.

🇺🇦 Ці методи призначені для перевірки `альфа` каналу:

- **`HasAlpha(String)`** — базовий існструмент, який працює аналогічно з `IsHexColorWithAlpha(String)`, але не здійснює перевірку на відповідність Hex коду.
- **`HasColor(String)`** — інший базовий існструмент, який перевіряє, чи має Hex код колір.

> Навідміну від `HasAlpha(String)`, **`HasColor(String)`** перевіряє
> значення `альфа` каналу на **0**. Повертає `false`, якщо `альфа`
> дорівнює **0**, в іншому ж видпадку — `true`.
> 
> Це означає, що при значенні `альфа` каналу **0** — колір не відображається, але він має значення.

*Let’s take a look at other features* 🍇

```C#
static string IsShortHexColor(); Returns true if the string is a shortened HEX code
```
> 🇬🇧 The method checks whether the Hex code corresponds to a shortened
> format (for example, `#F0F`), and if the condition is met, it returns
> `true`, otherwise - `false`.

> 🇺🇦 Метод перевіряє, чи відповідає Hex код скороченому формату
> (наприклад, `#F0F`), і якщо умова виконується, то повертає `true`, в
> іншому ж випадку — `false`.

```C#
static bool IsNone(String); // Checks if the string is a none-color
```
🇬🇧 This method checks if the string `none` is a color, if the condition is true it returns `true`, otherwise it returns `false`.

> In CSS, the value `none' is used to indicate **transparency**,
> but it is not a complete **no color**.

🇺🇦 Цей метод перевіряє, чи є рядок `none`-кольором, якщо умова кинонується, то повертає `true`, в іншому ж випадку — `false`.

> У CSS значення `none` використовується для позначення **прозорості**,
> однак це не є повною **відсутністю кольору**.
> 
```C#
static readonly char Hash; // Повертає символ Хешу (#)
```
🇬🇧 Additionally, this class contains the `Hash` variable, which returns the hash character `#`.

🇺🇦 Додатково у цьому класі розміщена змінна `Hash`, яка повертає символ Хешу `#`.

---
🍉 Features of the **HexExtension** class group:
```C#
float[] Color.GetColorValues() // Fixed method
```

> 🇬🇧 Fixes the standard method from **Color**, now it returns an array of
> color values and does not cause an error with missing context.

> 🇺🇦 Виправляє стандартний метод з **Color**, тепер він повертає масив
> значень кольору і не викликає помилку з відсутнім контекстом.

🇬🇧 The new method converts **Color** to **HexColor** and uses tools to summarize the original data, which allows you to get more accurate values.

🇺🇦 Новий метод конвертує **Color** у **HexColor** та використовує інструменти для узагальнення вихідних даних, це дозволяє отримати більш точні значення.
```C#
Color.FromString(String) // Converts string to Color
```

> 🇬🇧 This method implements the missing function in **Color** and allows
> you to specify a string as a value for **Color**.

> 🇺🇦 Цей метод реалізує відсутню функцію у **Color** і дозволяє ввказувати
> рядок як значення для **Color**.

Let's see what other features the **HexExtension** class group has 🍡
```C#
string.TrimHash() // Removes the hash character (#) from the string
string.AddHash() // Adds the hash character (#) to the beginning of the string
```
🇬🇧 The last methods I would like to analyze are `string.TrimHash()` and `string.AddHash()`.

> **`string.TrimHash()`** allows you to remove the first occurrence of the hash character (#), which is at the beginning of the string. 

> While **`string.AddHash()`** adds a hash character (#) to the beginning of a Hex color string.

These methods are well suited for manipulating Hex code.

🇺🇦 Останні методи, який хотілося б розібрати — `string.TrimHash()` та `string.AddHash()`.

> **`string.TrimHash()`** дозволяє прибирати перше входження символа Хешу (#), який знаходиться на початку рядка. 

> В той час як **`string.AddHash()`** — додає символ Хешу (#) на початок рядка Hex кольору.

Ці методи добре підходять для здійснення маніпуляцій над Hex кодом.

## 🧁Available Platforms

🇬🇧 Currently, support for **.Net Framework 4.8** is implemented, but the library will probably work on other versions as well.

🇺🇦 На даний момент реалізована підтримка **.Net Framework 4.8**, однак імовірно бібліотека буде працювати і на інших версіях.

