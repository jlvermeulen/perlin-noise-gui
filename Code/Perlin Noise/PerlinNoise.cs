using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;

public enum RangeHandling { Absolute, Clamp, InverseAbsolute, Shift };

namespace PerlinNoise
{
    public class PerlinNoiseGenerator
    {
        public static Bitmap GetImage(PerlinNoiseSettings settings)
        {
            PerlinNoiseGenerator generator = new PerlinNoiseGenerator(settings);
            Bitmap bmp = new Bitmap(settings.Resolution, settings.Resolution, PixelFormat.Format24bppRgb);
            byte[] colours = generator.Generate();
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            Marshal.Copy(colours, 0, ptr, colours.Length);
            bmp.UnlockBits(bmpData);
            return bmp;
        }

        public static Bitmap GetImage2(PerlinNoiseSettings settings)
        {
            PerlinNoiseGenerator generator = new PerlinNoiseGenerator(settings);
            Bitmap bmp = new Bitmap(settings.Resolution, settings.Resolution);
            byte[] colours = generator.Generate();
            for (int i = 0; i < settings.Resolution; i++)
                for (int j = 0; j < settings.Resolution; j++)
                    bmp.SetPixel(i, j, Color.FromArgb(colours[(i + j * settings.Resolution) * 3], colours[(i + j * settings.Resolution) * 3 + 1], colours[(i + j * settings.Resolution) * 3 + 2]));
            return bmp;
        }

        PerlinNoiseSettings settings;
        byte[] texels;
        Vector2[] vectors;
        int[] hashLookup;
        int[,] vectorIndices;
        int arraySize;

        private PerlinNoiseGenerator(PerlinNoiseSettings settings)
        {
            this.settings = settings;
        }

        private byte[] Generate()
        {
            Thread[] threads = new Thread[settings.Threads];
            Random random;
            if (settings.Seed != 0)
                random = new Random(settings.Seed);
            else
                random = new Random();

            texels = new byte[settings.Resolution * settings.Resolution * 3];
            for (int n = 0; n < settings.Levels; n++)
            {
                arraySize = (int)Math.Pow(2, settings.Offset + 1);
                float ratio = (float)settings.Resolution / arraySize;

                vectors = new Vector2[arraySize];
                hashLookup = new int[arraySize];

                for (int i = 0; i < arraySize; i++)
                {
                    vectors[i].X = 2 * (float)random.NextDouble() - 1;
                    vectors[i].Y = 2 * (float)random.NextDouble() - 1;
                    if (vectors[i].Length() < 1)
                        vectors[i].Normalize();
                    else if (i > 0)
                        i--;
                    else
                        i = 0;
                    hashLookup[i] = i;
                }

                Scramble(hashLookup, random);

                vectorIndices = new int[arraySize + 1, arraySize + 1];
                for (int x = 0; x < arraySize + 1; x++)
                    for (int y = 0; y < arraySize + 1; y++)
                        vectorIndices[x, y] = hashLookup[(x + hashLookup[y % arraySize]) % arraySize];

                for (int i = 0; i < settings.Threads; i++)
                    threads[i] = new Thread(new ParameterizedThreadStart(FillTexels));
                for (int i = 0; i < settings.Threads; i++)
                    threads[i].Start(new ThreadParams(ratio, i / ratio, settings.Threads));
                for (int i = 0; i < settings.Threads; i++)
                    threads[i].Join();
                settings.Offset++;
            }
            return texels;
        }

        private void FillTexels(object data)
        {
            ThreadParams tParams = (ThreadParams)data;
            for (float x = tParams.Start; x < arraySize; x += tParams.Step / tParams.Ratio)
                for (float y = 0; y < arraySize; y += 1.0f / tParams.Ratio)
                {
                    float value = 0;

                    int fx = (int)Math.Floor(x);
                    int fy = (int)Math.Floor(y);
                    for (int i = fx; i <= fx + 1; i++)
                        for (int j = fy; j <= fy + 1; j++)
                            value += Omega(x - i) * Omega(y - j) * Vector2.Dot(vectors[vectorIndices[i, j]], new Vector2(x - i, y - j));

                    int tx = (int)Math.Round((x * tParams.Ratio));
                    int ty = (int)Math.Round((y * tParams.Ratio));
                    int pos = (tx + ty * settings.Resolution) * 3;

                    if (settings.RangeHandling == RangeHandling.Absolute)
                        value = Math.Abs(value) * settings.Intensity;
                    else if (settings.RangeHandling == RangeHandling.Clamp)
                        value = value * settings.Intensity;
                    else if (settings.RangeHandling == RangeHandling.InverseAbsolute)
                        value = 1f - Math.Abs(value) * settings.Intensity;
                    else if (settings.RangeHandling == RangeHandling.Shift)
                        value = (value + 1) / 2 * settings.Intensity;

                    Color col = new Vector3(value).ToColor(settings.Highlight, settings.Shadow, settings.Wrap);

                    texels[pos] = (byte)(Math.Min(texels[pos] + col.B, 255));
                    texels[pos + 1] = (byte)(Math.Min(texels[pos + 1] + col.G, 255));
                    texels[pos + 2] = (byte)(Math.Min(texels[pos + 2] + col.R, 255));
                }
        }

        private static float Omega(float u)
        {
            u = Math.Abs(u);
            if (u < 1)
                u = 2 * (float)Math.Pow(u, 3) - 3 * (float)Math.Pow(u, 2) + 1;
            else
                u = 0;

            return u;
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

        private static byte Mul(byte left, byte right)
        {
            return (byte)(left * ((float)right / 255));
        }
    }

    public class PerlinNoiseSettings
    {
        public int Seed;
        public int Resolution;
        public float Intensity;
        public int Offset;
        public int Levels;
        public RangeHandling RangeHandling;
        public int Threads;
        public Color Shadow;
        public Color Highlight;
        public bool Wrap;
    }

    struct Vector2
    {
        public float X, Y;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static float Dot(Vector2 a, Vector2 b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public float Length()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        public void Normalize()
        {
            float length = Length();
            X /= length;
            Y /= length;
        }
    }

    struct Vector3
    {
        public float X, Y, Z;

        public Vector3(float val)
        {
            X = Y = Z = val;
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Color ToColor(Color highlight, Color shadow, bool wrap)
        {
            float x, y, z;
            if (wrap)
            {
                x = X;
                y = Y;
                z = Z;
            }
            else
            {
                x = X < 0 ? 0 : X > 1 ? 1 : X;
                y = Y < 0 ? 0 : Y > 1 ? 1 : Y;
                z = Z < 0 ? 0 : Z > 1 ? 1 : Z;
            }
            x = x * highlight.R + (1 - x) * shadow.R;
            y = y * highlight.G + (1 - y) * shadow.G;
            z = z * highlight.B + (1 - z) * shadow.B;
            return Color.FromArgb((byte)x, (byte)y, (byte)z);
        }
    }

    class ThreadParams
    {
        public float Ratio;
        public float Start;
        public int Step;

        public ThreadParams(float ratio, float start, int step)
        {
            Ratio = ratio;
            Start = start;
            Step = step;
        }
    }
}
/*
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

enum RangeHandling { Absolute, Clamp, InverseAbsolute, Shift };

class PerlinNoiseGenerator
{
    GraphicsDevice device;
    Random random;
    RenderTarget2D target1, target2;
    Effect merge;
    VertexPositionTexture[] screenVertices;
    short[] screenIndices;

    public PerlinNoiseGenerator(GraphicsDevice device, Effect merge)
    {
        this.device = device;

        screenVertices = new VertexPositionTexture[] 
                { 
                    new VertexPositionTexture(new Vector3(-1, 1, 0), new Vector2(0, 0)),
                    new VertexPositionTexture(new Vector3(1, 1, 0), new Vector2(1, 0)),
                    new VertexPositionTexture(new Vector3(-1, -1, 0), new Vector2(0, 1)),
                    new VertexPositionTexture(new Vector3(1, -1, 0), new Vector2(1, 1))
                };
        screenIndices = new short[] { 0, 1, 2, 1, 3, 2 };

        target1 = new RenderTarget2D(device, device.Viewport.Width, device.Viewport.Height, false, device.DisplayMode.Format, DepthFormat.Depth24);
        target2 = new RenderTarget2D(device, device.Viewport.Width, device.Viewport.Height, false, device.DisplayMode.Format, DepthFormat.Depth24);

        this.merge = merge;
    }

    public Texture2D GenerateTurbulentTexture(int seed, int size, float intensity, int levels, int levelOffset, RangeHandling rangeHandling)
    {
        Random r = new Random(seed);
        List<Texture2D> textures = new List<Texture2D>();

        // generate texture with increasing level of detail
        for (int i = 1; i <= levels; i++)
            textures.Add(GenerateTexture(r.Next(), size, (int)Math.Pow(2, i + levelOffset), intensity / levels, rangeHandling));

        return AddImages(textures);
    }

    public Texture2D GenerateTexture(int seed, int size, int arraySize, float intensity, RangeHandling rangeHandling)
    {
        random = new Random(seed);
        float ratio = (float)size / arraySize;
        // Adjust brightness depending on RangeHandling
        if (rangeHandling == RangeHandling.Shift)
            intensity *= 0.25f;
        else if (rangeHandling == RangeHandling.InverseAbsolute)
            intensity *= 5;

        // final image
        Color[] texels = new Color[size * size];

        // create 1D array of random 2D unit vectors
        Vector2[] vectors = new Vector2[arraySize];
        int[] hashLookup = new int[arraySize];

        // generate random vectors and fill hashLookup array with values 0-arraySize
        for (int i = 0; i < arraySize; i++)
        {
            vectors[i].X = 2 * (float)random.NextDouble() - 1;
            vectors[i].Y = 2 * (float)random.NextDouble() - 1;
            if (vectors[i].Length() < 1)
                vectors[i].Normalize();
            else if (i > 0)
                i--;
            else
                i = 0;
            hashLookup[i] = i;
        }

        // generate permutation of numbers 0-arraySize
        Scramble(hashLookup);

        // link lattice grid points to random vectors
        int[,] vectorIndices = new int[arraySize + 1, arraySize + 1];
        for (int x = 0; x < arraySize + 1; x++)
            for (int y = 0; y < arraySize + 1; y++)
                vectorIndices[x, y] = hashLookup[(x + hashLookup[y % arraySize]) % arraySize];
        
        // hermite interpolation
        for (float x = 0; x < arraySize; x += 1.0f / ratio)
            for (float y = 0; y < arraySize; y += 1.0f / ratio)
            {
                float value = 0;

                int fx = (int)Math.Floor(x);
                int fy = (int)Math.Floor(y);
                for (int i = fx; i <= fx + 1; i++)
                    for (int j = fy; j <= fy + 1; j++)
                        value += Omega(x - i) * Omega(y - j) * Vector2.Dot(vectors[vectorIndices[i, j]], new Vector2(x - i, y - j));

                // place value in correct pixel
                int tx = (int)Math.Round((x * ratio));
                int ty = (int)Math.Round((y * ratio));

                // process colour ranges based on RangeHandling parameter
                if (rangeHandling == RangeHandling.Absolute)
                    texels[tx + ty * size] = new Color(Math.Abs(value) * intensity, Math.Abs(value) * intensity, Math.Abs(value) * intensity);
                else if (rangeHandling == RangeHandling.Clamp)
                {
                    value *= intensity;
                    texels[tx + ty * size] = new Color(value, value, value);
                }
                else if (rangeHandling == RangeHandling.InverseAbsolute)
                    texels[tx + ty * size] = new Color(1f - Math.Abs(value) * intensity, 1f - Math.Abs(value) * intensity, 1f - Math.Abs(value) * intensity);
                else if (rangeHandling == RangeHandling.Shift)
                    texels[tx + ty * size] = new Color((value + 1) * intensity, (value + 1) * intensity, (value + 1) * intensity);
            }
        
        Texture2D texture = new Texture2D(device, size, size, false, SurfaceFormat.Color);
        texture.SetData(texels);
        
        return texture;
    }

    // omega function for hermite interpolation
    float Omega(float u)
    {
        u = Math.Abs(u);
        if (u < 1)
            u = 2 * (float)Math.Pow(u, 3) - 3 * (float)Math.Pow(u, 2) + 1;
        else
            u = 0;

        return u;
    }

    // simple scramble function which switches every position in the array with a random other position
    void Scramble(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int j = random.Next(array.Length);
            int t = array[i];
            array[i] = array[j];
            array[j] = t;
        }
    }

    // add all colour values of a list of images
    Texture2D AddImages(List<Texture2D> list)
    {
        RenderTarget2D result = new RenderTarget2D(device, list[0].Width, list[0].Height, false, device.DisplayMode.Format, DepthFormat.Depth24);
        merge.CurrentTechnique = merge.Techniques["Add"];

        for (int i = 0; i < list.Count; i++)
        {
            device.SetRenderTarget(i % 2 == 0 ? target1 : target2);
            merge.Parameters["Image1"].SetValue(result);
            merge.Parameters["Image2"].SetValue(list[i]);
            merge.CurrentTechnique.Passes[0].Apply();
            device.Clear(Color.Black);
            device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, screenVertices, 0, screenVertices.Length, screenIndices, 0, screenIndices.Length / 3);
            result = i % 2 == 0 ? target1 : target2;
        }

        device.SetRenderTarget(null);

        return result;
    }

    // multiply all colour values of one image with those of another image
    Texture2D MulImages(Texture2D image1, Texture2D image2)
    {
        merge.CurrentTechnique = merge.Techniques["Mul"];

        RenderTarget2D result = new RenderTarget2D(device, image1.Width, image1.Height, false, device.DisplayMode.Format, DepthFormat.Depth24);
        device.SetRenderTarget(result);
        device.Clear(Color.Black);
        merge.Parameters["Image1"].SetValue(image1);
        merge.Parameters["Image2"].SetValue(image2);
        merge.CurrentTechnique.Passes[0].Apply();
        device.Clear(Color.Black);
        device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, screenVertices, 0, screenVertices.Length, screenIndices, 0, screenIndices.Length / 3);

        device.SetRenderTarget(null);

        return result;
    }

    public Texture2D GenerateVineTexture(int seed, int size)
    {
        Random r = new Random(seed);
        Texture2D texture = new Texture2D(device, size, size, false, SurfaceFormat.Color);

        texture = GenerateTurbulentTexture(r.Next(), size, 10.0f, 4, 3, RangeHandling.InverseAbsolute);

        RenderTarget2D mulCol = new RenderTarget2D(device, size, size);
        device.SetRenderTarget(mulCol);
        device.Clear(new Color(0.3f, 0.5f, 0.1f));

        return MulImages(texture, mulCol);
    }

    public Texture2D GenerateGrassTexture(int seed, int size)
    {
        Random r = new Random(seed);
        List<Texture2D> textures = new List<Texture2D>();

        textures.Add(GenerateTurbulentTexture(r.Next(), size, 2.0f, 8, 0, RangeHandling.Clamp));
        textures.Add(GenerateTexture(r.Next(), size, 8, 0.25f, RangeHandling.Shift));

        RenderTarget2D mulCol = new RenderTarget2D(device, size, size);
        device.SetRenderTarget(mulCol);
        device.Clear(new Color(0.5f, 1.0f, 0.5f));

        for (int i = 0; i < textures.Count; i++)
            textures[i] = MulImages(textures[i], mulCol);

        return AddImages(textures);
    }

    public Texture2D GenerateMarbleTexture(int seed, int size)
    {
        Random r = new Random(seed);
        List<Texture2D> textures = new List<Texture2D>();

        textures.Add(GenerateTexture(r.Next(), size, 4, 1.0f, RangeHandling.Clamp));
        textures.Add(GenerateTexture(r.Next(), size, 4, 1.0f, RangeHandling.Clamp));
        textures.Add(GenerateTexture(r.Next(), size, 2, 20.0f, RangeHandling.InverseAbsolute));
        textures.Add(GenerateTexture(r.Next(), size, 4, 20.0f, RangeHandling.InverseAbsolute));
        textures.Add(GenerateTurbulentTexture(r.Next(), size, 0.2f, 2, 3, RangeHandling.Shift));

        return AddImages(textures);
    }

    public Texture2D GenerateWaterTexture(int seed, int size)
    {
        Random r = new Random(seed);
        List<Texture2D> textures = new List<Texture2D>();

        textures.Add(GenerateTexture(r.Next(), size, 2, 0.5f, RangeHandling.InverseAbsolute));
        textures.Add(GenerateTexture(r.Next(), size, 4, 1.0f, RangeHandling.Clamp));
        textures.Add(GenerateTexture(r.Next(), size, 4, 1.0f, RangeHandling.Clamp));
        textures.Add(GenerateTexture(r.Next(), size, 8, 0.25f, RangeHandling.InverseAbsolute));
        textures.Add(GenerateTexture(r.Next(), size, 8, 0.25f, RangeHandling.InverseAbsolute));

        RenderTarget2D mulCol = new RenderTarget2D(device, size, size);
        device.SetRenderTarget(mulCol);
        device.Clear(new Color(0.0075f, 0.15f, 0.2f));

        for (int i = 0; i < textures.Count; i++)
            textures[i] = MulImages(textures[i], mulCol);

        return AddImages(textures);
    }
}
*/