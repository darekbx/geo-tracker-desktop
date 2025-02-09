using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace geotracker_desktop.cloud
{
    internal class PlacesToVisit
    {
        private string firebaseAppId;

        public PlacesToVisit(string firebaseAppId)
        {
            this.firebaseAppId = firebaseAppId; 
        }

        public async Task<List<PlaceToVisit>> FetchPlacesToVisit()
        {
            try
            {
                var placesToVisit = new List<PlaceToVisit>();

                FirestoreDb db = FirestoreDb.Create(firebaseAppId);

                CollectionReference collection = db.Collection("places_to_visit");
                QuerySnapshot snapshot = await collection.GetSnapshotAsync();

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Exists)
                    {
                        Dictionary<string, object> data = document.ToDictionary();
                        var placeToVisit = new PlaceToVisit(
                            data["label"] as String,
                            Convert.ToDouble(data["latitude"]),
                            Convert.ToDouble(data["longitude"])
                        );
                        placesToVisit.Add(placeToVisit);
                    }
                }

                return placesToVisit;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error authenticating user: {e.Message}");
                return default;
            }
        }
    }
}
