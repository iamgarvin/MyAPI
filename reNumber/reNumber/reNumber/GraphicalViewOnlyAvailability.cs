using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace reNumber
{
    public class GraphicalViewOnlyAvailability : IExternalCommandAvailability
    {

        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            if (applicationData.get_ActiveUIDocument() == null)
                return false;
            ViewType viewType = applicationData.ActiveUIDocument.Document.ActiveView.ViewType;
            if (((object)viewType).ToString().EndsWith("Report") || ((object)viewType).ToString().EndsWith("Schedule"))
                return false;
            else
                return viewType != 11;      //problem here
        }
    }
}
