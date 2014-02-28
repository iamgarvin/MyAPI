﻿using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Media;
using System.Collections.Generic;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;



namespace reNumber
{
    [Transaction(TransactionMode.Manual)]
    class Application : IExternalApplication
    {
        
        private static AddInProperties addInProperties;  // <---- what is this
        

        internal static AddInProperties AddInProperties
        {
            get
            {
                return Application.addInProperties ?? (Application.addInProperties = new AddInProperties (Assembly.GetExecutingAssembly()));
            }
        }

        public static string HelpFilePath
        {
            get
            {
                return Path.Combine (Application.AddInProperties.AssemblyDirectory, "..\\..\\Resources\\Help.htm");
            }
        }

        public Application ()
        {
            //base..ctor();
        }

        
        public Result OnStartup(UIControlledApplication application)
        {

            //startup to initialise the push button for the addin in the ribbon//

            PushButton pushButton = (PushButton) application.CreateRibbonPanel(Application.AddInProperties.Name).AddItem((RibbonItemData) new PushButtonData(typeof (NumberingCommand).FullName, reNumberData.Numbering, Application.AddInProperties.Location, typeof (NumberingCommand).FullName));
            //((RibbonButton) pushButton).set_LargeImage();
            //((RibbonButton) pushButton).set_Image();
            pushButton.set_AvailabilityClassName(typeof (GraphicalViewOnlyAvailability).FullName);
            ((RibbonItem) pushButton).SetContextualHelp(new ContextualHelp((ContextualHelpType) 3,Application.HelpFilePath));

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }


            
    }
}
