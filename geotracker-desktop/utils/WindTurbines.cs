using GMap.NET;
using Google.Type;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace geotracker_desktop.utils
{
    public class WindTurbines
    {

        public class WindTurbine
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public Dictionary<string, string> Tags { get; set; }
            public PointLatLng LatLng { get; set; }

            public WindTurbine()
            {
                Tags = new Dictionary<string, string>();
            }

            public string TagsToString()
            {
                // If there are no tags, return an empty string
                if (Tags == null || Tags.Count == 0)
                    return string.Empty;

                // Convert the dictionary into a readable string format
                return string.Join("\n", Tags.Select(tag => $"{tag.Key}: {tag.Value}"));
            }
        }

        public async Task<List<WindTurbine>> LoadWindTurbinesAsync()
        {
            string url = "https://overpass-api.de/api/interpreter?data=%5Bout%3Ajson%5D%5Btimeout%3A25%5D%3B%0Anwr%5B%22generator%3Amethod%22%3D%22wind_turbine%22%5D%2851.51219196266224%2C18.468017578125004%2C52.902305628635254%2C23.9007568359375%29%3B%0Aout%20geom%3B";

            var windTurbines = new List<WindTurbine>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(jsonResponse);

                    foreach (var element in json["elements"])
                    {
                        if (element["lat"] != null)
                        {
                            var windTurbine = new WindTurbine
                            {
                                Id = element["id"].ToString(),
                                Type = element["type"].ToString(),
                                LatLng = new PointLatLng(Double.Parse(element["lat"].ToString()), Double.Parse(element["lon"].ToString()))
                            };

                            var tags = element["tags"];
                            if (tags != null)
                            {
                                foreach (var tag in tags)
                                {
                                    windTurbine.Tags[tag.Path.Split('.').Last()] = tag.First.ToString();
                                }
                            }

                            windTurbines.Add(windTurbine);
                        }
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Request error: " + e.Message);
                }
            }

            return windTurbines;
        }
    }
}
