using System.Collections.Generic;
using System.Text;

namespace reNumber
{
    public class RomanNumeralizer
    {
        private IEnumerable<RomanNumeralPair> PairSet
        {
            get
            {
                List<RomanNumeralPair> list = new List<RomanNumeralPair>();
                list.Add(new RomanNumeralPair(1000, "M"));
                list.Add(new RomanNumeralPair(900, "CM"));
                list.Add(new RomanNumeralPair(500, "D"));
                list.Add(new RomanNumeralPair(400, "CD"));
                list.Add(new RomanNumeralPair(100, "C"));
                list.Add(new RomanNumeralPair(90, "XC"));
                list.Add(new RomanNumeralPair(50, "L"));
                list.Add(new RomanNumeralPair(40, "XL"));
                list.Add(new RomanNumeralPair(10, "X"));
                list.Add(new RomanNumeralPair(9, "IX"));
                list.Add(new RomanNumeralPair(5, "V"));
                list.Add(new RomanNumeralPair(4, "IV"));
                list.Add(new RomanNumeralPair(1, "I"));

                return (IEnumerable<RomanNumeralPair>)list;
            }
        }

        public RomanNumeralizer()
        {
            //base..ctor();
        }

        internal string ConvertToRomanNumeral(int input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (RomanNumeralPair romanNumeralPair in PairSet)
            {
                while (input >= romanNumeralPair.Value)
                {
                    stringBuilder.Append(romanNumeralPair.StringValue);
                    input -= romanNumeralPair.Value;
                }
            }
            return ((object)stringBuilder).ToString();
        }
    }
}
