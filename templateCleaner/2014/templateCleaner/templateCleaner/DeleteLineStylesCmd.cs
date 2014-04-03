#region Namespaces
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace templateCleaner
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class DeleteLineStylesCmd : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {

                UIApplication uiapp = commandData.Application;
                UIDocument uidoc = uiapp.ActiveUIDocument;
                Application app = uiapp.Application;
                Document doc = uidoc.Document;

                
                using (Transaction t = new Transaction(doc, "Delete Linestyles"))
                {
                    t.Start();
                    DeleteLineStyles(doc);

                    t.Commit();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }

            return Result.Succeeded;
        }

        public void DeleteLineStyles(Document doc)
        {

            Category linesCat = doc.Settings.Categories.get_Item("Lines");

            IList<Category> categoryList = linesCat.SubCategories.Cast<Category>().ToList();

            IList<Category> noDelList = linesCat.SubCategories.Cast<Category>().Where(c => c.Name.StartsWith("<") || c.Name.Equals("Lines") || c.Name.Equals("Hidden Lines") || c.Name.Equals("Insulation Batting Lines") || c.Name.Equals("Medium Lines") || c.Name.Equals("Thin Lines") || c.Name.Equals("Wide Lines") || c.Name.Equals("Axis of Rotation")).ToList();

            IList<ElementId> idsToDelete = new List<ElementId>();
            IList<string> namesToDelete = new List<string>();

            foreach (Category cat in categoryList)
            {
                if (noDelList.Contains(cat))
                {
                    continue;
                }
                else
                {
                    namesToDelete.Add(cat.Name.ToString());
                    idsToDelete.Add(cat.Id);
                }

                //doc.Delete(cat.Id);
            }

            TaskDialog.Show("lol", string.Join("\n", namesToDelete.Select(i => i.ToString()).ToArray()));

            doc.Delete(idsToDelete);
        }


    }
}

    