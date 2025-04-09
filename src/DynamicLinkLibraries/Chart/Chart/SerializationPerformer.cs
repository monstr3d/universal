using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Chart
{
    static class SerializationPerformer
    {

        static internal T GetObject<T>(SerializationInfo info, string name) where T : class, ISerializable
        {
            byte[] b = info.GetValue(name, typeof(byte[])) as byte[];
            MemoryStream ms = new MemoryStream(b);
            BinaryFormatter bf = new BinaryFormatter();
            return bf.Deserialize(ms) as T;
        }


        static internal void Serialize(ISerializable obj, SerializationInfo info, string name)
        {
            Type t = obj.GetType();
            System.Reflection.TypeInfo tt = System.Reflection.IntrospectionExtensions.GetTypeInfo(t);

            SerializableAttribute attr =
                System.Reflection.CustomAttributeExtensions.GetCustomAttribute<SerializableAttribute>(tt);

            if (attr == null)
            {
                throw new ErrorHandler.OwnException("Object have no Serializable attribute");
            }
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            info.AddValue(name, ms.GetBuffer(), typeof(byte[]));
        }
    }
}
