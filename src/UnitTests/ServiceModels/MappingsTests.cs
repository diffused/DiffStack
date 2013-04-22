using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModels.Entities;
using ServiceStack.Text;
using ServiceStack.Common;
using Xunit;
using ServiceModels.DTOs;

namespace UnitTests.ServiceModels
{
    public class MappingsTests
    {
        [Fact]
        public void Products()
        {
            var products = new List<Product>();
            10.Times(i => products.Add(new Product { Id = i } ));
            
            products.PrintDump();

            var productsDto = products.ConvertAll(a => a.TranslateTo<ProductDto>());

            productsDto.PrintDump();
        }
    }
}
