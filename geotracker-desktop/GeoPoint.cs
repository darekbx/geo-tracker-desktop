using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geotracker_desktop
{
    public class PointDto
    {
        public long Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float Speed { get; set; }
        public double Altitude { get; set; }

        public PointDto() { }

        public PointDto(long timestamp, double latitude, double longitude, float speed, double altitude)
        {
            Timestamp = timestamp;
            Latitude = latitude;
            Longitude = longitude;
            Speed = speed;
            Altitude = altitude;
        }
    }
}
