using geotracker_desktop.utils;
using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geotracker_desktop.routes
{
    public delegate void RouteInvalidatedEventHandler(object sender, List<PointLatLng> points, double distance);

    internal class RouteCreator
    {
        private List<PointLatLng> points = new List<PointLatLng>();

        public event RouteInvalidatedEventHandler RouteInvalidated;

        public void AddPoint(PointLatLng point)
        {
            points.Add(point);
            var distance = CalculateTotalDistance(points);
            RouteInvalidated?.Invoke(this, points, distance);
        }

        public void RemoveLastPoint()
        {
            points.RemoveAt(points.Count - 1);
            var distance = CalculateTotalDistance(points);
            RouteInvalidated?.Invoke(this, points, distance);
        }

        public void Reset()
        {
            points.Clear();
            RouteInvalidated?.Invoke(this, points, 0);
        }

        public List<PointLatLng> GetPoints() { return points; }

        private double CalculateTotalDistance(List<PointLatLng> points)
        {
            double totalDistance = 0;

            for (int i = 0; i < points.Count - 1; i++)
            {
                double distance = GeoUtils.CalculateDistance(points[i], points[i + 1]);
                totalDistance += distance;
            }

            return totalDistance;
        }
    }
}
