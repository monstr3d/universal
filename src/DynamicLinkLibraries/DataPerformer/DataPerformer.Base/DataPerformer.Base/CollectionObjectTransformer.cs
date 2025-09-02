using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;
using DataPerformer.Interfaces;

namespace DataPerformer
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class CollectionObjectTransformer : CategoryObject, ISerializable, IObjectTransformer
    {

        #region Members

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new ErrorHandler.WriteProhibitedException();
        }

        #endregion

        #region IObjectTransformer Members

        string[] IObjectTransformer.Input
        {
            get { throw new ErrorHandler.WriteProhibitedException();  }
        }

        string[] IObjectTransformer.Output
        {
            get { throw new ErrorHandler.WriteProhibitedException(); }
        }

        object IObjectTransformer.GetInputType(int i)
        {
            throw new ErrorHandler.WriteProhibitedException();
        }

        object IObjectTransformer.GetOutputType(int i)
        {
            throw new ErrorHandler.WriteProhibitedException();
        }

        void IObjectTransformer.Calculate(object[] input, object[] output)
        {
            throw new ErrorHandler.WriteProhibitedException(); 
        }

        #endregion
    }
}
