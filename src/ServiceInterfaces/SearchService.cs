using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModels.DTOs;
using ServiceStack.ServiceClient.Web;
using ServiceStack.ServiceInterface;
using ServiceStack.OrmLite;
using ServiceModels.Entities;
using ServiceStack.Common;
using ServiceStack.Text;
using System.Web.Mvc;


namespace ServiceInterfaces
{
    public class SearchService : BaseService
    {
        /// <summary>
        /// Get products based on the response of the query to an external "search" service.
        /// </summary>  
        [HandleError]
        public async Task<ProductsResponseDto> GetAsync()
        {
            //
            var ppResponse = await Task.Factory
                .StartNew<ProductsSearchResponseDto>(callProductsProcessor);

            var productsResponse = await Task.Factory
                .StartNew<List<ProductResponseDto>>(() => getProducts(ppResponse));

            var response = new ProductsResponseDto
            {                
                Products = productsResponse
            };

            return response;
        }

        [HandleError]
        public ProductsSearchResponseDto callProductsProcessor()
        {
            // this will call a simulated products search api 
            // which is hosted in the SelfHostApi project. 
            // You'll need to make sure it's up and running first
            
            // Expecting response of int[] product id's
            
            // Endpoint is
            // http://localhost:1212/products-search

            var uri = "http://localhost:1212";
            var client = new JsonServiceClient(uri);
            var response = client.Get<ProductsSearchResponseDto>("/products-search");
            
            return response;       
        }

        public List<ProductResponseDto> getProducts(ProductsSearchResponseDto ppResponse)
        {
            // now select the products from the db using the int[] product ids 

            var products = Db.Select<Product>(p => Sql.In(p.Id, ppResponse.Ids));
            var productsListDto = products.ConvertAll(p => p.TranslateTo<ProductResponseDto>());

            return  productsListDto;
        }



    }
}
