using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Xunit;
using ServiceInterfaces;
using ServiceModels.Entities;
using ServiceStack.OrmLite;
using ServiceStack.Common.Extensions;
using ServiceStack.Text;

using Xunit;
using Xunit.Extensions;
using FluentAssertions;
using System.Linq.Expressions;
using ServiceStack.ServiceInterface.Testing;
using ServiceStack.ServiceInterface;

namespace IntegrationTests.ServiceInterfaces
{

    public class RepositoryTests
    {
        [Fact]
        public void Repo()
        {
            var mockRepo = new Mock<IRepository>();

            var fixture = new Fixture();
            fixture.Register<IRepository>(() => mockRepo.Object);
        }


        [Theory, AutoData]
        public void SingleById_Correct(Product[] products)        
        {            
            var sut = new Repository();
            sut.DbFactory = FakeDbFactory.Create<Product>(products);
            
            var savedProducts = sut.Db.Select<Product>();
            savedProducts.PrintDump();

            var testId = savedProducts[0].Id;

            sut.SingleById<Product>(testId).Id.Should().Be(testId);
        }    
    }
        
}
