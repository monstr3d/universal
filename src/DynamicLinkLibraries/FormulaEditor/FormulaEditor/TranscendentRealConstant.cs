using System;

namespace FormulaEditor
{
    /// <summary>
    /// Transcendent real
    /// </summary>
    public class TranscredentRealConstant : ElementaryRealConstant
    {

        private char symbol;

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol">Symbol of constant</param>
        public TranscredentRealConstant(char symbol)
            : base((symbol == 'e') ? Math.E : Math.PI)
        {
            this.symbol = symbol;
        }

        #endregion

        #region Members

        /// <summary>
        /// String value
        /// </summary>
        public override string StringValue
        {
            get { return (symbol == 'e') ? "Math.E" : "Math.PI"; }
        }

        #endregion

    }
}
