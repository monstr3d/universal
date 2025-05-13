using BaseTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTypes
{
    class SimpleDisassemblyObject : IDisassemblyObject
    {
        #region Fields

        static public readonly SimpleDisassemblyObject Singleton = new SimpleDisassemblyObject();

        List<Tuple<string, object>> types;

        static Dictionary<object, SimpleDisassemblyObject> objects = new Dictionary<object, SimpleDisassemblyObject>();

        #endregion

        #region Ctor

        private SimpleDisassemblyObject()
        {

        }

        /// <summary>
        /// Creating disassembly for each base type involved
        /// </summary>
        /// <param name="type"></param>
        private SimpleDisassemblyObject(object type)
        {
            if (StaticExtensionBaseTypes.SimpleTypes.Contains(type))
            {
                this.types = new List<Tuple<string, object>>(1) { new Tuple<string, object>(StaticExtensionBaseTypes.GetTypeString(type), type) };
            }
        }

        static SimpleDisassemblyObject()
        {

            foreach(object key in StaticExtensionBaseTypes.SimpleTypeList)
            {
                objects[key] = new SimpleDisassemblyObject(key);
            }
            
       
        }



        #endregion

        #region IDiasssemblyObject members

        IDisassemblyObject IDisassemblyObject.this[object type]
        {
            get
            {
                if (objects.ContainsKey(type))
                {
                    return objects[type];
                }
                return null;
            }
        }

        List<Tuple<string, object>> IDisassemblyObject.Types
        {
            get
            {
                return types;
            }
        }

        object[] IDisassemblyObject.Disassembly(object obj)
        {
            return new object[1] { obj };
        }

        #endregion

    }
}
