using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kg1
{
    class Sepia : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
            float k = 40.1f;

            return Color.FromArgb(clamp((int)(intensity + 2 * k), 0, 255), clamp((int)(intensity + 0.5f * k), 0, 255), clamp((int)(intensity - k), 0, 255));
        }
    }
}
