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

        public async Task<List<Track>> FetchTracks()
        {
            try
            {
                var tracks = new List<Track>();

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
                        List<TrackPoint> trackPoints = JsonConvert.DeserializeObject<List<TrackPoint>>(points);
                        var track = new Track(
                            document.Id,
                            data["label"] as String,
                            Convert.ToDouble(data["distance"]),
                            Convert.ToInt64(data["start_timestamp"]),
                            Convert.ToInt64(data["end_timestamp"]),
                            trackPoints
                        );
                        tracks.Add(track);
                    }
                }

                return tracks.OrderByDescending(x => x.startTimestamp).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error authenticating user: {e.Message}");
                return default;
            }
        }
    }
}
