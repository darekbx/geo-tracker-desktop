using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geotracker_desktop.cloud
{
    internal class TracksProvider
    {
        private string firebaseAppId;

        public TracksProvider(string firebaseAppId)
        {
            this.firebaseAppId = firebaseAppId; 
        }

        public async Task<List<List<GeoPoint>>> FetchTracks()
        {
            try
            {
                var tracksPoints = new List<List<GeoPoint>>();

                FirestoreDb db = FirestoreDb.Create(firebaseAppId);

                CollectionReference collection = db.Collection("track");
                Query query = collection.WhereNotEqualTo("points", "[]");
                QuerySnapshot snapshot = await query.GetSnapshotAsync();

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Exists)
                    {
                        Dictionary<string, object> data = document.ToDictionary();
                        var points = data["points"] as String;
                        List<GeoPoint> trackPoints = JsonConvert.DeserializeObject<List<GeoPoint>>(points);
                        tracksPoints.Add(trackPoints);
                    }
                }

                return tracksPoints;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error authenticating user: {e.Message}");
                return default;
            }
        }
    }
}
