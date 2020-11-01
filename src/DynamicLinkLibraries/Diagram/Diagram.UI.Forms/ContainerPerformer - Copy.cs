using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces.Labels;


namespace Diagram.UI
{
    class ContainerPerformer
    {
        private static Dictionary<IObjectLabel, IChildObjectLabel> children =
            new Dictionary<IObjectLabel, IChildObjectLabel>();

        public static IChildObjectLabel GetPanel(IObjectLabel c)
        {
            if (!children.ContainsKey(c))
            {
                return null;
            }
            return children[c];
        }

        public static Dictionary<IObjectLabel, IChildObjectLabel> Children
        {
            get
            {
                return children;
            }
        }

    }
}
