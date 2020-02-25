using SharpGL;
using SharpGL.Enumerations;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ObjectOpenGL
{
    public enum RotateOs
    {
        X = 2, Y = 4, Z = 8
    }

    public partial class MainForm : Form
    {
        private readonly Color baseColor = Color.White;
        readonly Scene scene = new Scene();

        public MainForm()
        {
            InitializeComponent();
            rotateComboBox.SelectedIndex = 0;
            this.Text = "ПРИ-116-ПКГ-#14-ЗИМИН";

#if DEBUG
            openGLControl.DrawFPS = true;
#endif
        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gl = this.openGLControl.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(baseColor.R, baseColor.G, baseColor.B, baseColor.A);
            gl.Color(1.0, 1.0, 1.0, 1.0);
            gl.LoadIdentity();

            scene.CreateModelviewAndNormalMatrix();

            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);
            scene.RenderImmediateMode(gl);
        }

        private void OxScrollChanged(object sender, System.EventArgs e) => scene.rotatePosition.Item1 = oxScroll.Value;

        private void OyScrollChanged(object sender, System.EventArgs e) => scene.rotatePosition.Item2 = oyScroll.Value;

        private void ozScroll_Scroll(object sender, System.EventArgs e) => scene.rotatePosition.Item3 = ozScroll.Value;

        private void zoomScroll_Scroll(object sender, System.EventArgs e) => scene.zoom = zoomScroll.Value;

        private void rotateComboBox_SelectedIndexChanged(object sender, System.EventArgs e) => scene.rotateOs = (RotateOs)Math.Pow(2, rotateComboBox.SelectedIndex + 1);

        private void angleScroll_Scroll(object sender, System.EventArgs e) => scene.angle = angleScroll.Value;

        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            var gl = openGLControl.OpenGL;
            scene.Initialise(gl);
            gl.PolygonMode(FaceMode.FrontAndBack, PolygonMode.Filled);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            scene.Load(gl, "Objects/Apricot_02_hi_poly.obj");
        }
    }
}
