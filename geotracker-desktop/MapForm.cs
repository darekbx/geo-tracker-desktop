using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using geotracker_desktop.cloud;
using geotracker_desktop.mapproviders;
using geotracker_desktop.routes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

/*
 * TODO:
 * - draw route by clicking on map
 *   - export to gpx
 * - export to image (size of image can be defined in dialog)
 * 
 */
namespace geotracker_desktop
{
    public partial class MapForm : Form
    {
        private readonly ProjectIdProvider projectIdprovider = new ProjectIdProvider();
        private readonly RouteCreator routeCreator = new RouteCreator();
        private readonly TracksProvider tracksProvider;

        private readonly GMapOverlay overlay;
        private readonly GMapOverlay routeOverlay;

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

            overlay = new GMapOverlay("routesOverlay");
            routeOverlay = new GMapOverlay("routeOverlay");

            gMapControl.Overlays.Add(overlay);
            gMapControl.Overlays.Add(routeOverlay);

            tracksProvider = new TracksProvider(projectIdprovider.GetApiKey());

            routeCreator.RouteInvalidated += RouteCreator_RouteInvalidated;

            UpdateZoomLevellLabel();
            FillMapProviders();
            PlaceLoadingPanel();
        }

        private void RouteCreator_RouteInvalidated(object sender, List<PointLatLng> points, double distance)
        {
            if (points.Count > 0)
            {
                routePanel.Visible = true;
            }
            else
            {
                routePanel.Visible = false;
                routeOverlay.Markers.Clear();
                routeOverlay.Routes.Clear();
                return;
            }

            labelDistanceValue.Text = string.Format("{0:F2} km", distance);
            labelPointsValue.Text = points.Count.ToString();

            DrawRoute(points);
        }

        private void DrawRoute(List<PointLatLng> points)
        {
            var route = new GMapRoute(points, "user_route")
            {
                Stroke = new Pen(Color.SteelBlue, 2.5F)
            };

            routeOverlay.Markers.Clear();
            routeOverlay.Routes.Clear();

            foreach (var point in points)
            {
                GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.red_small);
                routeOverlay.Markers.Add(marker);
            }

            routeOverlay.Routes.Add(route);
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
            if (tracksPoints == null)
            {
                return;
            }

            var count = tracksPoints.Count;
            loadingProgressBar.Maximum = count;

            for (int i = 0; i < count; i++)
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
            panelLoading.Visible = false;
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

        private void gMapControl_OnMapClick(PointLatLng pointClick, MouseEventArgs e)
        {
            routeCreator.AddPoint(pointClick);
        }

        private void PlaceLoadingPanel()
        {
            panelLoading.Location = new Point(
                (this.ClientSize.Width - panelLoading.Size.Width) / 2,
                (this.ClientSize.Height - panelLoading.Size.Height) / 2
            );
        }

        private void buttonUndoPoint_Click(object sender, EventArgs e)
        {
            routeCreator.RemoveLastPoint();
        }

        private void buttonRouteClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to remote all points?", 
                "Confirmation", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                routeCreator.Reset();
            }
        }
    }
}
