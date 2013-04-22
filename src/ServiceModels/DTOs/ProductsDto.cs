using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceHost;

namespace ServiceModels.DTOs
{
    [Route("/products", "POST")]
    [Route("/products/{Id}", "GET, PUT")]    
    public class ProductDto : IReturn<ProductResponseDto>
    {
        public int Id { get; set; }        
    }

    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
    }

    [Route("/products")]
    public class ProductsDto : IReturn<ProductsResponseDto>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class ProductsResponseDto
    {
        public List<ProductResponseDto> Products { get; set; }
        public int Page { get; set; } // requested page
        public int PageSize { get; set; } // requested page size
        
    }
        
    
}
