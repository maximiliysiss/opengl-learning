using SharpGL;
using System.Collections.Generic;
using System.Drawing;

namespace OpenGlProject.Filters
{
    public abstract class BasePixelFilter : IFilter
    {
        protected BasePixelFilter(OpenGL openGL)
        {
            OpenGL = openGL;
        }

        public OpenGL OpenGL { get; set; }

        public abstract Color Filter(Color color);

        public void DrawFilter(OpenGL gl, List<Layout> layouts)
        {
            foreach (var layout in layouts)
                layout.FilterAccesses.ForEach(x => x.Filter(this, this.OpenGL));
        }

        public abstract Bitmap Filter(Bitmap bitmap);
    }
}
