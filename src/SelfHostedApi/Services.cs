using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceInterfaces;

namespace SelfHostedApi
{
    /// <summary>
    /// A simple way to have a custom selection of Services from a shared Services lib
    /// 
    /// Only ProductsSearchService available. (or any others defined like this)
    /// 
    /// Initializing AppHostHttpListenerBase using the ServiceInterfaces assembly 
    /// exposes all the services. As of now, I can't find a simpler way to have a 
    /// custom selection of Services
    /// </summary>
    public class SelfHostedSearchService : ProductsSearchService
    {
    }
}
