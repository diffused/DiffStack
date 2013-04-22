using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceHost;

namespace ServiceModels.DTOs
{
    /// <summary>
    /// Pretend service that finds product id's from a given query
    /// </summary>
    [Route("/products-search")]
    public class ProductsSearchDto : IReturn<ProductsSearchResponseDto>
    {
        public string Query { get; set; }
    }

    public class ProductsSearchResponseDto
    {
        public int[] Ids { get; set; }
    }
}
