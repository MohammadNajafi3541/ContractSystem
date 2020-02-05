using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ContractSystem.Endpoint.Core.Test
{
   public class StartupTests
    {
        /// <summary>
        /// Startup service should be add to ServiceCollection
        /// expect: Increasing number of services  
        /// </summary>
        [Fact]
        [Trait("ServiceCollection", "Startup")]

        public void ConfigureServices_RegistersDependenciesCorrectly()
        {
            //Arrange
            Mock<IConfigurationSection> configurationSectionStub = new Mock<IConfigurationSection>();
            configurationSectionStub.Setup(x => x["ContractDatabaseSettings"]).Returns("ContractDatabaseSettings");
            Mock<Microsoft.Extensions.Configuration.IConfiguration> configurationStub = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
            configurationStub.Setup(x => x.GetSection("ContractDatabaseSettings")).Returns(configurationSectionStub.Object);

            IServiceCollection services = new ServiceCollection();

            //Act
            var target = new Startup(configurationStub.Object);
            target.ConfigureServices(services);

            //Assert
            Assert.NotEqual(0, services.Count);
        }


    }
}
