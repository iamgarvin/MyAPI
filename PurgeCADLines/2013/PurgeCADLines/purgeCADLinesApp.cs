using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit;
using System.Diagnostics;
using System.IO;
using System.Windows.Media;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Events;

namespace PurgeCADLines
{

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Automatic)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]

    class purgeCADLinesApp : IExternalApplication
    {

        static string AddInPath = typeof(purgeCADLinesApp).Assembly.Location;
        static string ButtonIconsFolder = Path.GetDirectoryName(AddInPath) + "\\rspIcons\\";

        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                CreatePurgeCADRibbonPanel(application);
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "RSP Tools");
                return Result.Failed;
            }
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        private void CreatePurgeCADRibbonPanel(UIControlledApplication application)
        {
            string firstPanelName = "RSP Purge CAD lines";

            RibbonPanel rspRibbonPanel = application.CreateRibbonPanel(firstPanelName);

            PushButtonData pushButtonData = new PushButtonData("purgeCADLines", "Purge CAD Lines", AddInPath, "PurgeCADLines.purgeCADLinesCmd");
            PushButton pushButton = (PushButton)(rspRibbonPanel.AddItem(pushButtonData));

            pushButton.ToolTip = "Purge CAD Imported Linetypes";
        }
    }
}
