using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using CategoryTheory;

namespace MathGraph
{
    /// <summary>
    /// Vertex of digraph
    /// </summary>
    public class DigraphVertex : IAssociatedObject, IRemovableObject
    {
        /// <summary>
        /// Linked object
        /// </summary>
        protected object obj;

        /// <summary>
        /// Incoming edges
        /// </summary>
        protected List<DigraphEdge> incomingEdges = new List<DigraphEdge>();

        /// <summary>
        /// Outcoming edges
        /// </summary>
        protected List<DigraphEdge> outcomingEdges = new List<DigraphEdge>();

        /// <summary>
        /// The index
        /// </summary>
        protected int index;

        /// <summary>
        /// Parent graph
        /// </summary>
        protected Digraph parent;

        /// <summary>
        /// Old vertices in loop searching
        /// </summary>
        private List<DigraphVertex> oldVertices = new List<DigraphVertex>();

        /// <summary>
        /// New vertices in loop searching
        /// </summary>
        private List<DigraphVertex> newVertices = new List<DigraphVertex>();

        /// <summary>
        /// Loops of paths
        /// </summary>
        private List<DigraphPath> pathLoops = new List<DigraphPath>();


        /// <summary>
        /// Concructor
        /// </summary>
        /// <param name="digraph">Digraph of this vertex</param>
        public DigraphVertex(Digraph digraph)
        {
            parent = digraph;
            parent.AddVertex(this);
        }

        /// <summary>
        /// Adds new path
        /// </summary>
        /// <param name="path">The path to add</param>
        /// <returns>False if path have been already added and true otherwise</returns>
        public bool AddPath(DigraphPath path)
        {
            foreach (object o in pathLoops)
            {
                if (path.Equals(o))
                {
                    return false;
                }
            }
            pathLoops.Add(path);
            return true;
        }

        /// <summary>
        /// The associated object
        /// </summary>
        public object Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        /// <summary>
        /// Adds incoming edge
        /// </summary>
        /// <param name="edge">The edge to add</param>
        public void AddIncoming(DigraphEdge edge)
        {
            incomingEdges.Add(edge);
        }

        /// <summary>
        /// Removes incoming edge
        /// </summary>
        /// <param name="edge">The edge to remove</param>
        public void RemoveIncoming(DigraphEdge edge)
        {
            incomingEdges.Remove(edge);
        }

        /// <summary>
        /// Adds outcoming edge
        /// </summary>
        /// <param name="edge">The edge to add</param>
        public void AddOutcoming(DigraphEdge edge)
        {
            outcomingEdges.Add(edge);
        }

        /// <summary>
        /// Removes outcoming edge
        /// </summary>
        /// <param name="edge">The edge to remove</param>
        public void RemoveOutcoming(DigraphEdge edge)
        {
            outcomingEdges.Remove(edge);
        }

        /// <summary>
        /// Removes itself
        /// </summary>
        public void RemoveObject()
        {
            foreach (DigraphEdge e in incomingEdges)
            {
                e.RemoveObject();
            }
            foreach (DigraphEdge e in outcomingEdges)
            {
                e.RemoveObject();
            }
            parent.RemoveVertex(this);
        }

        /// <summary>
        /// Outcoming edges
        /// </summary>
        public List<DigraphEdge> OutcomingEdges
        {
            get
            {
                return outcomingEdges;
            }
        }

        /// <summary>
        /// Incoming edges
        /// </summary>
        public List<DigraphEdge> IncomingEdges
        {
            get
            {
                return incomingEdges;
            }
        }

        /// <summary>
        /// The index of vertex
        /// </summary>
        public int Index
        {
            set
            {
                index = value;
            }
            get
            {
                return index;
            }
        }

        /// <summary>
        /// Parent digraph
        /// </summary>
        public Digraph Parent
        {
            get
            {
                return parent;
            }
        }

        /// <summary>
        /// Gets all loops
        /// </summary>
        /// <param name="list">List of loops</param>
        public void GetLoops(List<DigraphLoop> list)
        {
            pathLoops.Clear();
            index = 0;
            newVertices.Add(this);
            while (step())
            {
            }
            for (int i = 0; i < pathLoops.Count; i++)
            {
                DigraphPath path1 = pathLoops[i] as DigraphPath;
                for (int j = i + 1; j < pathLoops.Count; j++)
                {
                    DigraphPath path2 = pathLoops[j] as DigraphPath;
                    if ((path1.Source != path2.Source) | (path1.Target != path2.Target))
                    {
                        continue;
                    }
                    DigraphLoop loop = new DigraphLoop(new DigraphPath[] { path1, path2 });
                    loop.Reduce();
                    if (list.Contains(loop))
                    {
                        continue;
                    }
                    list.Add(loop);
                }
            }
        }

        /// <summary>
        /// Gets closed loops
        /// </summary>
        public List<DigraphPath> ClosedLoops
        {
            get
            {
                pathLoops.Clear();
                while (stepClosedLoop())
                {
                }
                return pathLoops;
            }
        }

        /// <summary>
        /// Step for closed loops finding 
        /// </summary>
        /// <returns>True if process is not finished and false otherwise</returns>
        private bool stepClosedLoop()
        {
            oldVertices.Clear();
            oldVertices.AddRange(newVertices);
            newVertices.Clear();
            foreach (DigraphVertex v in oldVertices)
            {
                foreach (DigraphEdge e in v.outcomingEdges)
                {
                    DigraphVertex t = e.Target;
                    if (t == this)
                    {
                        List<DigraphEdge> l = new List<DigraphEdge>();
                        e.Source.backwardPath(e.Source.index - 1, l);
                        l.Add(e);
                        DigraphPath path = new DigraphPath(l, true);
                        AddPath(path);
                        continue;
                    }
                    if (t.index == -1)
                    {
                        t.index = v.index + 1;
                        newVertices.Add(t);
                        continue;
                    }
                    List<DigraphEdge> list = new List<DigraphEdge>();
                    List<DigraphEdge> incoming = t.IncomingEdges;
                    foreach (DigraphEdge et in incoming)
                    {
                        if (et == e)
                        {
                            continue;
                        }
                        if (et.Source.index == t.index - 1)
                        {
                            list.Add(et);
                            et.Source.backwardPath(et.Source.index - 1, list);
                            break;
                        }
                    }
                    //DigraphPath path = new DigraphPath(list, true);
                    //AddPath(path);
                    //ArrayList newList = new ArrayList();
                    //newList.Add(e);
                    //v.backwardPath(v.index - 1, newList);
                    //DigraphPath newPath = new DigraphPath(newList, true);
                    //AddPath(newPath);
                }
            }
            return newVertices.Count > 0;

        }



        /// <summary>
        /// Step for loops finding
        /// </summary>
        /// <returns>True if process is not finished and false otherwise</returns>
        private bool step()
        {
            oldVertices.Clear();
            oldVertices.AddRange(newVertices);
            newVertices.Clear();
            foreach (DigraphVertex v in oldVertices)
            {
                foreach (DigraphEdge e in v.outcomingEdges)
                {
                    DigraphVertex t = e.Target;
                    if (t.index == -1)
                    {
                        t.index = v.index + 1;
                        newVertices.Add(t);
                        continue;
                    }
                    List<DigraphEdge> list = new List<DigraphEdge>();
                    List<DigraphEdge> incoming = t.IncomingEdges;
                    foreach (DigraphEdge et in incoming)
                    {
                        if (et == e)
                        {
                            continue;
                        }
                        if (et.Source.index == t.index - 1)
                        {
                            list.Add(et);
                            et.Source.backwardPath(et.Source.index - 1, list);
                            break;
                        }
                    }
                    DigraphPath path = new DigraphPath(list, true);
                    AddPath(path);
                    List<DigraphEdge> newList = new List<DigraphEdge>();
                    newList.Add(e);
                    v.backwardPath(v.index - 1, newList);
                    DigraphPath newPath = new DigraphPath(newList, true);
                    AddPath(newPath);
                }
            }
            return newVertices.Count > 0;
        }

        /// <summary>
        /// Calculates backward shortest path 
        /// </summary>
        /// <param name="index">Path length</param>
        /// <param name="list">The path</param>
        private void backwardPath(int index, List<DigraphEdge> list)
        {
            foreach (DigraphEdge e in incomingEdges)
            {
                DigraphVertex v = e.Source;
                if (v.index == index)
                {
                    list.Add(e);
                    if (index == 0)
                    {
                        return;
                    }
                    v.backwardPath(index - 1, list);
                    return;
                }
            }
        }

    }
}
