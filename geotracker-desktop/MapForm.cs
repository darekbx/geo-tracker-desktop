using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using geotracker_desktop.cloud;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace geotracker_desktop
{
    public partial class MapForm : Form
    {
        private readonly ProjectIdProvider projectIdprovider = new ProjectIdProvider();
        private readonly TracksProvider tracksProvider;
        private readonly GMapOverlay overlay;

        public MapForm()
        {
            InitializeComponent();

            gMapControl.Position = new PointLatLng(52.2, 21.0);
            gMapControl.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            gMapControl.MinZoom = 0;
            gMapControl.MaxZoom = 24;
            gMapControl.Zoom = 10;
            gMapControl.MarkersEnabled = true;
            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.ShowCenter = false;

            overlay = new GMapOverlay("routeOverlay");
            gMapControl.Overlays.Add(overlay);

            tracksProvider = new TracksProvider(projectIdprovider.GetApiKey());
        }

        private void gMapControl1_LoadAsync(object sender, EventArgs e){
            FetchTracksFromCloud();
        }

        private async void FetchTracksFromCloud()
        {
            var tracksPoints = await tracksProvider.FetchTracks();
            var count = tracksPoints.Count;

            loadingProgressBar.Maximum = count;

            for (int i = 0; i < tracksPoints.Count; i++)
            {
                var route = new GMapRoute(tracksPoints[i].Select(cloudPoint =>
                new PointLatLng
                {
                    Lat = cloudPoint.Latitude,
                    Lng = cloudPoint.Longitude
                }), $"track_{i}")
                {
                    Stroke = new Pen(Color.Red, 1.75F)
                };
                overlay.Routes.Add(route);

                loadingProgressBar.Value = i;
            };

            loadingProgressBar.Visible = false;
        }
    }
}
