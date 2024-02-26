using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Creator of elementary functions
    /// </summary>
    public class ElementaryObjectsCreator : ElementaryFunctionsCreator
    {

        /// <summary>
        /// Detector
        /// </summary>
        protected IOperationDetector[] opDetectors;

        /// <summary>
        /// Additional binary detectors
        /// </summary>
        protected List<IBinaryDetector> binary = new List<IBinaryDetector>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="table">Table of variables</param>
        public ElementaryObjectsCreator(Dictionary<char, object> table)
            : this(table, true)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="table">Table of variables</param>
        /// <param name="init">Initialization sign</param>
        protected ElementaryObjectsCreator(Dictionary<char, object> table, bool init)
            : base(init)
        {
            if (!init)
            {
                return;
            }
            opDetectors = new IOperationDetector[] { new OneVariableFunctionDetector(table), new ElementaryObjectDetector(table) };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="detector">Detector of variables</param>
        /// <param name="init">Initialization sign</param>
        protected ElementaryObjectsCreator(IVariableDetector detector, bool init)
            : base(init)
        {
            if (!init)
            {
                return;
            }
            opDetectors = 
                new IOperationDetector[] { new OneVariableFunctionDetector(detector), new ElementaryObjectDetector(detector) };
        }


        /// <summary>
        /// Count of operations
        /// </summary>
        public override int OperationCount
        {
            get
            {
                return opDetectors.Length + unaryDetectors.Count;
            }
        }

        /// <summary>
        /// Gets i - th operation detector
        /// </summary>
        /// <param name="i">Detector number</param>
        /// <returns>The i - th detector</returns>
        public override IOperationDetector GetDetector(int i)
        {
            if (i < opDetectors.Length)
            {
                return opDetectors[i];
            }
            return unaryDetectors[i - opDetectors.Length] as IOperationDetector;
        }

        /// <summary>
        /// Adds binary detector
        /// </summary>
        /// <param name="detector">Detector to add</param>
        public void AddBinaryDetector(IBinaryDetector detector)
        {
            binary.Add(detector);
        }

        /// <summary>
        /// Count of binary operations
        /// </summary>
        public override int BinaryCount
        {
            get
            {
                return base.BinaryCount + binary.Count;
            }
        }
        /// <summary>
        /// Gets i - th binary detector
        /// </summary>
        /// <param name="i">Detector number</param>
        /// <returns>The i - th detector</returns>
        public override IBinaryDetector GetBinaryDetector(int i)
        {
            if (i < base.BinaryCount)
            {
                return base.GetBinaryDetector(i);
            }
            int n = i - base.BinaryCount;
            return binary[n];
        }


    }

}
