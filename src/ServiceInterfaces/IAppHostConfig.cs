using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funq;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;

namespace ServiceInterfaces
{
    /// <summary>
    /// Injectable common config settings.    
    /// </summary>
    public interface IAppHostConfig
    {
        void Init(
            Container container, 
            IList<IPlugin> plugins, 
            IServiceRoutes routes, 
            EndpointHostConfig endpointHostconfig
            );        

    }
}
