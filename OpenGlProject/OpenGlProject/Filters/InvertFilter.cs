using SharpGL;
using System.Drawing;

namespace OpenGlProject.Filters
{
    public class InvertFilter : BasePixelFilter
    {
        public override Color Filter(Color color) => Color.FromArgb(color.ToArgb() ^ 0xffffff);

        public override Bitmap Filter(Bitmap bitmap)
        {
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    var pixel = bitmap.GetPixel(i, j);
                    bitmap.SetPixel(i, j, Filter(pixel));
                }
            }
            return bitmap;
        }
    }
}
