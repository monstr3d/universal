using BaseTypes.CodeCreator.Interfaces;
using Diagram.UI;
using ErrorHandler;
using FormulaEditor.CodeCreators.Interfaces;
using FormulaEditor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Formula
{
    public class Performer : Portable.Performer
    {
        public Performer() { }


        private readonly Type tcreatort = typeof(ITreeCollectionCodeCreator);

        private readonly Type tcrea = typeof(ITreeCodeCreator);

        public override T GetLaguageObject<T>(string o) where T : class
        {
            var x = base.GetLaguageObject<T>(o);
            if (x != null)
            {
                return x;
            }
            var t = typeof(T);
            if (t == tcreatort)
            {
                return StaticExtensionDataPerformerFormula.TreeCollectionCodeCreators[o] as T;
            }
            if (t == tcrea)
            {
                return  StaticExtensionDataPerformerFormula.TreeCodeCreators[o] as T;
            }


            return null;
        }
    }
}
