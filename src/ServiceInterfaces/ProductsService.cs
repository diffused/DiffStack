using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModels.DTOs;
using ServiceStack.OrmLite;
using ServiceStack.Common;
using ServiceStack.Common.Extensions;
using ServiceStack.Text;
using ServiceModels.Entities;
using ServiceStack.ServiceModel;
using ServiceStack.ServiceInterface;
using ServiceStack.Logging;

namespace ServiceInterfaces
{
    public interface IProductsService
    {
        ProductResponseDto Get(ProductDto request);
        ProductsResponseDto Get(ProductsDto request);
    }

    /// <summary>
    /// Regular ServiceStack Service that is exposed on /api/products
    /// </summary>
    public class ProductsService : BaseService, IProductsService
    {
        public ProductResponseDto Get(ProductDto request)
        {
            var response = Repository.ProductById(request.Id)
                .TranslateTo<ProductResponseDto>();
            
            return response;
        }

        public ProductsResponseDto Get(ProductsDto request)
        {
            var pageSize = 5;
            var page = request.Page; 
            if(page < 0) page = 0;            
            
            var productsList = Repository.PagedProducts(page, pageSize);
                
            var productsResponseDtoList = productsList.ConvertAll(a => a.TranslateTo<ProductResponseDto>());

            //var products = Db.Select<Product>
            //    (a =>
            //        a.OrderByDescending(b => b.Id)
            //        .Limit(pageSize * request.Page, pageSize)
            //    )
            //    .ConvertAll(a => a.TranslateTo<ProductResponseDto>());

            var response = new ProductsResponseDto
            {
                Products = productsResponseDtoList,
                Page = page,
                PageSize = pageSize
            };

            return response;
        }

        //public object Post(ProductDto request)
        //{
        //    //
        //}
        
    }
}
