﻿using FileFormatWavefront.Model;
using GlmNet;
using SharpGL;
using SharpGL.Shaders;
using SharpGL.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ObjectOpenGL
{
    public static class VertexAttributes
    {
        public const uint Position = 0;
        public const uint Normal = 1;
        public const uint TexCoord = 2;
    }

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
            //  Create the per pixel shader.
            shaderPerPixel = new ShaderProgram();
            shaderPerPixel.Create(gl,
                ManifestResourceLoader.LoadTextFile(@"Shaders\PerPixel.vert"),
                ManifestResourceLoader.LoadTextFile(@"Shaders\PerPixel.frag"), null);
            shaderPerPixel.BindAttributeLocation(gl, VertexAttributes.Position, "Position");
            shaderPerPixel.BindAttributeLocation(gl, VertexAttributes.Normal, "Normal");
            gl.ClearColor(0f, 0f, 0f, 1f);

            //  Immediate mode only features!
            gl.Enable(OpenGL.GL_TEXTURE_2D);
        }

        /// <summary>
        /// Creates the projection matrix for the given screen size.
        /// </summary>
        /// <param name="screenWidth">Width of the screen.</param>
        /// <param name="screenHeight">Height of the screen.</param>
        public void CreateProjectionMatrix(float screenWidth, float screenHeight)
        {
            //  Create the projection matrix for our screen size.
            const float S = 0.46f;
            float H = S * screenHeight / screenWidth;
            projectionMatrix = glm.frustum(-S, S, -H, H, 1, 100);
        }

        /// <summary>
        /// Creates the modelview and normal matrix. Also rotates the sceen by a specified amount.
        /// </summary>
        /// <param name="rotationAngle">The rotation angle, in radians.</param>
        public void CreateModelviewAndNormalMatrix()
        {
            //  Create the modelview and normal matrix. We'll also rotate the scene
            //  by the provided rotation angle, which means things that draw it 
            //  can make the scene rotate easily.
            mat4 translation = glm.translate(mat4.identity(), new vec3(0, -2, -10 + zoom));
            mat4 rotation = mat4.identity();
            rotation = glm.rotate(rotation, rotatePosition.Item1, new vec3(1, 0, 0));
            rotation = glm.rotate(rotation, rotatePosition.Item2, new vec3(0, 1, 0));
            rotation = glm.rotate(rotation, rotatePosition.Item3, new vec3(0, 0, 1));
            rotation = glm.rotate(rotation, angle, new vec3((int)rotateOs & 2, (int)rotateOs & 4, (int)rotateOs & 8));
            mat4 scale = glm.scale(mat4.identity(), new vec3(scaleFactor, scaleFactor, scaleFactor));
            modelviewMatrix = scale * rotation * translation;
            normalMatrix = modelviewMatrix.to_mat3();
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
            //  TODO: cleanup old files.

            //  Destroy all of the vertex buffer arrays in the meshes.
            foreach (var vertexBufferArray in meshVertexBufferArrays.Values)
                vertexBufferArray.Delete(gl);
            meshes.Clear();
            meshVertexBufferArrays.Clear();

            //  Load the object file.
            var result = FileFormatWavefront.FileFormatObj.Load(objectFilePath, true);

            meshes.AddRange(SceneDenormaliser.Denormalize(result.Model));

            //  Create a vertex buffer array for each mesh.
            meshes.ForEach(m => CreateVertexBufferArray(gl, m));

            //  Create textures for each texture map.
            CreateTextures(gl, meshes);

            //  TODO: handle errors and warnings.

            //  TODO: cleanup

        }

        private void CreateVertexBufferArray(OpenGL gl, Mesh mesh)
        {
            //  Create and bind a vertex buffer array.
            var vertexBufferArray = new VertexBufferArray();
            vertexBufferArray.Create(gl);
            vertexBufferArray.Bind(gl);

            //  Create a vertex buffer for the vertices.
            var verticesVertexBuffer = new VertexBuffer();
            verticesVertexBuffer.Create(gl);
            verticesVertexBuffer.Bind(gl);
            verticesVertexBuffer.SetData(gl, VertexAttributes.Position,
                                 mesh.vertices.SelectMany(v => v.to_array()).ToArray(),
                                 false, 3);
            if (mesh.normals != null)
            {
                var normalsVertexBuffer = new VertexBuffer();
                normalsVertexBuffer.Create(gl);
                normalsVertexBuffer.Bind(gl);
                normalsVertexBuffer.SetData(gl, VertexAttributes.Normal,
                                            mesh.normals.SelectMany(v => v.to_array()).ToArray(),
                                            false, 3);
            }

            if (mesh.uvs != null)
            {
                var texCoordsVertexBuffer = new VertexBuffer();
                texCoordsVertexBuffer.Create(gl);
                texCoordsVertexBuffer.Bind(gl);
                texCoordsVertexBuffer.SetData(gl, VertexAttributes.TexCoord,
                                              mesh.uvs.SelectMany(v => v.to_array()).ToArray(),
                                              false, 2);
            }
            //  We're done creating the vertex buffer array - unbind it and add it to the dictionary.
            verticesVertexBuffer.Unbind(gl);
            meshVertexBufferArrays[mesh] = vertexBufferArray;
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

        /// <summary>
        /// Sets the scale factor automatically based on the size of the geometry.
        /// Returns the computed scale factor.
        /// </summary>
        /// <returns>The computed scale factor.</returns>
        public float SetScaleFactorAuto()
        {
            //  0.02 good for inet models.

            //  If we have no meshes, just use 1.0f.
            if (!meshes.Any())
            {
                scaleFactor = 1.0f;
                return scaleFactor;
            }

            //  Find the maximum vertex value.
            var maxX = meshes.SelectMany(m => m.vertices).AsParallel().Max(v => Math.Abs(v.x));
            var maxY = meshes.SelectMany(m => m.vertices).AsParallel().Max(v => Math.Abs(v.y));
            var maxZ = meshes.SelectMany(m => m.vertices).AsParallel().Max(v => Math.Abs(v.z));
            var max = (new[] { maxX, maxY, maxZ }).Max();

            //  Set the scale factor accordingly.
            //  sf = max/c
            scaleFactor = 8.0f / max;
            return scaleFactor;
        }

        /// <summary>
        /// Gets or sets the scale factor.
        /// </summary>
        public float ScaleFactor
        {
            get { return scaleFactor; }
            set { scaleFactor = value; }
        }

        /// <summary>
        /// Gets the projection matrix.
        /// </summary>
        public mat4 ProjectionMatrix
        {
            get { return projectionMatrix; }
        }

        private readonly Material defaultMaterial;

        private readonly List<Mesh> meshes = new List<Mesh>();
        private readonly Dictionary<Mesh, VertexBufferArray> meshVertexBufferArrays = new Dictionary<Mesh, VertexBufferArray>();
        private readonly Dictionary<Mesh, Texture2D> meshTextures = new Dictionary<Mesh, Texture2D>();

        //  The shaders we use.
        private ShaderProgram shaderPerPixel;

        //  The modelview, projection and normal matrices.
        private mat4 modelviewMatrix = mat4.identity();
        private mat4 projectionMatrix = mat4.identity();
        private mat3 normalMatrix = mat3.identity();

        private float scaleFactor = 1.0f;
    }
}
