using System;
using System.Collections.Generic;

using FormulaEditor.Interfaces;
using FormulaEditor;


namespace ExtendedFormulaEditor
{
    /// <summary>
    /// Static Extension
    /// </summary>
    public static class StaticExtensionExtendedFormulaEditor
    {

        #region Specific members

        /// <summary>
        /// Gets a formula object creator
        /// </summary>
        /// <param name="table">The table of variables</param>
        /// <returns>The creator</returns>
        public static IFormulaObjectCreator GetCreator(this Dictionary<char, object> table)
        {
            IFormulaObjectCreator prot = new ExtendedFormulaCreator(table);
            prot.Add(ElementaryRealDetector.Object);
            IFormulaObjectCreator creator = new FormulaArrayObjectCreator(prot);
            return creator;
        }

        /// <summary>
        /// Gets a formula object creator
        /// </summary>
        /// <param name="detector">Detector of variables</param>
        /// <returns>The creator</returns>
        public static IFormulaObjectCreator GetCreator(this IVariableDetector detector)
        {
            IFormulaObjectCreator prot = new ExtendedFormulaCreator(detector);
            prot.Add(ElementaryRealDetector.Object);
            IFormulaObjectCreator creator = new FormulaArrayObjectCreator(prot);
            return creator;
        }

        /// <summary>
        /// Gets a formula object creator
        /// </summary>
        /// <param name="detector">Detector of variables</param>
        /// <param name="binary">Binary detectors</param>
        /// <returns>The creator</returns>
        public static IFormulaObjectCreator GetCreator(this IVariableDetector detector,
            IEnumerable<IOperationDetector> additional,
            IEnumerable<IBinaryDetector> binary)
        {
            IFormulaObjectCreator prot = new ExtendedFormulaCreator(detector);
            prot.Add(ElementaryRealDetector.Object);
            prot.Add(PropertyFictionOperation.Singleton);
            prot.Add(BinaryPropertyDetector.Singleton);
            foreach (IOperationDetector d in additional)
            {
                prot.Add(d);
            }
            foreach (IBinaryDetector d in binary)
            {
                prot.Add(d);
            }
            IFormulaObjectCreator creator = new FormulaArrayObjectCreator(prot);
            foreach (IOperationDetector d in additional)
            {
                creator.Add(d);
            }
            foreach (IBinaryDetector d in binary)
            {
                creator.Add(d);
            }
            return creator;
        }


        #endregion

    }
}
