﻿using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Lighting;
using SharpGL.SceneGraph.Primitives;
using SharpGL.SceneGraph.Quadrics;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOpenGL
{
    public enum RotateOs
    {
        X = 2, Y = 4, Z = 8
    }

    public partial class MainForm : Form
    {
        private RotateOs rotateOs = RotateOs.X;
        private readonly Color baseColor = Color.Black;
        private (int, int, int) rotatePosition = (0, 0, 0);
        private int zoom;
        private int angle;
        Scene scene = new Scene();
        private DrawStyle drawStyle = DrawStyle.Fill;


        public MainForm()
        {
            InitializeComponent();
            rotateComboBox.SelectedIndex = 0;

#if DEBUG
            openGLControl.DrawFPS = true;
#endif

            Light light = new Light()
            {
                On = true,
                Position = new Vertex(0, 0, 3),
                GLCode = OpenGL.GL_LIGHT0
            };


            scene.SceneContainer.AddChild(light);
            scene.RenderBoundingVolumes = false;
            scene.ClearColor = baseColor;

            this.Load += MainForm_Load;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            Parallel.ForEach(scene.SceneContainer.Children.OfType<Quadric>(), x => x.QuadricDrawStyle = drawStyle);

            OpenGL gl = this.openGLControl.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(baseColor.R, baseColor.G, baseColor.B, baseColor.A);
            gl.LoadIdentity();
            // a bit magic numbers
            gl.Translate(0, 0, -2.3f + (float)zoom / 20);
            gl.Rotate(rotatePosition.Item1, 1, 0, 0);
            gl.Rotate(rotatePosition.Item2, 0, 1, 0);
            gl.Rotate(rotatePosition.Item3, 0, 0, 1);

            gl.Rotate(angle, (int)rotateOs & 2, (int)rotateOs & 4, (int)rotateOs & 8);

            scene.Draw();

            gl.Flush();
        }

        private void OxScrollChanged(object sender, System.EventArgs e) => rotatePosition.Item1 = oxScroll.Value;

        private void OyScrollChanged(object sender, System.EventArgs e) => rotatePosition.Item2 = oyScroll.Value;

        private void ozScroll_Scroll(object sender, System.EventArgs e) => rotatePosition.Item3 = ozScroll.Value;

        private void zoomScroll_Scroll(object sender, System.EventArgs e) => zoom = zoomScroll.Value;

        private void checkBox_CheckedChanged(object sender, System.EventArgs e) => drawStyle = checkBox.Checked ? DrawStyle.Line : DrawStyle.Fill;

        private void rotateComboBox_SelectedIndexChanged(object sender, System.EventArgs e) => rotateOs = (RotateOs)Math.Pow(2, rotateComboBox.SelectedIndex + 1);

        private void angleScroll_Scroll(object sender, System.EventArgs e) => angle = angleScroll.Value;
    }
}
