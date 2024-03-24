using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geotracker_desktop.mapproviders
{
    internal class GoogleMapsSatteliteProvider : IMapProvider
    {
        public string GetLabel() { return "Google Maps (Satellite)"; }

        GMapProvider IMapProvider.GetProvider() { return GoogleSatelliteMapProvider.Instance; }
    }
}
