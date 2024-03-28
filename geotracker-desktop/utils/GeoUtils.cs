using GMap.NET.MapProviders;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geotracker_desktop.utils
{
    public static class GeoUtils
    {
        public static double CalculateDistance(PointLatLng point1, PointLatLng point2)
        {
            return GMapProviders.EmptyProvider.Projection.GetDistance(point1, point2);
        }
    }
}
