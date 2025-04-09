using System;

using CategoryTheory;
using DataPerformer.Interfaces;
using NamedTree;
using Web.Interfaces;

namespace Gravity_36_36.Wrapper
{
    /// <summary>
    /// Gravity field
    /// </summary>
    public class Gravity : Gravity_36_36.Gravity, ICategoryObject, IObjectTransformer,
       IUrlProvider, IUrlConsumer
    {
        #region Fields

        CategoryTheory.Performer performer = new();


        object obj;

        double ret = 0;

        protected string url;

        /// <summary>
        /// Inputs
        /// </summary>
        static private readonly string[] inputs = new string[] { "x", "y", "z" };

        /// <summary>
        /// Outputs
        /// </summary>
        static private readonly string[] outputs = new string[] { "Gx", "Gy", "Gz" };

        protected event Action<string> changeConsumer = (string url) => { };

        protected event Action<string> changeProvider = (string url) => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public Gravity()
            : base()
        {

        }

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
            get
            {
                return inputs;
            }
        }

        string[] IObjectTransformer.Output
        {
            get
            {
                return outputs;
            }
        }


        void IObjectTransformer.Calculate(object[] input, object[] output)
        {
            // Input cast
            double x = (double)input[0];
            double y = (double)input[1];
            double z = (double)input[2];

            double fx, fy, fz;

            // Call of forces
            Forces(x, y, z, out fx, out fy, out fz);

            // filling of output
            output[0] = fx;
            output[1] = fy;
            output[2] = fz;
        }

        object IObjectTransformer.GetInputType(int i)
        {
            return ret;
        }

        object IObjectTransformer.GetOutputType(int i)
        {
            return ret;
        }


        #endregion

        #region IUrlConsumer Members


        string IUrlConsumer.Url
        {
            set
            {
                url = value;
                ChangeConsumer();
                changeConsumer(url);
            }
        }


        event Action<string> IUrlConsumer.Change
        {
            add
            {
                changeConsumer += value;
            }

            remove
            {
                changeConsumer -= value;
            }
        }

        #endregion

        #region IUrlProvider Members

        string IUrlProvider.Url
        {
            get
            {
                ChangeProvider();
                changeProvider(url);
                return url;
            }
        }

        string INamed.Name { get => performer.GetAssociatedName(this); set =>new  ErrorHandler.WriteProhibitedException(); }

        event Action<string> IUrlProvider.Change
        {
            add
            {
                changeProvider += value;
            }

            remove
            {
                changeConsumer += value;
            }
        }

        #endregion
 
        #region Protected Members

        /// <summary>
        /// The change consumer URL
        /// </summary>
        protected virtual void ChangeConsumer()
        {

        }

        /// <summary>
        /// The change provider URL
        /// </summary>
        protected virtual void ChangeProvider()
        {

        }

        #endregion


    }
}
