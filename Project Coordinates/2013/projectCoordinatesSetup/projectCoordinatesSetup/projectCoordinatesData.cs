using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace projectCoordinatesSetup
{
    
    public class projectCoordinatesData //this class gets, sets and manages the project coordinates info
    {
        ExternalCommandData m_command; // the ExternalCommandData reference
        Autodesk.Revit.UI.UIApplication m_application; //the revit application reference

        const double Modulus = 0.0174532925199433; //a modulus for degree convert to pi 
        const int Precision = 3; //default precision 

        string m_currentLocationName;   //the location of the active project;
        List<string> m_locationnames = new List<string>(); //a list to store all the location name
        double m_angle;        //Angle from True North
        double m_eastWest;     //East to West offset
        double m_northSouth;   //North to South offset
        double m_elevation;    //Elevation above ground level
        string m_Rotation;
        double m_RotationAngle;

        public double returnAngleOffset
        {
            get
            {
                return m_angle;
            }
        }

        public double returnEastingOffset
        {
            get
            {
                return m_eastWest / 0.0032808398950131;
            }
        }

        public double returnNorthingOffset
        {
            get
            {
                return m_northSouth / 0.0032808398950131;
            }
        }

        public double returnElevation
        {
            get
            {
                return m_elevation / 0.0032808398950131;
            }
        }

        public string returnRotation
        {
            get
            {
                return m_Rotation;
            }
        }

        public double returnRotationAngle
        {
            get
            {
                return m_RotationAngle;
            }
        }

        public string getSetLocationName
        {
            get
            {
                return m_currentLocationName;
            }
            set
            {
                m_currentLocationName = value;
            }
        }

        public List<string> getProjectLocationNames
        {
            get
            {
                return m_locationnames;
            }
        }

        public projectCoordinatesData(ExternalCommandData commandData)
        {
            m_command = commandData;
            m_application = m_command.Application;
        }

        public void GetLocation()
        {
            m_locationnames.Clear();
            ProjectLocation currentLocation = m_application.ActiveUIDocument.Document.ActiveProjectLocation;
            m_currentLocationName = currentLocation.Name; //get the current location name

            ProjectLocationSet locations = m_application.ActiveUIDocument.Document.ProjectLocations; //Retrieve all the project locations associated with this project
            
            ProjectLocationSetIterator iter = locations.ForwardIterator();
            iter.Reset();
            while (iter.MoveNext())
            {
                ProjectLocation locationTransform = iter.Current as ProjectLocation;
                string transformName = locationTransform.Name;
                m_locationnames.Add(transformName); //add the location's name to the list
            }
        }

        public void GetOffset(string locationName)
        {
            ProjectLocationSet locationSet = m_application.ActiveUIDocument.Document.ProjectLocations;
            foreach (ProjectLocation projectLocation in locationSet)
            {
                if (projectLocation.Name == locationName || projectLocation.Name + " (current)" == locationName)
                {
                    Autodesk.Revit.DB.XYZ origin = new Autodesk.Revit.DB.XYZ(0, 0, 0);
                    //get the project position
                    ProjectPosition pp = projectLocation.get_ProjectPosition(origin);
                    m_angle = pp.Angle /= Modulus; //convert to unit degree
                    m_eastWest = pp.EastWest;     //East to West offset
                    m_northSouth = pp.NorthSouth; //north to south offset
                    m_elevation = pp.Elevation;   //Elevation above ground level
                    break;
                }
            }
            this.ChangePrecision();
        }

        public void EditPosition(string locationName, double newAngle, double newEast, double newNorth, double newElevation, string newRotation)
        {
            ProjectLocationSet locationSet = m_application.ActiveUIDocument.Document.ProjectLocations;
            foreach (ProjectLocation location in locationSet)
            {
                if (location.Name == locationName ||
                            location.Name + " (current)" == locationName)
                {
                    Autodesk.Revit.DB.XYZ origin = new Autodesk.Revit.DB.XYZ(0, 0, 0); //get the project position
                    ProjectPosition projectPosition = location.get_ProjectPosition(origin);
                    m_Rotation = newRotation;
                    m_RotationAngle = newAngle;
                    //set newAngle to equal something
                    
                    //change the offset value of the project position
                    if (newRotation == "Clockwise")
                    {
                        projectPosition.Angle = newAngle * Modulus; //convert the unit 
                    }
                    else if (newRotation == "Anti-Clockwise")
                    {
                        projectPosition.Angle = (360.0 - newAngle) * Modulus; //convert the unit 
                    }
                    projectPosition.EastWest = newEast * 0.0032808398950131;
                    projectPosition.NorthSouth = newNorth * 0.0032808398950131;
                    projectPosition.Elevation = newElevation * 0.0032808398950131;

                    location.set_ProjectPosition(origin, projectPosition); //set the value of the project position
                }
            }
        }

        private void ChangePrecision()
        {
            m_angle = unitConverter.dealValuePrecision(m_angle, Precision);
            m_eastWest = unitConverter.dealValuePrecision(m_eastWest, Precision);
            m_northSouth = unitConverter.dealValuePrecision(m_northSouth, Precision);
            m_elevation = unitConverter.dealValuePrecision(m_elevation, Precision);
        }
    }
}
