using System;
using System.Collections.Generic;
using System.Text;
using DataPerformer;
using DataPerformer.Interfaces;


namespace ImageTransformations
{
    #region ConstMeasure

    class ConstMeasurement : IMeasurement, IDerivation
    {
        const Int32 t = 0;
        private int c;
        const double z = 0;

        string name;


        Func<object> der;

        Func<object> par;

        internal ConstMeasurement(int c, string name)
        {
            this.c = c;
            this.name = name;
            par = getP;
            der = getD;
        }

        #region IMeasurement Members

        Func<object> IMeasurement.Parameter
        {
            get { return par; }
        }

        string IMeasurement.Name
        {
            get { return name; }
        }

        object IMeasurement.Type
        {
            get { return t; }
        }

        #endregion

        object getP()
        {
            return c;
        }
        object getD()
        {
            return z;
        }

        #region IDerivation Members

        IMeasurement IDerivation.Derivation
        {
            get { return DataPerformer.Portable.Measurements.ConstantMeasurement.Zero; }
        }

        #endregion
    }

    #endregion
}
