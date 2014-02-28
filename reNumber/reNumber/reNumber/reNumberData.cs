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
using Autodesk.Revit.DB.Architecture;

namespace reNumber
{
    internal class reNumberData
    {
        private static SingleAssemblyResourceManager resourceMan;   //where is this  from?
        private static CultureInfo resourceCulture; //where is this from?

        [EditorBrowsable(EditorBrowsableState.Advanced)]

        internal static SingleAssemblyResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals((object)reNumberData.resourceMan, (object)null))
                    reNumberData.resourceMan = new SingleAssemblyResourceManager("reNumber.Resources", typeof(reNumberData).Assembly);
                return reNumberData.resourceMan;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return reNumberData.resourceCulture;
            }
            set
            {
                reNumberData.resourceCulture = value;
            }
        }

        internal static string AllElements
        {
            get
            {
                return reNumberData.ResourceManager.GetString("AllElements", reNumberData.resourceCulture);
            }
        }

        internal static string AllElementsOfActiveView
        {
            get
            {
                return reNumberData.ResourceManager.GetString("AllElementsOfActiveView", reNumberData.resourceCulture);
            }
        }

        internal static string Alpha
        {
            get
            {
                return reNumberData.ResourceManager.GetString("Alpha", reNumberData.resourceCulture);
            }
        }

        internal static string AlphaLowerCase
        {
            get
            {
                return reNumberData.ResourceManager.GetString("AlphaLowerCase", reNumberData.resourceCulture);
            }
        }

        internal static string ChooseSelectingMethod
        {
            get
            {
                return reNumberData.ResourceManager.GetString("ChooseSelectingMethod", reNumberData.resourceCulture);
            }
        }

        internal static string ClickHere
        {
            get
            {
                return reNumberData.ResourceManager.GetString("ClickHere", reNumberData.resourceCulture);
            }
        }

        internal static string Column
        {
            get
            {
                return reNumberData.ResourceManager.GetString("Column", reNumberData.resourceCulture);
            }
        }

        internal static string ContactTechnicalSupport
        {
            get
            {
                return reNumberData.ResourceManager.GetString("ContactTechnicalSupport", reNumberData.resourceCulture);
            }
        }

        internal static string ElementByElement
        {
            get
            {
                return reNumberData.ResourceManager.GetString("ElementByElement", reNumberData.resourceCulture);
            }
        }

        internal static string FormatMustIncludeAtLeastOneMacro_
        {
            get
            {
                return reNumberData.ResourceManager.GetString("FormatMustIncludeAtLeastOneMacro_", reNumberData.resourceCulture);
            }
        }

        internal static string FormatValueMissing
        {
            get
            {
                return reNumberData.ResourceManager.GetString("FormatValueMissing", reNumberData.resourceCulture);
            }
        }

        internal static string FromRoomNumber
        {
            get
            {
                return reNumberData.ResourceManager.GetString("FromRoomNumber", reNumberData.resourceCulture);
            }
        }

        internal static string LevelName
        {
            get
            {
                return reNumberData.ResourceManager.GetString("LevelName", reNumberData.resourceCulture);
            }
        }

        internal static string LevelNumber
        {
            get
            {
                return reNumberData.ResourceManager.GetString("LevelNumber", reNumberData.resourceCulture);
            }
        }

        internal static string MandatoryField
        {
            get
            {
                return reNumberData.ResourceManager.GetString("MandatoryField", reNumberData.resourceCulture);
            }
        }

        internal static string MultipleSelection
        {
            get
            {
                return reNumberData.ResourceManager.GetString("MultipleSelection", reNumberData.resourceCulture);
            }
        }

        internal static string NoElementsFound
        {
            get
            {
                return reNumberData.ResourceManager.GetString("NoElementsFound", reNumberData.resourceCulture);
            }
        }

        internal static string NoElementThatCanBeRenumbered
        {
            get
            {
                return reNumberData.ResourceManager.GetString("NoElementThatCanBeRenumbered", reNumberData.resourceCulture);
            }
        }

        internal static string NoMacroInFormat
        {
            get
            {
                return reNumberData.ResourceManager.GetString("NoMacroInFormat", reNumberData.resourceCulture);
            }
        }

        internal static string Numbering
        {
            get
            {
                return reNumberData.ResourceManager.GetString("Numbering", reNumberData.resourceCulture);
            }
        }

        internal static string Numeric
        {
            get
            {
                return reNumberData.ResourceManager.GetString("Numeric", reNumberData.resourceCulture);
            }
        }

        internal static string PositionX
        {
            get
            {
                return reNumberData.ResourceManager.GetString("PositionX", reNumberData.resourceCulture);
            }
        }

        internal static string PositionY
        {
            get
            {
                return reNumberData.ResourceManager.GetString("PositionY", reNumberData.resourceCulture);
            }
        }

        internal static string PositionZ
        {
            get
            {
                return reNumberData.ResourceManager.GetString("PositionZ", reNumberData.resourceCulture);
            }
        }

        internal static string Roman
        {
            get
            {
                return reNumberData.ResourceManager.GetString("Roman", reNumberData.resourceCulture);
            }
        }

        internal static string RomanLowerCase
        {
            get
            {
                return reNumberData.ResourceManager.GetString("RomanLowerCase", reNumberData.resourceCulture);
            }
        }

        internal static string RoomName
        {
            get
            {
                return reNumberData.ResourceManager.GetString("RoomName", reNumberData.resourceCulture);
            }
        }

        internal static string RoomNumber
        {
            get
            {
                return reNumberData.ResourceManager.GetString("RoomNumber", reNumberData.resourceCulture);
            }
        }

        internal static string Row
        {
            get
            {
                return reNumberData.ResourceManager.GetString("Row", reNumberData.resourceCulture);
            }
        }

        internal static string SelectEltsToBeNumbered
        {
            get
            {
                return reNumberData.ResourceManager.GetString("SelectEltsToBeNumbered", reNumberData.resourceCulture);
            }
        }

        internal static string SelectEltToBeNumbered
        {
            get
            {
                return reNumberData.ResourceManager.GetString("SelectEltToBeNumbered", reNumberData.resourceCulture);
            }
        }

        internal static string SystemDatePostponed
        {
            get
            {
                return reNumberData.ResourceManager.GetString("SystemDatePostponed", reNumberData.resourceCulture);
            }
        }

        internal static string SystemDatePostponedTitle
        {
            get
            {
                return reNumberData.ResourceManager.GetString("SystemDatePostponedTitle", reNumberData.resourceCulture);
            }
        }

        internal static string TaskDialogSelectionTitle
        {
            get
            {
                return reNumberData.ResourceManager.GetString("TaskDialogSelectionTitle", reNumberData.resourceCulture);
            }
        }

        internal static string ToRoomNumber
        {
            get
            {
                return reNumberData.ResourceManager.GetString("ToRoomNumber", reNumberData.resourceCulture);
            }
        }

        internal static string TrialPeriodExpired
        {
            get
            {
                return reNumberData.ResourceManager.GetString("TrialPeriodExpired", reNumberData.resourceCulture);
            }
        }       //remove

        internal static string TrialVersion         //remove
        {
            get
            {
                return reNumberData.ResourceManager.GetString("TrialVersion", reNumberData.resourceCulture);
            }
        }

        internal static string TrialVersionExpiresOn
        {
            get
            {
                return reNumberData.ResourceManager.GetString("TrialVersionExpiresOn", reNumberData.resourceCulture);
            }
        }   //remove

        internal static string TrialVersionHasExpired
        {
            get
            {
                return reNumberData.ResourceManager.GetString("TrialVersionHasExpired", reNumberData.resourceCulture);
            }
        }   //remove

        internal static string Value
        {
            get
            {
                return reNumberData.ResourceManager.GetString("Value", reNumberData.resourceCulture);
            }
        }


        //bitmap below
        internal static Bitmap Down
        {
            get
            {
                return (Bitmap)reNumberData.ResourceManager.GetObject("Down", reNumberData.resourceCulture);
            }
        }

        internal static Bitmap HLBRT
        {
            get
            {
                return (Bitmap)reNumberData.ResourceManager.GetObject("HLBRT", reNumberData.resourceCulture);
            }
        }

        internal static Bitmap HLTRB
        {
            get
            {
                return (Bitmap)reNumberData.ResourceManager.GetObject("HLTRB", reNumberData.resourceCulture);
            }
        }

        internal static Bitmap HRBLT
        {
            get
            {
                return (Bitmap)reNumberData.ResourceManager.GetObject("HRBLT", reNumberData.resourceCulture);
            }
        }

        internal static Bitmap HRTLB
        {
            get
            {
                return (Bitmap)reNumberData.ResourceManager.GetObject("HRTLB", reNumberData.resourceCulture);
            }
        }

        internal static Bitmap Left
        {
            get
            {
                return (Bitmap)reNumberData.ResourceManager.GetObject("Left", reNumberData.resourceCulture);
            }
        }

        internal static Bitmap Right
        {
            get
            {
                return (Bitmap)reNumberData.ResourceManager.GetObject("Right", reNumberData.resourceCulture);
            }
        }

        internal static Bitmap Up
        {
            get
            {
                return (Bitmap)reNumberData.ResourceManager.GetObject("Up", reNumberData.resourceCulture);
            }
        }

        internal static Bitmap VLBRT
        {
            get
            {
                return (Bitmap)reNumberData.ResourceManager.GetObject("VLBRT", reNumberData.resourceCulture);
            }
        }

        internal static Bitmap VLTRB
        {
            get
            {
                return (Bitmap)reNumberData.ResourceManager.GetObject("VLTRB", reNumberData.resourceCulture);
            }
        }

        internal static Bitmap VRBLT
        {
            get
            {
                return (Bitmap)reNumberData.ResourceManager.GetObject("VRBLT", reNumberData.resourceCulture);
            }
        }

        internal static Bitmap VRTLB
        {
            get
            {
                return (Bitmap)reNumberData.ResourceManager.GetObject("VRTLB", reNumberData.resourceCulture);
            }
        }


        internal reNumberData()
        {
            //base..ctor();       //can remove
        }

    }

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

    public static class DoorsAndWindows
    {
        public static void UpdateFromTo(Element elem)
        {
            FamilyInstance familyInstance = elem as FamilyInstance;
            if (familyInstance == null)
                return;
            switch((familyInstance).Category.Id.IntegerValue)
            {
                case (-2000023):
                case (-2000014):
                    BoundingBoxXYZ boundingBox = (familyInstance).get_BoundingBox((View) null);
                    if (boundingBox == null)
                        break;
                    XYZ xyz1 = XYZ.op_Division(XYZ.op_Addition(boundingBox.Min, boundingBox.Max,2.0));
                    Room roomAtPoint1 = (familyInstance).Document.GetRoomAtPoint(xyz1);
                    if(roomAtPoint1!=null)
                    {
                        if(familyInstance.ToRoom !=null && roomAtPoint1.Id.IntegerValue == familyInstance.ToRoom.Id.IntegerValue)
                            break;
                        familyInstance.FlipFromToRoom();
                        break;
                    }
                    else
                    {
                        XYZ xyz2 = XYZ.op_Multiply (familyInstance.FacingOrientation, XYZ.op_Subtraction(boundingBox.Max, boundingBox.Min.GetLength()));
                        XYZ xyz3 = XYZ.op_Addition(xyz1, xyz2);
                        Room roomAtPoint2 = familyInstance.Document.GetRoomAtPoint(xyz3);

                        if(roomAtPoint2 == null || familyInstance.FromRoom!=null && roomAtPoint2.Id.IntegerValue == familyInstance.FromRoom.Id.IntegerValue)
                            break;
                        familyInstance.FlipFromToRoom();
                        break;
                    }
            }
        }
    }

}
