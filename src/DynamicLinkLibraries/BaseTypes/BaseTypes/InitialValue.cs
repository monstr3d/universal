using BaseTypes.Interfaces;

namespace BaseTypes
{

    public class InitialValue: IInitialValue
    {
        IValue val;

        object initial;

        public InitialValue(IValue val, object initial)
        {
            this.val = val;
            this.initial = initial;
        }

        object IInitialValue.Value { get => initial; set  {} }

        void IInitialValue.Set()
        {
           val.Value = initial;
        }
    }
}
