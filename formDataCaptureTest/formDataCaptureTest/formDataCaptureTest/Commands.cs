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

namespace formDataCaptureTest
{

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.NoCommandData)]

    public class Commands : IExternalCommand
    {

        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {

            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;

            try
            {
                formDataCaptureData Data = new formDataCaptureData(commandData);
                Data.refreshList();

                using (formDataCaptureForm displayForm = new formDataCaptureForm(Data))
                {
                    if (DialogResult.OK != displayForm.ShowDialog())
                    {
                        return Autodesk.Revit.UI.Result.Cancelled;
                    }
                }

                Autodesk.Revit.UI.TaskDialog.Show("Capturing Values from the Form", "Checkbox is: " + Data.returnCheckBoxText + "\n" + "Check ListBox Items are: " + Data.returnChecklistBoxItemText + "\n" + "ListBox Items are: " + Data.returnListBoxItemText + "\n" + "ComboBox Item is: " + Data.returnComboBoxText + "\n" + "Tree Node Items are: " + Data.returnTreeNodeItemText + "\n" + "TextBox Item is: " + Data.returnTextBoxText + "\n\n" + "That's all folks");

                // Return Success
                return Autodesk.Revit.UI.Result.Succeeded;

            }
            catch (Exception ex)
            {

                // Failure Message
                message = ex.Message;
                return Autodesk.Revit.UI.Result.Failed;

            }
        }
    }
}
