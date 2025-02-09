using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geotracker_desktop
{
    public class PlaceToVisit
    {
        public string label;
        public double latitude { get; set; }
        public double longitude { get; set; }

        public PlaceToVisit() { }

        public PlaceToVisit(string label, double latitude, double longitude)
        {
            this.label = label;
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
