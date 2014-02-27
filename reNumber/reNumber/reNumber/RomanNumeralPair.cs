
namespace reNumber
{
    class RomanNumeralPair
    {
        private readonly int value;
        private readonly string stringValue;

        public int Value
        {
            get
            {
                return value;
            }
        }

        public string StringValue
        {
            get
            {
                return stringValue;
            }
        }

        public RomanNumeralPair (int value, string stringValue)
        {
            //base..ctor();       //can remove this
            this.value = value;
            this.stringValue = stringValue;
        }
    }
}
