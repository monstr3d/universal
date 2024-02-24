using System;
using System.Collections.Generic;
using System.Text;

namespace Scada.Interfaces.Services
{
    /// <summary>
    /// Link with input and output
    /// </summary>
    public class InputOutputLink
    {
        #region Fields

        Func<object> input;

        Action<object> output;

        object o;


        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="output">Output</param>
        public InputOutputLink(Func<object> input, Action<object> output)
        {
            this.input = input;
            this.output = output;
        }

        #endregion

        #region Public

        /// <summary>
        /// Updates itself
        /// </summary>
        public void Update()
        {
            output(input());
        }

        /// <summary>
        /// Updates itself with comparation
        /// </summary>
        public void UpdateCompare()
        {
            object x = input();
            if (x.Equals(o))
            {
                return;
            }
            o = x;
            output(o);
        }

        #endregion
    }
}
