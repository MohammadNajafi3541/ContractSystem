using ContractSystem.AmcConfig.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace ContractSystem.AmcConfig.Tests
{
    public class AutomapperServiceTests
    {
        /// <summary>
        /// automapper service should be add to ServiceCollection
        /// expect: Increasing number of services  
        /// </summary>
        [Fact]
        [Trait("ServiceCollection", "AutoMapper")]
        public void ConfigureServices_RegistersAutomapperServices()
        {
            // Arrange
            IServiceCollection services = new ServiceCollection();

            // Act
            AutomapperExtension.AddAutoMapperExtensionService(services);

            //  Assert
            Assert.NotEqual(0, services.Count);
        }

    }
}
