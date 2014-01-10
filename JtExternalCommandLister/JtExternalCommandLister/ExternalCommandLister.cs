#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Autodesk.Revit.UI;
#endregion // Namespaces

namespace JtExternalCommandLister
{
  class ExternalCommandLister
  {
    string _assembly_filename;
    string[] _external_commmand_class_names;
    ExternalCommandData _commandData;
    Assembly _asm;

    public ExternalCommandLister(
      string assembly_filename,
      ExternalCommandData commandData )
    {
      _assembly_filename = assembly_filename;
      _external_commmand_class_names = null;
      _commandData = commandData;

      if( !File.Exists( assembly_filename ) )
      {
        throw new ArgumentOutOfRangeException(
          "assembly_filename", "file not found" );
      }
      try
      {
        // No need to load the Revit API assemblies, 
        // because we are ourselves a Revit API add-in 
        // inside of Revit, so they are guaranteed to
        // be present.

        //Assembly revit = Assembly.LoadFrom( "C:/Program Files/Autodesk/Revit Architecture 2014/RevitAPI.dll" );
        //string root = "C:/Program Files/Autodesk Revit Architecture 2014/";
        //Assembly adWindows = Assembly.LoadFrom( root + "AdWindows.dll" );
        //Assembly uiFramework = Assembly.LoadFrom( root + "UIFramework.dll" );
        //Assembly revit = Assembly.LoadFrom( root + "RevitAPI.dll" );

        // Load the selected assembly into 
        // the current application domain:

        //Assembly asm = Assembly.LoadFrom(
        //  assembly_filename );

        // Load the selected assembly into the current 
        // application domain via byte array to avoid
        // locking the DLL:

        byte[] assemblyBytes = File.ReadAllBytes(
          _assembly_filename );

        _asm = Assembly.Load( assemblyBytes );

        if( null == _asm )
        {
          Util.ErrorMsg( string.Format(
            "Unable to load assembly '{0}'",
            assembly_filename ) );
        }
        else
        {
          IEnumerable<Type> types = _asm.GetTypes()
            .Where<Type>( t =>
              null != t.GetInterface(
                "IExternalCommand" ) );

          _external_commmand_class_names = types
            .Select<Type, string>( t => t.FullName )
            .ToArray();
        }
      }
      catch( Exception ex )
      {
        Util.ErrorMsg( string.Format(
          "Exception '{0}' processing assembly '{1}'",
          ex.Message, assembly_filename ) );
      }
    }

    public string AssemblyFilename
    {
      get
      {
        return Path.GetFileName( _assembly_filename );
      }
    }

    public string[] CommandClassnames
    {
      get
      {
        return _external_commmand_class_names;
      }
    }

    public Result Launch( string command_name )
    {
      Debug.Assert(
        _external_commmand_class_names.Contains(
          command_name ),
        "expected valid command name" );

      Type typ = _asm.GetType( command_name );

      object cmd = _asm.CreateInstance( typ.FullName );

      string message = null;
      Autodesk.Revit.DB.ElementSet elements = null;

      object[] args = new object[] {
      _commandData, message, elements };

      BindingFlags flags = (BindingFlags)
        ( (int) BindingFlags.Default
        | (int) BindingFlags.InvokeMethod );

      Result r = (Result) typ.InvokeMember( "Execute",
        flags, null, cmd, args );

      message = args[1] as string;

      int n = ( null == message ) ? 0 : message.Length;

      Util.InfoMsg( string.Format(
        "{0} returned {1}{2}{3}",
        command_name, r,
        ( 0 == n ? "." : ": " ),
        ( 0 == n ? "" : message ) ) );

      return r;
    }
  }
}
