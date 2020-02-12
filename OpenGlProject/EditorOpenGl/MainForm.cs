using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorOpenGl
{
    public partial class MainForm : Form
    {
        private Color baseColor = Color.White;

        public MainForm()
        {
            InitializeComponent();
#if DEBUG
            openGLControl.DrawFPS = true;
#endif
        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gl = this.openGLControl.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(baseColor.R, baseColor.G, baseColor.B, baseColor.A);
            gl.LoadIdentity();

            // a bit magic numbers
            gl.Translate(0, 0, -0.3f);
            gl.Flush();
        }
    }
}
