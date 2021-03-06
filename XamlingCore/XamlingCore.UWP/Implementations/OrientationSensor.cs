﻿using System;
using Windows.Graphics.Display;
using XamlingCore.Portable.Contract.Device;
using XamlingCore.Portable.Model.Orientation;

namespace XamlingCore.UWP.Implementations
{
    public class OrientationSensor : IOrientationSensor
    {
        public event EventHandler OrientationChanged;

        public OrientationSensor()
        {
            DisplayProperties.OrientationChanged += DisplayProperties_OrientationChanged;
            
           
        }

        void DisplayProperties_OrientationChanged(object sender)
        {
            _fire();
        }

        void _fire()
        {
            if (OrientationChanged != null)
            {
                OrientationChanged(this, EventArgs.Empty);
            }
        }


        XPageOrientation _getOrientation()
        {
            var orientation = DisplayProperties.CurrentOrientation;

            switch (orientation)
            {
                case DisplayOrientations.Portrait:
                case DisplayOrientations.PortraitFlipped:
                    return XPageOrientation.Portrait;
                case DisplayOrientations.Landscape:
                case DisplayOrientations.LandscapeFlipped:
                    return XPageOrientation.Landscape;
                default:
                return XPageOrientation.Portrait;
            }
        }

        public XPageOrientation Orientation
        {
            get { return _getOrientation(); }
        }

        public bool UpsideDown
        {
            get
            {
                return DisplayProperties.CurrentOrientation == DisplayOrientations.PortraitFlipped ||
                       DisplayProperties.CurrentOrientation == DisplayOrientations.LandscapeFlipped;
            }
        }

        public void OnRotated()
        {
            //_fire();
        }
    }
}
