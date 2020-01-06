using SharpGL;
using System.Collections.Generic;
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
        void EndPaint(OpenGL gl);
        /// <summary>
        /// Set some data for set
        /// </summary>
        /// <param name="gl"></param>
        void PrePaint(OpenGL gl);
        void Add(Vertex2D v);
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

        public void AddVertex(T vertex2D) => vertex2Ds.Add(vertex2D);

        public virtual void PrePaint(OpenGL gl)
        {
        }

        public virtual void EndPaint(OpenGL gl)
        {
        }

        public virtual void Paint(OpenGL gl)
        {
            foreach (var v in vertex2Ds)
                v.Paint(gl);
        }

        public void Add(Vertex2D v) => AddVertex((T)v);
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

        public override void EndPaint(OpenGL gl) => gl.LineWidth(widthSet);

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
}
