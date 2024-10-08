﻿namespace DataPerformer.Portable.Measurements
{
    class ArrayMeasurement : Measurement
    {
        #region Fields

        object[][] obj;

        int i;

        #endregion

        #region Ctor

        internal ArrayMeasurement(object[][] obj, object type, int number, string name, object ob) : base(type, null, name, ob)
        {
            i = number;
            this.obj = obj;
            parameter = () => { return obj[0][i]; };
        }

        #endregion
    }
}
