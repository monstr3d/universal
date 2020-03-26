using System;
using System.Collections.Generic;
using System.Text;


namespace Motion6D
{
    class ScalarFieldTransformer : IFieldTransformer
    {
        public static readonly ScalarFieldTransformer Object = new ScalarFieldTransformer();

        private ScalarFieldTransformer()
        {
        }

        #region IFieldTransformer Members

        object IFieldTransformer.Transform(double[,] transformMatrix, object value)
        {
            return value;
        }

        #endregion
    }
}
