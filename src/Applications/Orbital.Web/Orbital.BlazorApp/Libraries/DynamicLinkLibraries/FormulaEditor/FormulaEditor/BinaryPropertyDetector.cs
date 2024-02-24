using FormulaEditor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaEditor.Symbols;
using BaseTypes.Interfaces;
using BaseTypes;

namespace FormulaEditor
{
    /// <summary>
    /// Detector of properties
    /// </summary>
    public class BinaryPropertyDetector : IBinaryDetector, IBinaryAcceptor, IChildTreeCreator
    {
        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly BinaryPropertyDetector Singleton = new BinaryPropertyDetector();

        private BinaryPropertyDetector()
        {

        }

        BinaryAssociationDirection IBinaryDetector.AssociationDirection
        {
            get
            {
                return BinaryAssociationDirection.RightLeft;
            }
        }

        IBinaryAcceptor IBinaryDetector.Detect(MathSymbol symbol)
        {
            if (symbol.Symbol == '.')
            {
                if (symbol.String.Equals("."))
                {
                    return new BinaryPropertyDetector();
                }
            }
            return null;
        }

        IObjectOperation IBinaryAcceptor.Accept(object typeA, object typeB)
        {
            return null;
        }

        #region IChildTreeCreator Members

        ObjectFormulaTree IChildTreeCreator.this[ObjectFormulaTree[] children]
        {
            get
            {
                if (children.Length != 2)
                {
                    return null;
                }
                IObjectOperation op = children[1].Operation;
                if (op is PropertyFictionOperation)
                {
                    string name = (op as PropertyFictionOperation).Name;
                    object t = children[0].ReturnType;
                    if (t.IsDynamicalArray())
                    {
                        object at = (t as ArrayReturnType).ElementType;
                        IObjectOperation oa = at.GetObjectOperation(name);
                        ArrayReturnType art = new ArrayReturnType(oa.ReturnType, new int[] { -1 }, true);
                        IObjectOperation da = new DynamicalArrayUnaryOperation(art, oa);
                        return new ObjectFormulaTree(da, new List<ObjectFormulaTree>() { children[0] });
                    }
                    IObjectOperation p = t.GetObjectOperation(name);
                    if (p != null)
                    {
                        return new ObjectFormulaTree(p, new List<ObjectFormulaTree>() { children[0] });
                    }
                }
                return null;
            }
        }

        #endregion

    }
}
