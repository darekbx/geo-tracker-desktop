using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geotracker_desktop.routes
{
    public delegate void RouteInvalidatedEventHandler(object sender, List<PointLatLng> points);

    internal class RouteCreator
    {
        private List<PointLatLng> points = new List<PointLatLng>();

        public event RouteInvalidatedEventHandler RouteInvalidated;

        public void AddPoint(PointLatLng point)
        {
            points.Add(point);
            RouteInvalidated?.Invoke(this, points);
        }

        public void RemoveLastPoint()
        {
            points.RemoveAt(points.Count - 1);
            RouteInvalidated?.Invoke(this, points);
        }

        public List<PointLatLng> GetPoints() {  return points; }
    }
}
