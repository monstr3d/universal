using System;

namespace Event.Interfaces
{
    class EventReaderLink : IDisposable
    {

        IEventReader reader;

        string name;

        IEventLog log;

        internal EventReaderLink(IEventReader reader, IEventLog log, string name)
        {
            this.reader = reader;
            this.log = log;
            this.name = name;
            reader.EventData += Log;
        }

        void Log(object[] output)
        {
            log.Write(reader, name, output, DateTime.Now);
        }

        #region IDisposable Support

        /// <summary>
        /// Disposes itself
        /// </summary>
        public void Dispose()
        {
            if (reader != null)
            {
                reader.EventData -= Log;
            }
            reader = null;
        }

        #endregion


    }
}
