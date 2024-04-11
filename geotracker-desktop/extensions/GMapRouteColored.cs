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
    public class GMapRouteColored : GMap.NET.WindowsForms.GMapRoute
    {
        public List<TrackPoint> trackPoints;
        public float strokeWidth;
        private double maxSpeed;

        public GMapRouteColored(List<TrackPoint> points, float strokeWidth, string name)
            : base(points.Select(cloudPoint =>
                new PointLatLng
                {
                    Lat = cloudPoint.Latitude,
                    Lng = cloudPoint.Longitude
                }), name)
        {
            this.trackPoints = points;
            this.strokeWidth = strokeWidth;
            this.maxSpeed = points.Max(p => p.Speed);
        }

        public override void OnRender(Graphics g)
        {
            var pen = new Pen(Color.Black, strokeWidth);
            for (int i = 0; i < LocalPoints.Count - 1; i++)
            {
                pen.Color = SpeedToColor.toColor(trackPoints[i].Speed, this.maxSpeed);
                g.DrawLine(pen, LocalPoints[i].X, LocalPoints[i].Y, LocalPoints[i + 1].X, LocalPoints[i + 1].Y);
            }
        }
    }
}
