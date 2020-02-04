using System;
using System.Linq;
using AutoMapper;
using ContractSystem.AmcConfig.Mapping;
using ContractSystem.DAL.MongoDb.DbSetting;
using ContractSystem.DAL.MongoDb.Services;
using ContractSystem.Domain.Model;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;


namespace ContractSystem.DAL.MongoDb.Tests
{
    public class IMapperFixture : IDisposable
    {
        public readonly IMapper mockMapper;

        public IMapperFixture()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new AutoMapperProfileConfiguration());
            });
            mockMapper = config.CreateMapper();

        }
        public void Dispose()
        {
            
        }
    }
    public class ContractServiceTest : IClassFixture<IMapperFixture>
    {
        private readonly Mock<IContractDatabaseSettings> mockIContractDatabaseSettings;
        private readonly IMapperFixture mapperFixture;
        public ContractServiceTest(IMapperFixture mapperFixture)
        {
            mockIContractDatabaseSettings = new Mock<IContractDatabaseSettings>();
            mockIContractDatabaseSettings.Setup(repo => repo.ContractCollectionName).Returns("Contracts");
            mockIContractDatabaseSettings.Setup(repo => repo.DatabaseName).Returns("ContractDb");
            mockIContractDatabaseSettings.Setup(repo => repo.ConnectionString).Returns("mongodb://localhost:27017");

            this.mapperFixture = mapperFixture;

        }


        [Fact]
        [Trait("ContractService", "Add")]
        public void Add_ContractObjectPassed_ProperMethodCalled()
        {
            // Arrange
            var contract = new ContractModel()
            {
                BrokerAgentName = "BrokerAgentName",
                BrokerCompanyName = "BrokerCompanyName",
                CustomerName = "CustomerName",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
            };     

            // Act
            var repository = new ContractService(mockIContractDatabaseSettings.Object, mapperFixture.mockMapper);
            var result = repository.Add(contract);

            //Assert
            Assert.False(string.IsNullOrEmpty(result.Id));

        }


        [Fact]
        [Trait("ContractService", "GetById")]
        public void GetById_ContractObjectPassed_ProperMethodCalled()
        {
            
            //act
            var repository = new ContractService(mockIContractDatabaseSettings.Object, mapperFixture.mockMapper);
            var contractList = repository.GetAll();
            var firstItem = contractList.First();
            var contract = repository.Find(firstItem.Id);

            // Assert
            Assert.Equal(contract.Id, firstItem.Id);

        }
                                  
    }

}
