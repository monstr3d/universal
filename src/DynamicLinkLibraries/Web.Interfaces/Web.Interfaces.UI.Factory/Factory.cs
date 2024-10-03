using Diagram.UI.Factory;
using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Web.Interfaces.UI;

namespace Web.Interfaces.UI.Factory
{
    public class Factory : EmptyUIFactory
    {

        #region Fields

        public static readonly Factory Singleton = new Factory();

        #endregion

        #region Ctor

        private Factory()
        {
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Gets additional feature
        /// </summary>
        /// <typeparam name="T">Feature type</typeparam>
        /// <param name="obj">Object</param>
        /// <returns>Feature</returns>
        public override object GetAdditionalFeature<T>(T obj)
        {
            if (!typeof(T).Equals(typeof(IUrlConsumer)))
            {
                return null;
            }
            IUrlConsumer c = obj as IUrlConsumer;
            UserControls.UserControlUrl uc = new UserControls.UserControlUrl();
            if (c is IUrlProvider)
            {
                uc.Set(c as IUrlProvider);
            }
            uc.Set(c);
            return uc;
        }

        #endregion
    }
}
