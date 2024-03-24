using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geotracker_desktop.mapproviders
{
    internal class BingMapsProvider : IMapProvider
    {
        public string GetLabel() { return "Bing Maps"; }

        GMapProvider IMapProvider.GetProvider() { return BingMapProvider.Instance; }
    }
}
