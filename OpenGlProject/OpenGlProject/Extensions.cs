using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGlProject
{
    public static class Extensions
    {
        public static byte[] ImageToByte(this Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public static float[] ToArray(this Color color) => new[] { (float)color.R, color.G, color.B };
        public static float ToArray(this Color color, int index) => color.ToArray()[index];
        public static Color ToColor(this float[] data) => Color.FromArgb((int)data[0], (int)data[1], (int)data[2]);

        public static void SetPixelCoord(this Bitmap bitmap, int x, int y, int index, int data)
        {
            var color = bitmap.GetPixel(x, y);
            var colorData = color.ToArray();
            colorData[index] = data;
            bitmap.SetPixel(x, y, colorData.ToColor());
        }
    }
}
