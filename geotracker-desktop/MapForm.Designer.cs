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
            this.buttonZoomMinus = new System.Windows.Forms.Button();
            this.buttonZoomPlus = new System.Windows.Forms.Button();
            this.toolStripInverseButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.invertedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
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
            this.gMapControl.Size = new System.Drawing.Size(1185, 616);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 0D;
            this.gMapControl.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.gMapControl_OnMapZoomChanged);
            this.gMapControl.Load += new System.EventHandler(this.gMapControl1_LoadAsync);
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.loadingProgressBar.Location = new System.Drawing.Point(0, 0);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(1185, 6);
            this.loadingProgressBar.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripZoomLabel,
            this.toolStripMapTypeButton,
            this.toolStripInverseButton});
            this.statusStrip.Location = new System.Drawing.Point(0, 594);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1185, 22);
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
            // buttonZoomMinus
            // 
            this.buttonZoomMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZoomMinus.Location = new System.Drawing.Point(1139, 544);
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
            this.buttonZoomPlus.Location = new System.Drawing.Point(1139, 504);
            this.buttonZoomPlus.Name = "buttonZoomPlus";
            this.buttonZoomPlus.Size = new System.Drawing.Size(34, 34);
            this.buttonZoomPlus.TabIndex = 4;
            this.buttonZoomPlus.Text = "+";
            this.buttonZoomPlus.UseVisualStyleBackColor = false;
            this.buttonZoomPlus.Click += new System.EventHandler(this.buttonZoomPlus_Click);
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
            this.toolStripInverseButton.Size = new System.Drawing.Size(89, 20);
            this.toolStripInverseButton.Text = "Not inverted";
            // 
            // invertedToolStripMenuItem
            // 
            this.invertedToolStripMenuItem.Name = "invertedToolStripMenuItem";
            this.invertedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.invertedToolStripMenuItem.Text = "Inverted";
            this.invertedToolStripMenuItem.Click += new System.EventHandler(this.invertedToolStripMenuItem_Click);
            // 
            // standardToolStripMenuItem
            // 
            this.standardToolStripMenuItem.Name = "standardToolStripMenuItem";
            this.standardToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.standardToolStripMenuItem.Text = "Not inverted";
            this.standardToolStripMenuItem.Click += new System.EventHandler(this.standardToolStripMenuItem_Click);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 616);
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
    }
}

