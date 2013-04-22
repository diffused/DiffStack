using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModels.DTOs;
using ServiceStack.ServiceInterface;

namespace ServiceInterfaces
{
    public class ProductsSearchService : Service
    {
        public object Get(ProductsSearchDto request)
        {
            // simulate long running service
            System.Threading.Thread.Sleep(1500);

            var response = new ProductsSearchResponseDto
            {
                Ids = new int[] { 1, 3, 5, 7 }
            };

            return response;
        }
    }
}
