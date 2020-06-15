using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Standard
{
    public class InputOutputIndicator : IIndicator
    {
        #region Fields

        static List<InputOutputIndicator> l = new List<InputOutputIndicator>();

        Action<object> output;

        string parameter;

        object o;

        object type;

        bool isActive;

        Action<object> update;

        Action upd;

        #endregion

        #region Ctor

        private InputOutputIndicator(Action<object> output, string parameter, object type, bool compare = true)
        {
            this.output = output;
            this.parameter = parameter;
            this.type = type;
            o = type;
            update = UpdateInernal;
            upd = UpdateInernal;
        }

        #endregion

        #region IIndicator members

        Action IIndicator.Update => upd;

        string IIndicator.Parameter => parameter;

        object IIndicator.Value { set => update(value); }

        object IIndicator.Type => type;

        bool IIndicator.IsActive { get => isActive; set => SetActive(value); }

        #endregion

        #region Overriden

        public override bool Equals(object obj)
        {
            if (!(obj is InputOutputIndicator))
            {
                return false;
            }
            InputOutputIndicator ii = obj as InputOutputIndicator;
            return (ii.parameter.Equals(parameter) & ii.output == output);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Public

        static public InputOutputIndicator  Create(Action<object> output, string parameter, object type, bool compare = true)
        {
            var i = new InputOutputIndicator(output, parameter, type, compare);
            if (l.Contains(i))
            {
                return null;
            }
            l.Add(i);
            return i;
        }
        #endregion

        void SetActive(bool active)
        {
            if (active == isActive)
            {
                return;
            }
            if (active)
            {
                upd = UpdateInernal;
                update = UpdateInernal;
                return;
            }
            update = (object o) => { };
            upd = () => { };
        }

        void UpdateInernal(object x)
        {
            if (o.Equals(x))
            {
                return;
            }
            o = x;
            output(o);
        }

        void UpdateInernal()
        {
            output(o);
        }
    }
}
