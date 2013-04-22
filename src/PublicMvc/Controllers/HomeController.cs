using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceInterfaces;
using ServiceStack.Configuration;
using ServiceStack.DataAnnotations;
using ServiceStack.Logging;
using ServiceStack.Mvc;

namespace PublicMvc.Controllers
{
    public class HomeController : ServiceStackController
    {
        public HomeService HomeService { get; set; }

        public ActionResult Index()
        {
            // Logging via NLog
            
            //var log = LogManager.GetLogger("thing");
            //log.Debug("lkjlkj");

            var home = HomeService.Get();

            return View(home);
        }        
        
    }




}
