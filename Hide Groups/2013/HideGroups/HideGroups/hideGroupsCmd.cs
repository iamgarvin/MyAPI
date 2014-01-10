using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace HideGroups
{

    /// <summary>
    /// Revit 2013 Command Class
    /// </summary>
    /// <remarks></remarks>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.NoCommandData)]

    public class hideGroupsCmd : IExternalCommand
    {
        #region IExternalCommand Members Implementation
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

            int i = 0;

            try
            {
                if (null == commandData)
                {
                    throw new ArgumentNullException("commandData");
                }

                Document doc = commandData.Application.ActiveUIDocument.Document;
                Autodesk.Revit.ApplicationServices.Application app = doc.Application;
                hideGroupsData Data = new hideGroupsData(doc);
                
                newTran = new Transaction(doc);
                newTran.Start("Hide Groups");   //What is this line for?
                
//                Data.refreshList();

                //Data.CleanGrps(doc); // call the clean command;
                for (i = 0; i < 6; i++)
                {
                    Data.CleanGroups(Data.viewstring[i], Data.grpstring[i]);
                }

                string viewnames = string.Join("\n", Data.returnAllViewsNames);
                string groupnames = string.Join("\n", Data.returnAllGroupsNames);

                Autodesk.Revit.UI.TaskDialog.Show("These are views", "Plan Views are: \n" + viewnames);

                Autodesk.Revit.UI.TaskDialog.Show("these are groups", "Groups are: \n" +groupnames + "\n");

                newTran.Commit();
                return Result.Succeeded;
            }
            catch (Exception e)
            {
                message = e.Message;
                if ((newTran != null) && newTran.HasStarted() && !newTran.HasEnded())
                    newTran.RollBack();

                return Result.Failed;
            }
        }
        #endregion IExternalCommand Members Implementation
    }
}
