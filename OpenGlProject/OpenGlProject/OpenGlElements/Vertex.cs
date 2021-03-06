﻿using OpenGlProject.Filters;
using SharpGL;
using System.Drawing;

namespace OpenGlProject.OpenGlElements
{
    public interface IFilterAccess
    {
        void Filter(IFilter filter, OpenGL openGL);
    }

    /// <summary>
    /// Type
    /// </summary>
    public enum VertexType
    {
        Vertex,
        Brush,
        Image,
        Eraser,
        Spline
    }

    /// <summary>
    /// Base class for Vertex
    /// </summary>
    public class Vertex2D : IFilterAccess
    {
        public virtual VertexType VertexType => VertexType.Vertex;

        public Vertex2D()
        {
        }

        public Vertex2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vertex2D(Color color, float x, float y)
        {
            Color = PaintColor = color;
            X = x;
            Y = y;
        }

        public Color PaintColor { get; set; }
        public Color Color { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public virtual float[] Coords => new[] { X, Y };

        public virtual void Paint(OpenGL gl)
        {
            gl.Color(Color.R, Color.G, Color.B, Color.A);
            gl.Vertex(Coords);
        }

        public virtual void PrePaint(OpenGL openGL) { }
        public virtual void EndPaint(OpenGL openGL) { }

        public virtual void Filter(IFilter filter, OpenGL openGL) => Color = filter?.Filter(PaintColor) ?? PaintColor;
    }

    public class Vertex3D : Vertex2D
    {
        public Vertex3D()
        {
        }

        public Vertex3D(float x, float y, float z) : base(x, y)
        {
            Z = z;
        }

        public Vertex3D(Color color, float x, float y, float z) : base(color, x, y)
        {
            Z = z;
        }

        public float Z { get; set; }

        public override float[] Coords => new[] { X, Y, Z };
    }
}
