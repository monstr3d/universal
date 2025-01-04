using System.Runtime.Serialization;

namespace Conversion3D.WebApplication.Models
{
    [Serializable]
    public class Header : ISerializable
    {

        public int Size { get; private set; }

        public string FileName { get; private set; }

        public string Extension { get; private set; }

        public Header(int size, string fileName, string extension)
        {
            Size = size;
            FileName = fileName;
            Extension = extension;
        }

        private Header(SerializationInfo info, StreamingContext context)
        {
            Size = info.GetInt32("Size");
            FileName = info.GetString("FileName");
            Extension = info.GetString("Extension");
        }


        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Size", Size);
            info.AddValue("FileName", FileName);
            info.AddValue("Extension", FileName);

        }
    }
}
