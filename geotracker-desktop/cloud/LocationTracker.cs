using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geotracker_desktop.cloud
{
    internal class LocationTracker
    {
        private string firebaseAppId;

        public LocationTracker(string firebaseAppId)
        {
            this.firebaseAppId = firebaseAppId;
        }

        public void SubscribeForUpdates(Action<RealLocation> locationUpdates)
        {
            try
            {
                FirestoreDb db = FirestoreDb.Create(firebaseAppId);
                CollectionReference collection = db.Collection("last_location");
                DocumentReference document = collection.Document("record");
                FirestoreChangeListener listener = document.Listen(snapshot =>
                {
                    if (snapshot.Exists)
                    {
                        Dictionary<string, object> data = snapshot.ToDictionary();
                        locationUpdates(new RealLocation(
                            Convert.ToDouble(data["altitude"]),
                            Convert.ToDouble(data["latitude"]),
                            Convert.ToDouble(data["longitude"]),
                            Convert.ToDouble(data["speed"]),
                            Convert.ToInt64(data["timestamp"])
                        ));
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error authenticating user: {e.Message}");
            }
        }
    }
}
