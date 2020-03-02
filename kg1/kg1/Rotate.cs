using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kg1
{
    class Rotate : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int x_center = sourceImage.Width  / 2;
            int y_center = sourceImage.Height / 2;
            double angle = 0.5;

            int new_x = (int)((x - x_center) * Math.Cos(angle) - (y - y_center) * Math.Sin(angle) + x_center);
            int new_y = (int)((x - x_center) * Math.Sin(angle) + (y - y_center) * Math.Cos(angle) + y_center);

            if((0 > new_x) || (sourceImage.Width  <= new_x))
            {
                return Color.FromArgb(0, 0, 0);
            }
            if((0 > new_y) || (sourceImage.Height <= new_y))
            {
                return Color.FromArgb(0, 0, 0);
            }

            return sourceImage.GetPixel(new_x, new_y);
        }
    }
}
