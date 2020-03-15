using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kg1
{
    class GrayWorld : Filters
    {
        private bool avg_calculated = false;
        private int  avg_red;
        private int  avg_green;
        private int  avg_blue;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int width  = sourceImage.Width;
            int height = sourceImage.Height;
            int total_pixels_count = width * height;

            if(!avg_calculated)
            {
                avg_red   = 0;
                avg_green = 0;
                avg_blue  = 0;

                for(int i = 0; i < width; ++i)
                {
                    for(int j = 0; j < height; ++j)
                    {
                        avg_red   += sourceImage.GetPixel(i, j).R;
                        avg_green += sourceImage.GetPixel(i, j).G;
                        avg_blue  += sourceImage.GetPixel(i, j).B;
                    }
                }

                avg_red   = (0 == (avg_red   / total_pixels_count)) ? (1) : 
                                  (avg_red   / total_pixels_count);
                avg_green = (0 == (avg_green / total_pixels_count)) ? (1) : 
                                  (avg_green / total_pixels_count);
                avg_blue  = (0 == (avg_blue  / total_pixels_count)) ? (1) : 
                                  (avg_blue  / total_pixels_count);

                avg_calculated = true;
            }

            Color sourceColor = sourceImage.GetPixel(x, y);

            int common_avg = (avg_red + avg_green + avg_blue) / 3;

            int red   = sourceColor.R;
            int green = sourceColor.G;
            int blue  = sourceColor.B;

            byte new_red   = (byte)clamp((int)(red   * ((double)common_avg / (double)avg_red)),   0, 0xff);
            byte new_green = (byte)clamp((int)(green * ((double)common_avg / (double)avg_green)), 0, 0xff);
            byte new_blue  = (byte)clamp((int)(blue  * ((double)common_avg / (double)avg_blue)),  0, 0xff);

            return Color.FromArgb(new_red, new_green, new_blue);
        }
    }
}
