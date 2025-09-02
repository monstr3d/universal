using BaseTypes.Interfaces;
using Diagram.UI.Interfaces;

namespace Diagram.UI
{
    public class AliasInit: IInitialValue
    {
        IAliasName aiasName;

        IValue value;

        public AliasInit(IAliasName aiasName, IValue value)
        {
            this.aiasName = aiasName;
            this.value = value;
        }

        public object Value { get => aiasName.Value; set => aiasName.Value = value; }

        public void Set()
        {
            value.Value = aiasName.Value;
        }
    }
}
