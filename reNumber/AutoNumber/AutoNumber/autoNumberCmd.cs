using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            UIApplication uiApp = commandData.Application;
            Document doc = commandData.Application.ActiveUIDocument.Document;
            Selection elementSelect = uiApp.ActiveUIDocument.Selection;
                        
            try
            {
                if (null == commandData)
                {
                    throw new ArgumentException("commandData");
                }
                
                autoNumberData numData = new autoNumberData(doc);

                newTran = new Transaction(doc);
                newTran.Start("AutoNumber");

                using (autoNumberForm dlg = new autoNumberForm(numData, doc))
                {
                    if (DialogResult.OK != dlg.ShowDialog())
                    {
                        return Result.Cancelled;
                    }
                }
                        //apply the method

                        //if
                        //scenario 1 : User has already selected a bunch of random elements
                        //1. assigns numbers to the sepcific category in the selected bunch of random elements


                        //else
                        //scenario 2 : User has not selec anything
                        //1. prompt user to select the  elements
                        //2. prompt user to select finish in the options bar


                        //3. displays a message box to inform user that XX number of items are numbered from what number to what number


                if (numData.SelectionType)
                {
                    CategorySelectionFilter manualSelect = new CategorySelectionFilter(numData.GetCategoryId(numData.SelectedCategory));
                    ICollection<ElementId> elementIds;

                    if(elementSelect.Elements.Size == 0)        //if no element is selected before invoking command
                    {
                        try 
                        {
                            IList <Reference> selectedElems = elementSelect.PickObjects((ObjectType) 1, manualSelect);//, statusPrompt);
                            if (selectedElems == null)
                                return Result.Cancelled;

                            elementIds = (ICollection<ElementId>) new Collection<ElementId>();

                            IEnumerator<Reference> enumerator;
                            using (enumerator = selectedElems.GetEnumerator())
                            {
                                while (enumerator.MoveNext())
                                {
                                    Reference current = enumerator.Current;
                                    elementIds.Add(current.ElementId);
                                }
                            }
                        }
                        catch(OperationCanceledException ex)
                        {
                            return Result.Cancelled;
                        }

                    }
                    else
                        elementIds = elementSelect.GetElementIds();
                    //this.Number(elementIds);
                }
                else
                {
                    ICollection<ElementId> elementIds;

                    FilteredElementCollector collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
                    elementIds = (ICollection<ElementId>)new Collection<ElementId>();
                    IEnumerator<Element> enumerator;
                    using(enumerator = collector.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            Element elem = enumerator.Current as Element;
                            if(elem.Category.Id.IntegerValue.Equals(numData.GetCategoryId(numData.SelectedCategory)))
                            {
                                elementIds.Add(elem.Id);
                            }
                        }
                    }
                    //this.Number(elementIds);
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
