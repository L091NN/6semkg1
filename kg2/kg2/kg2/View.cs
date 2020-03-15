using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace kg2
{
    class View
    {
        private Bitmap texture_image;
        private int texture_index;
        public int min   { get; set; }
        public int width { get; set; }

        public void SetupView(Bin bin, int width, int height)
        {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0f, bin.x, 0.0f, bin.y, -1.0f, 1.0f);
            GL.Viewport(0, 0, width, height);
        }


        public void DrawQuads(Bin bin, int layer_number)
        {
            int value;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Begin(BeginMode.Quads);
            for(int x = 0; x < bin.x; ++x)
            {
                for(int y = 0; y < bin.y; ++y)
                {
                    value = bin.array[x + y * bin.x + layer_number * bin.x * bin.y];
                    GL.Color3(TransferFunction(value));
                    GL.Vertex2(x, y);

                    value = bin.array[x + (y + 1) * bin.x + layer_number * bin.x * bin.y];
                    GL.Color3(TransferFunction(value));
                    GL.Vertex2(x, y + 1);

                    value = bin.array[x + 1 + (y + 1) * bin.x + layer_number * bin.x * bin.y];
                    GL.Color3(TransferFunction(value));
                    GL.Vertex2(x + 1, y + 1);

                    value = bin.array[x + 1 + y * bin.x + layer_number * bin.x * bin.y];
                    GL.Color3(TransferFunction(value));
                    GL.Vertex2(x + 1, y);
                }
            }
            GL.End();
        }


        public void DrawQuadStrips(Bin bin, int layer_number)
        {
            int value;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            for(int x = 0; x < bin.x; ++x)
            {
                GL.Begin(BeginMode.QuadStrip);

                value = bin.array[x + 0 * bin.x + layer_number * bin.x * bin.y];
                GL.Color3(TransferFunction(value));
                GL.Vertex2(x, 0);

                value = bin.array[x + 1 + 0 * bin.x + layer_number * bin.x * bin.y];
                GL.Color3(TransferFunction(value));
                GL.Vertex2(x + 1, 0);

                value = bin.array[x + (0 + 1) * bin.x + layer_number * bin.x * bin.y];
                GL.Color3(TransferFunction(value));
                GL.Vertex2(x, 0 + 1);

                value = bin.array[x + 1 + (0 + 1) * bin.x + layer_number * bin.x * bin.y];
                GL.Color3(TransferFunction(value));
                GL.Vertex2(x + 1, 0 + 1);


                for (int y = 1; y < bin.y; ++y)
                {
                    value = bin.array[x + (y + 1) * bin.x + layer_number * bin.x * bin.y];
                    GL.Color3(TransferFunction(value));
                    GL.Vertex2(x, y + 1);

                    value = bin.array[x + 1 + (y + 1) * bin.x + layer_number * bin.x * bin.y];
                    GL.Color3(TransferFunction(value));
                    GL.Vertex2(x + 1, y + 1);
                }

                GL.End();
            }
        }


        public void Load2DTexture()
        {
            GL.BindTexture(TextureTarget.Texture2D, texture_index);
            BitmapData bitmap_data = texture_image.LockBits(
                new System.Drawing.Rectangle(0, 0, texture_image.Width, texture_image.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmap_data.Width, bitmap_data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmap_data.Scan0);

            texture_image.UnlockBits(bitmap_data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        }


        public void GenerateTextureImage(Bin bin, int layer_number)
        {
            texture_image = new Bitmap(bin.x, bin.y);

            for(int i = 0; i < bin.x; ++i)
            {
                for(int j = 0; j < bin.y; ++j)
                {
                    int pixel_number = i + j * bin.x + layer_number * bin.x * bin.y;
                    texture_image.SetPixel(i, j, TransferFunction(bin.array[pixel_number]));
                }
            }
        }


        public void DrawTexture(Bin bin)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texture_index);

            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.White);

            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex2(0.0, 0.0);

            GL.TexCoord2(0.0f, 1.0f);
            GL.Vertex2(0.0, bin.y);

            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex2(bin.x, bin.y);

            GL.TexCoord2(1.0f, 0.0f);
            GL.Vertex2(bin.x, 0.0);

            GL.End();

            GL.Disable(EnableCap.Texture2D);
        }


        private Color TransferFunction(int value)
        {
            int max = min + width;
            int new_val = Clamp((int)((value - min) * 255.0 / (max - min)), 0, 0xff);

            return Color.FromArgb(0xff, new_val, new_val, new_val);
        }


        private int Clamp(int value, int min, int max)
        {
            if (min > value)
            {
                return min;
            }
            else if (max < value)
            {
                return max;
            }

            return value;
        }
    }
}
