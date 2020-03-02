using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kg1
{
    class Waves1 : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int new_x = (int)(x + 20.0 * Math.Sin(2.0 * Math.PI * y / 60.0));
            int new_y = y;

            if((0 > new_x) || (sourceImage.Width <= new_x))
            {
                return Color.FromArgb(0, 0, 0);
            }

            return sourceImage.GetPixel(new_x, new_y);
        }
    }

    class Waves2 : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int new_x = (int)(x + 20.0 * Math.Sin(2.0 * Math.PI * x / 30.0));
            int new_y = y;

            if ((0 > new_x) || (sourceImage.Width <= new_x))
            {
                return Color.FromArgb(0, 0, 0);
            }

            return sourceImage.GetPixel(new_x, new_y);
        }
    }
}
