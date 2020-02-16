using GlmNet;
using SharpGL;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ObjectOpenGL
{
    /// <summary>
    /// A class that represents the scene for this sample.
    /// </summary>
    public class Scene
    {
        public float zoom = 0;
        public float angle;
        public RotateOs rotateOs;
        public (float, float, float) rotatePosition;

        public void Initialise(OpenGL gl)
        {
            gl.ClearColor(0f, 0f, 0f, 1f);
            gl.Enable(OpenGL.GL_TEXTURE_2D);
        }

        /// <summary>
        /// Creates the modelview and normal matrix. Also rotates the sceen by a specified amount.
        /// </summary>
        /// <param name="rotationAngle">The rotation angle, in radians.</param>
        public void CreateModelviewAndNormalMatrix()
        {
            float scaleFactor = 1.0f;
            mat4 translation = glm.translate(mat4.identity(), new vec3(0, -2, -10));
            mat4 rotation = mat4.identity();
            mat4 scale = glm.scale(mat4.identity(), new vec3(scaleFactor, scaleFactor, scaleFactor));
            modelviewMatrix = scale * rotation * translation;
        }

        /// <summary>
        /// Renders the scene in immediate mode.
        /// </summary>
        /// <param name="gl">The OpenGL instance.</param>
        public void RenderImmediateMode(OpenGL gl)
        {
            //  Setup the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();
            gl.MultMatrix(modelviewMatrix.to_array());

            gl.Translate(0, 0, zoom);
            gl.Rotate(rotatePosition.Item1, 1, 0, 0);
            gl.Rotate(rotatePosition.Item2, 0, 1, 0);
            gl.Rotate(rotatePosition.Item3, 0, 0, 1);

            gl.Rotate(angle, (int)rotateOs & 2, (int)rotateOs & 4, (int)rotateOs & 8);

            //  Go through each group.
            foreach (var mesh in meshes)
            {
                var texture = meshTextures.ContainsKey(mesh) ? meshTextures[mesh] : null;
                if (texture != null)
                    texture.Bind(gl);

                uint mode = OpenGL.GL_TRIANGLES;
                if (mesh.indicesPerFace == 4)
                    mode = OpenGL.GL_QUADS;
                else if (mesh.indicesPerFace > 4)
                    mode = OpenGL.GL_POLYGON;

                //  Render the group faces.
                gl.Begin(mode);
                for (int i = 0; i < mesh.vertices.Length; i++)
                {
                    gl.Vertex(mesh.vertices[i].x, mesh.vertices[i].y, mesh.vertices[i].z);
                    if (mesh.normals != null)
                        gl.Normal(mesh.normals[i].x, mesh.normals[i].y, mesh.normals[i].z);
                    if (mesh.uvs != null)
                        gl.TexCoord(mesh.uvs[i].x, mesh.uvs[i].y);
                }
                gl.End();

                if (texture != null)
                    texture.Unbind(gl);
            }
        }

        public void Load(OpenGL gl, string objectFilePath)
        {
            meshes.Clear();
            //  Load the object file.
            var result = FileFormatWavefront.FileFormatObj.Load(objectFilePath, true);
            meshes.AddRange(SceneDenormaliser.Denormalize(result.Model));
            //  Create textures for each texture map.
            CreateTextures(gl, meshes);
        }

        private void CreateTextures(OpenGL gl, IEnumerable<Mesh> meshes)
        {
            foreach (var mesh in meshes.Where(m => m.material != null && m.material.TextureMapDiffuse != null))
            {
                //  Create a new texture and bind it.
                var texture = new Texture2D();
                texture.Create(gl);
                texture.Bind(gl);
                texture.SetParameter(gl, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
                texture.SetParameter(gl, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);
                texture.SetParameter(gl, OpenGL.GL_TEXTURE_WRAP_S, OpenGL.GL_CLAMP_TO_EDGE);
                texture.SetParameter(gl, OpenGL.GL_TEXTURE_WRAP_T, OpenGL.GL_CLAMP_TO_EDGE);
                texture.SetImage(gl, (Bitmap)mesh.material.TextureMapDiffuse.Image);
                texture.Unbind(gl);
                meshTextures[mesh] = texture;
            }
        }

        private readonly List<Mesh> meshes = new List<Mesh>();
        private readonly Dictionary<Mesh, Texture2D> meshTextures = new Dictionary<Mesh, Texture2D>();
        //  The modelview, projection and normal matrices.
        private mat4 modelviewMatrix = mat4.identity();
    }
}
