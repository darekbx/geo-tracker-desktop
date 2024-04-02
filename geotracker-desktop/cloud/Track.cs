using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geotracker_desktop.cloud
{
    internal class Track
    {
        public String id;
        public String label;
        public double distance;
        public long startTimestamp;
        public long endTimestamp;
        public List<TrackPoint> points;

        public Track(string id, string label, double distance, long startTimestamp, long endTimestamp, List<TrackPoint> points)
        {
            this.id = id;
            this.label = label;
            this.distance = distance;
            this.startTimestamp = startTimestamp;
            this.endTimestamp = endTimestamp;
            this.points = points;
        }
    }
}
