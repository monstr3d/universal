using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using ErrorHandler;

namespace MathGraph
{

    /// <summary>
    /// Loop of digraph
    /// </summary>
    public class DigraphLoop
    {
        /// <summary>
        /// Paths in loop
        /// </summary>
        protected DigraphPath[] paths;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="paths">paths</param>
        public DigraphLoop(DigraphPath[] paths)
        {
            if (paths.Length != 2)
            {
                throw new OwnException("Illegal number of paths");
            }
            if ((paths[0].Source != paths[1].Source) | (paths[0].Target != paths[1].Target))
            {
                throw new OwnException("Illegal endpoints of loop");
            }
            this.paths = paths;
        }

        /// <summary>
        /// Overriden "Equals" function
        /// </summary>
        /// <param name="o">Object to compare</param>
        /// <returns>True if o equals this object and false otherwise</returns>
        public override bool Equals(object o)
        {
            DigraphLoop l = o as DigraphLoop;
            return ((paths[0].Equals(l.paths[0]) & paths[1].Equals(l.paths[1]))
                | (paths[0].Equals(l.paths[1]) & paths[1].Equals(l.paths[0])));
        }

        /// <summary>
        /// Overriden "GetHashCode" function
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return paths[0].Count * paths[1].Count;
        }

        /// <summary>
        /// Checks whether this loop contains the edge
        /// </summary>
        /// <param name="edge">The edge to check</param>
        /// <returns>True if this loop contains edge and false otherwise</returns>
        public bool Contains(DigraphEdge edge)
        {
            return paths[0].Contains(edge) | paths[1].Contains(edge);
        }

        /// <summary>
        /// Checks whether this loop contains object
        /// </summary>
        /// <param name="o">The object to check</param>
        /// <returns>True if this loop contains the object and false otherwise</returns>
        public bool ContainsObject(object o)
        {
            return paths[0].ContainsObject(o) | paths[1].ContainsObject(o);
        }

        /// <summary>
        /// Reducing
        /// </summary>
        public void Reduce()
        {
            reduceBegin();
            reduceEnd();
        }

        /// <summary>
        /// Return i - ths path
        /// </summary>
        public DigraphPath this[int i]
        {
            get
            {
                return paths[i];
            }
        }

        /// <summary>
        /// Reduces begin of loop
        /// </summary>
        protected void reduceBegin()
        {
            int i = 0;
            for (; i < paths[0].Count & i < paths[1].Count; i++)
            {
                if (paths[0][i] != paths[1][i])
                {
                    break;
                }
            }
            for (int j = 0; j < 2; j++)
            {
                DigraphPath path = paths[j];
                List<DigraphEdge> l = new List<DigraphEdge>();
                for (int k = i; k < path.Count; k++)
                {
                    l.Add(path[k]);
                }
                paths[j] = new DigraphPath(l, false);
            }
        }

        /// <summary>
        /// Reduces end of loop
        /// </summary>
        protected void reduceEnd()
        {
            int i = 1;
            for (; i < paths[0].Count & i < paths[1].Count; i++)
            {
                if (paths[0][paths[0].Count - i] != paths[1][paths[1].Count - i])
                {
                    break;
                }
            }
            for (int j = 0; j < 2; j++)
            {
                DigraphPath path = paths[j];
                List<DigraphEdge> l = new List<DigraphEdge>();
                for (int k = 0; k < path.Count - i + 1; k++)
                {
                    l.Add(path[k]);
                }
                paths[j] = new DigraphPath(l, false);
            }
        }
    }
}
