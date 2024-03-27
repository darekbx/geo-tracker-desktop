using System;
using System.Collections.Generic;
using GMap.NET;

namespace geotracker_desktop.utils
{
    internal class PointLatLngUtils
    {
        public static List<PointLatLng> GetCirclePoints(PointLatLng center, double radiusInDegrees, int numberOfSegments = 12)
        {
            List<PointLatLng> points = new List<PointLatLng>();

            double segmentAngle = 360.0 / numberOfSegments;

            for (int i = 0; i < numberOfSegments; i++)
            {
                double angle = segmentAngle * i;
                double latitude = center.Lat + (radiusInDegrees * Math.Sin(DegreesToRadians(angle)));
                double longitude = center.Lng + (radiusInDegrees * Math.Cos(DegreesToRadians(angle)));

                points.Add(new PointLatLng(latitude, longitude));
            }

            return points;
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}
