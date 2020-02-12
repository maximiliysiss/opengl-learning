using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RotateOpenGL
{
    public enum DrawType : uint
    {
        Line = OpenGL.GL_LINES,
        Quads = OpenGL.GL_QUADS,
        Points = OpenGL.GL_POINTS,
        SideBySide = OpenGL.GL_TRIANGLES,
    }

    public partial class MainForm : Form
    {
        private DrawType drawType = DrawType.Points;
        private readonly Color baseColor = Color.White;
        private (double, double, double)[,] data;
        private (double, double, double)[,] original;

        private (double, double, double)[,] currentData;

        private double degree = 0;

        public MainForm()
        {
            generateData();
            InitializeComponent();
            drawTypeComboBox.DataSource = Enum.GetValues(typeof(DrawType)).Cast<DrawType>();
            drawTypeComboBox.SelectedIndex = 0;
#if DEBUG
            openGLControl.DrawFPS = true;
#endif
            this.MouseWheel += MainForm_MouseWheel;
        }

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            degree = (degree + e.Delta / 10) % 360;
        }

        private void generateData()
        {
            double angle = 5;
            int countEdge = (int)(360 / angle);

            double a = -5, b = 5;
            int n = 20;
            var offset = (b - a) / n;
            data = new (double, double, double)[countEdge, n];
            for (int i = 0; a < b; a += offset, i++)
                data[0, i] = (a, a * a * a * Math.Exp(-Math.Abs(a + 1)), 0);

            var matrix = GetRotateMatrix(angle);

            for (int i = 1; i < countEdge; i++)
            {
                for (int ii = 0; ii < n; ii++)
                {
                    var points = new[,] { { data[i - 1, ii].Item1, data[i - 1, ii].Item2, data[i - 1, ii].Item3 } };
                    var res = Matrix<double>.Build.DenseOfArray(points).Multiply(matrix);
                    data[i, ii] = (res[0, 0], res[0, 1], res[0, 2]);
                }
            }

            var tmp = new List<(double, double, double)>();
            for (int i = 1; i < data.GetLength(0); i++)
            {
                for (int j = 1; j < data.GetLength(1); j++)
                {
                    tmp.Add(data[i - 1, j - 1]);
                    tmp.Add(data[i - 1, j]);
                    tmp.Add(data[i, j]);
                    tmp.Add(data[i - 1, j - 1]);
                    tmp.Add(data[i, j - 1]);
                    tmp.Add(data[i, j]);
                }
            }

            original = new (double, double, double)[1, tmp.Count];
            for (int i = 0; i < tmp.Count; i++)
                original[0, i] = tmp[i];
        }

        private Matrix<double> GetRotateMatrix(double angle)
        {
            angle = Trig.DegreeToRadian(angle);
            double[,] rt = new[,] {
                { 1,0,0 },
                { 0,Math.Cos(angle),Math.Sin(angle) },
                { 0,-Math.Sin(angle),Math.Cos(angle) }
            };
            return Matrix<double>.Build.DenseOfArray(rt);
        }

        Random random = new Random();

        private void openGLControl_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gl = this.openGLControl.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(baseColor.R, baseColor.G, baseColor.B, baseColor.A);
            gl.LoadIdentity();

            // a bit magic numbers
            gl.Translate(0, 0, -10.3f);
            gl.Rotate(20, 0, 0, -1);
            gl.Rotate(degree, 0, 1, 0);
            gl.PointSize(5);
            gl.Color(1.0, 1.0, 1.0, 1.0);
            // draw
            gl.Begin((uint)drawType);

            foreach (var point in currentData)
            {
                var rnd = 0 + (random.NextDouble() * 1);
                gl.Color(rnd, rnd, rnd);
                gl.Vertex(point.Item1, point.Item2, point.Item3);
            }

            gl.End();
            gl.Flush();
        }

        private void drawTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawType = (DrawType)drawTypeComboBox.SelectedValue;
            currentData = (DrawType)drawTypeComboBox.SelectedValue != DrawType.SideBySide ? data : original;
        }
    }
}
