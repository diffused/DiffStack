using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModels.DTOs;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace ServiceInterfaces
{
    public class ProductsProcessorService : Service
    {
        public object Get(ProductsSearchDto request)
        {
            System.Threading.Thread.Sleep(1000);

            var response = new ProductsProcessorResponseDto
            {
                Ids = new int[] { 1, 2, 3, 4, 5}
            };

            return response;
        }
    }

    


}
