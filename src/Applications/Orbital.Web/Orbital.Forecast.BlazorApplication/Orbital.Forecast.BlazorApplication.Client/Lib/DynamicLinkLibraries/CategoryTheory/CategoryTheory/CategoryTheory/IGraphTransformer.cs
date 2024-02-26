using System;
using System.Collections.Generic;
using System.Text;

namespace MathGraph
{
    /// <summary>
    /// Transformer of associated with vertices and edges objects
    /// </summary>
    public interface IGraphTransformer
    {
        /// <summary>
        /// Transforms graph vertex
        /// </summary>
        /// <param name="o">Transformed vertex</param>
        /// <returns>Result of transformation</returns>
        object TransformVertex(object o);

        /// <summary>
        /// Tranforms graph edge
        /// </summary>
        /// <param name="o">Transformed edge</param>
        /// <returns>Result of transformation</returns>
        object TransformEdge(object o);
    }
}
