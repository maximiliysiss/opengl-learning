using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OpenGlProject.Filters
{
    public interface IFilter
    {
        void DrawFilter(OpenGLControl gl, List<Layout> layouts);
        Color Filter(Color color);
        Bitmap Filter(Bitmap bitmap);
        void PostDrawFilter(OpenGLControl gl);
    }

    public class EmptyFilter : IFilter
    {
        public Color Filter(Color color)
        {
            throw new NotImplementedException();
        }

        public void DrawFilter(OpenGLControl gl, List<Layout> layouts)
        {
            foreach (var layout in layouts)
                layout.FilterAccesses.ForEach(x => x.Filter(null, gl.OpenGL));
        }

        public Bitmap Filter(Bitmap color)
        {
            throw new NotImplementedException();
        }

        public void PostDrawFilter(OpenGLControl gl)
        {
        }
    }
}
