using BaseTypes;
using CategoryTheory;
using DataPerformer.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;
using NamedTree;
using NamedTree.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataPerformer.Portable.Wrappers
{
    /// <summary>
    /// Common Wrapper
    /// </summary>
    public class CommonWrapper
    {

        readonly double a = 0;

        protected Performer performer = new();


        /// <summary>
        /// Starts component collection
        /// </summary>
        /// <param name="componentCollection">The collection</param>
        /// <param name="cancellationToken">The token</param>
        /// <returns>The task</returns>
        public async Task StartAsync(IComponentCollection componentCollection,
            CancellationToken cancellationToken)
        {
            var l = new List<Task>();
            performer.ForEach(componentCollection, (IStartTask t) =>
            {
                l.Add(t.StartAsync(cancellationToken));
            });
            await Task.WhenAll(l);
        }



        /// <summary>
        /// Gets double value of measure
        /// </summary>
        /// <param name="measurement">The measure</param>
        /// <returns>The double value</returns>
        public double ToDouble(IMeasurement measurement)
        {
            var parameter = measurement.Parameter;
            object o = parameter();
            if (o == null)
            {

            }
            return (double)o;
        }

        /// <summary>
        /// Checks whether type is double
        /// </summary>
        /// <param name="obj">The type</param>
        /// <returns>The result of checking</returns>
        public bool IsDoubleType(object obj)
        {
            if (obj == null)
            {

            }
            if (obj.Equals(a)) return true;
            if (obj is ArrayReturnType)
            {
                ArrayReturnType art = obj as ArrayReturnType;
                return art.ElementType.Equals(a);
            }
            return false;
        }

        /// <summary>
        /// Converts object to differential equation solver
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The solver</returns>
        public  IDifferentialEquationSolver ToDifferentialEquationSolver(object obj)
        {
            if (obj is IDifferentialEquationSolver)
            {
                return obj as IDifferentialEquationSolver;
            }
            if (obj is IChildren<IAssociatedObject> tt)
            {
                return tt.GetChild<IDifferentialEquationSolver>();
            }
            return null;
        }
    }
}