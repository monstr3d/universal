using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEngineering.UI.Factory.Advanced.Converters
{
    class ListPropertyDescriptor<C, T> : PropertyDescriptor where C : IList
    {
        private readonly T _dataObject;

        public ListPropertyDescriptor(string name, T dataObject)
            : base(name, null)
        {
            this._dataObject = dataObject;
        }


        public override bool CanResetValue(object component)
        {
            return (false);
        }

        public override Type ComponentType
        {
            get { return (typeof(C)); }
        }

        public override object GetValue(object component)
        {
            return (this._dataObject);
        }

        public override bool IsReadOnly
        {
            get { return (true); }
        }

        public override Type PropertyType
        {
            get { return (this._dataObject.GetType()); }
        }

        public override void ResetValue(object component)
        {
            // Nothing to do
        }

        public override void SetValue(object component, object value)
        {
            // Nothing to do
        }

        public override bool ShouldSerializeValue(object component)
        {
            return (false);
        }
    }
}
