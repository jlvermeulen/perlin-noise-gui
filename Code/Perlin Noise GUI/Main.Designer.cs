namespace GUI
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
            this.generate.Location = new System.Drawing.Point(402, 487);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(75, 32);
            this.generate.TabIndex = 0;
            this.generate.Text = "Generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // resolutionLabel
            // 
            this.resolutionLabel.AutoSize = true;
            this.resolutionLabel.Location = new System.Drawing.Point(12, 15);
            this.resolutionLabel.Name = "resolutionLabel";
            this.resolutionLabel.Size = new System.Drawing.Size(57, 13);
            this.resolutionLabel.TabIndex = 2;
            this.resolutionLabel.Text = "Resolution";
            // 
            // seedLabel
            // 
            this.seedLabel.AutoSize = true;
            this.seedLabel.Location = new System.Drawing.Point(12, 501);
            this.seedLabel.Name = "seedLabel";
            this.seedLabel.Size = new System.Drawing.Size(32, 13);
            this.seedLabel.TabIndex = 4;
            this.seedLabel.Text = "Seed";
            // 
            // intensityLabel
            // 
            this.intensityLabel.AutoSize = true;
            this.intensityLabel.Location = new System.Drawing.Point(12, 41);
            this.intensityLabel.Name = "intensityLabel";
            this.intensityLabel.Size = new System.Drawing.Size(46, 13);
            this.intensityLabel.TabIndex = 6;
            this.intensityLabel.Text = "Intensity";
            // 
            // levelsLabel
            // 
            this.levelsLabel.AutoSize = true;
            this.levelsLabel.Location = new System.Drawing.Point(12, 67);
            this.levelsLabel.Name = "levelsLabel";
            this.levelsLabel.Size = new System.Drawing.Size(38, 13);
            this.levelsLabel.TabIndex = 8;
            this.levelsLabel.Text = "Levels";
            // 
            // shadowLabel
            // 
            this.shadowLabel.AutoSize = true;
            this.shadowLabel.Location = new System.Drawing.Point(12, 191);
            this.shadowLabel.Name = "shadowLabel";
            this.shadowLabel.Size = new System.Drawing.Size(46, 13);
            this.shadowLabel.TabIndex = 10;
            this.shadowLabel.Text = "Shadow";
            // 
            // highlightLabel
            // 
            this.highlightLabel.AutoSize = true;
            this.highlightLabel.Location = new System.Drawing.Point(12, 211);
            this.highlightLabel.Name = "highlightLabel";
            this.highlightLabel.Size = new System.Drawing.Size(48, 13);
            this.highlightLabel.TabIndex = 12;
            this.highlightLabel.Text = "Highlight";
            // 
            // offsetLabel
            // 
            this.offsetLabel.AutoSize = true;
            this.offsetLabel.Location = new System.Drawing.Point(12, 93);
            this.offsetLabel.Name = "offsetLabel";
            this.offsetLabel.Size = new System.Drawing.Size(35, 13);
            this.offsetLabel.TabIndex = 14;
            this.offsetLabel.Text = "Offset";
            // 
            // rangeHandlingLabel
            // 
            this.rangeHandlingLabel.AutoSize = true;
            this.rangeHandlingLabel.Location = new System.Drawing.Point(12, 120);
            this.rangeHandlingLabel.Name = "rangeHandlingLabel";
            this.rangeHandlingLabel.Size = new System.Drawing.Size(84, 13);
            this.rangeHandlingLabel.TabIndex = 16;
            this.rangeHandlingLabel.Text = "Range Handling";
            // 
            // threadsLabel
            // 
            this.threadsLabel.AutoSize = true;
            this.threadsLabel.Location = new System.Drawing.Point(12, 475);
            this.threadsLabel.Name = "threadsLabel";
            this.threadsLabel.Size = new System.Drawing.Size(46, 13);
            this.threadsLabel.TabIndex = 18;
            this.threadsLabel.Text = "Threads";
            // 
            // offset
            // 
            this.offset.Location = new System.Drawing.Point(153, 91);
            this.offset.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.offset.Name = "offset";
            this.offset.Size = new System.Drawing.Size(156, 20);
            this.offset.TabIndex = 19;
            // 
            // threads
            // 
            this.threads.Location = new System.Drawing.Point(153, 473);
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
            this.threads.Size = new System.Drawing.Size(120, 20);
            this.threads.TabIndex = 20;
            this.threads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // levels
            // 
            this.levels.Location = new System.Drawing.Point(153, 65);
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
            this.levels.TabIndex = 21;
            this.levels.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // intensity
            // 
            this.intensity.DecimalPlaces = 2;
            this.intensity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.intensity.Location = new System.Drawing.Point(153, 39);
            this.intensity.Name = "intensity";
            this.intensity.Size = new System.Drawing.Size(156, 20);
            this.intensity.TabIndex = 22;
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
            "Shift"});
            this.rangeHandling.Location = new System.Drawing.Point(153, 117);
            this.rangeHandling.Name = "rangeHandling";
            this.rangeHandling.Size = new System.Drawing.Size(156, 21);
            this.rangeHandling.TabIndex = 23;
            this.rangeHandling.Text = "Shift";
            // 
            // seed
            // 
            this.seed.Location = new System.Drawing.Point(153, 499);
            this.seed.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.seed.Name = "seed";
            this.seed.Size = new System.Drawing.Size(120, 20);
            this.seed.TabIndex = 24;
            // 
            // shadowRed
            // 
            this.shadowRed.Location = new System.Drawing.Point(153, 183);
            this.shadowRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.shadowRed.Name = "shadowRed";
            this.shadowRed.Size = new System.Drawing.Size(48, 20);
            this.shadowRed.TabIndex = 25;
            // 
            // shadowBlue
            // 
            this.shadowBlue.Location = new System.Drawing.Point(261, 183);
            this.shadowBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.shadowBlue.Name = "shadowBlue";
            this.shadowBlue.Size = new System.Drawing.Size(48, 20);
            this.shadowBlue.TabIndex = 26;
            // 
            // shadowGreen
            // 
            this.shadowGreen.Location = new System.Drawing.Point(207, 183);
            this.shadowGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.shadowGreen.Name = "shadowGreen";
            this.shadowGreen.Size = new System.Drawing.Size(48, 20);
            this.shadowGreen.TabIndex = 27;
            // 
            // redLabel
            // 
            this.redLabel.AutoSize = true;
            this.redLabel.Location = new System.Drawing.Point(150, 164);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(27, 13);
            this.redLabel.TabIndex = 28;
            this.redLabel.Text = "Red";
            // 
            // blueLabel
            // 
            this.blueLabel.AutoSize = true;
            this.blueLabel.Location = new System.Drawing.Point(258, 164);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(28, 13);
            this.blueLabel.TabIndex = 29;
            this.blueLabel.Text = "Blue";
            // 
            // greenLabel
            // 
            this.greenLabel.AutoSize = true;
            this.greenLabel.Location = new System.Drawing.Point(204, 164);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(36, 13);
            this.greenLabel.TabIndex = 30;
            this.greenLabel.Text = "Green";
            // 
            // highlightGreen
            // 
            this.highlightGreen.Location = new System.Drawing.Point(207, 209);
            this.highlightGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.highlightGreen.Name = "highlightGreen";
            this.highlightGreen.Size = new System.Drawing.Size(48, 20);
            this.highlightGreen.TabIndex = 33;
            this.highlightGreen.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // highlightBlue
            // 
            this.highlightBlue.Location = new System.Drawing.Point(261, 209);
            this.highlightBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.highlightBlue.Name = "highlightBlue";
            this.highlightBlue.Size = new System.Drawing.Size(48, 20);
            this.highlightBlue.TabIndex = 32;
            this.highlightBlue.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // highlightRed
            // 
            this.highlightRed.Location = new System.Drawing.Point(153, 209);
            this.highlightRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.highlightRed.Name = "highlightRed";
            this.highlightRed.Size = new System.Drawing.Size(48, 20);
            this.highlightRed.TabIndex = 31;
            this.highlightRed.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // wrap
            // 
            this.wrap.AutoSize = true;
            this.wrap.Location = new System.Drawing.Point(153, 144);
            this.wrap.Name = "wrap";
            this.wrap.Size = new System.Drawing.Size(52, 17);
            this.wrap.TabIndex = 36;
            this.wrap.Text = "Wrap";
            this.wrap.UseVisualStyleBackColor = true;
            // 
            // layers
            // 
            this.layers.FormattingEnabled = true;
            this.layers.Location = new System.Drawing.Point(12, 252);
            this.layers.Name = "layers";
            this.layers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.layers.Size = new System.Drawing.Size(465, 147);
            this.layers.TabIndex = 37;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(402, 206);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 38;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(402, 406);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 39;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // resolution
            // 
            this.resolution.Location = new System.Drawing.Point(153, 13);
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
            this.resolution.TabIndex = 35;
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
            this.ClientSize = new System.Drawing.Size(489, 531);
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
            this.Name = "Main";
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
    }
}

