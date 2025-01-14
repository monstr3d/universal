using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Copyright (c) 2012-2021 NMO13

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace EarClipperLib
{
    internal enum PropertyConstants
    {
        Marked, FaceListIndex, Median, IncidentEdges, HeVertexIndex
    }

    internal class DynamicProperties
    {
        private Dictionary<PropertyConstants, object> _properties = new Dictionary<PropertyConstants, object>();
        public int Count { get { return _properties.Count; } }

        internal void AddProperty(PropertyConstants key, object value)
        {
            _properties.Add(key, value);
        }

        internal bool ExistsKey(PropertyConstants key)
        {
            if (_properties.ContainsKey(key))
                return true;
            return false;
        }

        internal object GetValue(PropertyConstants key)
        {
            return _properties[key];
        }

        internal void ChangeValue(PropertyConstants key, object value)
        {
            if (!ExistsKey(key))
                throw new Exception("Key " + key + " was not found.");
            _properties[key] = value;
        }

        internal void Clear()
        {
            _properties.Clear();
        }

        internal void RemoveKey(PropertyConstants key)
        {
            _properties.Remove(key);
        }
    }
}
