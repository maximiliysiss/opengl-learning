using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Drawing;
using System.Windows;

namespace ParicalsOpenGl
{
    public class Particle
    {
        public float life;                  // Particle Life
        public float fade;                  // Fade Speed

        public float r;                 // Red Value
        public float g;                 // Green Value
        public float b;                 // Blue Value

        public float x;                 // X Position
        public float y;                 // Y Position
        public float z;                 // Z Position

        public float xi;                    // X Direction
        public float yi;                    // Y Direction
        public float zi;                    // Z Direction
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly float slowdown = 0.8f;          // Slow Down Particles
        readonly float zoom = -50.0f;			// Used To Zoom Out

        Texture particleTexture;
        readonly uint[] texture = new uint[1];			// Storage For Our Particle Texture

        /// <summary>
        /// A Random number generator we use.
        /// </summary>
        readonly Random random = new Random();
        readonly Particle[] particles = new Particle[1000];         // Particle Array (Room For Particle Info)

        readonly float[,] colors = new float[,] {
            {1.0f,0.5f,0.5f},{1.0f,0.75f,0.5f},{1.0f,1.0f,0.5f},{0.75f,1.0f,0.5f},
            {0.5f,1.0f,0.5f},{0.5f,1.0f,0.75f},{0.5f,1.0f,1.0f},{0.5f,0.75f,1.0f},
            {0.5f,0.5f,1.0f},{0.75f,0.5f,1.0f},{1.0f,0.5f,1.0f},{1.0f,0.5f,0.75f}
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        public uint LoadGLTextures()						// Load Bitmaps And Convert To Textures
        {
            OpenGL gl = openGLControl1.OpenGL;
            particleTexture = new Texture();
            particleTexture.Create(gl, (Bitmap)Bitmap.FromFile("Textures/Particle.png"));
            texture[0] = particleTexture.TextureName;
            return texture[0];
        }

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = openGLControl1.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);			// Clear Screen And Depth Buffer
            gl.LoadIdentity();							// Reset The ModelView Matrix

            for (var i = 0; i < particles.Length; i++)                 // Loop Through All The Particles
            {
                float x = particles[i].x;               // Grab Our Particle X Position
                float y = particles[i].y;               // Grab Our Particle Y Position
                float z = particles[i].z + zoom;                // Particle Z Pos + Zoom

                // Draw The Particle Using Our RGB Values, Fade The Particle Based On It's Life
                gl.Color(particles[i].r, particles[i].g, particles[i].b, particles[i].life);

                gl.Begin(OpenGL.GL_TRIANGLE_STRIP);             // Build Quad From A Triangle Strip
                gl.TexCoord(1, 1); gl.Vertex(x + 0.5f, y + 0.5f, z); // Top Right
                gl.TexCoord(0, 1); gl.Vertex(x - 0.5f, y + 0.5f, z); // Top Left
                gl.TexCoord(1, 0); gl.Vertex(x + 0.5f, y - 0.5f, z); // Bottom Right
                gl.TexCoord(0, 0); gl.Vertex(x - 0.5f, y - 0.5f, z); // Bottom Left
                gl.End();                       // Done Building Triangle Strip

                particles[i].x += particles[i].xi / (slowdown * 1000);  // Move On The X Axis By X Speed
                particles[i].y += particles[i].yi / (slowdown * 1000);  // Move On The Y Axis By Y Speed
                particles[i].z += particles[i].zi / (slowdown * 1000);  // Move On The Z Axis By Z Speed

                particles[i].life -= particles[i].fade;       // Reduce Particles Life By 'Fade'

                if (particles[i].life < 0.0f)                    // If Particle Is Burned Out
                {
                    particles[i].life = 1.0f;               // Give It New Life
                    particles[i].fade = random.Next(100) / 1000.0f + 0.003f;       // Random Fade Speed

                    particles[i].x = 0.0f;                  // Center On X Axis
                    particles[i].y = 0.0f;                  // Center On Y Axis
                    particles[i].z = 0.0f;                  // Center On Z Axis

                    particles[i].xi = (random.Next(50) - 26.0f) * 10.0f;       // Random Speed On X Axis
                    particles[i].yi = (random.Next(50) - 25.0f) * 10.0f;       // Random Speed On Y Axis
                    particles[i].zi = (random.Next(50) - 25.0f) * 10.0f;       // Random Speed On Y Axis

                    int colour = random.Next(12);
                    particles[i].r = colors[colour, 0];         // Select Red From Color Table
                    particles[i].g = colors[colour, 1];         // Select Green From Color Table
                    particles[i].b = colors[colour, 2];          // Select Blue From Color Table
                }
            }
        }

        private async void openGLControl1_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            LoadGLTextures();

            OpenGL gl = openGLControl1.OpenGL;

            gl.ShadeModel(OpenGL.GL_SMOOTH);						// Enables Smooth Shading
            gl.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);					// Black Background
            gl.ClearDepth(1.0f);							// Depth Buffer Setup
            gl.Disable(OpenGL.GL_DEPTH_TEST);						// Disables Depth Testing
            gl.Enable(OpenGL.GL_BLEND);							// Enable Blending
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE);					// Type Of Blending To Perform
            gl.Hint(OpenGL.GL_PERSPECTIVE_CORRECTION_HINT, OpenGL.GL_NICEST);			// Really Nice Perspective Calculations
            gl.Hint(OpenGL.GL_POINT_SMOOTH_HINT, OpenGL.GL_NICEST);					// Really Nice Point Smoothing
            gl.Enable(OpenGL.GL_TEXTURE_2D);						// Enable Texture Mapping
            gl.BindTexture(OpenGL.GL_TEXTURE_2D, texture[0]);				// Select Our Texture

            Random random = new Random();
            int particleCount = particles.Length;

            for (var i = 0; i < particleCount; i++)					// Initialize All The Textures
            {
                particles[i] = new Particle
                {
                    life = 1.0f,                    // Give All The Particles Full Life
                    fade = random.Next(100) / 1000.0f + 0.003f,        // Random Fade Speed

                    r = colors[i * (int)(12 / (float)particleCount), 0],     // Select Red Rainbow Color
                    g = colors[i * (int)(12 / (float)particleCount), 1],     // Select Red Rainbow Color
                    b = colors[i * (int)(12 / (float)particleCount), 2],     // Select Red Rainbow Color

                    xi = (random.Next(50) - 26.0f) * 10.0f,        // Random Speed On X Axis
                    yi = (random.Next(50) - 25.0f) * 10.0f,        // Random Speed On Y Axis
                    zi = (random.Next(50) - 25.0f) * 10.0f     // Random Speed On Z Axis
                };
            }
        }
    }
}
