using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Core;
using SharpGL.SceneGraph.Lighting;
using SharpGL.SceneGraph.Primitives;
using SharpGL.SceneGraph.Quadrics;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorOpenGl
{
    public partial class MainForm : Form
    {
        private readonly Color baseColor = Color.Black;
        private (int, int, int) rotatePosition = (0, 0, 0);
        private int zoom;
        readonly Scene scene = new Scene();
        private DrawStyle drawStyle = DrawStyle.Fill;

        private readonly Dictionary<string, SceneElement> visualObjects = new Dictionary<string, SceneElement> {
            { "Sphere", new Sphere{ Radius = 0.5, Slices = 40 } },
            { "Teapot", new Teapot{ Scale = 0.5,  } },
            { "Cylinder", new Cylinder{ Height = 0.5, TopRadius = 0.5, BaseRadius = 0.5, Slices= 40 } },
            { "Conus", new Cylinder{ Height = 0.5, TopRadius = 0.0, BaseRadius = 0.5, Slices= 40 } },
        };


        public MainForm()
        {
            InitializeComponent();
            objectsComboBox.DataSource = visualObjects.Keys.ToList();
            objectsComboBox.SelectedIndex = 0;

            (visualObjects["Cylinder"] as Cylinder).Transformation.RotateX = 90;
            (visualObjects["Conus"] as Cylinder).Transformation.RotateX = -90;

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
        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            Parallel.ForEach(scene.SceneContainer.Children.OfType<Quadric>(), x => x.QuadricDrawStyle = drawStyle);

            OpenGL gl = this.openGLControl.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(baseColor.R, baseColor.G, baseColor.B, baseColor.A);
            gl.LoadIdentity();
            // a bit magic numbers
            gl.Translate(0, 0, -2.3f);
            gl.Rotate(rotatePosition.Item1, 1, 0, 0);
            gl.Rotate(rotatePosition.Item2, 0, 1, 0);
            gl.Rotate(rotatePosition.Item3, 0, 0, 1);
            //gl.Translate(zoom, zoom, zoom);

            scene.Draw();

            gl.Flush();
        }

        private void OxScrollChanged(object sender, System.EventArgs e) => rotatePosition.Item1 = oxScroll.Value;

        private void OyScrollChanged(object sender, System.EventArgs e) => rotatePosition.Item2 = oyScroll.Value;

        private void ozScroll_Scroll(object sender, System.EventArgs e) => rotatePosition.Item3 = ozScroll.Value;

        private void zoomScroll_Scroll(object sender, System.EventArgs e) => zoom = zoomScroll.Value;

        private void objectsComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (scene.SceneContainer.Children.Count > 0)
                scene.SceneContainer.RemoveChild(scene.SceneContainer.Children.First(x => x.Name != "Light"));
            scene.SceneContainer.AddChild(visualObjects[objectsComboBox.SelectedItem as string]);
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e) => drawStyle = checkBox.Checked ? DrawStyle.Line : DrawStyle.Fill;
    }
}
