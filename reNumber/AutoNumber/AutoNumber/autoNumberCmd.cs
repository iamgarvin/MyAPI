using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace AutoNumber
{

    /// <summary>
    /// Revit 2013 Command Class
    /// </summary>
    /// <remarks></remarks>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]

    public class autoNumberCmd : IExternalCommand
    {
        /// <summary>
        /// Command Entry Point
        /// </summary>
        /// <param name="commandData">Input argument providing access to the Revit application and documents</param>
        /// <param name="message">Return message to the user in case of error or cancel</param>
        /// <param name="elements">Return argument to highlight elements on the graphics screen if Result is not Succeeded.</param>
        /// <returns>Cancelled, Failed or Succeeded</returns>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Transaction newTran = null;
                        
            try
            {
                if (null == commandData)
                {
                    throw new ArgumentException("commandData");
                }

                Document doc = commandData.Application.ActiveUIDocument.Document;

                newTran = new Transaction(doc);
                newTran.Start("AutoNumber");

                autoNumberForm dlg = new autoNumberForm();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //apply the method
                    
                    //if
                    //scenario 1 : User has already selected a bunch of random elements
                    //1. assigns numbers to the sepcific category in the selected bunch of random elements
                    

                    //else
                    //scenario 2 : User has not selec anything
                    //1. prompt user to select the  elements
                    //2. prompt user to select finish in the options bar


                    //3. displays a message box to inform user that XX number of items are numbered from what number to what number
                }
                newTran.Commit();

                return Result.Succeeded;
            }

            catch (Exception ex)
            {
                message = ex.Message;
                if ((newTran != null) && newTran.HasStarted() && !newTran.HasEnded())
                    newTran.RollBack();
                return Result.Failed;

            }
        }
    }
}
