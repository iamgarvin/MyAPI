using System;
using System.Diagnostics;
using Autodesk.Revit.UI;

namespace JtExternalCommandLister
{
  class Util
  {
    const string _caption = "External Command Lister";

    /// <summary>
    /// Display error message
    /// </summary>
    /// <param name="msg">Message to display</param>
    static public void ErrorMsg( string msg )
    {
      Debug.WriteLine( _caption + ": "
        + msg );

      TaskDialog.Show( _caption, msg );
    }

    /// <summary>
    /// Display informational message
    /// </summary>
    /// <param name="msg">Message to display</param>
    static public void InfoMsg( string msg )
    {
      Debug.WriteLine( _caption + ": "
        + msg );

      TaskDialog.Show( _caption, msg );
    }
  }
}
