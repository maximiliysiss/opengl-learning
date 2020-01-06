using System.Drawing;

namespace OpenGlProject.OpenGlElements
{
    /// <summary>
    /// 
    /// </summary>
    public class Eraser : Brush
    {
        public Eraser(Color color, float x, float y) : base(color, x, y)
        {
            // new line width
            this.width = 20;
        }

        public override VertexType VertexType => VertexType.Eraser;
    }
}
