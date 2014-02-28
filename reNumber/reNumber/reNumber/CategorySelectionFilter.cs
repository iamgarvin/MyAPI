using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;


namespace reNumber
{
    internal class CategorySelectionFilter : ISelectionFilter
    {
        private readonly int categoryId;

        public CategorySelectionFilter (int categoryId)
        {
            //base..ctor(); //can remove
            categoryId = categoryId;
        }

        public bool AllowElement(Element elem)
        {
            if (elem.get_Category() != null)
                return elem.get_Category().get_Id().get_IntegerValue() == categoryId;
            else
                return false;

        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }

    }
}
