using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using geotracker_desktop.cloud;
using geotracker_desktop.extensions;
using geotracker_desktop.mapproviders;
using geotracker_desktop.routes;
using geotracker_desktop.utils;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

/*
 * TODO:
 * - export to image (size of image can be defined in dialog)
 */
namespace geotracker_desktop
{

    public partial class MapForm : Form
    {
        private string haslo = "haslomaslo";

        private readonly ProjectIdProvider projectIdprovider = new ProjectIdProvider();
        private readonly RouteCreator routeCreator = new RouteCreator();
        private readonly WindTurbines windTurbines = new WindTurbines();
        private readonly TracksProvider tracksProvider;
        private readonly LocationTracker locationTracker;

        private readonly GMapOverlay overlay;
        private readonly GMapOverlay routeOverlay;
        private readonly GMapOverlay selectedRouteOverlay;
        private readonly GMapOverlay realLocationOverlay;
        private readonly GMapOverlay turbinesOverlay;

        private List<Track> tracksCache;

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
            this.Icon = Icon.ExtractAssociatedIcon("app_icon.ico");

            gMapControl.Position = new PointLatLng(52.2, 21.0);
            gMapControl.MapProvider = OpenStreetMapProvider.Instance;
            gMapControl.MinZoom = 4;
            gMapControl.MaxZoom = 20;
            gMapControl.Zoom = 11;
            gMapControl.MouseWheelZoomEnabled = false;
            gMapControl.MarkersEnabled = true;
            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.ShowCenter = false;
            gMapControl.Tag = haslo;

            overlay = new GMapOverlay("routesOverlay");
            routeOverlay = new GMapOverlay("routeOverlay");
            selectedRouteOverlay = new GMapOverlay("selectedRouteOverlay");
            realLocationOverlay = new GMapOverlay("realLocationOverlay");
            turbinesOverlay = new GMapOverlay("turbinesOverlay");

            gMapControl.Overlays.Add(overlay);
            gMapControl.Overlays.Add(routeOverlay);
            gMapControl.Overlays.Add(selectedRouteOverlay);
            gMapControl.Overlays.Add(realLocationOverlay);
            gMapControl.Overlays.Add(turbinesOverlay);

            tracksProvider = new TracksProvider(projectIdprovider.GetApiKey());
            locationTracker = new LocationTracker(projectIdprovider.GetApiKey());

            routeCreator.RouteInvalidated += RouteCreator_RouteInvalidated;

            StartLocationTracker();

            UpdateZoomLevellLabel();
            FillMapProviders();
            PlaceLoadingPanel();
        }

        private void StartLocationTracker()
        {
            var points = new List<PointLatLng>();
            locationTracker.SubscribeForUpdates(realLocation =>
            {
                realLocationOverlay.Markers.Clear();
                realLocationOverlay.Routes.Clear();

                var point = new PointLatLng(realLocation.latitude, realLocation.longitude);
                GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.purple);
                realLocationOverlay.Markers.Add(marker);

                TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
                DateTimeOffset dateTime = TimeZoneInfo.ConvertTime( DateTimeOffset.FromUnixTimeMilliseconds(realLocation.timestamp), timeZoneInfo);

                string formattedDateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");

                liveSpeedText.Text = string.Format("{0:N2}km/h", realLocation.speed * 3.6F);
                labelLiveAltitudeText.Text = string.Format("{0:N2}m", realLocation.altitude);
                labelLiveTimeText.Text = formattedDateTime;

                points.Add(point);

                var route = new GMap.NET.WindowsForms.GMapRoute(points, "user_route")
                {
                    Stroke = new Pen(Color.Purple, 3F)
                };

                routeOverlay.Routes.Add(route);
            });
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
            var route = new GMap.NET.WindowsForms.GMapRoute(points, "user_route")
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
            var tracks = await tracksProvider.FetchTracks();
            if (tracks == null)
            {
                return;
            }

            this.tracksCache = tracks;

            var count = tracks.Count;

            for (int i = 0; i < count; i++)
            {
                // Use GmapRouteColored to highlight only one
                // Don't use for all tracks! It will affect performance!
                var route = new GMapRouteEx(tracks[i].points, $"track_{i}")
                {
                    Stroke = new Pen(Color.Red, 1.75F)
                };
                overlay.Routes.Add(route);
            };

            FillList(tracks);

            panelLoading.Visible = false;
        }

        private void FillList(List<Track> tracks)
        {
            var count = tracks.Count;
            tracksListView.View = View.Details;
            tracksListView.Columns.Add("Date", 100);
            tracksListView.Columns.Add("Distance", 70);
            tracksListView.Columns.Add("Time", 70);

            for (int i = 0; i < count; i++)
            {
                var track = tracks[i];
                DateTimeOffset startOffset = DateTimeOffset.FromUnixTimeMilliseconds(track.startTimestamp);

                string formattedDateTime = startOffset.ToString("yyyy-MM-dd");
                long timeDifference = track.endTimestamp - track.startTimestamp;
                TimeSpan timeSpan = TimeSpan.FromMilliseconds(timeDifference);
                string hours = timeSpan.Hours.ToString("00");
                string minutes = timeSpan.Minutes.ToString("00");

                string[] row = {
                    formattedDateTime,
                    string.Format("{0:F2} km", track.distance / 1000),
                    $"{hours}h {minutes}m"
                };
                tracksListView.Items.Add(new ListViewItem(row));
            }
        }

        private void ExportMapToImage(string fileName)
        {
            Bitmap bmp = new Bitmap(gMapControl.Width, gMapControl.Height);
            gMapControl.DrawToBitmap(bmp, new Rectangle(0, 0, gMapControl.Width, gMapControl.Height));
            bmp.Save(fileName, ImageFormat.Png);
            bmp.Dispose();
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
            panelLoading.Location = new System.Drawing.Point(
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "GPX files (*.gpx)|*.gpx|All files (*.*)|*.*"; 
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "untitled";

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                string currentDateTimeString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                var points = routeCreator.GetPoints();
                new GpxCreator().CreateGpx(points, fileName, $"New track ({currentDateTimeString})");
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Image files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "map_export";

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                ExportMapToImage(saveFileDialog.FileName);
            }
        }

        private void tracksListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var index = e.ItemIndex;

            overlay.IsVisibile = false;
            selectedRouteOverlay.Clear();

            if (tracksCache != null && tracksCache.Count > 0)
            {
                var route = new GMapRouteColored(tracksCache[index].points, 3F, $"track_{index}")
                {
                    Stroke = new Pen(Color.Red, 3F)
                };
                selectedRouteOverlay.Routes.Add(route);
            }
        }

        private void buttonClearSelection_Click(object sender, EventArgs e)
        {
            this.tracksListView.SelectedItems.Clear();
            this.tracksListView.Update();

            overlay.IsVisibile = true;
            selectedRouteOverlay.Clear();
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            panelLoading.Visible = true;

            overlay.Clear();
            routeOverlay.Clear();
            selectedRouteOverlay.Clear();
            tracksListView.Items.Clear();
            tracksListView.Columns.Clear();

            FetchTracksFromCloud();
        }

        private async void buttonTurbines_Click(object sender, EventArgs e)
        {
            //Copy this file to bin/Debug and bin/Release
            panelLoading.Visible = true;
            var turbines = await windTurbines.LoadWindTurbinesAsync();
            if (turbines != null)
            {
                foreach (var turbine in turbines)
                {
                    GMarkerGoogle marker = new GMarkerGoogle(turbine.LatLng, GMarkerGoogleType.orange_small);
                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    marker.ToolTip = new GMapBaloonToolTip(marker);
                    marker.ToolTipText = turbine.TagsToString();
                    routeOverlay.Markers.Add(marker);
                }

            }
            panelLoading.Visible = false;
        }
    }
}
