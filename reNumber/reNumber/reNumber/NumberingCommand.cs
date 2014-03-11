testing this shit


﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
//using Wiip.Revit.Lib;
//using reNumber.Resources;


namespace reNumber
{
    [Regeneration(RegenerationOption.Manual)]
    [Transaction(TransactionMode.Manual)]

    internal class NumberingCommand :IExternalCommand
    {
        private const double EPSILON = 1E-06;
        private HashSet<double> columns;
        private IComparer<XYZ> comparer;
        private Document document;
        private NumberGenerator ng;
        private static readonly Options options;
        private HashSet<double> rows;
        private reNumber.SelectionMode selectionMode;  //<--what is this?

        static NumberingCommand()
        {
            NumberingCommand.options = new Options();
        }

        public NumberingCommand() 
        {
            //base..ctor();       //can remove
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            document = uiDoc.Document;
            Selection selection = uiDoc.Selection;
            
            selectionMode = reNumber.SelectionMode.Multiple;        //selectionmode on default is set to Multiple
            ///consideration for the addin to only be used for multiple selection and element by element. because our practice does not have a standard direction of how the elements are to be numbered. (ie. doors, windows, carpark, column, beam, etc)

            
            if(selection.Elements.Size == 0)        //when nothing is selected in the document
            {
                //init taskdialog for user to invokde the command.
                TaskDialog taskDialog1 = new TaskDialog(reNumberData.TaskDialogSelectionTitle);
                taskDialog1.MainInstruction = reNumberData.ChooseSelectingMethod; 

                TaskDialog taskDialog2 = taskDialog1;
                //taskDialog2.AddCommandLink((TaskDialogCommandLinkId) 1001, reNumberData.AllElements);         //not needed for the office
                //taskDialog2.AddCommandLink((TaskDialogCommandLinkId)1002, reNumberData.AllElementsOfActiveView);      // not needed for the office
                taskDialog2.AddCommandLink((TaskDialogCommandLinkId)1003, reNumberData.MultipleSelection);
                taskDialog2.AddCommandLink((TaskDialogCommandLinkId) 1004, reNumberData.ElementByElement);
                taskDialog2.CommonButtons = ((TaskDialogCommonButtons) 8);      // init the commonButtons for the taskdialog//      //dunno what does '8' stand for
                TaskDialogResult taskDialogResult = taskDialog2.Show();            //show the taskdialog as a result        //what is the rationale for showing taskdialog2 as the result? why dont call the taskdialog directly?

                if (taskDialogResult.Equals(2))     //what is '2'
                    return Result.Cancelled;
                switch (taskDialogResult - 1001)
                {
                    case 0:
                        //selectionMode = reNumber.SelectionMode.AllElements;           //not needed for the office
                        break;
                    case 1: 
                        //selectionMode = reNumber.SelectionMode.AllElementsOfTheActiveView;        //not needed for the office
                        break;
                    case 2:
                        selectionMode = reNumber.SelectionMode.Multiple;
                        break;
                    case 3:
                        selectionMode = reNumber.SelectionMode.OneByOne;
                        break;
                }
            }

            //activate the Form, based on the selectionMode//
            using (NumberingOptionsForm numberingOptionsForm = new NumberingOptionsForm (NumberingCommand.options, document))       //options not prepared yet, have to manually settle
            {
                if (numberingOptionsForm.LoadCategories(selectionMode))
                {
                    if (DialogResult.Cancel == numberingOptionsForm.ShowDialog())
                        return Result.Cancelled;
                }
                else
                {
                    TaskDialog.Show(reNumberData.NoElementsFound, reNumberData.NoElementThatCanBeRenumbered);
                    return Result.Failed;
                    
                }
            }
            comparer = (IComparer<XYZ>) null;
            switch (NumberingCommand.options.Direction)
            {
                case Direction.Right:
                    comparer = (IComparer<XYZ>) new HorizontalComparer(false, false, true);
                    break;
                case Direction.Left:
                    comparer = (IComparer<XYZ>) new HorizontalComparer(true,false,true);
                    break;
                case Direction.Down:
                    comparer = (IComparer<XYZ>) new VerticalComparer(true, true,true);
                    break;
                case Direction.Up:
                    comparer = (IComparer<XYZ>) new VerticalComparer(false, false, true);
                    break;
<<<<<<< HEAD
                //case Direction.HorizontalLeftBottomToRightTop:   //can omit from code// not needed for practice
                    //comparer = (IComparer<XYZ> new HorizontalComparer(false, false, false));
                    //break;
                //case Direction.HorizontalLeftTopToRightBottom:
                    //comparer = (IComparer<XYZ> new HorizontalComparer(false, true, false));
                    //break;
                //case Direction.HorizontalRightBottomToLeftTop:
                    //comparer = (IComparer<XYZ> new HorizontalComparer(true, false, false));
                    //break;
                //case Direction.HorizontalRightTopToLeftBottom:
                    //comparer = (IComparer<XYZ> new HorizontalComparer(true, true, false));
                    //break;
                //case Direction.VerticalLeftBottomToRightTop:
                    //comparer = (IComparer<XYZ> new VerticalComparer(false, false, false));
                    //break;
                //case Direction.VerticalLeftTopToRightBottom:
                    //comparer = (IComparer<XYZ> new VerticalComparer(false, true, false));
                    //break;
                //case Direction.VerticalRightBottomToLeftTop:
                    //comparer = (IComparer<XYZ> new VerticalComparer(true, false, false));
                    //break;
                //case Direction.VerticalRightTopToLeftBottom:
                    //comparer = (IComparer<XYZ> new VerticalComparer(true, true, false));
                    //break;
=======
                
//                //case Direction.HorizontalLeftBottomToRightTop:
//                    comparer = (IComparer<XYZ> new HorizontalComparer(false, false, false));
//                    break;
//                case Direction.HorizontalLeftTopToRightBottom:
//                    comparer = (IComparer<XYZ> new HorizontalComparer(false, true, false));
//                    break;
//                case Direction.HorizontalRightBottomToLeftTop:
//                    comparer = (IComparer<XYZ> new HorizontalComparer(true, false, false));
//                    break;
//                case Direction.HorizontalRightTopToLeftBottom:
//                    comparer = (IComparer<XYZ> new HorizontalComparer(true, true, false));
//                    break;
//                case Direction.VerticalLeftBottomToRightTop:
//                    comparer = (IComparer<XYZ> new VerticalComparer(false, false, false));
//                    break;
//                case Direction.VerticalLeftTopToRightBottom:
//                    comparer = (IComparer<XYZ> new VerticalComparer(false, true, false));
//                    break;
//                case Direction.VerticalRightBottomToLeftTop:
//                    comparer = (IComparer<XYZ> new VerticalComparer(true, false, false));
//                    break;
//                case Direction.VerticalRightTopToLeftBottom:
//                    comparer = (IComparer<XYZ> new VerticalComparer(true, true, false));
//                    break;
>>>>>>> branch 'master' of https://github.com/iamgarvin/MyAPI
            }

            using (Transaction transaction = new Transaction(document))
            {
<<<<<<< HEAD
                if (transaction.Start("Numbering") == 1) //double check if "Numbering should be used, because class name is changed to reNumber
=======
                if (transaction.Start("Numbering").Equals(1))
>>>>>>> branch 'master' of https://github.com/iamgarvin/MyAPI
                {
                    ng = new NumberGenerator(NumberingCommand.options);
                    switch (selectionMode)
                    {
<<<<<<< HEAD
                        //case reNumber.SelectionMode.AllElements: //not needed for practice
                            //FilteredElementCollector elementCollector1 = new FilteredElementCollector(document);
                            //elementCollector1.WhereElementIsNotElementType().WherePasses((ElementFilter) new ElementCategoryFilter(new ElementId(NumberingCommand.options.CategoryId)));
                            //this.Number(elementCollector1.ToElementIds());
                            //break;
=======
//                        case reNumber.SelectionMode.AllElements:
//                            FilteredElementCollector elementCollector1 = new FilteredElementCollector(document);
//                            elementCollector1.WhereElementIsNotElementType().WherePasses((ElementFilter) new ElementCategoryFilter(new ElementId(NumberingCommand.options.CategoryId)));
//                            this.Number(elementCollector1.ToElementIds());
//                            break;
>>>>>>> branch 'master' of https://github.com/iamgarvin/MyAPI

<<<<<<< HEAD
<<<<<<< HEAD
                        //case SelectionMode.AllElementsOfTheActiveView: //not needed for practice
                            //FilteredElementCollector elementCollector2 = new FilteredElementCollector(document, (document.ActiveView.Id()));
=======
                        case SelectionMode.AllElementsOfTheActiveView:
                            FilteredElementCollector elementCollector2 = new FilteredElementCollector(document, document.ActiveView.Id);
>>>>>>> branch 'master' of https://github.com/iamgarvin/MyAPI
=======
//                        case SelectionMode.AllElementsOfTheActiveView:
//                            FilteredElementCollector elementCollector2 = new FilteredElementCollector(document, document.ActiveView.Id);
>>>>>>> branch 'master' of https://github.com/iamgarvin/MyAPI

<<<<<<< HEAD
                            //elementCollector2.WhereElementIsNotElementType().WherePasses((ElementFilter) new ElementCategoryFilter(new ElementId(NumberingCommand.options.CategoryId)));
                            //this.Number(elementCollector2.ToElementIds());
                            break;
=======
//                            elementCollector2.WhereElementIsNotElementType().WherePasses((ElementFilter) new ElementCategoryFilter(new ElementId(NumberingCommand.options.CategoryId)));
//                            this.Number(elementCollector2.ToElementIds());
//                            break;
>>>>>>> branch 'master' of https://github.com/iamgarvin/MyAPI

                        case SelectionMode.Multiple:
                            CategorySelectionFilter categorySelectionFilter1 = new CategorySelectionFilter (NumberingCommand.options.CategoryId);
                            ICollection<ElementId> elementIds;
<<<<<<< HEAD
<<<<<<< HEAD
                            if ((ElementSet) selection.Elements.Size == 0) //check for elements selected during initialization
=======
                            if (selection.Elements.Size == 0)
>>>>>>> branch 'master' of https://github.com/iamgarvin/MyAPI
=======
                            if (selection.Elements.Size == 0)       //if no elements are selected before init of the code,
>>>>>>> branch 'master' of https://github.com/iamgarvin/MyAPI
                            {
                                try 
                                {
                                    IList<Reference> list = selection.PickObjects((ObjectType) 1, (ISelectionFilter) categorySelectionFilter1, reNumberData.SelectEltsToBeNumbered);
<<<<<<< HEAD
                                    if(list == null)
                                        return Result.Cancelled;
                                    elementIds= (ICollection<ElementId>) new Collection<ElementId>();
                                    using (IEnumerator<Reference> CharEnumerator = ((IEnumerable<Reference>)list).GetEnumerator()) //enumerator to cycle thru selected items for renumbering
=======
                                    if (list == null)               //if there is no selection, cancel
>>>>>>> branch 'master' of https://github.com/iamgarvin/MyAPI
                                    {
                                        return Result.Cancelled;
                                    }

                                    elementIds= new Collection<ElementId>();            //refresh elementIds as anew
                                    using (IEnumerator<Reference> CharEnumerator = ((IEnumerable<Reference>)list).GetEnumerator()) //using loop to cycle thru enumerator to retrieve the elementid of the current element in the selection.
                                    {
                                        while ( CharEnumerator.MoveNext())
                                        {
                                            Reference current = CharEnumerator.Current;
                                            elementIds.Add(current.ElementId);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
<<<<<<< HEAD
                                    return (Result) 1; //cancelled
=======
                                    return Result.Cancelled;
>>>>>>> branch 'master' of https://github.com/iamgarvin/MyAPI
                                }
                            }
                            else   //if there are elements selected before the init of the code, retrieve the elementIds of the selection.
                            {
                                elementIds = selection.GetElementIds();
                            }
                                
                            Number(elementIds);         //call Number method to enter the numbering for the selected elementIds
                            break;

<<<<<<< HEAD
                        case reNumber.SelectionMode.OneByOne:
=======
                        case SelectionMode.OneByOne:
>>>>>>> branch 'master' of https://github.com/iamgarvin/MyAPI
                            CategorySelectionFilter categorySelectionFilter2 = new CategorySelectionFilter (NumberingCommand.options.CategoryId);
                            while (true)
                            {
                                try
                                {
                                    Reference reference = selection.PickObject((ObjectType) 1, (ISelectionFilter) categorySelectionFilter1, reNumberData.SelectEltToBeNumbered);
                                    if (System.Windows.Forms.Control.ModifierKeys.HasFlag((Enum)Keys.Control))
                                    {
                                        this.ng.ResetValues();
                                    }

                                    this.SetMark(document.GetElement(reference.ElementId),-1,-1);  // init SetMark to collect elements as the reference element to start numbering
                                    document.Regenerate();
                                }

                                catch (Exception ex)
                                {
                                    break;
                                }
                            }
                            
                    }
                }
                transaction.Commit();
            }
            return Result.Succeeded;
        }

        private void Number (ICollection<ElementId> elementIds)
        {
            SortedList<XYZ, List<Element>> sortedList = this.Sort(elementIds);
            List<double> list1 = Enumerable.ToList<double>((IEnumerable<double>) rows);
            List<double> list2 = Enumerable.ToList<double>((IEnumerable<double>) columns);
            using (IEnumerator<KeyValuePair<XYZ, List<Element>>> enumerator1 = sortedList.GetEnumerator())
            {
                while (((IEnumerator) enumerator1).MoveNext())
                {
                    KeyValuePair<XYZ, List<Element>> current1  =enumerator1.Current;
                    Predicate<double> predicate1 = (Predicate<double>) null;
                    Predicate<double> predicate2 = (Predicate<double>) null;
                    //NumberingCommand.c__DisplayClass5 cDisplayClass5 = new NumberingCommand.c__DisplayClass5();         //What is this??

                    //cDisplayClass5.point = current1.Key;
                    using (List<Element>.Enumerator enumerator2 = current1.Value.GetEnumerator())
                    {
                        while (enumerator2.MoveNext())
                        {
                            Element current2 = enumerator2.Current;
                            NumberingCommand numberingCommand = this;
                            Element elem = current2;
                            List<double> list3 = list1;
                            if (predicate1 ==null)
                            {
                                //ISSUE: method pointer  ///what is this again.. please go find out
                                //predicate1 = new Predicate<double> ((object) cDisplayClass5, __methodptr(<Number>b__!));
                            }
                            Predicate<double> match1 = predicate1;
                            int row = list3.FindIndex(match1) + 1;
                            List<double> list4 = list2;
                            if( predicate2 ==null)
                            {
                                // ISSUE: method pointer ///what is this again.. pleas go find out
                                //predicate2 = new Predicate<double>((object) cDisplayClass5, __mthodptr(<Number>b_2));
                            }
                            Predicate<double> match2 = predicate2;
                            int column = list4.FindIndex(match2)+1;
                            numberingCommand.SetMark(elem, row, column); //call SetMark to renumber the element using the loop
                        }
                    }
                }
            }
        }

        private SortedList<XYZ, List<Element>> Sort(ICollection<ElementId> elementIds)
        {
            SortedList<XYZ, List<Element>> sortedList1 = new SortedList<XYZ,List<Element>>(elementIds.Count, this.comparer);
            Transform transform = null;
            using (IEnumerator<ElementId> enumerator = elementIds.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Element element = document.GetElement(enumerator.Current);
                    if (element.Category != null && element.Category.Id.IntegerValue == NumberingCommand.options.CategoryId)
                    {
                        BoundingBoxXYZ boundingBox = element.get_BoundingBox(element.Document.ActiveView);
                        if (boundingBox != null)
                        {
                            XYZ key1 =  XYZ.op_Division(XYZ.op_Addition(boundingBox.Min, boundingBox.Max),2.0);
                            if(selectionMode != reNumber.SelectionMode.AllElements)
                            {
                                if(transform == null)
                                {
                                    transform = Transform.Identity;
                                    Autodesk.Revit.DB.View activeView = element.Document.ActiveView;
                                    transform.BasisX = activeView.RightDirection;
                                    transform.BasisY = activeView.UpDirection;
                                    transform.BasisZ = activeView.ViewDirection;
                                }

                                XYZ xyz = transform.OfPoint(key1);
                                key1 = new XYZ (xyz.X, xyz.Y, 0.0);
                            }
                            if(sortedList1.ContainsKey(key1))
                            {
                                sortedList1[key1].Add(element);
                            }
                            else
                            {
                                SortedList<XYZ, List<Element>> sortedList2 = sortedList1;
                                XYZ key2 = key1;
                                List<Element> list1 = new List<Element>();
                                list1.Add(element);
                                List<Element> list2 =list1;
                                sortedList2.Add(key2, list2);
                            }
                        }
                    }
                }
            }
            rows = new HashSet<double>();
            columns = new HashSet<double>();
            using (IEnumerator<XYZ> enumerator = ((IEnumerable<XYZ>) sortedList1.Keys).GetEnumerator())
            {
                while (((IEnumerator) enumerator).MoveNext())
                {
                    XYZ current =  enumerator.Current;
                    bool flag1 = false;
                    foreach (double num in rows)
                    {
                        if (Math.Abs(current.Y - num) < 1E-06)
                        {
                            flag1 = true;
                            break;
                        }
                    }
                    if (!flag1)
                        rows.Add(current.Y);
                    bool flag2 = false;
                    foreach (double num in columns)
                    {
                        if (Math.Abs(current.X-num) < 1E-06)
                        {
                            flag2 = true;
                            break;
                        }
                    }
                    if(!flag2)
                        columns.Add(current.X);
                }
            }
            return sortedList1;
        }

        private void SetMark (Element elem, int row = -1, int column = -1)
        {
            DoorsAndWindows.UpdateFromTo(elem);
            string str1 = "";
            if (elem.Level!=null)
            str1 = NumberGenerator.ExtractLevelNumber(elem.Level.Name.ToString());
            
            string str2 = "";
            FamilyInstance familyInstance1 = elem as FamilyInstance;
            if (familyInstance1 != null && familyInstance1.Room != null)
                str2 = (familyInstance1.Room.get_Parameter((BuiltInParameter) (-1006900)).AsString());

            string str3 = "";
            FamilyInstance familyInstance2 = elem as FamilyInstance;
            if(familyInstance2!=null && familyInstance2.FromRoom !=null)
                str3 = ((SpatialElement) familyInstance2.Room).Number;

            string str4 = "";
            FamilyInstance familyInstance3 = elem as FamilyInstance;
            if(familyInstance3 != null && familyInstance3.FromRoom != null)
                str4 = ((SpatialElement) familyInstance3.FromRoom).Number;

            string str5 = "";
            FamilyInstance familyInstance4 = elem as FamilyInstance;
            if(familyInstance4 != null && familyInstance4.ToRoom != null)
                str5 = ((SpatialElement) familyInstance4.ToRoom).Number;
            
            Dictionary<string, string> dictionary1 = new Dictionary<string,string>();
            dictionary1.Add (reNumberData.LevelName, elem.Level != null ? ((Element) elem.Level).Name : "");
            dictionary1.Add(reNumberData.LevelNumber, str1);
            dictionary1.Add(reNumberData.RoomName, str2);
            dictionary1.Add(reNumberData.RoomNumber, str3);
            dictionary1.Add(reNumberData.FromRoomNumber, str4);
            dictionary1.Add(reNumberData.ToRoomNumber, str5);

            Dictionary<string, string> dictionary2 = dictionary1;
            BoundingBoxXYZ  boundingBox = elem.get_BoundingBox((Autodesk.Revit.DB.View) null);

            if(boundingBox !=null)
            {
                XYZ xyz = XYZ.op_Division(XYZ.op_Addition(boundingBox.Min, boundingBox.Max, 2.0));
                dictionary2.Add(reNumberData.PositionX, Units.InternalToDoc(elem.Document, xyz.X, (UnitType) 0).ToString("F2"));
                dictionary2.Add(reNumberData.PositionY, Units.InternalToDoc(elem.Document, xyz.Y, (UnitType) 0).ToString("F2"));
                dictionary2.Add(reNumberData.PositionZ, Units.InternalToDoc(elem.Document, xyz.Z, (UnitType) 0).ToString("F2"));
            }

            List<string> list = new List<string>(NumberingCommand.options.GroupBy.Count);
            foreach (string index in NumberingCommand.options.GroupBy)
                list.Add(dictionary2[index]);
            
            string str6 = ng.NextNumber(row,column, string.Join("\t", (IEnumerable<string>) list));

            foreach (KeyValuePair<string, string> keyValuePair in dictionary2)
            {
                string str7 = NumberGenerator.LabelToMacro(keyValuePair.Key);
                str6 = str6.Replace("$(" + str7 + ")", keyValuePair.Value);
            }

            TextNote textNote = elem as TextNote;
            if(textNote != null)
            {
                ((TextElement) textNote).Text = str6;
            }

            else
            {
                Parameter parameter = elem.get_Parameter(NumberingCommand.options.ParameterName);
                if(parameter == null)
                    return;
                parameter.Set(str6);
            }
        }
    }
}