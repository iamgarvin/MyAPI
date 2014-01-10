using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media;
using System.Windows.Forms;

namespace PrintScreen
{

    /// <summary>
    /// Revit 2013 Command Class
    /// </summary>
    /// <remarks></remarks>
    [Transaction(TransactionMode.Manual)]
    public class printScreenCmd : IExternalCommand
    {
        public static Timer timer = new Timer();
        public static bool picTaken = false;
        public static Bitmap picture;
        public static Graphics graphic;
        public static UIApplication application;

        static printScreenCmd()
        {
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            application = commandData.Application;
            picTaken = false;
            timer.Enabled = true;
            timer.Tick += new EventHandler(printScreenCmd.OnTimerEvent);
            timer.Interval = 250;
            timer.Start();
            return (Result) 0;

        }

        public static void OnTimerEvent(object source, EventArgs e)
        {
            timer.Stop();
            if (picTaken)
                return;
            int top = application.DrawingAreaExtents.Top;
            int bottom = application.DrawingAreaExtents.Bottom;
            int left = application.DrawingAreaExtents.Left;
            int right = application.DrawingAreaExtents.Right;

            picture = new Bitmap(right - left, bottom - top, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            graphic = Graphics.FromImage((Image)picture);
            Size pictureSize = new Size(right - left, bottom - top);
            graphic.CopyFromScreen(left, top, 0, 0, pictureSize, CopyPixelOperation.SourceCopy);
            SaveFileDialog savefileDialog = new SaveFileDialog();
            savefileDialog.Title = "Save image at";
            savefileDialog.Filter = "PNG (*.png)|*.png";
            savefileDialog.AddExtension = true;
            if (savefileDialog.ShowDialog() == DialogResult.OK)
                picture.Save(savefileDialog.FileName, ImageFormat.Png);
            picTaken = true;
        }

    }
}
