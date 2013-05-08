using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;

/// <summary>
/// How to convert values from [-1, 1] to [0, 1].
/// <para>- Absolute: take the absolute value</para>
/// <para>- Clamp: clamp the value between 0 and 1</para>
/// <para>- InverseAbsolute: take 1 minus the absolute value</para>
/// <para>- None: perform no conversion</para>
/// <para>- Shift: add 1 and divide by 2</para>
/// </summary>
public enum RangeHandling { Absolute, Clamp, InverseAbsolute, None, Shift };

namespace PerlinNoise
{
    /// <summary>
    /// Provides methods for generating Perlin noise.
    /// </summary>
    public class PerlinNoiseGenerator
    {
        private int resolution, threadCount, seed,arraySize, progress;
        private byte[] texels;
        private Vector2[] vectors;
        private int[] hashLookup;
        private int[,] vectorIndices;

        private static readonly PerlinNoiseGenerator generator = new PerlinNoiseGenerator();

        /// <summary>
        /// Returns a <code>Bitmap</code> of a specified <paramref name="resolution"/> according to the specified <paramref name="settings"/>.
        /// </summary>
        /// <param name="settings">An array of <code>PerlinNoiseSettings</code> objects representing the layers of the image to be generated.</param>
        /// <param name="resolution">The resolution of the image.</param>
        /// <param name="threads">The number of threads to use while generating the image.</param>
        /// <param name="seed">The seed to use when generating the image. When set to 0, a random seed will be used.</param>
        /// <returns>A <code>Bitmap</code> containing Perlin noise.</returns>
        public static Bitmap GetImage(PerlinNoiseSettings[] settings, int resolution, int threads, int seed)
        {
            generator.GenerateImage(settings, resolution, threads, seed);

            Bitmap bmp = new Bitmap(resolution, resolution, PixelFormat.Format24bppRgb);
            byte[] colours = generator.texels;

            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            Marshal.Copy(colours, 0, bmpData.Scan0, colours.Length);
            bmp.UnlockBits(bmpData);

            return bmp;
        }

        /// <summary>
        /// Gets or sets the number of fields that has already been computed.
        /// </summary>
        public static int Progress { get { return generator.progress; } set { generator.progress = value; } }

        private void GenerateImage(PerlinNoiseSettings[] settings, int resolution, int threads, int seed)
        {
            this.texels = new byte[resolution * resolution * 3];
            this.resolution = resolution;
            this.threadCount = threads;
            this.seed = seed;

            foreach (PerlinNoiseSettings s in settings)
                Generate(s);
        }

        private byte[] Generate(PerlinNoiseSettings settings)
        {
            Thread[] threads = new Thread[this.threadCount];
            Random random;
            if (seed != 0)
                random = new Random(seed);
            else
                random = new Random();

            for (int n = 0; n < settings.Levels; n++)
            {
                this.arraySize = (int)Math.Pow(2, settings.Offset + 1);
                float ratio = (float)this.resolution / this.arraySize;

                this.vectors = new Vector2[arraySize];
                this.hashLookup = new int[arraySize];

                for (int i = 0; i < this.arraySize; i++)
                {
                    this.vectors[i].X = 2 * (float)random.NextDouble() - 1;
                    this.vectors[i].Y = 2 * (float)random.NextDouble() - 1;

                    if (this.vectors[i].Length() < 1)
                        this.vectors[i].Normalize();
                    else if (i > 0)
                        i--;
                    else
                        i = 0;

                    hashLookup[i] = i;
                }

                Scramble(hashLookup, random);

                this.vectorIndices = new int[this.arraySize + 1, this.arraySize + 1];
                for (int x = 0; x < this.arraySize + 1; x++)
                    for (int y = 0; y < this.arraySize + 1; y++)
                        this.vectorIndices[x, y] = this.hashLookup[(x + this.hashLookup[y % this.arraySize]) % this.arraySize];

                for (int i = 0; i < this.threadCount; i++)
                    threads[i] = new Thread(new ParameterizedThreadStart(this.FillTexels));
                for (int i = 0; i < this.threadCount; i++)
                    threads[i].Start(new ThreadParams(ratio, i / ratio, this.threadCount, settings));
                for (int i = 0; i < this.threadCount; i++)
                    threads[i].Join();

                settings.Offset++;
            }
            return texels;
        }

        private void FillTexels(object data)
        {
            ThreadParams tParams = (ThreadParams)data;
            for (float x = tParams.Start; x < this.arraySize; x += tParams.Step / tParams.Ratio)
            {
                for (float y = 0; y < this.arraySize; y += 1.0f / tParams.Ratio)
                {
                    float value = 0;
                    int fx = (int)Math.Floor(x);
                    int fy = (int)Math.Floor(y);

                    for (int i = fx; i <= fx + 1; i++)
                        for (int j = fy; j <= fy + 1; j++)
                            value += Omega(x - i) * Omega(y - j) * Vector2.Dot(this.vectors[this.vectorIndices[i, j]], new Vector2(x - i, y - j));

                    int tx = (int)Math.Round((x * tParams.Ratio));
                    int ty = (int)Math.Round((y * tParams.Ratio));
                    int pos = (tx + ty * this.resolution) * 3;

                    if (tParams.Settings.RangeHandling == RangeHandling.Absolute)
                        value = Math.Abs(value) * tParams.Settings.Intensity;
                    else if (tParams.Settings.RangeHandling == RangeHandling.Clamp)
                        value = Math.Min(Math.Max(0, value), 1) * tParams.Settings.Intensity;
                    else if (tParams.Settings.RangeHandling == RangeHandling.InverseAbsolute)
                        value = 1f - Math.Abs(value) * tParams.Settings.Intensity;
                    else if (tParams.Settings.RangeHandling == RangeHandling.None)
                        value *= tParams.Settings.Intensity;
                    else if (tParams.Settings.RangeHandling == RangeHandling.Shift)
                        value = (value + 1) / 2 * tParams.Settings.Intensity;

                    Color col = new Vector(value).ToColor(tParams.Settings.Highlight, tParams.Settings.Shadow, tParams.Settings.Wrap, tParams.Settings.ChannelWrap);

                    this.texels[pos] = (byte)(Math.Min(this.texels[pos] + col.B, 255));
                    this.texels[pos + 1] = (byte)(Math.Min(this.texels[pos + 1] + col.G, 255));
                    this.texels[pos + 2] = (byte)(Math.Min(this.texels[pos + 2] + col.R, 255));
                }
                Interlocked.Increment(ref this.progress);
            }
        }

        private static float Omega(float u)
        {
            u = Math.Abs(u);
            if (u < 1)
            {
                float uu = u * u;
                return 2 * uu * u - 3 * uu + 1;
            }
            return 0;
        }

        private static void Scramble(int[] array, Random r)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int j = r.Next(array.Length);
                int t = array[i];
                array[i] = array[j];
                array[j] = t;
            }
        }
    }

    /// <summary>
    /// Represents the settings to be used when generating Perlin noise.
    /// </summary>
    public class PerlinNoiseSettings
    {
        /// <summary>
        /// The intensity multiplier.
        /// </summary>
        public float Intensity;
        /// <summary>
        /// The base size of the noise array.
        /// </summary>
        public int Offset;
        /// <summary>
        /// The levels of turbulence to create.
        /// </summary>
        public int Levels;
        /// <summary>
        /// How to handle values (in the range [-1, 1]) that are generated.
        /// - Absolute: take the absolute value
        /// - Clamp: clamp the value between 0 and 1
        /// - InverseAbsolute: take 1 minus the absolute value
        /// - Shift: add 1 and divide by 2
        /// </summary>
        public RangeHandling RangeHandling;
        /// <summary>
        /// The base colour of the image to create.
        /// </summary>
        public Color Shadow;
        /// <summary>
        /// The highlight colour of the image to create.
        /// </summary>
        public Color Highlight;
        /// <summary>
        /// When set to <code>true</code>, causes values that exceed 1 to wrap back to 0.
        /// </summary>
        public bool Wrap;
        /// <summary>
        /// When set to <code>true</code>, allows channels to wrap individually.
        /// </summary>
        public bool ChannelWrap;

        /// <summary>
        /// Parse <code>PerlinNoiseSettings</code> from a string representation.
        /// </summary>
        /// <param name="s">The string to parse the <code>PerlinNoiseSettings</code> from.</param>
        /// <returns>A <code>PerlinNoiseSettings</code> that the input string represents.</returns>
        public static PerlinNoiseSettings Parse(string s)
        {
            try
            {
                PerlinNoiseSettings settings = new PerlinNoiseSettings();
                string[] parts = s.Split(',');

                settings.Intensity = float.Parse(parts[0], CultureInfo.CreateSpecificCulture("en-GB"));
                settings.Levels = int.Parse(parts[1]);
                settings.Offset = int.Parse(parts[2]);
                settings.RangeHandling = (RangeHandling)Enum.Parse(typeof(RangeHandling), parts[3]);
                settings.Highlight = Color.FromArgb(byte.Parse(parts[4]), byte.Parse(parts[5]), byte.Parse(parts[6]));
                settings.Shadow = Color.FromArgb(byte.Parse(parts[7]), byte.Parse(parts[8]), byte.Parse(parts[9]));
                settings.Wrap = bool.Parse(parts[10]);
                settings.ChannelWrap = bool.Parse(parts[11]);

                return settings;
            }
            catch (Exception e) { throw new FormatException("The input string is not in the correct format.", e); }
        }

        /// <summary>
        /// Returns a string representation of the current <code>PerlinNoiseSettings</code> object.
        /// </summary>
        /// <returns>A string representation of the current <code>PerlinNoiseSettings</code> object.</returns>
        public override string ToString()
        {
            return this.Intensity.ToString("0.00", CultureInfo.CreateSpecificCulture("en-GB")) + ", " +
                    this.Levels + ", " +
                    this.Offset + ", " +
                    this.RangeHandling.ToString() + ", " +
                    this.Highlight.R + ", " +
                    this.Highlight.G + ", " +
                    this.Highlight.B + ", " +
                    this.Shadow.R + ", " +
                    this.Shadow.G + ", " +
                    this.Shadow.B + ", " +
                    this.Wrap + ", " +
                    this.ChannelWrap;
        }
    }

    struct Vector2
    {
        public float X, Y;

        public Vector2(float x, float y) { this.X = x; this.Y = y; }

        public static float Dot(Vector2 a, Vector2 b) { return a.X * b.X + a.Y * b.Y; }

        public float Length() { return (float)Math.Sqrt(this.X * this.X + this.Y * this.Y); }

        public void Normalize()
        {
            float length = this.Length();
            this.X /= length;
            this.Y /= length;
        }
    }

    struct Vector
    {
        private float val;

        public Vector(float val) { this.val = val; }

        public Color ToColor(Color highlight, Color shadow, bool wrap, bool channelWrap)
        {
            float x, y, z;
            if (wrap)
                if (channelWrap)
                    x = y = z = this.val;
                else
                    x = y = z = this.val % 1;
            else
                x = y = z = this.val < 0 ? 0 : this.val > 1 ? 1 : this.val;

            x = x * highlight.R + (1 - x) * shadow.R;
            y = y * highlight.G + (1 - y) * shadow.G;
            z = z * highlight.B + (1 - z) * shadow.B;
            return Color.FromArgb((byte)x, (byte)y, (byte)z);
        }
    }

    class ThreadParams
    {
        public float Ratio, Start;
        public int Step;
        public PerlinNoiseSettings Settings;

        public ThreadParams(float ratio, float start, int step, PerlinNoiseSettings settings)
        {
            this.Ratio = ratio;
            this.Start = start;
            this.Step = step;
            this.Settings = settings;
        }
    }
}