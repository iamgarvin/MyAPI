using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
//using Wiip.Lib;

namespace reNumber
{
    internal class NumberGenerator
    {
        private readonly Dictionary<string, int> values;
        private readonly Options options;
        private readonly reNumber.RomanNumeralizer rn;

        internal NumberGenerator (Options option)
        {
            this.values = new Dictionary<string,int>();
            this.rn = new RomanNumeralizer();
            //base..ctor(); // can remove
            this.options = options;
            this.values.Add("", options.StartValue);
        }

        public static string ExtractLevelNumber(string levelName)
        {
            string str = "";
            Match match = Regex.Match(levelName, "([\\d\\.]+)");
            if (match.Success)
                str = match.Groups[1].Captures[0].Value.TrimStart(new char[1] { '0' });
            return str;
        }

        public static string LabelToMacro(string label)
        {
            label = label.Replace("du ", "");
            label = Extensions.RemoveDiacritics(label);
            label = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(label);
            label = label.Replace(" ", "");
            label = label.Replace("\"", "");
            label = label.Replace(":", "");
            return label;
        }

        public string NextNumber(int row = -1, int column = -1, string group = "")
        {
            if (!values.ContainsKey(group)) values.Add(group, options.StartValue);
            string str = options.Format.Replace("$(" + Resources.Value + ")", GetValueAsString(values[group], options.NumberingType).PadLeft(options.LeftPadding, options.NumberingType == NumberingType.Numeric ? '0' : ' '));
            if (0 <= row)
                str = str.Replace("$(" + Resources.Row + ")", GetValueAsString(row, options.RowNumberingType).PadLeft(options.RowLeftPadding, options.RowNumberingType == NumberingType.Numeric ? '0' : ' '));
            if (0 <= column)
                str = str.Replace("$(" + Resources.Column + ")", GetValueAsString(column, options.ColumnNumberingType).PadLeft(options.ColumnLeftPadding, options.ColumnNumberingType == NumberingType.Numeric ? '0' : ' '));
            values[group] = values[group] + options.Increment;
            return str;
        }

        private string GetValueAsString(int v, NumberingType numberingType)
        {
            string str = "";
            switch (numberingType)
            {
                case NumberingType.Numeric: str = v.ToString((IFormatProvider)CultureInfo.InvariantCulture);
                    break;
                case NumberingType.Alpha: str = Mark.NumToalpha(ValueType);
                    break;
                case NumberingType.AlphaLowerCase: str = Mark.NumToAlpha(v).ToLower();
                    break;
                case NumberingType.Roman: str = rn.ConvertToRomanNumeral(v);
                    break;
                case NumberingType.RomanLowerCase: str = rn.ConvertToRomanNumeral(v).ToLower();
                    break;
            }
            return str;
        }

        public void ResetValues()
        {
            string[] array = new string[values.Count];
            values.Keys.CopyTo(array, 0);
            foreach (string index in array)
                values[index] = options.StartValue;
        }
    }
}
