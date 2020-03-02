using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kg1
{
    class Dilation : Morphology
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int x_center = Morphology.x / 2;
            int y_center = Morphology.y / 2;

            if (((x_center <= x) && (sourceImage.Width  - x_center) > x) &&
                ((y_center <= y) && (sourceImage.Height - y_center) > y))
            {
                return findMax(sourceImage, x, y);
            }

            return sourceImage.GetPixel(x, y);
        }
    }
}
