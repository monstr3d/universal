using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytes.Exchange
{
    public partial class PublisherProxy : System.ServiceModel.ClientBase<IEvent>, IEvent
    {
        public PublisherProxy()
        {
        }

        public PublisherProxy(string endpointConfigurationName)
            : base(endpointConfigurationName)
        {
        }

        public PublisherProxy(string endpointConfigurationName, string remoteAddress)
            : base(endpointConfigurationName, remoteAddress)
        {
        }

        public PublisherProxy(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            : base(endpointConfigurationName, remoteAddress)
        {
        }

        public PublisherProxy(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
            : base(binding, remoteAddress)
        {
        }



        #region IEvent Members

        public void OnEvent(AlertData e)
        {
            base.Channel.OnEvent(e);
        }

        #endregion
    }
}
