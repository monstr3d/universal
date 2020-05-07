using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes.Attributes
{
    /// <summary>
    /// Fiction exception
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class FictionAttribute : Attribute
    {
    }
}
