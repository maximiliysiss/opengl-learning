using SharpGL;
using System.Collections.Generic;
using System.Drawing;

namespace OpenGlProject.Filters
{
    public enum FilterType
    {
        Pixel,
        Image
    }

    public abstract class BasePixelFilter : IFilter
    {
        protected virtual FilterType FilterType => FilterType.Pixel;

        public abstract Color Filter(Color color);

        public void DrawFilter(OpenGLControl gl, List<Layout> layouts)
        {
            if (FilterType == FilterType.Pixel)
                foreach (var layout in layouts)
                    layout.FilterAccesses.ForEach(x => x.Filter(this, gl.OpenGL));
        }

        public void PostDrawFilter(OpenGLControl gl)
        {
            if (FilterType == FilterType.Image)
                AnotherWay(gl);
        }

        public abstract Bitmap Filter(Bitmap bitmap);
        public virtual void AnotherWay(OpenGLControl openGL) { }
    }

    public abstract class BaseImageFilter : BasePixelFilter
    {
        protected override FilterType FilterType => FilterType.Image;

        public override void AnotherWay(OpenGLControl openGL)
        {
            Bitmap bitmap = new Bitmap(openGL.Width, openGL.Height);
            openGL.DrawToBitmap(bitmap, new Rectangle(openGL.Left, openGL.Top, openGL.Width, openGL.Height));
            FilterImage(bitmap);
        }

        public override Color Filter(Color color)
        {
            throw new System.NotImplementedException();
        }

        public override Bitmap Filter(Bitmap bitmap)
        {
            throw new System.NotImplementedException();
        }

        public abstract void FilterImage(Bitmap bitmap);
    }

    public abstract class BaseMatrixFilter : BaseImageFilter
    {
        public abstract float[] Matrix { get; }
        public abstract int Corr { get; }
        public abstract int Coeff { get; }
        public abstract bool NeedCountCorrection { get; }

        public override void FilterImage(Bitmap bitmap) => PixelTransformation(bitmap, Matrix, Corr, Coeff, NeedCountCorrection);

        protected void PixelTransformation(Bitmap bitmap, float[] mat, int corr, float COEFF, bool need_count_correction)
        {
            float[] resault_RGB = new float[3];
            int count = 0;
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int c = 0, ax = 0, bx = 0; c < 3; c++)
                    {
                        resault_RGB[c] = 0;
                        count = 0;
                        for (bx = -1; bx < 2; bx++)
                        {
                            for (ax = -1; ax < 2; ax++)
                            {
                                if (x + ax < 0 || x + ax > bitmap.Width - 1 || y + bx < 0 || y + bx > bitmap.Height - 1)
                                {
                                    resault_RGB[c] += bitmap.GetPixel(x, y).ToArray(c) * mat[count] * COEFF + corr;
                                    continue;
                                }
                                resault_RGB[c] += bitmap.GetPixel(x, y).ToArray(c) * mat[count] * COEFF + corr;
                                count++;
                            }
                        }

                    }

                    for (int c = 0; c < 3; c++)
                    {
                        if (count != 0 && need_count_correction)
                            resault_RGB[c] /= count;
                        if (resault_RGB[c] < 0)
                            resault_RGB[c] = 0;
                        if (resault_RGB[c] > 255)
                            resault_RGB[c] = 255;
                        bitmap.SetPixelCoord(x, y, c, (int)resault_RGB[c]);
                    }

                }

            }

        }
    }
}
