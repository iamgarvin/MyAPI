using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Autodesk.Revit;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace projectCoordinatesSetup
{

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Automatic)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]

    public class Commands : IExternalCommand
    {

        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {

            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;

            try
            {
                projectCoordinatesData Data = new projectCoordinatesData(commandData);
                Data.GetLocation();

                using (projectCoordinatesForm displayForm = new projectCoordinatesForm(Data, commandData.Application.ActiveUIDocument.Document.SiteLocation))
                {
                    if (DialogResult.OK != displayForm.ShowDialog())
                    {
                        return Autodesk.Revit.UI.Result.Cancelled;
                    }
                }

                #region return final values
                ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_ProjectBasePoint);

                FilteredElementCollector collector = new FilteredElementCollector(doc);
                IList<Element> elementzz = collector.WherePasses(filter).ToElements();

                foreach (Element element in elementzz)
                {
                    double x = element.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsDouble() / 0.0032808398950131;
                    string a = System.Convert.ToString(x);
                    double y = element.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsDouble() / 0.0032808398950131;
                    string b = System.Convert.ToString(y);
                    double elevation = element.get_Parameter(BuiltInParameter.BASEPOINT_ELEVATION_PARAM).AsDouble() / 0.0032808398950131;
                    string elevation123 = System.Convert.ToString(elevation);
                    double z = element.get_Parameter(BuiltInParameter.BASEPOINT_ANGLETON_PARAM).AsDouble() / 0.0174532925199433;
                    string c = System.Convert.ToString(z);
                    string reminderMsg = "After closing this dialog box, select your Project Base Point and set Elevation to zero (0.00).\n\nRemember to CLIP both the Survey Point and Project Base Point after all is complete";
                    string r = Data.returnRotation;
                    string rA = System.Convert.ToString(Data.returnRotationAngle);

                    //Autodesk.Revit.UI.TaskDialog.Show("Project Coordinates Set-up Success", "Northing Value: " + a + "\nEasting Value: " + b + "\nFirst Storey FFL: " + elevation123 + "\n" + "Angle to True North: " + c + " °\n\n" + reminderMsg);
                    Autodesk.Revit.UI.TaskDialog.Show("Project Coordinates Set-up Success", "Northing Value: " + a + "\nEasting Value: " + b + "\nFirst Storey FFL: " + elevation123 + "\n" + "North Rotation Angle: " + rA + "° " + r + "\nAngle to True North: " + c + "°\n\n" + reminderMsg);
                    
                    
                }
                #endregion return final values
                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Autodesk.Revit.UI.Result.Failed;
            }

        }
    }
}
