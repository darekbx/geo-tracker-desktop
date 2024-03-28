namespace geotracker_desktop
{
    partial class MapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapForm));
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.loadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripZoomLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMapTypeButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripInverseButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.standardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonZoomMinus = new System.Windows.Forms.Button();
            this.buttonZoomPlus = new System.Windows.Forms.Button();
            this.routePanel = new System.Windows.Forms.Panel();
            this.buttonRouteClear = new System.Windows.Forms.Button();
            this.buttonUndoPoint = new System.Windows.Forms.Button();
            this.labelPointsValue = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelDistanceValue = new System.Windows.Forms.Label();
            this.labelDistance = new System.Windows.Forms.Label();
            this.panelLoading = new System.Windows.Forms.Panel();
            this.labelLoading = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.routePanel.SuspendLayout();
            this.panelLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapControl
            // 
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemory = 5;
            this.gMapControl.Location = new System.Drawing.Point(0, 0);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 2;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomEnabled = true;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(834, 405);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 0D;
            this.gMapControl.OnMapClick += new GMap.NET.WindowsForms.MapClick(this.gMapControl_OnMapClick);
            this.gMapControl.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.gMapControl_OnMapZoomChanged);
            this.gMapControl.Load += new System.EventHandler(this.gMapControl1_LoadAsync);
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.loadingProgressBar.Location = new System.Drawing.Point(0, 0);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(834, 6);
            this.loadingProgressBar.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripZoomLabel,
            this.toolStripMapTypeButton,
            this.toolStripInverseButton});
            this.statusStrip.Location = new System.Drawing.Point(0, 383);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(834, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripZoomLabel
            // 
            this.toolStripZoomLabel.Name = "toolStripZoomLabel";
            this.toolStripZoomLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripMapTypeButton
            // 
            this.toolStripMapTypeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMapTypeButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMapTypeButton.Image")));
            this.toolStripMapTypeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMapTypeButton.Name = "toolStripMapTypeButton";
            this.toolStripMapTypeButton.Size = new System.Drawing.Size(114, 20);
            this.toolStripMapTypeButton.Text = "Open Street Maps";
            this.toolStripMapTypeButton.ToolTipText = "Map type";
            // 
            // toolStripInverseButton
            // 
            this.toolStripInverseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripInverseButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardToolStripMenuItem,
            this.invertedToolStripMenuItem});
            this.toolStripInverseButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripInverseButton.Image")));
            this.toolStripInverseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripInverseButton.Name = "toolStripInverseButton";
            this.toolStripInverseButton.Size = new System.Drawing.Size(86, 20);
            this.toolStripInverseButton.Text = "Not inverted";
            // 
            // standardToolStripMenuItem
            // 
            this.standardToolStripMenuItem.Name = "standardToolStripMenuItem";
            this.standardToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.standardToolStripMenuItem.Text = "Not inverted";
            this.standardToolStripMenuItem.Click += new System.EventHandler(this.standardToolStripMenuItem_Click);
            // 
            // invertedToolStripMenuItem
            // 
            this.invertedToolStripMenuItem.Name = "invertedToolStripMenuItem";
            this.invertedToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.invertedToolStripMenuItem.Text = "Inverted";
            this.invertedToolStripMenuItem.Click += new System.EventHandler(this.invertedToolStripMenuItem_Click);
            // 
            // buttonZoomMinus
            // 
            this.buttonZoomMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZoomMinus.Location = new System.Drawing.Point(788, 333);
            this.buttonZoomMinus.Name = "buttonZoomMinus";
            this.buttonZoomMinus.Size = new System.Drawing.Size(34, 34);
            this.buttonZoomMinus.TabIndex = 3;
            this.buttonZoomMinus.Text = "-";
            this.buttonZoomMinus.UseVisualStyleBackColor = true;
            this.buttonZoomMinus.Click += new System.EventHandler(this.buttonZoomMinus_Click);
            // 
            // buttonZoomPlus
            // 
            this.buttonZoomPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZoomPlus.BackColor = System.Drawing.Color.Transparent;
            this.buttonZoomPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonZoomPlus.Location = new System.Drawing.Point(788, 293);
            this.buttonZoomPlus.Name = "buttonZoomPlus";
            this.buttonZoomPlus.Size = new System.Drawing.Size(34, 34);
            this.buttonZoomPlus.TabIndex = 4;
            this.buttonZoomPlus.Text = "+";
            this.buttonZoomPlus.UseVisualStyleBackColor = false;
            this.buttonZoomPlus.Click += new System.EventHandler(this.buttonZoomPlus_Click);
            // 
            // routePanel
            // 
            this.routePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.routePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.routePanel.Controls.Add(this.buttonSave);
            this.routePanel.Controls.Add(this.buttonRouteClear);
            this.routePanel.Controls.Add(this.buttonUndoPoint);
            this.routePanel.Controls.Add(this.labelPointsValue);
            this.routePanel.Controls.Add(this.labelPoints);
            this.routePanel.Controls.Add(this.labelDistanceValue);
            this.routePanel.Controls.Add(this.labelDistance);
            this.routePanel.Location = new System.Drawing.Point(561, 293);
            this.routePanel.Name = "routePanel";
            this.routePanel.Size = new System.Drawing.Size(221, 74);
            this.routePanel.TabIndex = 5;
            this.routePanel.Visible = false;
            // 
            // buttonRouteClear
            // 
            this.buttonRouteClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRouteClear.Location = new System.Drawing.Point(3, 39);
            this.buttonRouteClear.Name = "buttonRouteClear";
            this.buttonRouteClear.Size = new System.Drawing.Size(60, 30);
            this.buttonRouteClear.TabIndex = 5;
            this.buttonRouteClear.Text = "Clear";
            this.buttonRouteClear.UseVisualStyleBackColor = true;
            this.buttonRouteClear.Click += new System.EventHandler(this.buttonRouteClear_Click);
            // 
            // buttonUndoPoint
            // 
            this.buttonUndoPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUndoPoint.Location = new System.Drawing.Point(156, 39);
            this.buttonUndoPoint.Name = "buttonUndoPoint";
            this.buttonUndoPoint.Size = new System.Drawing.Size(60, 30);
            this.buttonUndoPoint.TabIndex = 4;
            this.buttonUndoPoint.Text = "Undo";
            this.buttonUndoPoint.UseVisualStyleBackColor = true;
            this.buttonUndoPoint.Click += new System.EventHandler(this.buttonUndoPoint_Click);
            // 
            // labelPointsValue
            // 
            this.labelPointsValue.AutoSize = true;
            this.labelPointsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPointsValue.Location = new System.Drawing.Point(55, 20);
            this.labelPointsValue.Name = "labelPointsValue";
            this.labelPointsValue.Size = new System.Drawing.Size(14, 13);
            this.labelPointsValue.TabIndex = 3;
            this.labelPointsValue.Text = "0";
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Location = new System.Drawing.Point(4, 20);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(39, 13);
            this.labelPoints.TabIndex = 2;
            this.labelPoints.Text = "Points:";
            // 
            // labelDistanceValue
            // 
            this.labelDistanceValue.AutoSize = true;
            this.labelDistanceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDistanceValue.Location = new System.Drawing.Point(55, 3);
            this.labelDistanceValue.Name = "labelDistanceValue";
            this.labelDistanceValue.Size = new System.Drawing.Size(34, 13);
            this.labelDistanceValue.TabIndex = 1;
            this.labelDistanceValue.Text = "0 km";
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(4, 3);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(55, 13);
            this.labelDistance.TabIndex = 0;
            this.labelDistance.Text = "Distance: ";
            // 
            // panelLoading
            // 
            this.panelLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLoading.Controls.Add(this.labelLoading);
            this.panelLoading.Location = new System.Drawing.Point(311, 107);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(200, 200);
            this.panelLoading.TabIndex = 6;
            // 
            // labelLoading
            // 
            this.labelLoading.AutoSize = true;
            this.labelLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoading.Location = new System.Drawing.Point(62, 91);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(81, 17);
            this.labelLoading.TabIndex = 1;
            this.labelLoading.Text = "Loading...";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(69, 39);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(81, 30);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save (GPX)";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 405);
            this.Controls.Add(this.panelLoading);
            this.Controls.Add(this.routePanel);
            this.Controls.Add(this.buttonZoomPlus);
            this.Controls.Add(this.buttonZoomMinus);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.loadingProgressBar);
            this.Controls.Add(this.gMapControl);
            this.Name = "MapForm";
            this.RightToLeftLayout = true;
            this.Text = "GeoTracker Cloud";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.routePanel.ResumeLayout(false);
            this.routePanel.PerformLayout();
            this.panelLoading.ResumeLayout(false);
            this.panelLoading.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.ProgressBar loadingProgressBar;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripZoomLabel;
        private System.Windows.Forms.Button buttonZoomMinus;
        private System.Windows.Forms.Button buttonZoomPlus;
        private System.Windows.Forms.ToolStripDropDownButton toolStripMapTypeButton;
        private System.Windows.Forms.ToolStripDropDownButton toolStripInverseButton;
        private System.Windows.Forms.ToolStripMenuItem standardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertedToolStripMenuItem;
        private System.Windows.Forms.Panel routePanel;
        private System.Windows.Forms.Label labelDistanceValue;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.Panel panelLoading;
        private System.Windows.Forms.Label labelLoading;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelPointsValue;
        private System.Windows.Forms.Button buttonUndoPoint;
        private System.Windows.Forms.Button buttonRouteClear;
        private System.Windows.Forms.Button buttonSave;
    }
}

