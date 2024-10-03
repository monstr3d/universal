using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;

using Diagram.UI.Factory;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;


namespace Diagram.UI.Factory
{
    /// <summary>
    /// Default label facory
    /// </summary>
    public class DefalutLabelFactory : IDefaultLabelFactory
    {

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly DefalutLabelFactory Object = new DefalutLabelFactory();

        #region Ctor

        private DefalutLabelFactory()
        {
        }

        #endregion



        #region IDefaultLabelFactory Members

        IObjectLabelUI IDefaultLabelFactory.CreateObjectLabel(IPaletteButton button)
        {
            if (button.ReflectionType.GetInterface(typeof(IObjectContainer).FullName) != null)
            {
                return new ContainerObjectLabel(button);
            }
            return new ObjectLabel(button);
        }

        IArrowLabelUI IDefaultLabelFactory.CreateArrowLabel(IPaletteButton button, ICategoryArrow arrow, IObjectLabel source, IObjectLabel target)
        {
            return new ArrowLabel(button, arrow, source, target);
        }

        IObjectLabelUI IDefaultLabelFactory.CreateObjectLabel(ICategoryObject obj)
        {
            IPropertiesEditor pe = obj.GetObject<IPropertiesEditor>();
            if (pe != null)
            {
                object ob = pe.Properties;
                if (ob is object[])
                {
                    object[] o = ob as object[];
                    if (o.Length >= 2)
                    {
                        object oi = o[1];
                    }
                }
            }
            return null;
        }

        object IDefaultLabelFactory.CreateDefaultForm(INamedComponent component)
        {
            return new DefaultForm(component);
        }

        #endregion
    }
}
