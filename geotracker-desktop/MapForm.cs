using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using geotracker_desktop.cloud;
using geotracker_desktop.mapproviders;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

/*
 * TODO:
 * - draw route by clicking on map
 *   - display distance
 *   - number of points
 *   - ability to undo added point
 *   - export to gpx
 * - check if map style can be changed (at least inversion)
 * - export to image (size of image can be defined in dialog)
 * 
 */
namespace geotracker_desktop
{
    public partial class MapForm : Form
    {
        private readonly ProjectIdProvider projectIdprovider = new ProjectIdProvider();
        private readonly TracksProvider tracksProvider;
        private readonly GMapOverlay overlay;

        private readonly List<IMapProvider> providers = new List<IMapProvider>
        {
            new BingMapsProvider(),
            new GoogleMapsSatteliteProvider(),
            new GoogleMapsTerrainProvider(),
            new OpenStreetMapsProvider()
        };

        public MapForm()
        {
            InitializeComponent();

            gMapControl.Position = new PointLatLng(52.2, 21.0);
            gMapControl.MapProvider = OpenStreetMapProvider.Instance;
            gMapControl.MinZoom = 4;
            gMapControl.MaxZoom = 20;
            gMapControl.Zoom = 10;
            gMapControl.MouseWheelZoomEnabled = false;
            gMapControl.MarkersEnabled = true;
            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.ShowCenter = false;

            overlay = new GMapOverlay("routeOverlay");
            gMapControl.Overlays.Add(overlay);

            tracksProvider = new TracksProvider(projectIdprovider.GetApiKey());

            UpdateZoomLevellLabel();
            FillMapProviders();
        }

        private void gMapControl1_LoadAsync(object sender, EventArgs e) {
            FetchTracksFromCloud();
        }

        private void FillMapProviders()
        {
            toolStripMapTypeButton.DropDownItems.AddRange(providers.Select(provider =>
            {
                var item = new ToolStripMenuItem
                {
                    Text = provider.GetLabel(),
                    Tag = provider
                };
                item.Click += new EventHandler(providerToolStripMenuItem_Click);
                return item;
            }
            ).ToArray());
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

        private void gMapControl_OnMapZoomChanged()
        {
            UpdateZoomLevellLabel();
        }

        private void UpdateZoomLevellLabel()
        {
            toolStripZoomLabel.Text = $"Zoom level: {gMapControl.Zoom}";
        }

        private void buttonZoomMinus_Click(object sender, EventArgs e)
        {
            if (gMapControl.Zoom > gMapControl.MinZoom)
            {
                gMapControl.Zoom--;
            }
        }

        private void buttonZoomPlus_Click(object sender, EventArgs e)
        {
            if (gMapControl.Zoom < gMapControl.MaxZoom)
            {
                gMapControl.Zoom++;
            }
        }

        private void providerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            var mapProvider = (IMapProvider)item.Tag;
            gMapControl.MapProvider = mapProvider.GetProvider();
            toolStripMapTypeButton.Text = mapProvider.GetLabel();
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripInverseButton.Text = standardToolStripMenuItem.Text;
            gMapControl.NegativeMode = false;
        }

        private void invertedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripInverseButton.Text = invertedToolStripMenuItem.Text;
            gMapControl.NegativeMode = true;
        }
    }
}
