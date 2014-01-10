#region Namespaces
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Windows;
using TextBox = System.Windows.Forms.TextBox;
#endregion

namespace JtExternalCommandLister
{
  [Transaction( TransactionMode.Manual )]
  public class Command : IExternalCommand
  {
    /// <summary>
    /// Define the initial .NET assembly folder.
    /// </summary>
    const string _assembly_folder_name
      = "C:\\ProgramData\\Autodesk\\Revit\\Addins\\2014";

    /// <summary>
    /// Select a .NET assembly file in the given folder.
    /// </summary>
    /// <param name="folder">Initial folder.</param>
    /// <param name="filename">Selected filename on success.</param>
    /// <returns>Return true if a file was successfully selected.</returns>
    static bool FileSelect(
      string folder,
      out string filename )
    {
      OpenFileDialog dlg = new OpenFileDialog();
      dlg.Title = "Select .NET Assembly or Cancel to Exit";
      dlg.CheckFileExists = true;
      dlg.CheckPathExists = true;
      dlg.InitialDirectory = folder;
      dlg.Filter = ".NET Assembly DLL Files (*.dll)|*.dll";
      bool rc = ( DialogResult.OK == dlg.ShowDialog() );
      filename = dlg.FileName;
      return rc;
    }

    void OnDoubleClick( object sender, EventArgs e )
    {
      Debug.Print( "{0}: {1}", sender, e );

      TextBox tb = sender as TextBox;

      if( null != tb )
      {
        string text = tb.Text;
        int i = tb.GetFirstCharIndexOfCurrentLine();
        text = text.Substring( i );
        int n = text.IndexOf( '\n' );
        if( 0 <= n )
        {
          text = text.Substring( 0, n );
        }
        text.Trim();
        Debug.Print( text );
        if( 0 < text.Length )
        {
          ExternalCommandLister lister = tb.Tag
            as ExternalCommandLister;

          lister.Launch( text );
        }
      }
    }

    void DisplayExternalCommands(
      string filename,
      IWin32Window owner,
      ExternalCommandData commandData )
    {
      ExternalCommandLister lister
        = new ExternalCommandLister(
          filename, commandData );

      string[] a = lister.CommandClassnames;
      int n = a.Length;

      System.Windows.Forms.Form form
        = new System.Windows.Forms.Form();

      form.Size = new Size( 400, 150 );

      form.Text = string.Format(
        "{0} defines {1} external command{2} - double click to launch",
        lister.AssemblyFilename, n,
        ( 1 == n ? "" : "s" ) );

      form.FormBorderStyle
        = FormBorderStyle.SizableToolWindow;

      System.Windows.Forms.TextBox tb
        = new System.Windows.Forms.TextBox();

      tb.Dock = System.Windows.Forms.DockStyle.Fill;
      tb.Location = new System.Drawing.Point( 0, 0 );
      tb.Multiline = true;
      tb.TabIndex = 0;
      tb.WordWrap = false;
      tb.ReadOnly = true;

      tb.Text = string.Join( "\r\n",
        lister.CommandClassnames );

      tb.Tag = lister;

      tb.DoubleClick += new EventHandler(
        OnDoubleClick );

      form.Controls.Add( tb );

      //System.Windows.Forms.ToolStripMenuItem mi 
      //  = new System.Windows.Forms.ToolStripMenuItem();

      //mi.Text = "Launch external command...";
      //mi.Click += new System.EventHandler( 
      //  OnLaunchCommand );

      //System.Windows.Forms.ContextMenuStrip menu 
      //  = new System.Windows.Forms.ContextMenuStrip(); // this.components

      //menu.SuspendLayout();
      //menu.Items.AddRange( 
      //  new System.Windows.Forms.ToolStripItem[] { 
      //    mi } );
      //menu.ResumeLayout( false );

      form.ShowDialog( owner );
    }

    public Result Execute(
      ExternalCommandData commandData,
      ref string message,
      ElementSet elements )
    {
      IWin32Window revit_window
        = new JtWindowHandle(
          ComponentManager.ApplicationWindow );

      string filename;

      while( FileSelect(
        _assembly_folder_name,
        out filename ) )
      {
        DisplayExternalCommands( filename,
          revit_window, commandData );
      }
      return Result.Succeeded;
    }
  }
}
