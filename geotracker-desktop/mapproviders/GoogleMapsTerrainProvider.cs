using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geotracker_desktop.mapproviders
{
    internal class GoogleMapsTerrainProvider : IMapProvider
    {
        public string GetLabel() { return "Google Maps (Terrain)"; }

        GMapProvider IMapProvider.GetProvider() { return GoogleTerrainMapProvider.Instance; }
    }
}
