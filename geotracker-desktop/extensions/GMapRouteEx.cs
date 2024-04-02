using geotracker_desktop.utils;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geotracker_desktop.extensions
{
    public class GMapRouteEx : GMap.NET.WindowsForms.GMapRoute
    {
        public GMapRouteEx(List<TrackPoint> points, string name)
            : base(points.Select(cloudPoint =>
                new PointLatLng
                {
                    Lat = cloudPoint.Latitude,
                    Lng = cloudPoint.Longitude
                }), name)
        {
        }
    }
}
