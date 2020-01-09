using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGlProject.OpenGlElements
{
    public class Spline : Vertex2D
    {
        public Spline()
        {
        }

        public Spline(float x, float y) : base(x, y)
        {
        }

        public Spline(Color color, float x, float y) : base(color, x, y)
        {
        }

        public override VertexType VertexType => VertexType.Spline;
    }
}
