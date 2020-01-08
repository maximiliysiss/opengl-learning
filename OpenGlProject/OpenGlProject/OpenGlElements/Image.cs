using OpenGlProject.Filters;
using SharpGL;
using SharpGL.SceneGraph.Assets;
using System.Drawing;

namespace OpenGlProject.OpenGlElements
{
    /// <summary>
    /// 
    /// </summary>
    public class Image : Vertex2D
    {
        private readonly float width = 0.3f;
        private readonly float height = 0.3f;

        public Texture texture = null;

        Bitmap actualBitmap;
        /// <summary>
        /// Load not from resources for Perfomance
        /// </summary>
        Bitmap bitmap;

        public void LoadTexture(OpenGL gl)
        {
            texture = new Texture();
            texture.Create(gl, bitmap);
        }

        private void RecreateTexture(OpenGL gl)
        {
            texture.Destroy(gl);
            texture.Create(gl, bitmap);
        }

        public Image(Bitmap bitmap, OpenGL gl, float oXCoord, float oYCoord) : base(Color.Black, oXCoord, oYCoord)
        {
            this.bitmap = bitmap;
            this.actualBitmap = (Bitmap)bitmap.Clone();
            LoadTexture(gl);
        }

        public override VertexType VertexType => VertexType.Image;

        public override void Paint(OpenGL gl)
        {
            var startX = this.X - width / 2;
            var startY = this.Y - width / 2;

            gl.TexCoord(0, 1); gl.Vertex(new[] { startX, startY });
            gl.TexCoord(1, 1); gl.Vertex(new[] { startX + width, startY });
            gl.TexCoord(1, 0); gl.Vertex(new[] { startX + width, startY + height });
            gl.TexCoord(0, 0); gl.Vertex(new[] { startX, startY + height });
        }

        public override void PrePaint(OpenGL openGL)
        {
            texture.Bind(openGL);
        }

        public override void Filter(IFilter filter, OpenGL openGL)
        {
            bitmap = (Bitmap)actualBitmap.Clone();
            filter?.Filter(bitmap);
            RecreateTexture(openGL);
        }
    }
}
