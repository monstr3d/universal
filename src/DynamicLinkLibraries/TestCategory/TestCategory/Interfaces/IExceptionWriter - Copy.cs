using System;
using System.Collections.Generic;
using System.Text;

namespace TestCategory.Interfaces
{
    /// <summary>
    /// Writer of exception
    /// </summary>
    public interface IExceptionWriter
    {
        /// <summary>
        /// Writes exception
        /// </summary>
        /// <param name="e">The exception to for writting</param>
        void Write(TestException e);

        /// <summary>
        /// Writes header object
        /// </summary>
        /// <param name="o"></param>
        void WriteHeader(object o);
    }

    /// <summary>
    /// Writes exception
    /// </summary>
    /// <param name="e">The exception to for writting</param>
    public delegate void Write(TestException e);


    /// <summary>
    /// Writes header object
    /// </summary>
    /// <param name="o"></param>
    public delegate void WriteHeader(object o);
}
