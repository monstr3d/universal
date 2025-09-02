using FormulaEditor;
using FormulaEditor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Formula.CodeCreators
{
    public class TreeCollectionCodeCreatorCollection : ITreeCollectionCodeCreator
    {

        List<ITreeCollectionCodeCreator> list = new List<ITreeCollectionCodeCreator>();
        Dictionary<string, List<string>> ITreeCollectionCodeCreator.CreateCode(object obj, ObjectFormulaTree[] trees, string className, string constructorModifier, bool checkValue)
        {
            foreach (ITreeCollectionCodeCreator code in list)
            {
                var x = code.CreateCode(obj, trees, className, constructorModifier, checkValue);
                if (x != null)
                {
                    return x;
                }
            }
            return null;
        }
    }
}
