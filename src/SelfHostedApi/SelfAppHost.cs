using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funq;
using ServiceInterfaces;
using ServiceModels.DTOs;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;

namespace SelfHostedApi
{
    public class SelfAppHost : AppHostHttpListenerBase
    {
        IAppHostConfig _appHostConfig;

        public SelfAppHost(IAppHostConfig appHostConfig)
            : base("SelfHostedApi", typeof(SelfAppHost).Assembly)
        {
            _appHostConfig = appHostConfig;
        }

        public override void Configure(Container container)
        {
            _appHostConfig.Init(container, Plugins, Routes, EndpointHost.Config);
        }
    }

    public class SelfAppHostConfig : IAppHostConfig
    {
        public void Init(
            Container container, 
            IList<IPlugin> plugins,
            IServiceRoutes routes,
            EndpointHostConfig endpointHostconfig
            )
        {
            
        }
    }

}
