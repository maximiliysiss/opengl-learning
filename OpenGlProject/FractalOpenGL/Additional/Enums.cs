using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalOpenGL.Additional
{
    public enum DrawMode
    {
        Standard,
        Custom
    }

    public static class DrawSettings
    {
        private static readonly double[] values = new[] { 0.34, 0.12 };

        public static double ToValue(this DrawMode drawMode, int? index = null)
        {
            if (drawMode != DrawMode.Custom)
                return 0;
            return values[index ?? 0];
        }
    }
}
