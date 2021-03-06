﻿using OpenGlProject.OpenGlElements;
using OpenGlProject.OpenGlElements.Sets;
using SharpGL;
using System.Collections.Generic;
using System.Linq;

namespace OpenGlProject
{
    /// <summary>
    /// 
    /// </summary>
    public class Layout
    {
        /// <summary>
        /// Sets
        /// </summary>
        private readonly List<IVisualSet> vertex2Ds = new List<IVisualSet>();
        public List<IFilterAccess> FilterAccesses => vertex2Ds.SelectMany(x => x.Elements).OfType<IFilterAccess>().ToList();

        public Layout(int index)
        {
            Index = index;
        }

        public bool IsInstrumentChanged { get; set; }

        public int Index { get; set; }
        /// <summary>
        /// Add vertex to last layout's set
        /// </summary>
        /// <param name="vertex2D"></param>
        public void AddVertex(Vertex2D vertex2D)
        {
            if (vertex2D.VertexType != VertexType.Spline)
                this.vertex2Ds.Last().Add(vertex2D);
        }
        /// <summary>
        /// Add new layout's set and add vertex to one
        /// </summary>
        /// <param name="vertex2D"></param>
        public void AddNewSet(Vertex2D vertex2D)
        {
            IVisualSet visualSet = null;
            switch (vertex2D.VertexType)
            {
                case VertexType.Vertex:
                    visualSet = new SimpleSet();
                    break;
                case VertexType.Brush:
                    visualSet = new BrushSet();
                    break;
                case VertexType.Eraser:
                    visualSet = new EraserSet();
                    break;
                case VertexType.Image:
                    visualSet = new ImageSet();
                    break;
                case VertexType.Spline:
                    visualSet = IsInstrumentChanged ? new SplineSet() : vertex2Ds.Last(x => x is SplineSet);
                    IsInstrumentChanged = false;
                    break;
            }

            visualSet?.Add(vertex2D);
            if (visualSet != null)
                vertex2Ds.Add(visualSet);
        }
        public void Clear() => vertex2Ds.Clear();
        /// <summary>
        /// Paint all active sets
        /// </summary>
        /// <param name="gl"></param>
        public void Paint(OpenGLControl gl)
        {
            foreach (var vertexSet in vertex2Ds)
            {
                vertexSet.PrePaint(gl.OpenGL);
                gl.OpenGL.Begin(vertexSet.BeginType);
                vertexSet.Paint(gl.OpenGL);
                gl.OpenGL.End();
                vertexSet.EndPaint(gl);
            }

            gl.OpenGL.Flush();
        }
    }
}
