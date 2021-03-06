﻿namespace GUI
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.generate = new System.Windows.Forms.Button();
            this.resolutionLabel = new System.Windows.Forms.Label();
            this.seedLabel = new System.Windows.Forms.Label();
            this.intensityLabel = new System.Windows.Forms.Label();
            this.levelsLabel = new System.Windows.Forms.Label();
            this.shadowLabel = new System.Windows.Forms.Label();
            this.highlightLabel = new System.Windows.Forms.Label();
            this.offsetLabel = new System.Windows.Forms.Label();
            this.rangeHandlingLabel = new System.Windows.Forms.Label();
            this.threadsLabel = new System.Windows.Forms.Label();
            this.offset = new System.Windows.Forms.NumericUpDown();
            this.threads = new System.Windows.Forms.NumericUpDown();
            this.levels = new System.Windows.Forms.NumericUpDown();
            this.intensity = new System.Windows.Forms.NumericUpDown();
            this.rangeHandling = new System.Windows.Forms.ComboBox();
            this.seed = new System.Windows.Forms.NumericUpDown();
            this.shadowRed = new System.Windows.Forms.NumericUpDown();
            this.shadowBlue = new System.Windows.Forms.NumericUpDown();
            this.shadowGreen = new System.Windows.Forms.NumericUpDown();
            this.redLabel = new System.Windows.Forms.Label();
            this.blueLabel = new System.Windows.Forms.Label();
            this.greenLabel = new System.Windows.Forms.Label();
            this.highlightGreen = new System.Windows.Forms.NumericUpDown();
            this.highlightBlue = new System.Windows.Forms.NumericUpDown();
            this.highlightRed = new System.Windows.Forms.NumericUpDown();
            this.wrap = new System.Windows.Forms.CheckBox();
            this.layers = new System.Windows.Forms.ListBox();
            this.add = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.manage = new System.Windows.Forms.Button();
            this.channelWrap = new System.Windows.Forms.CheckBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.info = new System.Windows.Forms.Label();
            this.resolution = new GUI.ResolutionUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.offset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shadowRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shadowBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shadowGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highlightGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highlightBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highlightRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolution)).BeginInit();
            this.SuspendLayout();
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(386, 426);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(91, 46);
            this.generate.TabIndex = 23;
            this.generate.Text = "Generate";
            this.toolTip.SetToolTip(this.generate, "Generate the image.");
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // resolutionLabel
            // 
            this.resolutionLabel.AutoSize = true;
            this.resolutionLabel.Location = new System.Drawing.Point(12, 402);
            this.resolutionLabel.Name = "resolutionLabel";
            this.resolutionLabel.Size = new System.Drawing.Size(57, 13);
            this.resolutionLabel.TabIndex = 2;
            this.resolutionLabel.Text = "Resolution";
            // 
            // seedLabel
            // 
            this.seedLabel.AutoSize = true;
            this.seedLabel.Location = new System.Drawing.Point(12, 454);
            this.seedLabel.Name = "seedLabel";
            this.seedLabel.Size = new System.Drawing.Size(32, 13);
            this.seedLabel.TabIndex = 4;
            this.seedLabel.Text = "Seed";
            // 
            // intensityLabel
            // 
            this.intensityLabel.AutoSize = true;
            this.intensityLabel.Location = new System.Drawing.Point(12, 14);
            this.intensityLabel.Name = "intensityLabel";
            this.intensityLabel.Size = new System.Drawing.Size(46, 13);
            this.intensityLabel.TabIndex = 6;
            this.intensityLabel.Text = "Intensity";
            // 
            // levelsLabel
            // 
            this.levelsLabel.AutoSize = true;
            this.levelsLabel.Location = new System.Drawing.Point(12, 40);
            this.levelsLabel.Name = "levelsLabel";
            this.levelsLabel.Size = new System.Drawing.Size(38, 13);
            this.levelsLabel.TabIndex = 8;
            this.levelsLabel.Text = "Levels";
            // 
            // shadowLabel
            // 
            this.shadowLabel.AutoSize = true;
            this.shadowLabel.Location = new System.Drawing.Point(12, 164);
            this.shadowLabel.Name = "shadowLabel";
            this.shadowLabel.Size = new System.Drawing.Size(46, 13);
            this.shadowLabel.TabIndex = 10;
            this.shadowLabel.Text = "Shadow";
            // 
            // highlightLabel
            // 
            this.highlightLabel.AutoSize = true;
            this.highlightLabel.Location = new System.Drawing.Point(12, 184);
            this.highlightLabel.Name = "highlightLabel";
            this.highlightLabel.Size = new System.Drawing.Size(48, 13);
            this.highlightLabel.TabIndex = 12;
            this.highlightLabel.Text = "Highlight";
            // 
            // offsetLabel
            // 
            this.offsetLabel.AutoSize = true;
            this.offsetLabel.Location = new System.Drawing.Point(12, 66);
            this.offsetLabel.Name = "offsetLabel";
            this.offsetLabel.Size = new System.Drawing.Size(35, 13);
            this.offsetLabel.TabIndex = 14;
            this.offsetLabel.Text = "Offset";
            // 
            // rangeHandlingLabel
            // 
            this.rangeHandlingLabel.AutoSize = true;
            this.rangeHandlingLabel.Location = new System.Drawing.Point(12, 93);
            this.rangeHandlingLabel.Name = "rangeHandlingLabel";
            this.rangeHandlingLabel.Size = new System.Drawing.Size(84, 13);
            this.rangeHandlingLabel.TabIndex = 16;
            this.rangeHandlingLabel.Text = "Range Handling";
            // 
            // threadsLabel
            // 
            this.threadsLabel.AutoSize = true;
            this.threadsLabel.Location = new System.Drawing.Point(12, 428);
            this.threadsLabel.Name = "threadsLabel";
            this.threadsLabel.Size = new System.Drawing.Size(46, 13);
            this.threadsLabel.TabIndex = 18;
            this.threadsLabel.Text = "Threads";
            // 
            // offset
            // 
            this.offset.Location = new System.Drawing.Point(153, 64);
            this.offset.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.offset.Name = "offset";
            this.offset.Size = new System.Drawing.Size(156, 20);
            this.offset.TabIndex = 3;
            this.toolTip.SetToolTip(this.offset, "The base size of the noise array.");
            this.offset.ValueChanged += new System.EventHandler(this.offset_ValueChanged);
            // 
            // threads
            // 
            this.threads.Location = new System.Drawing.Point(153, 426);
            this.threads.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.threads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threads.Name = "threads";
            this.threads.Size = new System.Drawing.Size(156, 20);
            this.threads.TabIndex = 21;
            this.toolTip.SetToolTip(this.threads, "The number of threads to use when generating the image.");
            this.threads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // levels
            // 
            this.levels.Location = new System.Drawing.Point(153, 38);
            this.levels.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.levels.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.levels.Name = "levels";
            this.levels.Size = new System.Drawing.Size(156, 20);
            this.levels.TabIndex = 2;
            this.toolTip.SetToolTip(this.levels, "The levels of turbulence to create.");
            this.levels.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.levels.ValueChanged += new System.EventHandler(this.levels_ValueChanged);
            // 
            // intensity
            // 
            this.intensity.DecimalPlaces = 2;
            this.intensity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.intensity.Location = new System.Drawing.Point(153, 12);
            this.intensity.Name = "intensity";
            this.intensity.Size = new System.Drawing.Size(156, 20);
            this.intensity.TabIndex = 1;
            this.toolTip.SetToolTip(this.intensity, "The intensity of this layer.");
            this.intensity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rangeHandling
            // 
            this.rangeHandling.FormattingEnabled = true;
            this.rangeHandling.Items.AddRange(new object[] {
            "Absolute",
            "Clamp",
            "InverseAbsolute",
            "None",
            "Shift"});
            this.rangeHandling.Location = new System.Drawing.Point(153, 90);
            this.rangeHandling.Name = "rangeHandling";
            this.rangeHandling.Size = new System.Drawing.Size(156, 21);
            this.rangeHandling.TabIndex = 4;
            this.rangeHandling.Text = "Shift";
            this.toolTip.SetToolTip(this.rangeHandling, resources.GetString("rangeHandling.ToolTip"));
            // 
            // seed
            // 
            this.seed.Location = new System.Drawing.Point(153, 452);
            this.seed.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.seed.Name = "seed";
            this.seed.Size = new System.Drawing.Size(156, 20);
            this.seed.TabIndex = 22;
            this.toolTip.SetToolTip(this.seed, "The seed to use for generating the image. If the value is zero, a random seed wil" +
        "l be used.");
            // 
            // shadowRed
            // 
            this.shadowRed.Location = new System.Drawing.Point(153, 156);
            this.shadowRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.shadowRed.Name = "shadowRed";
            this.shadowRed.Size = new System.Drawing.Size(48, 20);
            this.shadowRed.TabIndex = 7;
            this.toolTip.SetToolTip(this.shadowRed, "The red component of the base colour.");
            // 
            // shadowBlue
            // 
            this.shadowBlue.Location = new System.Drawing.Point(261, 156);
            this.shadowBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.shadowBlue.Name = "shadowBlue";
            this.shadowBlue.Size = new System.Drawing.Size(48, 20);
            this.shadowBlue.TabIndex = 9;
            this.toolTip.SetToolTip(this.shadowBlue, "The blue component of the base colour.");
            // 
            // shadowGreen
            // 
            this.shadowGreen.Location = new System.Drawing.Point(207, 156);
            this.shadowGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.shadowGreen.Name = "shadowGreen";
            this.shadowGreen.Size = new System.Drawing.Size(48, 20);
            this.shadowGreen.TabIndex = 8;
            this.toolTip.SetToolTip(this.shadowGreen, "The green component of the base colour.");
            // 
            // redLabel
            // 
            this.redLabel.AutoSize = true;
            this.redLabel.Location = new System.Drawing.Point(150, 137);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(27, 13);
            this.redLabel.TabIndex = 28;
            this.redLabel.Text = "Red";
            // 
            // blueLabel
            // 
            this.blueLabel.AutoSize = true;
            this.blueLabel.Location = new System.Drawing.Point(258, 137);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(28, 13);
            this.blueLabel.TabIndex = 29;
            this.blueLabel.Text = "Blue";
            // 
            // greenLabel
            // 
            this.greenLabel.AutoSize = true;
            this.greenLabel.Location = new System.Drawing.Point(204, 137);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(36, 13);
            this.greenLabel.TabIndex = 30;
            this.greenLabel.Text = "Green";
            // 
            // highlightGreen
            // 
            this.highlightGreen.Location = new System.Drawing.Point(207, 182);
            this.highlightGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.highlightGreen.Name = "highlightGreen";
            this.highlightGreen.Size = new System.Drawing.Size(48, 20);
            this.highlightGreen.TabIndex = 11;
            this.toolTip.SetToolTip(this.highlightGreen, "The green component of the highlight colour.");
            this.highlightGreen.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // highlightBlue
            // 
            this.highlightBlue.Location = new System.Drawing.Point(261, 182);
            this.highlightBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.highlightBlue.Name = "highlightBlue";
            this.highlightBlue.Size = new System.Drawing.Size(48, 20);
            this.highlightBlue.TabIndex = 12;
            this.toolTip.SetToolTip(this.highlightBlue, "The blue component of the highlight colour.");
            this.highlightBlue.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // highlightRed
            // 
            this.highlightRed.Location = new System.Drawing.Point(153, 182);
            this.highlightRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.highlightRed.Name = "highlightRed";
            this.highlightRed.Size = new System.Drawing.Size(48, 20);
            this.highlightRed.TabIndex = 10;
            this.toolTip.SetToolTip(this.highlightRed, "The red component of the highlight colour.");
            this.highlightRed.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // wrap
            // 
            this.wrap.AutoSize = true;
            this.wrap.Location = new System.Drawing.Point(153, 117);
            this.wrap.Name = "wrap";
            this.wrap.Size = new System.Drawing.Size(52, 17);
            this.wrap.TabIndex = 5;
            this.wrap.Text = "Wrap";
            this.toolTip.SetToolTip(this.wrap, "Wrap values that exceed 1 back to 0.");
            this.wrap.UseVisualStyleBackColor = true;
            this.wrap.CheckedChanged += new System.EventHandler(this.wrap_CheckedChanged);
            // 
            // layers
            // 
            this.layers.FormattingEnabled = true;
            this.layers.Location = new System.Drawing.Point(12, 208);
            this.layers.Name = "layers";
            this.layers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.layers.Size = new System.Drawing.Size(368, 186);
            this.layers.TabIndex = 13;
            this.toolTip.SetToolTip(this.layers, "The layers that will be used for creating the current texture.");
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(386, 208);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(91, 26);
            this.add.TabIndex = 14;
            this.add.Text = "Add layer";
            this.toolTip.SetToolTip(this.add, "Add the curent settings as a layer.");
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(386, 240);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(91, 26);
            this.delete.TabIndex = 15;
            this.delete.Text = "Delete layer";
            this.toolTip.SetToolTip(this.delete, "Delete selected layers.");
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(386, 304);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(91, 26);
            this.save.TabIndex = 17;
            this.save.Text = "Save preset";
            this.toolTip.SetToolTip(this.save, "Save the current set of layers as a preset.");
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(386, 336);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(91, 26);
            this.load.TabIndex = 18;
            this.load.Text = "Load preset";
            this.toolTip.SetToolTip(this.load, "Load a set of layers from a preset.");
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(386, 272);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(91, 26);
            this.clear.TabIndex = 16;
            this.clear.Text = "Clear layers";
            this.toolTip.SetToolTip(this.clear, "Delete all layers.");
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // manage
            // 
            this.manage.Location = new System.Drawing.Point(386, 368);
            this.manage.Name = "manage";
            this.manage.Size = new System.Drawing.Size(91, 26);
            this.manage.TabIndex = 19;
            this.manage.Text = "Manage presets";
            this.toolTip.SetToolTip(this.manage, "Delete presets or restore the default presets.");
            this.manage.UseVisualStyleBackColor = true;
            this.manage.Click += new System.EventHandler(this.manage_Click);
            // 
            // channelWrap
            // 
            this.channelWrap.AutoSize = true;
            this.channelWrap.Enabled = false;
            this.channelWrap.Location = new System.Drawing.Point(207, 117);
            this.channelWrap.Name = "channelWrap";
            this.channelWrap.Size = new System.Drawing.Size(83, 17);
            this.channelWrap.TabIndex = 6;
            this.channelWrap.Text = "Per channel";
            this.toolTip.SetToolTip(this.channelWrap, "Allow channels to wrap individually.");
            this.channelWrap.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 30000;
            this.toolTip.InitialDelay = 1000;
            this.toolTip.ReshowDelay = 500;
            // 
            // info
            // 
            this.info.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.info.AutoSize = true;
            this.info.Enabled = false;
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.Location = new System.Drawing.Point(343, 53);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(121, 78);
            this.info.TabIndex = 31;
            this.info.Text = "Perlin Noise GUI\r\nby Jordi Vermeulen\r\nCopyright 2013\r\n\r\nGUI v1.0\r\nPerlin Noise Li" +
    "brary v1.0";
            this.info.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // resolution
            // 
            this.resolution.Location = new System.Drawing.Point(153, 400);
            this.resolution.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.resolution.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.resolution.Name = "resolution";
            this.resolution.Size = new System.Drawing.Size(156, 20);
            this.resolution.TabIndex = 20;
            this.toolTip.SetToolTip(this.resolution, "The resolution of the texture.");
            this.resolution.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.resolution.Validated += new System.EventHandler(this.resolution_Validated);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 484);
            this.Controls.Add(this.info);
            this.Controls.Add(this.channelWrap);
            this.Controls.Add(this.manage);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.load);
            this.Controls.Add(this.save);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.layers);
            this.Controls.Add(this.wrap);
            this.Controls.Add(this.resolution);
            this.Controls.Add(this.highlightGreen);
            this.Controls.Add(this.highlightBlue);
            this.Controls.Add(this.highlightRed);
            this.Controls.Add(this.greenLabel);
            this.Controls.Add(this.blueLabel);
            this.Controls.Add(this.redLabel);
            this.Controls.Add(this.shadowGreen);
            this.Controls.Add(this.shadowBlue);
            this.Controls.Add(this.shadowRed);
            this.Controls.Add(this.seed);
            this.Controls.Add(this.rangeHandling);
            this.Controls.Add(this.intensity);
            this.Controls.Add(this.levels);
            this.Controls.Add(this.threads);
            this.Controls.Add(this.offset);
            this.Controls.Add(this.threadsLabel);
            this.Controls.Add(this.rangeHandlingLabel);
            this.Controls.Add(this.offsetLabel);
            this.Controls.Add(this.highlightLabel);
            this.Controls.Add(this.shadowLabel);
            this.Controls.Add(this.levelsLabel);
            this.Controls.Add(this.intensityLabel);
            this.Controls.Add(this.seedLabel);
            this.Controls.Add(this.resolutionLabel);
            this.Controls.Add(this.generate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Perlin Noise GUI";
            ((System.ComponentModel.ISupportInitialize)(this.offset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shadowRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shadowBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shadowGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highlightGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highlightBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highlightRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Label resolutionLabel;
        private System.Windows.Forms.Label seedLabel;
        private System.Windows.Forms.Label intensityLabel;
        private System.Windows.Forms.Label levelsLabel;
        private System.Windows.Forms.Label shadowLabel;
        private System.Windows.Forms.Label highlightLabel;
        private System.Windows.Forms.Label offsetLabel;
        private System.Windows.Forms.Label rangeHandlingLabel;
        private System.Windows.Forms.Label threadsLabel;
        private System.Windows.Forms.NumericUpDown offset;
        private System.Windows.Forms.NumericUpDown threads;
        private System.Windows.Forms.NumericUpDown levels;
        private System.Windows.Forms.NumericUpDown intensity;
        private System.Windows.Forms.ComboBox rangeHandling;
        private System.Windows.Forms.NumericUpDown seed;
        private System.Windows.Forms.NumericUpDown shadowRed;
        private System.Windows.Forms.NumericUpDown shadowBlue;
        private System.Windows.Forms.NumericUpDown shadowGreen;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.NumericUpDown highlightGreen;
        private System.Windows.Forms.NumericUpDown highlightBlue;
        private System.Windows.Forms.NumericUpDown highlightRed;
        private ResolutionUpDown resolution;
        private System.Windows.Forms.CheckBox wrap;
        private System.Windows.Forms.ListBox layers;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button manage;
        private System.Windows.Forms.CheckBox channelWrap;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label info;
    }
}

