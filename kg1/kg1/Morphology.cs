using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kg1
{
    class Morphology : Filters
    {
        public static int x = 10;
        public static int y = 10;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }

        protected int GetGrayscale(Color color)
        {
            return (color.R + color.G + color.B) / 3;
        }

        protected Color findMax(Bitmap sourceImage, int x, int y)
        {
            Color max = Color.FromArgb(0, 0, 0);

            for (int i = x - Morphology.x / 2; i < x + Morphology.x / 2; ++i)
            {
                for (int j = y - Morphology.y / 2; j < y + Morphology.y / 2; ++j)
                {
                    int currentColor = GetGrayscale(sourceImage.GetPixel(i, j));

                    if (currentColor > GetGrayscale(max))
                    {
                        max = sourceImage.GetPixel(i, j);
                    }
                }
            }

            return max;
        }

        protected Color findMin(Bitmap sourceImage, int x, int y)
        {
            Color min = Color.FromArgb(0xff, 0xff, 0xff);

            for (int i = x - Morphology.x / 2; i < x + Morphology.x / 2; ++i)
            {
                for (int j = y - Morphology.y / 2; j < y + Morphology.y / 2; ++j)
                {
                    int currentColor = GetGrayscale(sourceImage.GetPixel(i, j));

                    if (currentColor < GetGrayscale(min))
                    {
                        min = sourceImage.GetPixel(i, j);
                    }
                }
            }

            return min;
        }
    }
}
