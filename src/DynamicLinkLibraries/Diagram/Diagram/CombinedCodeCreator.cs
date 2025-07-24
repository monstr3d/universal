using System.Collections.Generic;

using Diagram.UI.Interfaces;
using ErrorHandler;

namespace Diagram.UI
{
    /// <summary>
    /// Combined class code creator
    /// </summary>
    public class CombinedCodeCreator : IClassCodeCreator
    {
        public CombinedCodeCreator(string language)
        {
            Language = language;   
        }

        protected virtual string Language { get; set; }



        #region Fields

        List<IClassCodeCreator> list = new List<IClassCodeCreator>();

        #endregion

        #region IClassCodeCreator Members

        List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
        {
            foreach (IClassCodeCreator creator in list)
            {
                List<string> l = creator.CreateCode(preffix, obj);
                if (l != null)
                {
                    return l;
                }
            }
            throw new IncludedException("Type \"" + obj.GetType() + "\" is not supported", obj);
        }

        #endregion

        #region Public Members

        public void Add(IClassCodeCreator creator)
        {
            list.Add(creator);
        }

        #endregion
    }
}
