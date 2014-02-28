using System.Collections.Generic;
using System.Runtime.CompilerServices;
//using reNumber.Resources;


namespace reNumber
{
    public class Options
    {
        public int categoryId;
        private int columnIncrement;
        private NumberingType columnNumberingType;
        private int columnStartValue;
        private string format;
        private readonly List<string> groupBy;
        private int increment;
        private NumberingType numberingType;
        private int rowIncrement;
        private NumberingType rowNumberingType;
        private int rowStartValue;
        private int startValue;

        //afew methods and variables that are compiler created are not added here.
        private int columnLeftPadding;
        private Direction direction;
        private int leftPadding;
        private string parameterName;
        private int rowLeftPadding;


        public int CategoryId
        {
            get
            {
                return categoryId;
            }
            set
            {
                categoryId = value;
            }
        }

        public int ColumnIncrement
        {
            get
            {
                return columnIncrement;
            }
            set
            {
                columnIncrement = value;
            }
        }

        public NumberingType ColumnNumberingType
        {
            get
            {
                return columnNumberingType;
            }
            set
            {
                columnNumberingType = value;
            }
        }

        public int ColumnStartValue
        {
            get
            {
                return columnStartValue;
            }
            set
            {
                columnStartValue = value;
            }
        }

        public string Format
        {
            get
            {
                return this.format;
            }
            set
            {
                format = value;
            }
        }

        public List<string> GroupBy
        {
            get
            {
                return groupBy;
            }
        }

        public int Increment
        {
            get
            {
                return increment;
            }
            set
            {
                increment = value;
            }
        }

        public NumberingType NumberingType
        {
            get
            {
                return numberingType;
            }
            set
            {
                numberingType = value;
            }
        }

        public int RowIncrement
        {
            get
            {
                return rowIncrement;
            }
            set
            {
                rowIncrement = value;
            }
        }

        public NumberingType RowNumberingType
        {
            get
            {
                return rowNumberingType;
            }
            set
            {
                rowNumberingType = value;
            }
        }

        public int RowStartValue
        {
            get
            {
                return rowStartValue;
            }
            set
            {
                rowStartValue = value;
            }
        }

        public int StartValue
        {
            get
            {
                return startValue;
            }
            set
            {
                startValue = value;
            }
        }

        public int ColumnLeftPadding
        {
            get
            {
                return columnLeftPadding;
            }
            set
            {
                columnLeftPadding = value;
            }
        }

        public Direction Direction
        {
            get
            {
                return direction;
            }
            set
            {
                direction = value;
            }
        }

        public int LeftPadding
        {
            get
            {
                return leftPadding;
            }
            set
            {
                leftPadding = value;
            }
        }

        public string ParameterName
        {
            get
            {
                return parameterName;
            }
            set
            {
                parameterName = value;
            }
        }

        public int RowLeftPadding
        {
            get
            {
                return rowLeftPadding;
            }
            set
            {
                rowLeftPadding = value;
            }
        }



        public Options()
        {
            categoryId = -1;
            columnIncrement=1;
            columnNumberingType = NumberingType.Alpha;
            columnStartValue = 1;
            format = "$(" + reNumberData.Value + ")";
            groupBy = new List<string>();
            increment = 1;
            numberingType = NumberingType.Numeric;
            rowIncrement = 1;
            rowNumberingType = NumberingType.Numeric;
            rowStartValue = 1;
            startValue = 1;

            //base..ctor; //can remove
        }


    }
}
