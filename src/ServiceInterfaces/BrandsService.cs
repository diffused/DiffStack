using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModels.DTOs;
using ServiceStack.ServiceClient.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace ServiceInterfaces
{
    public class BrandsService : Service
    {
        public object Get(BrandDto request)
        {           

            var brand = new BrandDto { Name = "hmm" };
            return brand;
        }
    }

    
}
