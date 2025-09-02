using System;
using System.Collections;
using System.Collections.Generic;
using CategoryTheory;
using ErrorHandler;

namespace MathGraph
{
    /// <summary>
    /// Digraph
    /// </summary>
    public class Digraph
    {

        #region Fields

        /// <summary>
        /// The "in not a path" string
        /// </summary>
        static public readonly string NotPath = "This diagram is not a path";

        /// <summary>
        /// Vertices
        /// </summary>
        protected List<DigraphVertex> vertices = new List<DigraphVertex>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Digraph()
        {
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Transforms digraph
        /// </summary>
        /// <param name="vertTransformer">Vertex transformer</param>
        /// <param name="edgeTransformer">Edge transformer</param>
        public void Transform(Func<object, object> vertTransformer, Func<object, object> edgeTransformer)
        {
            foreach (DigraphVertex v in vertices)
            {
                v.Object = vertTransformer(v.Object);
                foreach (DigraphEdge edge in v.OutcomingEdges)
                {
                    edge.Object = edgeTransformer(edge.Object);
                }
            }
        }

        /// <summary>
        /// Adds vertex to this digraph
        /// </summary>
        /// <param name="vertex">Vertex to add</param>
        public void AddVertex(DigraphVertex vertex)
        {
            if (vertices.Contains(vertex))
            {
                throw new OwnException("Vertex already exists");
            }
            vertices.Add(vertex);
        }

        /// <summary>
        /// Removes vertex from this digraph
        /// </summary>
        /// <param name="vertex">Vertex to remove</param>
        public void RemoveVertex(DigraphVertex vertex)
        {
            if (vertices.Contains(vertex))
            {
                vertices.Remove(vertex);
            }
            if (vertex is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        /// <summary>
        /// Resets indexes if vetices
        /// </summary>
        public void Reset()
        {
            foreach (DigraphVertex v in vertices)
            {
                v.Index = -1;
            }
        }

        /// <summary>
        /// Loops of digraph
        /// </summary>
        public List<DigraphLoop> Loops
        {
            get
            {
                List<DigraphLoop> list = new List<DigraphLoop>();
                Reset();
                foreach (DigraphVertex v in vertices)
                {
                    v.GetLoops(list);
                    Reset();
                }
                return list;
            }
        }

        /// <summary>
        /// Count of vertices
        /// </summary>
        public int Count
        {
            get
            {
                return vertices.Count;
            }
        }

        /// <summary>
        /// Access to i th vertex
        /// </summary>
        public DigraphVertex this[int i]
        {
            get
            {
                return vertices[i] as DigraphVertex;
            }
        }

        /// <summary>
        /// Digraph path. Throws exception if digraph is not a path
        /// </summary>
        public DigraphEdge[] Path
        {
            get
            {
                List<DigraphEdge> e = new List<DigraphEdge>();
                List<DigraphVertex> v = new List<DigraphVertex>();
                DigraphVertex current = null;
                foreach (DigraphVertex vertex in vertices)
                {
                    if (vertex.IncomingEdges.Count == 0)
                    {
                        current = vertex;
                        break;
                    }
                }
                if (current == null)
                {
                    throw new OwnException(NotPath);
                }
                v.Add(current);
                while (current.OutcomingEdges.Count > 0)
                {
                    if (current.OutcomingEdges.Count > 1)
                    {
                        throw new OwnException(NotPath);
                    }
                    DigraphEdge edge = current.OutcomingEdges[0] as DigraphEdge;
                    current = edge.Target;
                    if ((current.IncomingEdges.Count > 1) | v.Contains(current))
                    {
                        throw new OwnException(NotPath);
                    }
                    v.Add(current);
                    e.Add(edge);
                }
                foreach (DigraphVertex vertex in vertices)
                {
                    if (!v.Contains(vertex))
                    {
                        throw new OwnException(NotPath);
                    }
                }
                DigraphEdge[] path = new DigraphEdge[e.Count];
                for (int i = 0; i < path.Length; i++)
                {
                    path[i] = e[i] as DigraphEdge;
                }
                return path;
            }
        }

        #endregion

    }
}
