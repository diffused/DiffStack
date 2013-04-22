using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using PublicMvc.Controllers;
using ServiceInterfaces;
using ServiceModels.DTOs;
using Xunit;

namespace UnitTests.PublicMvc.Controllers
{
    public class ProductsControllerTests
    {
        [Fact]
        public void Index_Calls_ProductsService_Get()
        {
            var mockService = new Mock<IProductsService>();            

            var sut = new ProductsController();
            sut.ProductsService = mockService.Object;

            sut.Index(new ProductsDto());

            mockService.Verify(a => a.Get(It.IsAny<ProductsDto>()), Times.AtLeastOnce());
        }
    }
}
