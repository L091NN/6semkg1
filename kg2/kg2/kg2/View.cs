using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace kg2
{
    class View
    {
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

        private Color TransferFunction(int value)
        {
            const int min = 0x0;
            const int max = 0x7D0;
            int new_val = Clamp((int)((value - min) * 255.0f / (max - min)), 0, 0xff);

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
