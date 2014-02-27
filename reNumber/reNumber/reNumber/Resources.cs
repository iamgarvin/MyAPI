using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

using Autodesk.Revit.DB;

namespace reNumber
{
    public class SingleAssemblyResourceManager : ComponentResourceManager
    {
        private readonly Type contextTypeInfo;
        private CultureInfo neutralResourceCulture;

        public SingleAssemblyResourceManager (Type t)
        {
            //base..ctor(t);      //can remove
            contextTypeInfo = t;
        }

        public SingleAssemblyResourceManager (string baseName, Assembly assembly)
        {
            //base..ctor(baseName, assembly);
        }

        protected override ResourceSet InternalGetResourceSet(CultureInfo culture, bool createIfNotExists, bool tryParents)
        {
            ResourceSet rs = (ResourceSet)ResourceSets[(object)culture];
            if (rs == null)
            {
                if (neutralResourceCulture == null)
                    neutralResourceCulture = ResourceManager.GetNeutralResourcesLanguage(MainAssembly);

                if (neutralResourceCulture.Equals((object)culture))
                    culture = CultureInfo.InvariantCulture;
                Stream manifestResourceStream = MainAssembly.GetManifestResourceStream(contextTypeInfo, GetResourceFileName(culture));

                if (manifestResourceStream != null)
                {
                    rs = new ResourceSet(manifestResourceStream);
                    SingleAssemblyResourceManager.AddResourceSet(ResourceSets, culture, ref rs);
                }
                else 
                    rs = base.InternalGetResourceSet(culture, createIfNotExists, tryParents);
            }
            return rs;
        }

        private static void AddResourceSet(Hashtable localResourceSets, CultureInfo culture, ref ResourceSet rs)
        {
            bool lockTaken = false;
            Hashtable hashtable;
            try
            {
                Monitor.Enter((object)(hashtable = localResourceSets), ref lockTaken);
                ResourceSet resourceSet = (ResourceSet)localResourceSets[(object)culture];
                if (resourceSet != null)
                {
                    if (object.Equals((object)resourceSet, (object)rs))
                        return;
                    rs.Dispose();
                    rs = resourceSet;
                }
                else
                    localResourceSets.Add((object)culture, (object)rs);
            }

            finally
            {
                if (lockTaken)
                    Monitor.Exit((object)hashtable);
            }
        }
	}

    internal class Resources
    {
        private static SingleAssemblyResourceManager resourceMan;   //where is this  from?
        private static CultureInfo resourceCulture; //where is this from?

        [EditorBrowsable(EditorBrowsableState.Advanced)]

        internal static SingleAssemblyResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals((object)Resources.resourceMan, (object)null))
                    Resources.resourceCulture = new SingleAssemblyResourceManager("reNumber.Resources", typeof(Resources).Assembly);
                return Resources.resourceMan;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return Resources.resourceCulture;
            }
            set
            {
                Resources.resourceCulture = value;
            }
        }

        internal static string AllElements
        {
            get
            {
                return Resources.ResourceManager.GetString("AllElements", Resources.resourceCulture);
            }
        }

        internal static string AllElementsOfActiveView
        {
            get
            {
                return Resources.ResourceManager.GetString("AllElementsOfActiveView", Resources.resourceCulture);
            }
        }

        internal static string Alpha
        {
            get
            {
                return Resources.ResourceManager.GetString("Alpha", Resources.resourceCulture);
            }
        }

        internal static string AlphaLowerCase
        {
            get
            {
                return Resources.ResourceManager.GetString("AlphaLowerCase", Resources.resourceCulture);
            }
        }

        internal static string ChooseSelectingMethod
        {
            get
            {
                return Resources.ResourceManager.GetString("ChooseSelectingMethod", Resources.resourceCulture);
            }
        }

        internal static string ClickHere
        {
            get
            {
                return Resources.ResourceManager.GetString("ClickHere", Resources.resourceCulture);
            }
        }

        internal static string Column
        {
            get
            {
                return Resources.ResourceManager.GetString("Column", Resources.resourceCulture);
            }
        }

        internal static string ContactTechnicalSupport
        {
            get
            {
                return Resources.ResourceManager.GetString("ContactTechnicalSupport", Resources.resourceCulture);
            }
        }

        internal static string ElementByElement
        {
            get
            {
                return Resources.ResourceManager.GetString("ElementByElement", Resources.resourceCulture);
            }
        }

        internal static string FormatMustIncludeAtLeastOneMacro_
        {
            get
            {
                return Resources.ResourceManager.GetString("FormatMustIncludeAtLeastOneMacro_", Resources.resourceCulture);
            }
        }

        internal static string FormatValueMissing
        {
            get
            {
                return Resources.ResourceManager.GetString("FormatValueMissing", Resources.resourceCulture);
            }
        }

        internal static string FromRoomNumber
        {
            get
            {
                return Resources.ResourceManager.GetString("FromRoomNumber", Resources.resourceCulture);
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

        internal static string MandatoryField
        {
            get
            {
                return Resources.ResourceManager.GetString("MandatoryField", Resources.resourceCulture);
            }
        }

        internal static string MultipleSelection
        {
            get
            {
                return Resources.ResourceManager.GetString("MultipleSelection", Resources.resourceCulture);
            }
        }

        internal static string NoElementsFound
        {
            get
            {
                return Resources.ResourceManager.GetString("NoElementsFound", Resources.resourceCulture);
            }
        }

        internal static string NoElementThatCanBeRenumbered
        {
            get
            {
                return Resources.ResourceManager.GetString("NoElementThatCanBeRenumbered", Resources.resourceCulture);
            }
        }

        internal static string NoMacroInFormat
        {
            get
            {
                return Resources.ResourceManager.GetString("NoMacroInFormat", Resources.resourceCulture);
            }
        }

        internal static string Numbering
        {
            get
            {
                return Resources.ResourceManager.GetString("Numbering", Resources.resourceCulture);
            }
        }

        internal static string Numeric
        {
            get
            {
                return Resources.ResourceManager.GetString("Numeric", Resources.resourceCulture);
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

        internal static string Roman
        {
            get
            {
                return Resources.ResourceManager.GetString("Roman", Resources.resourceCulture);
            }
        }

        internal static string RomanLowerCase
        {
            get
            {
                return Resources.ResourceManager.GetString("RomanLowerCase", Resources.resourceCulture);
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

        internal static string Row
        {
            get
            {
                return Resources.ResourceManager.GetString("Row", Resources.resourceCulture);
            }
        }

        internal static string SelectEltsToBeNumbered
        {
            get
            {
                return Resources.ResourceManager.GetString("SelectEltsToBeNumbered", Resources.resourceCulture);
            }
        }

        internal static string SelectEltToBeNumbered
        {
            get
            {
                return Resources.ResourceManager.GetString("SelectEltToBeNumbered", Resources.resourceCulture);
            }
        }

        internal static string SystemDatePostponed
        {
            get
            {
                return Resources.ResourceManager.GetString("SystemDatePostponed", Resources.resourceCulture);
            }
        }

        internal static string SystemDatePostponedTitle
        {
            get
            {
                return Resources.ResourceManager.GetString("SystemDatePostponedTitle", Resources.resourceCulture);
            }
        }

        internal static string TaskDialogSelectionTitle
        {
            get
            {
                return Resources.ResourceManager.GetString("TaskDialogSelectionTitle", Resources.resourceCulture);
            }
        }

        internal static string ToRoomNumber
        {
            get
            {
                return Resources.ResourceManager.GetString("ToRoomNumber", Resources.resourceCulture);
            }
        }

        internal static string TrialPeriodExpired
        {
            get
            {
                return Resources.ResourceManager.GetString("TrialPeriodExpired", Resources.resourceCulture);
            }
        }       //remove

        internal static string TrialVersion         //remove
        {
            get
            {
                return Resources.ResourceManager.GetString("TrialVersion", Resources.resourceCulture);
            }
        }

        internal static string TrialVersionExpiresOn
        {
            get
            {
                return Resources.ResourceManager.GetString("TrialVersionExpiresOn", Resources.resourceCulture);
            }
        }   //remove

        internal static string TrialVersionHasExpired
        {
            get
            {
                return Resources.ResourceManager.GetString("TrialVersionHasExpired", Resources.resourceCulture);
            }
        }   //remove

        internal static string Value
        {
            get
            {
                return Resources.ResourceManager.GetString("Value", Resources.resourceCulture);
            }
        }


        //bitmap below
        internal static Bitmap Down
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("Down", Resources.resourceCulture);
            }
        }

        internal static Bitmap HLBRT
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("HLBRT", Resources.resourceCulture);
            }
        }

        internal static Bitmap HLTRB
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("HLTRB", Resources.resourceCulture);
            }
        }

        internal static Bitmap HRBLT
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("HRBLT", Resources.resourceCulture);
            }
        }

        internal static Bitmap HRTLB
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("HRTLB", Resources.resourceCulture);
            }
        }

        internal static Bitmap Left
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("Left", Resources.resourceCulture);
            }
        }

        internal static Bitmap Right
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("Right", Resources.resourceCulture);
            }
        }

        internal static Bitmap Up
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("Up", Resources.resourceCulture);
            }
        }

        internal static Bitmap VLBRT
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("VLBRT", Resources.resourceCulture);
            }
        }

        internal static Bitmap VLTRB
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("VLTRB", Resources.resourceCulture);
            }
        }

        internal static Bitmap VRBLT
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("VRBLT", Resources.resourceCulture);
            }
        }

        internal static Bitmap VRTLB
        {
            get
            {
                return (Bitmap)Resources.ResourceManager.GetObject("VRTLB", Resources.resourceCulture);
            }
        }


        internal Resources()
        {
            //base..ctor();       //can remove
        }

    }

    public class AddInProperties
    {
        private readonly Assembly AddInMainAssembly;

        public string AssemblyDirectory
        {
            get
            {
                return Path.GetDirectoryName(this.Location);
            }
        }

        public string Company
        {
            get
      {
        return ((AssemblyCompanyAttribute) Attribute.GetCustomAttribute(this.addInMainAssembly, typeof (AssemblyCompanyAttribute))).Company;
      }
    }

    public string Location
    {
      get
      {
        return this.addInMainAssembly.Location;
      }
    }

    public string Name
    {
      get
      {
        return ((AssemblyProductAttribute) Attribute.GetCustomAttribute(this.addInMainAssembly, typeof (AssemblyProductAttribute))).Product;
      }
    }

    public string FullName
    {
      get
      {
        return this.Name + " " + this.MajorAndMinorVersion;
      }
    }

    public string VendorId
    {
      get
      {
        return this.Company.Substring(0, 4).ToUpperInvariant();
      }
    }

    public string Version
    {
      get
      {
        return ((object) this.addInMainAssembly.GetName().Version).ToString();
      }
    }

    public string MajorAndMinorVersion
    {
      get
      {
        Version version = this.addInMainAssembly.GetName().Version;
        return (string) (object) version.Major + (object) "." + (string) (object) version.Minor;
      }
    }

    public AddInProperties(Assembly addInMainAssembly)
    {
      //base.\u002Ector();
      this.addInMainAssembly = addInMainAssembly;
    }
  }

    public static class Units
    {
        private const double FEETS_TO_METERS = 0.3048;

        public static double InternalToDoc(Document document, double internalUnits, UnitType unitType = 0)
        {
            FormatOptions formatOptions = document.get_ProjectUnit().get_FormatOptions(unitType);
            if (unitType != 0)
                throw new NotSupportedException(string.Format("Units type not supported: {0}", (object)unitType));
            switch ((int)formatOptions.get_Units())
            {
                case 0:
                case 9:
                    return internalUnits * 0.3048;
                case 1:
                    return internalUnits * 0.3048 * 100.0;
                case 2:
                    return internalUnits * 0.3048 * 1000.0;
                case 3:
                    return internalUnits;
                case 6:
                    return internalUnits * 12.0;
                default:
                    throw new NotSupportedException(string.Format("Units not supported: {0}", (object)formatOptions.get_Units()));
            }
        }

        public static double FeetToMeters(double feet)
        {
            return feet * 0.3048;
        }


        public static double MetersToFeet(double meters)
        {
            return meters / 0.3048;
        }

        public static double SquareFeetToSquareMeters(double squareFeet)
        {
            return squareFeet * Math.Pow(0.3048, 2.0);
        }
    }

    public class Mark
    {
        public Mark()
        {

        }

        public static int AlphaToNum(string alpha)
        {
            alpha = alpha.Trim();
            alpha = alpha.Replace(" ", "");
            alpha = alpha.ToUpper();
            int result;

            if (int.TryParse(alpha, out result))
                return result;
            char[] chArray = alpha.ToCharArray();
            int num1 = 0;
            int num2 = alpha.Length - 1;
            for (int i = 0; i < alpha.Length; ++i)
            {
                int num3 = Convert.ToInt32(chArray[IndexerNameAttribute]);
                if (num3 < 65 || num3 > 90)
                    return (-1);
                int num4 = num3 - 65;
                num1 += (num4 + 1) * (int)Math.Pow(26.0, (double)num2);
                --num2;
            }
            return num1;
        }

        public static string NumToAlpha(int num)
        {
            int num1 = num;
            int num2;
            string str = string.Empty;
            for(; num1 > 0; num1 = (num1-num2)/26)     //problem here
            {
                num2 = (num1 - 1) % 26;
                str = (string) (object) Convert.ToChar(65+num2) + (object) str;
            }
        }
    }

    public static class Extensions
    {
        public static string RemoveDiacritics(this string s)
        {
            return StringUtils.RemoveDiacritics(s);
        }

        public static string ToPascalCasing(this string s)
        {
            return StringUtils.ToPascalCasing(s);
        }

        public static string UpperCaseFirstLetter(this string s)
        {
            return StringUtils.UpperCaseFirstLetter(s);
        }
    }

    internal static class StringUtils
    {
        public static string UpperCaseFirstLetter(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;
            char[] chArray = text.ToCharArray();
            chArray[0] = char.ToUpper(chArray[0]);
            return new string(chArray);
        }

        public static string ToPascalCasing(string text)
        {
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text).Replace(" ", "");
        }

        public static string RemoveDiacritics(string s)
        {
            string str = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char ch in str)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(ch);
            }
            return ((object)stringBuilder).ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
