using System;

using CategoryTheory;

using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using System.Collections.Generic;

namespace DinAtm.Portable
{
    /// <summary>
    /// Atmosphere
    /// </summary>
    public class Atmosphere : Pure.Atmosphere, ICategoryObject, IObjectTransformer, IAlias, IAssociatedObject
    {

        const Double type = 0;

        const Int32 atype = 0;

        protected object obj;

        private Action<IAlias, string> onChange = (IAlias a, string n) => { };

        private static readonly List<string> names = new List<string>()  {"F107A", "Ap", "F107"};

        private static readonly Dictionary<string, int> dnames = new Dictionary<string, int> 
            {
            {names[0], 0 },
            {names[1], 1 },
            {names[2], 2 },
            };


        #region IAssociatedObject Members

        object IAssociatedObject.Object { get => obj; set { obj = value; } }

        #endregion

        #region IAlias Members

        object IAlias.GetType(string name)
        {
            return atype;
        }

        IList<string> IAlias.AliasNames => names;

        object IAlias.this[string name]
        { get => ifa[dnames[name]]; 
            set { ifa[dnames[name]] = (int)value; onChange(this, name); } 
        }

        event Action<IAlias, string> IAlias.OnChange
        {
            add
            {
                onChange += value;
            }

            remove
            {
                onChange -= value;
            }
        }

        object IObjectTransformer.GetInputType(int i)
        {
            return type;
        }

        #endregion

        #region IObjectTransformer Members


        object IObjectTransformer.GetOutputType(int i)
        {
            return type;
        }



        string[] IObjectTransformer.Input
        {
            get { return sins; }
        }

        string[] IObjectTransformer.Output
        {
            get { return sous; }
        }

        void IObjectTransformer.Calculate(object[] input, object[] output)
        {
            double t = (double)input[0];
            for (int i = 0; i < 3; i++)
            {
                xout[i] = (double)input[i + 1];
            }
            double rho = Atm(t, xout);
            output[0] = rho;
        }



        #endregion


    }

}
