using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Rpc.Context.AttributeContext.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace geotracker_desktop.cloud
{
    internal class RealLocation
    {
        public double altitude;
        public double latitude;
        public double longitude;
        public double speed;
        public long timestamp;

        public RealLocation(double altitude, double latitude, double longitude, double speed, long timestamp)
        {
            this.altitude = altitude;
            this.latitude = latitude;
            this.longitude = longitude;
            this.speed = speed;
            this.timestamp = timestamp;
        }   
    }
}
