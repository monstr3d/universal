using System;

namespace DataPerformer.Interfaces.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InternalVariableAttribute : Attribute
    {
        public bool IsDerivation
        {
            get;
            set;
        } = false;
    }
}
