using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CategoryTheory;

using Diagram.UI.Interfaces;


using DataPerformer.Interfaces;
using DataPerformer;


using Simulink.CSharp.Library.Interfaces;
using Simulink.Parser.Library.DiagramElements;
using DataPerformer.Portable.Measurements;

namespace Simulink.CSharp.Proxy.DifferentialEquations
{
    class StateSolver : CategoryObject, IDifferentialEquationSolver, IStack
    {
        #region Fields

        IStateCalculation calculation;

        bool isUpdated;

        int count;

       IMeasurement[] mea;

        double[] state;

        double[] der;

        Stack<double[]> stack = new Stack<double[]>();

        IMeasurements parent;
        
        #endregion

        internal StateSolver(IStateCalculation calculation, IMeasurements parent, Block[] blocks)
        {
            this.calculation = calculation;
            this.parent = parent;
            count = calculation.State.Length;
            state = calculation.State;
            der = calculation.Derivation;
            List<IMeasurement> l = new List<IMeasurement>();
            int k = 0;
            for (int i = 0; i < blocks.Length; i++)
            {
                Block block = blocks[i];
                string name = block.Name;
                name = name.Replace("/", " ") + "_";
                string dname = "D_" + name;
                for (int j = 0; j < block.Dim; j++)
                {
                    int[] mm = new int[] { k };
                    Func<object> f = () => state[mm[0]];
                    Func<object> deri = () => der[mm[0]];
                    ++k;
                    Measurement m = new Measurement(deri, dname + j);
                    MeasurementDerivation md = new MeasurementDerivation(f, m, name + j);
                    l.Add(md);
                }
            }
            mea = l.ToArray();
        }


        #region IDifferentialEquationSolver Members

        void IDifferentialEquationSolver.CalculateDerivations()
        {
            parent.UpdateMeasurements();
        }

        void IDifferentialEquationSolver.CopyVariablesToSolver(int offset, double[] variables)
        {
            Array.Copy(variables, offset, calculation.State, 0, count); 
        }

        List<string> IStateDoubleVariables.Variables
        {
            get 
            {
                int n = calculation.State.Length;
                List<string> l = new List<string>();
                for (int i = 0; i < n; i++)
                {
                    l.Add("var_" + i);
                }
                return l;
            }
        }

        double[] IStateDoubleVariables.Vector
        {
            get
            {
                return calculation.State;
            }
            set
            {
            }
        }

        void IStateDoubleVariables.Set(double[] input, int offset, int length)
        {
            Array.Copy(input, offset, calculation.State, 0, count);
        }

  
        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return mea.Length; }
        }

        IMeasurement IMeasurements.this[int number]
        {
            get { return mea[number]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            //calculation.Update();
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return isUpdated;
            }
            set
            {
                isUpdated = value;
            }
        }





        #endregion

        #region IStack Members

        void IStack.Push()
        {
            double[] x = new double[state.Length];
            Array.Copy(state, x, state.Length);
            stack.Push(x);
        }

        void IStack.Pop()
        {
            double[] x = stack.Pop();
            Array.Copy(x, state, x.Length);
        }

        #endregion

    }
}
