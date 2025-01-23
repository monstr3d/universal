using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public  class StringWriterWithEncoding : StringWriter
    {
        private readonly Encoding encoding;

        public StringWriterWithEncoding(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public override Encoding Encoding
        {
            get
            {
                return encoding;
            }
        }
    }

    public class Utf8StringWriter : StringWriterWithEncoding
    {
        public Utf8StringWriter() : base(Encoding.UTF8)
        {

        }
    }


}
