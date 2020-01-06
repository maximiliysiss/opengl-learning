using System.Drawing;

namespace OpenGlProject.OpenGlElements
{
    /// <summary>
    /// 
    /// </summary>
    public class Brush : Vertex2D
    {
        /// <summary>
        /// Width for line (const)
        /// </summary>
        protected float width = 5;
        public float Widht => width;

        public override VertexType VertexType => VertexType.Brush;

        public Brush()
        {
        }

        public Brush(float x, float y) : base(x, y)
        {
        }

        public Brush(Color color, float x, float y) : base(color, x, y)
        {
        }
    }
}
