using System;
using System.Collections.Generic;
using System.Globalization;

namespace projectCoordinatesSetup
{
    
    public enum ValueType //define type of value
    {
        General = 0, //general value
        Angle //angle value
    }

    public class unitConverter //class to convert units
    {
        private static readonly int DefaultPrecision = 3;  //default precision 
        private static readonly double AngleRatio = 0.0174532925199433;  //ratio of Angle

        
        public static double dealValuePrecision(double value, int precision) //dealing with value precision
        {
            if (precision < 0 && precision > 15) //first make sure 0 =< precision <= 15
            {
                return value;
            }

            double newValue;
            if (value >= 1 || value <= -1 || 0 == value) //using Math.Round to deal with <1 ot >-1
            {
                newValue = Math.Round(value, precision); //round off to the nearest value with the given precision
                return newValue;
            }

            //if -1 < value < 1, find first number which is not "0", compare it with precision, then select min of them as final precision
            int firstNumberPos = 0;
            double temp = Math.Abs(value);
            for (firstNumberPos = 1; ; firstNumberPos++)
            {
                temp *= 10;
                if (temp >= 1)
                {
                    break;
                }
            }

            if (firstNumberPos > 15) //make sure firstNumberPos <= 15
            {
                firstNumberPos = 15;
            }
            
            newValue = Math.Round(value, firstNumberPos > precision ? firstNumberPos : precision); //round off to nearest value at given precision
            return newValue;
        }

        public static string DoubleToString(double value, ValueType valueType) //converting double to string
        {
            string displayText = null; // string included value and unit of parameter
            double newValue;
            ValueConversion(value, ValueType.Angle, true, out newValue);
            value = newValue;
            newValue = dealValuePrecision(value, DefaultPrecision);

            displayText = convertDecimalToString(newValue.ToString(), DefaultPrecision); //adding zeros behind numbers after decimal point

            if (ValueType.Angle == valueType)
            {
                char degree = (char)0xb0;
                displayText += degree;
            }

            return displayText;
        }

        public static string convertDecimalToString(string value, int number) //converting decimal numbers to string
        {
            string newValue = value;
            int dist;
            if (newValue.Contains("."))
            {
                int index = newValue.IndexOf(".");
                dist = newValue.Length - (index + 1);
            }
            else
            {
                dist = 0;
                newValue += ".";
            }
            if (dist < number)
            {
                for (int i = 0; i < number - dist; i++)
                {
                    newValue += "0";
                }
            }
            return newValue;
        }

        public static bool StringToDouble(string value, ValueType valueType, out double newValue) //converting string to double
        {
            newValue = 0;

            if (null == value)
            {
                return false;
            }

            double result;
            if (ParseFromString(value, valueType, out result)) //Parse double from string
            {
                ValueConversion(result, valueType, false, out newValue);//deal with ratio
                return true;
            }
            return false;
        }

        private static bool ParseFromString(string value, ValueType valueType, out double result) //Parse Double from string
        {
            string newValue = null;
            string degree = ((char)0xb0).ToString();

            //if nothing, set result = 0;
            if (value.Length == 0)
            {
                result = 0;
                return true;
            }
            else if (ValueType.General == valueType)
            {
            }
            //check if contain degree symbol
            else if (value.Contains(degree))
            {
                int index = value.IndexOf(degree);
                newValue = value.Substring(0, index);
            }
            //check if have string" " ,for there is string" " 
            //between value and unit when show in PropertyGrid
            else if (value.Contains(" "))
            {
                int index = value.IndexOf(" ");
                newValue = value.Substring(0, index);
            }
            //finally if don't have unit name in it 
            //other situation, set newValue = value
            else
            {
                newValue = value;
            }

            //double.TryParse's return value:
            //true if s is converted successfully; otherwise, false.
            if (double.TryParse(newValue, out result))
            {
                return true;
            }
            return false;
        }

        private static void ValueConversion(double value, ValueType valueType, bool isDoubleToString, out double newValue) //deal with ratio
        {
            //ValueType.General == valueType,do nothing and return
            if (ValueType.General == valueType)
            {
                newValue = value;
                return;
            }

            //otherwise,check whether be called by function "DoubleToString"
            if (isDoubleToString)
            {
                newValue = value / AngleRatio;
            }
            else
            {
                newValue = value * AngleRatio;
            }
        }
    }
}
