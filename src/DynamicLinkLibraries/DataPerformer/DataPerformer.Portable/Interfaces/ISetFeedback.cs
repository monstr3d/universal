using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI.Interfaces;
using DataPerformer.Interfaces;

namespace DataPerformer.Portable.Interfaces
{
    /// <summary>
    /// Sets feedback
    /// </summary>
    public interface ISetFeedback
    {
        /// <summary>
        /// Adds feedback
        /// </summary>
        /// <param name="measure">Measure for feedback</param>
        /// <param name="alias">Feedback alias</param>
        /// <param name="name">Alias name</param>
        void AddFeedback(IMeasurement measure, IAlias alias, string name);
    }
}
