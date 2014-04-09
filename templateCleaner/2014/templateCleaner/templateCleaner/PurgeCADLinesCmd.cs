using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace rspTemplateCleaner
{

    /// <summary>
    /// Revit 2013 Command Class
    /// </summary>
    /// <remarks></remarks>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Automatic)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]

    public class purgeCADLinesCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                UIDocument activeUiDocument = commandData.Application.ActiveUIDocument;
                Document doc = activeUiDocument.Document;

                ICollection<ElementId> linePatternTypes = new FilteredElementCollector(doc).OfClass(typeof(LinePatternElement)).ToElementIds();
                ICollection<ElementId> linePatternTypesUsed = new FilteredElementCollector(doc).OfClass(typeof(LinePatternElement)).ToElementIds();

                foreach (ElementId linePatternId in linePatternTypesUsed)
                {
                    LinePatternElement lp = doc.GetElement(linePatternId) as LinePatternElement;
                    bool removed = linePatternTypes.Remove(lp.Id);
                }

                doc.Delete(linePatternTypes);


                //TaskDialog.Show("RSP Purge CAD Lines", num.ToString() + "  Imported Line Patterns were deleted!");
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }

            return Result.Succeeded;
        }

    }
}
