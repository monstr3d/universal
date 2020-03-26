using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Event.Interfaces;
using Event.Log.Database.Interfaces;
using Event.Log.Database;

namespace Event.Basic.Logs
{
    class DatabaseDirectoryLogReader : ILogReaderCollection, IChangeLogItem
    {
        #region Fields

        ILogDirectory directory;

 
        event Action<ILogItem> change = (ILogItem item) => { };

        #endregion

        #region Ctor

        internal DatabaseDirectoryLogReader(ILogDirectory directory)
        {
            this.directory = directory;
        }

        #endregion

        #region Members of interfaces

        IEnumerable<ILogReader> ILogReaderCollection.Readers
        {
            get
            {
                foreach (ILogItem item in directory.FullDirectory(change))
                {
                    if (item is ILogData)
                    {
                        yield return new DatabaseLogReader(item as ILogData);
                    }
                }
            }
        }


        /* int ILogReader.FullLength
         {
             get
             {
                 int n = 0;
                 Action<ILogItem> act = (ILogItem item) =>
                 {
                     if (item is ILogData)
                     {
                         n += (item as ILogData).Length;
                     }
                 };
                 foreach (ILogItem item in directory.FullDirectory(act))
                 {
                 }
                 return n;
             }
         }

         IEnumerable<ILogReader> ILogReaderCollection.Readers
         {
             get
             {
                 throw new NotImplementedException();
             }
         }

         IEnumerable<object> ILogReader.Load(uint begin, uint end)
         {
             return null;
           /*!!! OLD VERSION  IEnumerable<ILogItem> enu = directory.FullDirectory(change);
             foreach (ILogItem item in enu)
             {
                 if (item is ILogData)
                 {
                     ILogData ld = item as ILogData;
                     IEnumerable<byte[]> ee = ld.Create(0, (uint)ld.Length);
                     IEnumerable<object> eno =
                         ee.EnumerableTransform(StaticExtensionEventBasic.TransformDeserialize);
                     foreach (object o in eno)
                     {
                         yield return o;
                     }
                 }
             }
             /        }*/

        event Action<ILogItem> IChangeLogItem.Change
        {
            add
            {
                change += value;
            }

            remove
            {
                change -= value;
            }
        }

        #endregion

        

    }
}
