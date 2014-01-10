

using System;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace SectionBoxVisibility
{
    /// <summary>
    /// Implements the Revit add-in interface IExternalCommand
    /// </summary>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Automatic)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class Commands : IExternalCommand
    {
        public virtual Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData
            , ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            try
            {
                if (null == commandData)
                {
                    throw new ArgumentNullException("commandData");
                }
                // create an instance of VisibilityCtrl
                VisibilityCtrl visiController = new VisibilityCtrl(commandData.Application.ActiveUIDocument);

                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Autodesk.Revit.UI.Result.Failed;
            }
        }
    }

    public class VisibilityCtrl
    {
        private Autodesk.Revit.UI.UIDocument m_document;    // the active document

        public VisibilityCtrl(Autodesk.Revit.UI.UIDocument document)
        {
            if (null == document)
            {
                throw new ArgumentNullException("document");
            }
            else
            {
                m_document = document;
            }

            foreach (Category category in m_document.Document.Settings.Categories)
            {
                if (category.Name == "Section Boxes")
                {
                    if (category.get_Visible(m_document.ActiveView) == true)
                    {
                        category.set_Visible(m_document.ActiveView, false);
                    }
                    else
                    {
                        category.set_Visible(m_document.ActiveView, true);
                    }
                }
            }
        }
    }
}

