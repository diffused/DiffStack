using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceInterfaces;
using ServiceModels.DTOs;
using ServiceStack.Logging;
using ServiceStack.Mvc;
using ServiceStack.Validation;

namespace PublicMvc.Controllers
{
    public class ProductsController : ServiceStackController
    {
        public IProductsService ProductsService { get; set; }

        public ActionResult Index(ProductsDto productsRequest)
        {
            //var logger = LogManager.GetLogger(GetType());
            //logger.Debug("test here");
      

            var products = ProductsService.Get(productsRequest);
            return View(products);
        }



    }
}
