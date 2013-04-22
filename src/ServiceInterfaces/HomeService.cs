using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModels;
using ServiceModels.Entities;
using ServiceModels.ViewModels;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using ServiceStack.Text;


namespace ServiceInterfaces
{
    /// <summary>
    /// Service for use with MVC Controllers.
    /// Not exposed via API. 
    /// Returns ViewModels since behaviours like validation attributes can be attached.
    /// /// </summary>
    public class HomeService : Service
    {
        // mash 2 datasets into vm for home controller
        public HomeVm Get()
        {
            var vm = new HomeVm();
            var brand = Db.First<Brand>(b => b.Id == 1);
            var product = Db.First<Product>(p => p.Id == 1);
            
            vm.ProductName = product.Name;
            vm.BrandName = brand.Name;

            return vm;
        }
    }
}
