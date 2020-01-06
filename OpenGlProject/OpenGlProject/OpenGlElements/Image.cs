using SharpGL;
using System.Drawing;

namespace OpenGlProject.OpenGlElements
{
    /// <summary>
    /// 
    /// </summary>
    public class Image : Vertex2D
    {
        readonly string url;
        readonly Bitmap bitmap;
        private uint[] gtexture = new uint[1];

        public Image(string url, OpenGL gl)
        {
            this.url = url;
            bitmap = new Bitmap(this.url);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var gbitmapdata = bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            bitmap.UnlockBits(gbitmapdata);
            gl.GenTextures(1, gtexture);
            gl.BindTexture(OpenGL.GL_TEXTURE_2D, gtexture[0]);
            gl.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, (int)OpenGL.GL_RGB8, bitmap.Width, bitmap.Height, 0, OpenGL.GL_BGR_EXT, OpenGL.GL_UNSIGNED_BYTE, gbitmapdata.Scan0);
            uint[] array = new uint[] { OpenGL.GL_NEAREST };
            gl.TexParameterI(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, array);
            gl.TexParameterI(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, array);
        }

        public override VertexType VertexType => VertexType.Image;

        public override void Paint(OpenGL gl)
        {
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            gl.BindTexture(OpenGL.GL_TEXTURE_2D, gtexture[0]);
            gl.Color(1.0f, 1.0f, 1.0f, 0.1f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(1.0f, 1.0f);
            gl.Vertex(bitmap.Width, bitmap.Height, 1.0f);
            gl.TexCoord(0.0f, 1.0f);
            gl.Vertex(0.0f, bitmap.Height, 1.0f);
            gl.TexCoord(0.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, 1.0f);
            gl.TexCoord(1.0f, 0.0f);
            gl.Vertex(bitmap.Width, 0.0f, 1.0f);
        }
    }
}
