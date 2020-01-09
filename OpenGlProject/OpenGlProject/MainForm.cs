using OpenGlProject.Filters;
using OpenGlProject.OpenGlElements;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OpenGlProject
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        readonly List<Layout> layouts = new List<Layout> {
            new Layout(0)
        };

        /// <summary>
        /// Base background color for opengl control
        /// </summary>
        readonly Color baseColor = Color.White;
        /// <summary>
        /// Style
        /// </summary>
        PaintStyle? paintStyle = null;
        /// <summary>
        /// Is mouse paint?
        /// </summary>
        private bool isPaint = false;
        private IFilter currentFilter = null;

        public MainForm()
        {
            InitializeComponent();
            this.Name = this.Text = "Zimin_Maxim_PRI_116_Lab_07";
            this.openGLControl.DrawFPS = true;
            // Main layout is checked on start
            layoutsList.SetItemChecked(0, true);
        }

        /// <summary>
        /// Add new layout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLayout(object sender, EventArgs e)
        {
            layoutsList.Items.Add($"Слой {layoutsList.Items.Count}");
            layouts.Add(new Layout(layoutsList.Items.Count));
        }

        /// <summary>
        /// Remove layout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveLayout(object sender, EventArgs e)
        {
            if (layoutsList.SelectedItem != null && layoutsList.SelectedIndex != 0)
            {
                layouts.RemoveAt(layoutsList.SelectedIndex);
                layoutsList.Items.Remove(layoutsList.SelectedItem);
            }
        }

        /// <summary>
        /// Draw cycle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gl = this.openGLControl.OpenGL;

            var layoutIndex = layoutsList.CheckedIndices.Cast<int>().ToList();
            var layoutsReal = layouts.Where((x, i) => layoutIndex.Contains(i)).ToList();

            currentFilter?.DrawFilter(openGLControl, layoutsReal);

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(baseColor.R, baseColor.G, baseColor.B, baseColor.A);
            gl.LoadIdentity();
            gl.LineWidth(1);

            gl.Translate(0.0f, 0.0f, -2.4f);

            foreach (var layout in layoutsReal)
                layout.Paint(gl);

            currentFilter?.PostDrawFilter(openGLControl);
        }

        // Select instrument

        private void BrushBtnCheckedChanged(object sender, EventArgs e) => paintStyle = PaintStyle.Brush;

        private void pencilBtn_CheckedChanged(object sender, EventArgs e) => paintStyle = PaintStyle.Pencil;

        private void imageBtn_CheckedChanged(object sender, EventArgs e) => paintStyle = PaintStyle.Image;

        private void eraserBtn_CheckedChanged(object sender, EventArgs e) => paintStyle = PaintStyle.Eraser;

        private void signBtn_CheckedChanged(object sender, EventArgs e) => paintStyle = PaintStyle.Sign;

        /// <summary>
        /// Mouse button up => End of paint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openGLControl_MouseUp(object sender, MouseEventArgs e) => isPaint = false;

        /// <summary>
        /// Get info about new vertex
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private Vertex2D GetNewVertex(MouseEventArgs e)
        {
            Color color = e.Button == MouseButtons.Left ? this.colorsControl.MainColor.ColorEditor : this.colorsControl.ExtendColor.ColorEditor;
            Vertex2D visualPoint = null;
            float oXCoord = ((float)e.X - openGLControl.Width / 2) / (openGLControl.Width / 2);
            float oYCoord = -((float)e.Y - openGLControl.Height / 2) / (openGLControl.Height / 2);
            switch (paintStyle.Value)
            {
                case PaintStyle.Eraser:
                    visualPoint = new Eraser(baseColor, oXCoord, oYCoord);
                    break;
                case PaintStyle.Brush:
                    visualPoint = new OpenGlElements.Brush(color, oXCoord, oYCoord);
                    break;
                case PaintStyle.Pencil:
                    visualPoint = new Vertex2D(color, oXCoord, oYCoord);
                    break;
                case PaintStyle.Image:
                    visualPoint = new OpenGlElements.Image(Properties.Resources.fox, openGLControl.OpenGL, oXCoord, oYCoord);
                    break;
                case PaintStyle.Sign:
                    visualPoint = new OpenGlElements.Image(Properties.Resources.sign, openGLControl.OpenGL, oXCoord, oYCoord);
                    break;
            }
            return visualPoint;
        }

        /// <summary>
        /// Mouse button down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (paintStyle.HasValue)
            {
                var vertex2D = GetNewVertex(e);
                foreach (var layoutIndex in layoutsList.CheckedIndices.Cast<int>())
                    layouts[layoutIndex].AddNewSet(vertex2D);
                isPaint = true;
            }
        }

        /// <summary>
        /// Mouse moving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPaint && paintStyle.HasValue)
            {
                var vertex2D = GetNewVertex(e);
                foreach (var layoutIndex in layoutsList.CheckedIndices.Cast<int>())
                    layouts[layoutIndex].AddVertex(vertex2D);
            }
        }

        private void ApplyFilter(IFilter filter)
        {
            if (this.currentFilter?.GetType() == filter.GetType())
                this.currentFilter = new EmptyFilter();
            else
                this.currentFilter = filter;
        }

        private void BrushMenu(object sender, EventArgs e) => brushBtn.Checked = true;

        private void PencilMenu(object sender, EventArgs e) => pencilBtn.Checked = true;

        private void ImageMenu(object sender, EventArgs e) => imageBtn.Checked = true;

        private void EraserMenu(object sender, EventArgs e) => eraserBtn.Checked = true;

        private void SignMenu(object sender, EventArgs e) => signBtn.Checked = true;

        private void AddLayoutMenu(object sender, EventArgs e) => AddLayout(null, null);

        private void RemoveLayoutMenu(object sender, EventArgs e) => RemoveLayout(null, null);

        private void InvertFilterMenu(object sender, EventArgs e) => ApplyFilter(new InvertFilter());

        private void SharpnessFilterMenu(object sender, EventArgs e) { }/* => ApplyFilter(new SharpnessFilter());*/
    }
}
