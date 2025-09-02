using DataPerformer.Interfaces;

using Diagram.UI;
using Diagram.UI.Attributes;
using Diagram.UI.Interfaces;

namespace DataPerformer.Portable
{
    public class AliasInitialValueCollection : InitialValueCollection
    {

        Performer pr = new Performer();
        public AliasInitialValueCollection(IAlias alias, IMeasurements measurememts)
        {
          var attr = pr.GetAttribute<CodeCreatorAttribute>(measurememts);
            if (attr != null && attr.InitialState)
            {
                initial.Clear();
                for (int i = 0; i < measurememts.Count; i++)
                {
                    var al = pr.InitialValue(alias, measurememts[i]);
                    if (al != null)
                    {
                        initial.Add(al);
                    }
                }
            }
        }
    }

}