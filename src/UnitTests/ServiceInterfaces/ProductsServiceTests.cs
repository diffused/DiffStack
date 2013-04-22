using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Ploeh.AutoFixture.Xunit;
using ServiceInterfaces;
using ServiceModels.DTOs;
using ServiceModels.Entities;
using ServiceStack.ServiceInterface.Testing;
using ServiceStack.Text;
using Xunit;
using Xunit.Extensions;



namespace UnitTests.ServiceInterfaces
{
    public class ProductsServiceTests
    {
        [Theory, AutoData]
        public void Get_Calls_ProductById(ProductDto productDto)
        {
            var mockRepo = new Mock<IRepository>();

            
            var sut = new ProductsService
            {
                Repository = mockRepo.Object
            };            

            var response = sut.Get(productDto);
            
            mockRepo.Verify(a => a.ProductById(productDto.Id), Times.AtLeastOnce());

        }

        [Theory, AutoData]
        public void Get_Calls_PagedProducts(ProductsDto productsDto, List<Product> products)
        {
            var mockRepo = new Mock<IRepository>();

            mockRepo.Setup(a => a.PagedProducts(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(products);

            var sut = new ProductsService
            {
                Repository = mockRepo.Object
            };            

            var response = sut.Get(productsDto);

            mockRepo.Verify(a => a.PagedProducts(It.IsAny<int>(), It.IsAny<int>()), Times.AtLeastOnce());
        }
    }

    
}
