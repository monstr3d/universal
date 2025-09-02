using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;
using DataPerformer.Interfaces;
using NamedTree;

namespace Dynamic.Atmosphere.Portable
{
    /// <summary>
    /// Dynamical atmosphere
    /// </summary>
    public class Atmosphere : Dynamic.Atmosphere.Atmosphere, ICategoryObject, IObjectTransformer
    {
        #region Fields

        private object obj;

        const double type = 0;

        static private readonly string[] sins = new string[] { "t", "x", "y", "z" };

        static private readonly string[] sous = new string[] { "Density" };

        CategoryTheory.Performer performer = new();


        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object
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

        #endregion

        #region IObjectTransformer Members

        string[] IObjectTransformer.Input
        {
            get { return sins; }
        }

        string[] IObjectTransformer.Output
        {
            get { return sous; }
        }

        string INamed.Name { get => performer.GetAssociatedName(this); set =>new  ErrorHandler.WriteProhibitedException(); }
       

        object IObjectTransformer.GetInputType(int i)
        {
            return type;
        }

        object IObjectTransformer.GetOutputType(int i)
        {
            return type;
        }

        void IObjectTransformer.Calculate(object[] input, object[] output)
        {
            double t = (double)input[0];
            for (int i = 0; i < 3; i++)
            {
                xout[i] = (double)input[i + 1];
            }
            double rho = Density(t, xout);
            output[0] = rho;
        }

        #endregion



    }
}
