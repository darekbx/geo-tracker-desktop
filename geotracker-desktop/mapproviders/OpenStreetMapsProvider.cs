using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geotracker_desktop.mapproviders
{
    internal class OpenStreetMapsProvider : IMapProvider
    {
        public string GetLabel() { return "Open Street Maps"; }

        GMapProvider IMapProvider.GetProvider() { return OpenStreetMapProvider.Instance; }
    }
}
