using SharpGL;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace OpenGlProject.OpenGlElements
{
    /// <summary>
    /// 
    /// </summary>
    public class Image : Vertex2D
    {
        private readonly float width = 0.3f;
        private readonly float height = 0.3f;
        private uint _list;

        readonly Bitmap bitmap;
        private uint[] gtexture = new uint[1];

        public uint LoadTexture(OpenGL gl)
        {
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            var texture = new uint[1];
            var id = texture[0];
            gl.GenTextures(1, texture);
            gl.BindTexture(OpenGL.GL_TEXTURE_2D, id);

            var bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            gl.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, 3, bmpData.Width, bmpData.Height, 0, OpenGL.GL_BGR, OpenGL.GL_UNSIGNED_BYTE, bmpData.Scan0);

            gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
            gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);

            bitmap.UnlockBits(bmpData);

            return id;
        }

        public Image(Bitmap bitmap, OpenGL gl, float oXCoord, float oYCoord) : base(Color.Black, oXCoord, oYCoord)
        {
            this.bitmap = bitmap;
        }

        public override VertexType VertexType => VertexType.Image;

        public override void Paint(OpenGL gl)
        {
            gl.Color(Color.R, Color.G, Color.B, Color.A);

            // LoadTexture(gl);

            var startX = this.X - width / 2;
            var startY = this.Y - width / 2;

            //var quadratic = gl.NewQuadric();
            //gl.QuadricNormals(quadratic, OpenGL.GLU_SMOOTH);
            //gl.QuadricTexture(quadratic, (int)OpenGL.GL_TRUE);

            //_list = gl.GenLists(1);
            //gl.NewList(_list, OpenGL.GL_COMPILE);
            //gl.PushMatrix();
            //gl.Rect(new[] { startX, startY }, new[] { startX + width, startY + height });
            //gl.PopMatrix();
            //gl.EndList();

            gl.Vertex(new[] { startX, startY });
            gl.Vertex(new[] { startX + width, startY });
            gl.Vertex(new[] { startX + width, startY + height });
            gl.Vertex(new[] { startX, startY + height });
            gl.Vertex(new[] { startX, startY });
        }
    }
}
