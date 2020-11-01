using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


using PhysicalField.Interfaces;


namespace PhysicalField.Support
{
    public abstract class PhysicalFieldDataConsumer : Portable.PhysicalFieldDataConsumer, ISerializable
    {
       

        #region Ctor

        protected PhysicalFieldDataConsumer()
        {
            cons = this;
            IPhysicalField f = this;
            input = new string[f.SpaceDimension];
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected PhysicalFieldDataConsumer(SerializationInfo info, StreamingContext context)
            : this()
        {
            input = info.GetValue("Input", typeof(string[])) as string[];
            output = info.GetValue("Output", typeof(string[])) as string[];
            transformationTypes = info.GetValue("TransformationTypes", typeof(object[])) as object[];
        }

        #endregion

        #region ISerializable Members

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Input", input, typeof(string[]));
            info.AddValue("Output", output, typeof(string[]));
            info.AddValue("TransformationTypes", transformationTypes, typeof(object[]));
        }

        #endregion

 
    }
}
