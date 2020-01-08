using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OpenGlProject.Filters
{
    public interface IFilter
    {
        void DrawFilter(OpenGL gl, List<Layout> layouts);
        Color Filter(Color color);
        Bitmap Filter(Bitmap bitmap);
        OpenGL OpenGL { get; set; }
    }

    public class EmptyFilter : IFilter
    {
        public OpenGL OpenGL { get; set; }

        public Color Filter(Color color)
        {
            throw new NotImplementedException();
        }

        public void DrawFilter(OpenGL gl, List<Layout> layouts)
        {
            foreach (var layout in layouts)
                layout.FilterAccesses.ForEach(x => x.Filter(null, this.OpenGL));
        }

        public Bitmap Filter(Bitmap color)
        {
            throw new NotImplementedException();
        }
    }
}
