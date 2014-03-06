using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoNumber
{
    class autoNumberData
    {
        private int categoryId;
        private int increment;
        private int startValue;

        private NumberDirection direction;
        private string parameterName;


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

        public NumberDirection Direction


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


        internal static string LevelName
        {
            get
            {
                return Resources.ResourceManager.GetString("LevelName", Resources.resourceCulture);
            }
        }

        internal static string LevelNumber
        {
            get
            {
                return Resources.ResourceManager.GetString("LevelNumber", Resources.resourceCulture);
            }
        }

        internal static string PositionX
        {
            get
            {
                return Resources.ResourceManager.GetString("PositionX", Resources.resourceCulture);
            }
        }

        internal static string PositionY
        {
            get
            {
                return Resources.ResourceManager.GetString("PositionY", Resources.resourceCulture);
            }
        }

        internal static string PositionZ
        {
            get
            {
                return Resources.ResourceManager.GetString("PositionZ", Resources.resourceCulture);
            }
        }

        internal static string RoomName
        {
            get
            {
                return Resources.ResourceManager.GetString("RoomName", Resources.resourceCulture);
            }
        }

        internal static string RoomNumber
        {
            get
            {
                return Resources.ResourceManager.GetString("RoomNumber", Resources.resourceCulture);
            }
        }

        internal static string FromRoomNumber
        {
            get
            {
                return Resources.ResourceManager.GetString("FromRoomNumber", Resources.resourceCulture);
            }
        }

        internal static string ToRoomNumber
        {
            get
            {
                return Resources.ResourceManager.GetString("ToRoomNumber", Resources.resourceCulture);
            }
        }


    }
    
    public enum NumberDirection
    {
        Right,
        Left,
        Down,
        Up,
    } //might remove because is already defined in the form item

    public enum NumberType
    {
        Numeric,
        AlphabeticUppercase,
        AlphabeticLowercase,
        RomanNumericUppercase,
        RomanNumericLowercase,
    }       //might remove because is already defined in the form item

    public enum SelectionMode
    {
        Multiple,
        OneByOne,
    }   //might remove because decision to keep only multiple as the only option


}
