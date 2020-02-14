using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TextureOpenGL
{
    public partial class MainForm : Form
    {
        readonly Color baseColor = Color.White;
        readonly Texture texture = new Texture();
        private int rotate = 0;

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            timer.Tick += (s, e) => rotate = (rotate + 1) % 360;
            timer.Start();
#if DEBUG
            openGLControl.DrawFPS = true;
#endif
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            texture.Create(openGLControl.OpenGL, "Texture/texture.png");
        }

        private void openGLControl_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gl = this.openGLControl.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(baseColor.R, baseColor.G, baseColor.B, baseColor.A);
            gl.LoadIdentity();
            // a bit magic numbers
            gl.Translate(0, 0, -1.3f);
            gl.Color(1.0, 1.0, 1.0, 1.0);
            gl.Rotate(rotate, 0, 0, 1);

            gl.Enable(OpenGL.GL_TEXTURE_2D);
            texture.Bind(gl);

            gl.Begin(OpenGL.GL_QUADS);

            var width = 0.3;
            var height = 0.3;

            var startX = -width / 2;
            var startY = -width / 2;

            gl.TexCoord(0, 1); gl.Vertex(new[] { startX, startY });
            gl.TexCoord(1, 1); gl.Vertex(new[] { startX + width, startY });
            gl.TexCoord(1, 0); gl.Vertex(new[] { startX + width, startY + height });
            gl.TexCoord(0, 0); gl.Vertex(new[] { startX, startY + height });

            gl.End();

            gl.Disable(OpenGL.GL_TEXTURE_2D);

            gl.Flush();
        }
    }
}
