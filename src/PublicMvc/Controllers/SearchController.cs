using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Threading;
using ServiceInterfaces;
using System.Net.Sockets;

namespace PublicMvc.Controllers
{
    /// <summary>
    /// Sketch out various ways to perform longer running calls.
    /// 
    /// 
    /// </summary>
    public class SearchController : AsyncController
    {
        public SearchService SearchService { get; set; }

        public ActionResult Index()
        {
            return View("Index");
        }
         

        /// <summary>
        /// MVC 4 async/await method
        /// 
        /// </summary>           
        //[HandleError(ExceptionType = typeof(SocketException), View = "SelfHostedApiDownError")]
        [HandleError(View = "SelfHostedApiDownError")]
        public async Task<ActionResult> MvcLookup()
        {   
            // todo: currently only works with WebException. 
            // Would be good to respond to actual child exceptions 
            // check out http://www.prideparrot.com/blog/archive/2012/5/exception_handling_in_asp_net_mvc

            var vm = await SearchService.GetAsync();

            return View("MvcLookup", vm);            
        }

        //[AsyncTimeout(10)]
        //[HandleError(ExceptionType = typeof(TimeoutException), View = "LookupTimeoutError")]
        //public async Task<ActionResult> LookupCancelAsync(CancellationToken cancellationToken)
        //{
        //    ViewBag.SyncOrAsync = "Asynchronos";
        //    //var gizmoService = new GizmoService();

        //}

    }
}
