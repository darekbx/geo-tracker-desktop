using GMap.NET;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace geotracker_desktop.utils
{
    public class GpxCreator
    {
        public void CreateGpx(List<PointLatLng> points, string fileName, string trackName)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(xmlDeclaration);

            XmlElement gpxElement = xmlDoc.CreateElement("gpx");
            xmlDoc.AppendChild(gpxElement);

            XmlElement metadataElement = xmlDoc.CreateElement("metadata");
            gpxElement.AppendChild(metadataElement);

            XmlElement nameElement = xmlDoc.CreateElement("name");
            nameElement.InnerText = trackName;
            metadataElement.AppendChild(nameElement);

            XmlElement trkElement = xmlDoc.CreateElement("trk");
            gpxElement.AppendChild(trkElement);

            XmlElement trksegElement = xmlDoc.CreateElement("trkseg");
            trkElement.AppendChild(trksegElement);

            foreach (PointLatLng point in points)
            {
                XmlElement trkptElement = xmlDoc.CreateElement("trkpt");
                trkptElement.SetAttribute("lat", point.Lat.ToString(CultureInfo.InvariantCulture));
                trkptElement.SetAttribute("lon", point.Lng.ToString(CultureInfo.InvariantCulture));
                trksegElement.AppendChild(trkptElement);
            }

            xmlDoc.Save(fileName);
        }
    }
}
