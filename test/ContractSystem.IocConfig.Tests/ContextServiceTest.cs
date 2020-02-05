using ContractSystem.IocConfig.Base;
using ContractSystem.IocConfig.Content;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace ContractSystem.IocConfig.Tests
{
    public class ContextServiceTest
    {
        /// <summary>
        /// CustomContext service should be add to ServiceCollection
        /// expect: Increasing number of services  
        /// </summary>
        [Fact]
        [Trait("ServiceCollection", "CustomContext")]
       public void ConfigureServices_RegistersContextCustomContentServices()
        {
            // Arrange
            IServiceCollection services = new ServiceCollection();

            // Act
            ContextServicesRegistry.AddCustomContextServices(services);

            //  Assert
            Assert.NotEqual(0, services.Count);

        }

        /// <summary>
        /// ContentCustomContent service should be add to ServiceCollection
        /// expect: Increasing number of services  
        /// </summary>
        [Fact]
        [Trait("ServiceCollection", "ContentCustomContent")]
        public void ConfigureServices_RegistersContentCustomContentServices()
        {
            // Arrange
            IServiceCollection services = new ServiceCollection();

            // Act
            ContentServicesRegistry.AddCustomContentServices(services);

            //  Assert
            Assert.NotEqual(0, services.Count);
        }


    }
}
