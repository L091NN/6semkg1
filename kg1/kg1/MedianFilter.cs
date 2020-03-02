using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace kg1
{
    class MedianFilter : MatrixFilter
    {
        int sizex;
        int sizey;
        public MedianFilter()
        {
            sizex = 10;
            sizey = 10;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = sizex / 2;
            int radiusY = sizey / 2;

            int[] resultR = new int[sizex * sizey];
            int[] resultG = new int[sizex * sizey];
            int[] resultB = new int[sizex * sizey];

            int n = 0;

            for (int l = -radiusY; l <= radiusY - 1; l++)
            {
                for (int k = -radiusX; k <= radiusX - 1; k++)
                {
                    Color curColor = sourceImage.GetPixel(clamp(x + k, 0, sourceImage.Width - 1), clamp(y + l, 0, sourceImage.Height - 1));
                    resultR[n] = curColor.R;
                    resultG[n] = curColor.G;
                    resultB[n] = curColor.B;
                    n++;
                }
            }

            return Color.FromArgb(
                getMedian(resultR),
                getMedian(resultG),
                getMedian(resultB)
                );
        }

        protected int getMedian(int[] colors)
        {
            Array.Sort(colors);
            return colors[colors.Length / 2];
        }
    }
}
