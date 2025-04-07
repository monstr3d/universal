using System;

using BaseTypes;

using CategoryTheory;

using Diagram.UI;


using DataPerformer.Interfaces;
using NamedTree;

namespace DataPerformer.Portable.Wrappers
{
    public class CommonWrapper
    {

        readonly Double a = 0;

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