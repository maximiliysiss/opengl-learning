using FractalOpenGL.Additional;
using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalOpenGL
{
    public partial class MainWindow : Form
    {
        public readonly Color baseColor = Color.White;
        private Bitmap currentFractal;
        private readonly Texture texture = new Texture();
        private Additional.DrawMode drawMode = Additional.DrawMode.Standard;

        public MainWindow()
        {
            InitializeComponent();
            modeComboBox.SelectedIndex = 0;
#if DEBUG
            openGLControl.DrawFPS = true;
#endif
        }

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gl = this.openGLControl.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(baseColor.R, baseColor.G, baseColor.B, baseColor.A);
            gl.LoadIdentity();

            // a bit magic numbers
            gl.Translate(-0.3f, -0.3f, -0.3f);

            if (currentFractal != null)
            {
                float[] color = new float[4];
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                gl.GetFloat(OpenGL.GL_COLOR, color);
                gl.Color(1.0, 1.0, 1.0, 1.0);
                // set Texture binding
                texture.Bind(gl);

                // Paint here
                gl.Begin(OpenGL.GL_QUADS);

                double width = 0.3;
                double height = 0.3;

                var startX = width / 2;
                var startY = height / 2;

                gl.TexCoord(0, 1); gl.Vertex(new[] { startX, startY });
                gl.TexCoord(1, 1); gl.Vertex(new[] { startX + width, startY });
                gl.TexCoord(1, 0); gl.Vertex(new[] { startX + width, startY + height });
                gl.TexCoord(0, 0); gl.Vertex(new[] { startX, startY + height });

                gl.End();

                gl.Color(color[0], color[1], color[2], color[3]);
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            }

            gl.Flush();
        }

        private async void DrawClick(object sender, System.EventArgs e)
        {
            currentFractal?.Dispose();
            currentFractal = new Bitmap(openGLControl.Width, openGLControl.Height);

            List<Task> tasks = new List<Task>();
            int count = 8;
            for (int i = 0; i < count; i++)
            {
                tasks.Add(CalculateBitmapPart(currentFractal, currentFractal.Height / count * i,
                    currentFractal.Height / count * (i + 1), drawMode));
            }
            await Task.WhenAll(tasks);
        }

        private async Task CalculateBitmapPart(Bitmap bitmap, int fromHeight, int toHeight, Additional.DrawMode drawMode)
        {
            int width = bitmap.Width;

            double xmin = -1.5;
            double ymin = -1.2;
            double xmax = 1.5;
            double ymax = 1.5;

            int W = 600;
            int H = 600;

            double dx = (xmax - xmin) / (W - 1);
            double dy = (ymax - ymin) / (H - 1);

            double x, y, X, Y, Cx, Cy;

            for (int ax = fromHeight; ax < toHeight; ax++)
            {

                for (int bx = 0; bx < width; bx++)
                {
                    x = xmin + ax * dx;
                    y = ymin + bx * dy;

                    Cx = x;
                    Cy = y;
                    X = x;
                    Y = y;

                    double ix = 0, iy = 0, n = 0;
                    while ((ix * ix + iy * iy < 4) && (n < 64))
                    {
                        switch (drawMode)
                        {
                            case Additional.DrawMode.Standard:
                                ix = X * X - Y * Y + Cx;
                                iy = 2 * X * Y + Cy;
                                break;
                            case Additional.DrawMode.Custom:
                                ix = X * X - Y * Y + drawMode.ToValue();
                                iy = 2 * X * Y + drawMode.ToValue(1);
                                break;
                        }
                        n++;
                        X = ix;
                        Y = iy;
                    }

                    n = 255 - n;

                    Color color = Color.FromArgb((int)n, (int)n, (int)n);
                    bitmap.SetPixel(bx, ax, color);
                }
            }

            using (Bitmap cpy = (Bitmap)bitmap.Clone())
            {
                texture.Destroy(openGLControl.OpenGL);
                texture.Create(openGLControl.OpenGL, cpy);
            }
            await Task.Yield();
        }

        private void modeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
            => drawMode = (Additional.DrawMode)modeComboBox.SelectedIndex;
    }
}
