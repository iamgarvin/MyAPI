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

namespace rspTemplateCleaner
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Automatic)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]

    public class rspTemplateCleanerApp : IExternalApplication
    {
        static string AddInPath = typeof(rspTemplateCleanerApp).Assembly.Location;
        static string ButtonIconsFolder = Path.GetDirectoryName(AddInPath) + "\\rspIcons\\"; //need to get the RSP icon

        #region IExternalApplication Members - actions when revit starts or shuts down
        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                //Autodesk.Revit.UI.TaskDialog.Show("AddInPath Location", "The AddInPath Location is" + AddInPath);       //remove when  done, this is just for understanding purposes only
                CreaterspTemplateCleanerPanel(application);      //method to create the ribbon panels

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "RSP Tools");     //show a message box stating the error msg

                return Result.Failed;
            }
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            // Return Success
            return Result.Succeeded;
        }
        #endregion


        #region Create the RSP Ribbon Panel(s)
        private void CreaterspTemplateCleanerPanel(UIControlledApplication application)
        {
            //application.CreateRibbonTab("RSP BIM");

            #region RSP Template Cleaner Split Button

            string firstPanelName = "RSP Template Cleaner";

            RibbonPanel rspTemplateCleanerRibbonPanel = application.CreateRibbonPanel("RSP", firstPanelName);

            PulldownButtonData rspTemplateCleanerPullDownButtonData = new PulldownButtonData("rspTemplateCleanerPullDownButton", firstPanelName);
            PulldownButton rspTemplateCleanerPullDownButton = (PulldownButton)rspTemplateCleanerRibbonPanel.AddItem((RibbonItemData)rspTemplateCleanerPullDownButtonData);

            rspTemplateCleanerPullDownButton.ToolTip = "Click to open up menu of RSP In-House Revit tools";
            rspTemplateCleanerPullDownButton.ItemText = firstPanelName;

            rspTemplateCleanerPullDownButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "RSP_Template_RVT_S.png"), UriKind.Absolute));
            rspTemplateCleanerPullDownButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "RSP_Template_RVT.png"), UriKind.Absolute));

            PushButtonData delLineStylesPushButtonData = new PushButtonData("delLineStylesPushBtn", "Delete All Line Styles", AddInPath, "rspTemplateCleaner.DeleteLineStylesCmd");
            (rspTemplateCleanerPullDownButton.AddPushButton(delLineStylesPushButtonData)).ToolTip = "Delete and Purge all Line Styles of the Project.";

            PushButtonData delCADLineStylesPushButtonData = new PushButtonData("delCADLineStylesPushBtn", "Delete All CAD Line Styles", AddInPath, "rspTemplateCleaner.DeleteCADLineStylesCmd");
            (rspTemplateCleanerPullDownButton.AddPushButton(delCADLineStylesPushButtonData)).ToolTip = "Delete and Purge all CAD Line Styles of the Project.";

            PushButtonData delCADLinePatternsPushButtonData = new PushButtonData("delCADLinePatternsPushBtn", "Delete All CAD Line Patterns", AddInPath, "rspTemplateCleaner.PurgeCADLinesCmd");
            (rspTemplateCleanerPullDownButton.AddPushButton(delCADLinePatternsPushButtonData)).ToolTip = "Delete and Purge all CAD Imported Line Patterns of the Project.";

            #endregion

            //rspRibbonPanel.AddSeparator();        //add a seperator in between buttons

          

        }
        #endregion

    }
}
