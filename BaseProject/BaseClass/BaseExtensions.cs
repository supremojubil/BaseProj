using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace BaseProject.BaseClass {
    public static class BaseExtensions {

        #region Currency
        public static string ToCurrency(this string value, int decimalPlaces = 2) {
            return Convert.ToDecimal(value).ToText(decimalPlaces, decimalPlaces);
        }
        public static string ToCurrency(this decimal valueText, int decimalPlaces = 2) {
            return valueText.ToText(decimalPlaces, decimalPlaces);
        }
        #endregion

        #region Number Formatting
        public static string ToText(this decimal valueText, int minDecimalPlaces = 0, int maxDecimalPlaces = 0) {
            if (maxDecimalPlaces > minDecimalPlaces) {
                throw new ArgumentException("MaxDecimalPlaces must be less than or equal to MinDecimalPlaces");
            }
            int count = minDecimalPlaces - maxDecimalPlaces;
            string format = string.Concat("#,##0.", string.Concat(Enumerable.Repeat("0", maxDecimalPlaces)), string.Concat(Enumerable.Repeat("#", count)));
            if (minDecimalPlaces <= 0) {
                return Math.Floor(valueText).ToString("#,##0");
            }

            return valueText.ToString(format);
        }
        public static string ToText(this int value, int decimalPlaces = 0) {
            return Convert.ToDecimal(value).ToText(decimalPlaces);
        }
        public static decimal ToDecimal(this string value) {
            if (!decimal.TryParse(value, out decimal result)) {
                result = 0;
            }
            return result;
        }
        public static int ToInt(this string value) {
            return ParseToInt(value);
        }
        public static int ParseToInt(string value) {
            if (value.Contains(".")) {
                return Convert.ToInt32(value.Split('.')
                    .ToArray()[0]
                    .PadLeft(3, '0')
                    .Replace(",", ""));
            }
            return Convert.ToInt32(value.Replace(",", ""));
        }
        #endregion

        #region Date Formatting
        public static string ToText(this DateTime value) {
            return value.ToString("yyyy-MM-dd");
        }
        #endregion

        #region Image Conversion
        //public static byte[] ImageToByteArray(this Image image) {
        //    using (MemoryStream stream = new MemoryStream()) {
        //        image.Save(stream, ImageFormat.Jpeg);
        //        return stream.ToArray();
        //    }
        //}
        //public static Image ByteArrayToImage(this byte[] value) {
        //    return Image.FromStream(new MemoryStream(value));
        //}
        #endregion

        #region String Formatting
        public static string ExtractNumbers(this string value) {
            return string.Join(null, Regex.Split(value, "[^\\d]"));
        }
        public static string ToOrdinal(this int value) {
            string text = value.ToString();
            if (value == 11 || value == 12 || value == 13) {
                return text + "th";
            }
            switch (value % 10) {
                case 1:
                    return text + "st";
                case 2:
                    return text + "nd";
                case 3:
                    return text + "rd";
                default:
                    return text + "th";
            }
        }
        #endregion

        #region Amount to Words
        public static string ToWords(this decimal value) {
            string[] ones = {
                "",
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine",
                "Ten",
                "Eleven",
                "Twelve",
                "Thirteen",
                "Fourteen",
                "Fifteen",
                "Sixteen",
                "Seventeen",
                "Eighteen",
                "Nineteen"
            };
            string[] tens = {
                "",
                "",
                "Twenty",
                "Thirty",
                "Forty",
                "Fifty",
                "Sixty",
                "Seventy",
                "Eighty",
                "Ninety"
            };
            string[] scales = {
                "",
                "Thousand ",
                "Million ",
                "Billion ",
                "Trillion ",
                "Quadrillion ",
                "Quintillion "
            };
            if (value == 0m) {
                return "Zero";
            }
            decimal wholeNumber = decimal.Truncate(value);
            decimal decimalNumber = decimal.Truncate((value - wholeNumber) * 100m);
            StringBuilder result = new StringBuilder();
            int scaleIndex = 0;
            decimal scaleValue = 1m;

            if (wholeNumber < 0m) {
                result.Append("Minus ");
                wholeNumber = -wholeNumber;
            }
            for (decimal currentValue = wholeNumber; currentValue >= 1000m; currentValue /= 1000m) {
                scaleValue *= 1000m;
                scaleIndex++;
            }
            decimal remainingValue = wholeNumber;
            while (scaleIndex >= 0) {
                int groupValue = (int)(remainingValue / scaleValue);

                int lastTwoDigits = groupValue % 100;

                int hundreds = groupValue / 100;

                int tensDigit = groupValue % 100 / 10;

                int onesDigit = groupValue % 10;

                if (groupValue != 0) {
                    if (hundreds > 0) {
                        result.Append(ones[hundreds]);
                        result.Append(" Hundred ");
                    }

                    if (lastTwoDigits != 0) {
                        if (lastTwoDigits < 20) {
                            result.Append(ones[lastTwoDigits]);
                        }
                        else {
                            result.Append(tens[tensDigit]);
                            if (onesDigit > 0) {
                                result.Append("-");
                                result.Append(ones[onesDigit]);
                            }
                        }
                    }

                    if (scaleIndex > 0) {
                        result.Append(" ");
                        result.Append(scales[scaleIndex]);
                    }
                }

                remainingValue %= scaleValue;
                scaleIndex--;
                scaleValue /= 1000m;
            }

            result.Append(" and ");

            if (decimalNumber < 10m) {
                result.Append("0");
            }

            result.Append(decimalNumber);

            result.Append("/100 ");

            result.Append("Pesos only");

            return result.ToString();
        }

        #endregion
    }
}
