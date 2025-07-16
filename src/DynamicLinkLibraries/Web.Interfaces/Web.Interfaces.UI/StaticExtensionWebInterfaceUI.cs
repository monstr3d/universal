using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI;
using NamedTree;

namespace Web.Interfaces.UI
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionWebInterfaceUI
    {
        /// <summary>
        /// Sets url provider for control
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="provider">Provider</param>
        public static void Set(this Control control, IUrlProvider provider)
        {
            if (control is IUrlConsumer)
            {
                (control as IUrlConsumer).Url = provider.Url;
            }
            foreach (Control c in control.Controls)
            {
                c.Set(provider);
            }
        }

        /// <summary>
        /// Sets url provider for control
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="provider">Provider</param>
        public static void Set(this Control control, IUrlConsumer consumer)
        {

            if (control is IUrlProvider)
            {
                string urlc = (consumer as IAssociatedObject).GetUrl();
                if (urlc != null)
                {
                    if (control is IConstantUrl)
                    {
                        (control as IConstantUrl).ConstantUrl = urlc;
                    }
                }

                (control as IUrlProvider).Change += (string url) =>
                 { consumer.Url = url; };
            }
            foreach (Control c in control.Controls)
            {
                c.Set(consumer);
            }
        }
    }
}