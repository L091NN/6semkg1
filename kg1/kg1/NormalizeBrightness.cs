using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kg1
{
    class NormalizeBrightness : Filters
    {
        int min_index_red;
        int min_index_green;
        int min_index_blue;

        int max_index_red;
        int max_index_green;
        int max_index_blue;

        bool indexes_calculated = false;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            if (!indexes_calculated)
            {
                min_index_red   = GetMinIndex(sourceImage, true, false, false);
                min_index_green = GetMinIndex(sourceImage, false, true, false);
                min_index_blue  = GetMinIndex(sourceImage, false, false, true);

                max_index_red   = GetMaxIndex(sourceImage, true, false, false);
                max_index_green = GetMaxIndex(sourceImage, false, true, false);
                max_index_blue  = GetMaxIndex(sourceImage, false, false, true);

                indexes_calculated = true;
            }

            int red   = sourceColor.R;
            int green = sourceColor.G;
            int blue  = sourceColor.B;

            return Color.FromArgb(clamp((int)((0xff * (double)(red   - min_index_red))   / (double)(clamp(max_index_red   - min_index_red,   1, 0xff))), 0, 0xff),
                                  clamp((int)((0xff * (double)(green - min_index_green)) / (double)(clamp(max_index_green - min_index_green, 1, 0xff))), 0, 0xff),
                                  clamp((int)((0xff * (double)(blue  - min_index_blue))  / (double)(clamp(max_index_blue  - min_index_blue,  1, 0xff))), 0, 0xff));
        }


        private int GetMinIndex(Bitmap sourceImage, bool red, bool green, bool blue)
        {
            int min_index = 0;

            for (int i = 0; i < sourceImage.Width; ++i)
            {
                for (int j = 0; j < sourceImage.Height; ++j)
                {
                    Color currentColor = sourceImage.GetPixel(i, j);
                    int value = (red) ? (currentColor.R) : (green) ? (currentColor.G) : (currentColor.B);

                    if (0 != value)
                    {
                        min_index = j + i * sourceImage.Width;
                        return min_index;
                    }
                }
            }

            return min_index;
        }


        private int GetMaxIndex(Bitmap sourceImage, bool red, bool green, bool blue)
        {
            int max_index = 0;

            for (int i = sourceImage.Width - 1; i >= 0; --i)
            {
                for (int j = sourceImage.Height - 1; j >= 0; --j)
                {
                    Color currentColor = sourceImage.GetPixel(i, j);
                    int value = (red) ? (currentColor.R) : (green) ? (currentColor.G) : (currentColor.B);

                    if (0 != value)
                    {
                        max_index = j + i * sourceImage.Width;
                        return max_index;
                    }
                }
            }

            return max_index;
        }
    }
}
