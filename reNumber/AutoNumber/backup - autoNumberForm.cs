using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Autodesk.Revit.DB;


namespace AutoNumber
{
    public partial class autoNumberForm : System.Windows.Forms.Form
    {
        private const int ROW_INDEX_COLUMN = 2;
        private const int ROW_INDEX_ROW = 1;
        private const int ROW_INDEX_VALUE = 0;
        private readonly Dictionary<BuiltInParameter, string> builtInParameterNames;
        private readonly Dictionary<int, List<string>> macros;
        private readonly Document document;
        private readonly autoNumberData dataOptions; //private readonly Options options;
        private Dictionary<string, ElementId> categories;
        private int formatSelectionLength;      //?? what length?
        private int formatSelectionStart;       //?? what start?

        private BiDictionaryOneToOne<string, NumberType> numberType;        //might remove because is already defined in the form item
        private Dictionary<int, List<string>> parameters;
        private SelectionMode selectionMode;     //might remove because decision to keep only multiple as the only option
        private IContainer components;

        private int Increment
        {
            get
            {
                object obj = updwnIncrement.Value;
                return int.Parse(obj.ToString());
            }
        }

        private int StartValue
        {
            get
            {
                object obj = updwnStartValue.Value;
                return int.Parse(obj.ToString());
            }
        }

        private NumberType NumberType       //might remove because is already defined in the form item
        {
            get
            {
                return numberType.GetByFirst(cboNumberingType.SelectedValue.ToString());
            }
        }

        public autoNumberForm(autoNumberData opt, Document doc)
        {
            builtInParameterNames = new Dictionary<BuiltInParameter, string>();     // why builtinparametersNames for what?
            macros = new Dictionary<int, List<string>>();   //macros is for what?

            InitializeComponent();
            dataOptions = opt;
            document = doc;
        }

        private void autoNumberForm_Load(object sender, EventArgs e)
        {
            WinFormUtils.SwitchToGdiForTextRendering(Controls); //not sure what is this for
            autoNumberForm form = this;
            string str = form.Text; //string str = form.Text + " - " + Resources.TrialVersion;        // remove this last part on TrialVersion
            form.Text = str;
            //llVersion.Text = string.Format("{0} {1}", Wiip.Revit.Numbering.Application.AddInProperties.Name, Wiip.Revit.Numbering.Application.AddInProperties.MajorMinorVersion);       //no need cos we dont talk about versioning here


            this.UpdateParametersAndMacros();   //call UpdateParametersAndMacros Method

            // no need cbFormat because our addin does not control the type of formatting for the mark numbers
            //cbFormat.Text = Options.Format; 
            //cbFormat.Items.Add("$(" + NumberGenerator.LabelToMacro(Resources.Value) + ")");
            //cbFormat.Items.Add((object)("$(" + NumberGenerator.LabelToMacro(Resources.Row) + ")$(" + NumberGenerator.LabelToMacro(Resources.Column) + ")"));
            //cbFormat.Items.Add((object)("$(" + NumberGenerator.LabelToMacro(Resources.Column) + ")$(" + NumberGenerator.LabelToMacro(Resources.Row) + ")"));
            //cbFormat.Items.Add((object)("$(" + NumberGenerator.LabelToMacro(Resources.ToRoomNumber) + ")$(" + NumberGenerator.LabelToMacro(Resources.Value) + ")"));
            //cbFormat.Items.Add((object)("$(" + NumberGenerator.LabelToMacro(Resources.PositionX) + ") $(" + NumberGenerator.LabelToMacro(Resources.PositionY) + ") $(" + NumberGenerator.LabelToMacro(Resources.PositionZ) + ")"));

            if (SelectionMode.OneByOne == selectionMode)
            {
                cboDirection.Enabled = false;   //disable the Direction if selection mode is one by one

                ///consideration: do we need to select one by one? can we just do the direction thing by multiple? I dont see the need to number one by one....
            }
            else
            {
                //cboDirection.DataSource = Enum.GetValues(NumberDirection);  //no need because we predefined the directions already
                cboDirection.SelectedItem = dataOptions.Direction;  //options to go into Data //assign the selected item to the Direction method in the options data //
            }

            updwnStartValue.Minimum = new Decimal(-1, -1, -1, true, (byte)0);
            updwnStartValue.Maximum = new Decimal(-1, -1, -1, false, (byte)0);
            updwnIncrement.Maximum = new Decimal(-1, -1, -1, false, (byte)0);

            //            numberType = new BiDictionaryOneToOne<string, NumberType>();        //i cannot use this because the code is too long.. i need to recreate or make use of the pre-defined in the form item

            //            foreach (NumberType second in Enum.GetValues(typeof(NumberType)))
            //            {
            //                string first = second.ToString();

            //                string @string = Resources.ResourceManager.GetString(((object)second).ToString());

            //                if (!string.IsNullOrEmpty(@string))
            //                    first = @string;
            //                numberType.Add(first, second);
            //                if (second != NumberType.Numeric)
            //                    cboNumberingType.Items.Add(first);

            //            }

            ///there is no dataGridView
            //this.dataGridView.Rows.Add((object)Resources.Value, (object)this.options.StartValue, (object)this.options.Increment, (object)"0".PadLeft(this.options.LeftPadding, '0'), (object)this.numberingTypes.GetBySecond(this.options.NumberingType));
            updwnStartValue.Value = dataOptions.StartValue;
            updwnIncrement.Value = dataOptions.Increment;

            //            UpdatePreview((autoNumberData)null);        // do i need to update preview? because this is for the update preview of the text box that i dont have
        }

        public bool GetCategories(SelectionMode select)
        {
            selectionMode = select;
            FilteredElementCollector elementCollector = null;
            switch (select)
            {
                case SelectionMode.Multiple:
                case SelectionMode.OneByOne:
                    elementCollector = new FilteredElementCollector(document);
                    break;
            }

            elementCollector.WhereElementIsNotElementType();
            categories = new Dictionary<string, ElementId>();
            parameters = new Dictionary<int, List<string>>();
            cboFamilyCategory.BeginUpdate();
            cboFamilyCategory.Sorted = true;

            string str = null;

            HashSet<int> hashSetInt = new HashSet<int>();
            HashSet<BuiltInCategory> hashSetBuiltInCategory = new HashSet<BuiltInCategory>();

            hashSetBuiltInCategory.Add((BuiltInCategory)(-2000500));
            hashSetBuiltInCategory.Add((BuiltInCategory)(-2000535));
            hashSetBuiltInCategory.Add((BuiltInCategory)(-2003101));
            hashSetBuiltInCategory.Add((BuiltInCategory)(-2000700));
            hashSetBuiltInCategory.Add((BuiltInCategory)(-2000578));
            hashSetBuiltInCategory.Add((BuiltInCategory)(-2000510));

            HashSet<BuiltInCategory> hashSetBuiltInCategory2 = hashSetBuiltInCategory;

            using (IEnumerator<Element> enumerator = elementCollector.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Element current = enumerator.Current;
                    if (current.Category != null && !hashSetBuiltInCategory2.Contains((BuiltInCategory)current.Category.Id.IntegerValue) && (!(current is ElevationMarker) && (current is Autodesk.Revit.DB.View)) && (current is TextNote || GetParameters(current)))     
                    {
                        string categoryName = current.Category.Name;
                        if (!hashSetInt.Contains(current.Category.Id.IntegerValue))
                        {
                            hashSetInt.Add(current.Category.Id.IntegerValue);
                            cboFamilyCategory.Items.Add(categoryName);
                            ElementId elemId = current.Category.Id;
                            List<string> list1 = new List<string>();
                            list1.Add(autoNumberData.LevelName);
                            list1.Add(autoNumberData.LevelNumber);
                            list1.Add(autoNumberData.PositionX);
                            list1.Add(autoNumberData.PositionY);
                            list1.Add(autoNumberData.PositionZ);

                            List<string> list2 = list1;

                            if ((PropertyInfo)null != current.GetType().GetProperty("Room", new System.Type[0]))
                            {
                                list2.Add(autoNumberData.RoomName);
                                list2.Add(autoNumberData.RoomNumber);
                            }
                            if (elemId.IntegerValue == (-2000023) || elemId.IntegerValue == (-2000014))
                            {
                                list2.Add(autoNumberData.FromRoomNumber);
                                list2.Add(autoNumberData.ToRoomNumber);
                            }

                            if (macros.ContainsKey(elemId.IntegerValue))
                                macros.Add(elemId.IntegerValue, list2);
                            if (categories.ContainsKey(categoryName))
                                categories.Add(categoryName, elemId);
                            if (dataOptions.CategoryId == elemId.IntegerValue)
                                str = categoryName;
                        }
                    }
                }
            }

            if (cboFamilyCategory.Items.Count > 0)           //set the initial selection of cboFamilyCategory to first item or selected item
            {
                if (str != null)
                    cboFamilyCategory.SelectedItem = str;
                else
                    cboFamilyCategory.SelectedIndex = 0;
            }
            cboFamilyCategory.EndUpdate();
            return categories.Count > 0;
        }

        private void autoNumberForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Cancel == DialogResult)
                return;
            PushValues(dataOptions);
        }

        private void UpdatePreview(autoNumberData opts = null)    //change name of method.. check to see if there is a need to methodise this at all
        {
            if (opts == null)
            {
                opts = new autoNumberData();
                PushValues(opts);
            }

            NumberGenerator numberGenerator = new NumberGenerator(opts);
            //TextBox[] textBoxArray = new TextBox[4]     // we dont even need this preview
            //{
            //    tbPreview1,
            //    tbPreview2,
            //    tbPreview3,
            //    tbPreview4,
            //};

            if (cboDirection.SelectedItem != null)        //originally this is used to setup the preview boxes above, but can be used as other purposes
            {
                switch ((NumberDirection)cboDirection.SelectedItem)
                {
                    case NumberDirection.Right:
                        //this.tbPreview3.Text = this.tbPreview4.Text = "";
                        //textBoxArray = new TextBox[2]
                        //{
                        //this.tbPreview1,
                        //this.tbPreview2
                        //};
                        //do something
                        break;

                    case NumberDirection.Left:
                        //this.tbPreview3.Text = this.tbPreview4.Text = "";
                        //textBoxArray = new TextBox[2]
                        //{
                        //  this.tbPreview2,
                        //  this.tbPreview1
                        //};
                        //do something
                        break;
                    case NumberDirection.Up:
                        //this.tbPreview2.Text = this.tbPreview4.Text = "";
                        //textBoxArray = new TextBox[2]
                        //{
                        //    this.tbPreview1,
                        //    this.tbPreview3
                        //};
                        //do somehting
                        break;
                    case NumberDirection.Down:
                        //this.tbPreview2.Text = this.tbPreview4.Text = "";
                        //textBoxArray = new TextBox[2]
                        //{
                        //    this.tbPreview3,
                        //    this.tbPreview1
                        //};
                        //do something
                        break;
                }

                //using the numberGenerator to show preview numbers in the textbox
                // we dont have textbox previews, so omit
                //textBoxArray[0].Text = numberGenerator.NextNumber(this.RowStartValue, this.ColumnStartValue, "");
                //textBoxArray[1].Text = numberGenerator.NextNumber(this.RowStartValue, this.ColumnStartValue + this.ColumnIncrement, "");

                //this.ExpandLevelMacros((IEnumerable<TextBox>)textBoxArray);     // what is this?
            }

            else
            {
                //tbPreview1.Text = numberGenerator.NextNumber(-1, -1, "");
                //tbPreview2.Text = numberGenerator.NextNumber(-1, -1, "");
                //tbPreview3.Text = numberGenerator.NextNumber(-1, -1, "");
                //tbPreview4.Text = numberGenerator.NextNumber(-1, -1, "");
                //ExpandLevelMacros((IEnumerable<TextBox>)textBoxArray);
            }
        }

//        private void ExpandLevelMacros (IEnumerable<TextBox> textBoxes)
//        {
//            IGrouping(document == null || document.ActiveView.GenLevel == null)
//                return;
//            foreach (TextBox textBox in textBoxes)
//            {
//                textBox.Text = textBox.Text.Replace("$(" + NumberGenerator.LabelToMacro(Resources.LevelName) + ")", ((Element) this.document.get_ActiveView().get_GenLevel()).get_Name());
//                textBox.Text = textBox.Text.Replace("$(" + NumberGenerator.LabelToMacro(Resources.LevelNumber) + ")", NumberGenerator.ExtractLevelNumber(((Element) this.document.get_ActiveView().get_GenLevel()).get_Name()));
//            }
//        }       //not in use yet


        private bool GetParameters(Element elem)        //method to retrieve all parameters within the selected elements
        {
            if (elem.Category == null || parameters.ContainsKey(elem.Category.Id.IntegerValue))
                return false;

            List<string> paramList = new List<string>();
            IEnumerator paramEnumerator = elem.Parameters.GetEnumerator();
            try
            {
                while (paramEnumerator.MoveNext())
                {
                    Parameter parameter = (Parameter)paramEnumerator.Current;
                    if (!((APIObject)parameter).get_IsReadOnly() && parameter.StorageType = 3)
                    {
                        string paramName = parameter.Definition.Name;
                        paramList.Add(paramName);
                        InternalDefinition internalDef = parameter.Definition as InternalDefinition;

                        if (internalDef != null && !builtInParameterNames.ContainsKey(internalDef.BuiltInParameter))
                            builtInParameterNames.Add(internalDef.BuiltInParameter, paramName);
                    }
                }
            }
            finally
            {
                IDisposable disposable = paramEnumerator as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }

            if (paramList.Count == 0)
                return false;
            paramList.Sort();
            parameters.Add(elem.Category.Id.IntegerValue.paramList);
            return true;
        }

        private void PushValues(autoNumberData data)
        {
            data.CategoryId = cboFamilyCategory.SelectedItem == null ? -1 : categories[cboFamilyCategory.SelectedItem.ToString()].IntegerValue;
            data.ParameterName = cboParameter.SelectedItem != null ? cboParameter.SelectedItem.ToString() : "";
            //data.GroupBy.Clear();       //GroupBy?? //might not need
            //foreach(DataGridViewRow dataGridViewRow in (IEnumerable) dgv.EltMacros.Rows)
            //{
            //    if((bool) DataGridViewRow.Cells [this.dgcGroup.Index].Value)
            //        data.GroupBy.Add(DataGridViewRow.Cells[this.dgcEltMacro.Index].Value.ToString());
            //}

            //if (cboDirection.SelectedItem != null)
            //data.Direction = (Wiip.Revit.Numbering.Direction)cboDirection.SelectedItem;       //no need for direction because we have direction defined in the form item
            data.Increment = Increment;
            data.StartValue = StartValue;
            //data.NumberingType = NumberType;  //no need for NumberType because we already defined it in the form item

        }

        private void cbElements_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateParametersAndMacros();
        }

        private void UpdateParametersAndMacros()
        {
            string index = cboFamilyCategory.SelectedItem.ToString();
            if (cboParameter.Tag == index)
                return;

            int integerValue = categories[index].IntegerValue;

            if (parameters.ContainsKey(integerValue))
            {
                cboParameter.Enabled = true;
                cboParameter.BeginUpdate();
                cboParameter.DataSource = (object)parameters[integerValue];

                if (string.IsNullOrEmpty(dataOptions.ParameterName) || -1 == cboParameter.Items.IndexOf(dataOptions.ParameterName))
                {
                    if (integerValue == (-2000160))
                        cboParameter.SelectedItem = builtInParameterNames[(BuiltInParameter)(-1006901)];
                    else if (builtInParameterNames.ContainsKey((BuiltInParameter)(-1001203)) && -1 != cboParameter.Items.IndexOf(builtInParameterNames[(BuiltInParameter)(-1001203)]))
                        cboParameter.SelectedItem = builtInParameterNames[(BuiltInParameter)(-10012033)];
                    else
                        cboParameter.SelectedIndex = 0;
                }
                else
                    cboParameter.SelectedItem = dataOptions.ParameterName;

                cboParameter.EndUpdate();
            }
            else
            {
                cboParameter.DataSource = null;
                cboParameter.Enabled = false;
            }

            cboParameter.Tag = index;

            //dgvEltMacros.Rows.Clear();        //no need cos we have no data grid view
            //foreach (string str in macros[integerValue])
            //{
            //    dgvEltmacros.Rows.Add((object)str, (object)(bool)(dataOptions.GroupBy.Contains(str) ? 1 : 0));
            //}
        }

        private void cboDirection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdatePreview(null);
        }





    }
}


