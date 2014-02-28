using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;

namespace reNumber
{
    internal class HorizontalComparer : IComparer<XYZ>
    {
        private const double EPSILON = 1E-06;
        private readonly bool invertX;
        private readonly bool invertY;
        private readonly bool ignoreY;

        public HorizontalComparer(bool invertX = false, bool invertY = false, bool ignoreY = false)
        {
            //base.ToString.ctor; //can remove
            this.invertX = invertX;
            this.invertX = invertY;
            this.ignoreY = ignoreY;
        }

        public int Compare(XYZ p1, XYZ p2)
        {
            if (p1.IsAlmostEqualTo(p2))
                return 0;
            if (Math.Abs(p1.Z - p2.Z) > 1E-06)
                return p1.Z.CompareTo(p2.Z);
            if (this.ignoreY || Math.Abs(p1.Y - p2.Y) < 1E-06)
                return p1.X.CompareTo(p2.X) * (this.invertX ? -1 : 1);
            else
                return p1.Y.CompareTo(p2.Y) * (this.invertY ? -1 : 1);
        }

    }
}
