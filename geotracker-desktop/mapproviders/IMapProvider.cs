using GMap.NET.MapProviders;

namespace geotracker_desktop.mapproviders
{
    internal interface IMapProvider
    {
        GMapProvider GetProvider();

        string GetLabel();
    }
}
