using OpenGlProject.Algorithm;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OpenGlProject.OpenGlElements.Sets
{
    /// <summary>
    /// Set of visual points
    /// </summary>
    public interface IVisualSet
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gl"></param>
        void Paint(OpenGL gl);
        /// <summary>
        /// Recover data
        /// </summary>
        /// <param name="gl"></param>
        void EndPaint(OpenGLControl gl);
        /// <summary>
        /// Set some data for set
        /// </summary>
        /// <param name="gl"></param>
        void PrePaint(OpenGL gl);
        void Add(Vertex2D v);
        uint BeginType { get; }
        List<object> Elements { get; }
    }

    /// <summary>
    /// BaseClass for simplify
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class VisualSet<T> : IVisualSet where T : Vertex2D
    {
        /// <summary>
        /// Points
        /// </summary>
        protected List<T> vertex2Ds = new List<T>();

        public virtual void AddVertex(T vertex2D) => vertex2Ds.Add(vertex2D);

        public virtual uint BeginType => OpenGL.GL_LINE_STRIP;

        public List<object> Elements => vertex2Ds.Cast<object>().ToList();

        public virtual void PrePaint(OpenGL gl)
        {
        }

        public virtual void EndPaint(OpenGLControl gl)
        {
        }

        public virtual void Paint(OpenGL gl)
        {
            foreach (var v in vertex2Ds)
                v.Paint(gl);
        }

        public virtual void Add(Vertex2D v) => AddVertex((T)v);
    }

    /// <summary>
    /// Set for Vertexes
    /// </summary>
    public class SimpleSet : VisualSet<Vertex2D>
    {

    }

    /// <summary>
    /// Set for Brushes
    /// </summary>
    public class BrushSet : VisualSet<Brush>
    {
        /// <summary>
        /// Old line width 
        /// </summary>
        public float widthSet;

        public override void EndPaint(OpenGLControl gl) => gl.OpenGL.LineWidth(widthSet);

        public override void PrePaint(OpenGL gl)
        {
            float[] tmp = new float[1];
            gl.GetFloat(OpenGL.GL_LINE_WIDTH, tmp);
            widthSet = tmp[0];
            gl.LineWidth(vertex2Ds.FirstOrDefault()?.Widht ?? 0);
        }
    }

    /// <summary>
    /// EraseSet
    /// </summary>
    public class EraserSet : BrushSet { }

    public class ImageSet : VisualSet<Image>
    {
        float[] color = new float[4];
        public override uint BeginType => OpenGL.GL_QUADS;

        public override void EndPaint(OpenGLControl gl)
        {
            gl.OpenGL.Color(color[0], color[1], color[2], color[3]);
            gl.OpenGL.Disable(OpenGL.GL_TEXTURE_2D);
        }

        public override void PrePaint(OpenGL gl)
        {
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            gl.GetFloat(OpenGL.GL_COLOR, color);
            gl.Color(1.0, 1.0, 1.0, 1.0);
            foreach (var img in vertex2Ds)
                img.PrePaint(gl);
        }
    }

    public class SplineSet : VisualSet<Spline>
    {
        private readonly float size = 0.03f;
        private readonly List<Spline> points = new List<Spline>();

        public override void AddVertex(Spline vertex2D)
        {
            points.Add(vertex2D);
            vertex2Ds.Clear();
            vertex2Ds = new BezierSpline(points).GenerateSpline(50);
        }

        public override void EndPaint(OpenGLControl gl)
        {
            for (int i = 0; i < points.Count; i++)
            {
                var p = points[i];
                var startX = p.X - size / 2;
                var startY = p.Y - size / 2;
                gl.OpenGL.Begin(OpenGL.GL_LINE_STRIP);
                gl.OpenGL.Vertex(new[] { startX, startY });
                gl.OpenGL.Vertex(new[] { startX + size, startY });
                gl.OpenGL.Vertex(new[] { startX + size, startY + size });
                gl.OpenGL.Vertex(new[] { startX, startY + size });
                gl.OpenGL.Vertex(new[] { startX, startY });
                gl.OpenGL.End();
            }
        }
    }
}
