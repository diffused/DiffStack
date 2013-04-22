using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Funq;
using ServiceInterfaces;
using ServiceStack.Common.Web;
using ServiceStack.OrmLite;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.Common;
using ServiceStack.Logging.NLogger;
using ServiceStack.Logging;


namespace PublicMvc.App_Start
{
    public class AppHostConfig : IAppHostConfig
    {
        public void Init(
            Container container, 
            IList<IPlugin> plugins, 
            IServiceRoutes routes,
            EndpointHostConfig endpointHostconfig
            )
        {
            LogManager.LogFactory = new NLogFactory();

            //Configure User Defined REST Paths
            //Routes
            //  .Add<Hello>("/hello")
            //  .Add<Hello>("/hello/{Name*}");

            //Set JSON web services to return idiomatic JSON camelCase properties
            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

            setPlugins(plugins);

            registerDependencies(container);

            setEndpointHostConfig(endpointHostconfig);

        }

        void setPlugins(IList<IPlugin> plugins)
        {
            // eg: 
            //plugins = new List<IPlugin>
            //{
            //    new RazorFormat(),
            //    new SwaggerFeature(),
            //    new RequestLogsFeature()
            //};

            plugins = new List<IPlugin>();
        }

        void registerDependencies(Container container) {
            
            // ReuseScope.None disposes the Db connection. 
            // Needed for Sql Server
            container.RegisterAutoWiredAs<Repository, IRepository>().ReusedWithin(ReuseScope.None);

            container.RegisterAutoWired<BaseService>().ReusedWithin(ReuseScope.None);
            container.RegisterAutoWired<HomeService>().ReusedWithin(ReuseScope.None);
            container.RegisterAutoWired<SearchService>().ReusedWithin(ReuseScope.None);
            container.RegisterAutoWiredAs<ProductsService, IProductsService>().ReusedWithin(ReuseScope.None);
            
            // not exposing this on PublicMvc
            //container.RegisterAutoWired<ProductsProcessorService>().ReusedWithin(ReuseScope.None);

            var connectionString = ConfigurationManager
                .ConnectionStrings["DiffStack"].ConnectionString;
            container.Register<IDbConnectionFactory>(c =>
                new OrmLiteConnectionFactory(
                    connectionString,
                    SqlServerDialect.Provider
                    )
                );
        }

        void setEndpointHostConfig(EndpointHostConfig endpointHostconfig)
        {
            endpointHostconfig = new EndpointHostConfig
            {
                EnableFeatures = Feature.All.Remove(
                    Feature.Xml | Feature.Jsv |
                    Feature.Csv | Feature.Soap),
                DefaultContentType = ContentType.Json
            };
        }

        
    }
}