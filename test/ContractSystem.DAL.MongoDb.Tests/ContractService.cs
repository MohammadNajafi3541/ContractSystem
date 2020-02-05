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
    /// <summary>
    ///this class used to avoid create map by every test method running 
    /// </summary>
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

        /// <summary>
        /// we can here set test database name and mongo db host
        /// </summary>
        public ContractServiceTest(IMapperFixture mapperFixture)
        {
            mockIContractDatabaseSettings = new Mock<IContractDatabaseSettings>();
            mockIContractDatabaseSettings.Setup(repo => repo.ContractCollectionName).Returns("Contracts");
            mockIContractDatabaseSettings.Setup(repo => repo.DatabaseName).Returns("ContractDbTest");
            mockIContractDatabaseSettings.Setup(repo => repo.ConnectionString).Returns("mongodb://localhost:27017");

            this.mapperFixture = mapperFixture;

        }

        /// <summary>
        /// expect: add new contract to mongo db and get new id
        /// </summary>
        [Fact]
        [Trait("ContractService", "Add")]
        public void Add_ContractObjectPassed_ShouldResultGetId()
        {
            // Arrange
            var newContract = new ContractModel()
            {
                BrokerAgentName = "BrokerAgentName",
                BrokerCompanyName = "BrokerCompanyName",
                CustomerName = "CustomerName",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
            };     

            // Act
            var repository = new ContractService(mockIContractDatabaseSettings.Object, mapperFixture.mockMapper);
            var result = repository.Add(newContract);
             
            //Assert
            Assert.False(string.IsNullOrEmpty(result.Id));          

        }


        /// <summary>
        /// expect: add new contract to mongo db and finde in database
        /// </summary>
        [Fact]
        [Trait("ContractService", "Add")]
        public void Add_ContractObjectPassed_ShouldCanFindeInDb()
        {
            // Arrange
            var newContract = new ContractModel()
            {
                BrokerAgentName = "BrokerAgentName",
                BrokerCompanyName = "BrokerCompanyName",
                CustomerName = "CustomerName",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
            };

            // Act
            var repository = new ContractService(mockIContractDatabaseSettings.Object, mapperFixture.mockMapper);
            var result = repository.Add(newContract);             
            var contract = repository.Find(result.Id);

            //Assert 
            Assert.False(string.IsNullOrEmpty(result.Id));
            Assert.NotNull(contract);

        }


        /// <summary>
        /// expect: read all data from database
        /// </summary>
        [Fact]
        [Trait("ContractService", "GetAll")]
        public void Add_ContractObjectPassed_ShouldCanBeInGetAll()
        {
            // Arrange
            var newContract = new ContractModel()
            {
                BrokerAgentName = "BrokerAgentName",
                BrokerCompanyName = "BrokerCompanyName",
                CustomerName = "CustomerName",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
            };

            // Act
            var repository = new ContractService(mockIContractDatabaseSettings.Object, mapperFixture.mockMapper);
            var result = repository.Add(newContract);
            var contractList = repository.GetAll();           
            var Expect = contractList.Any(x=>x.Id==result.Id);

            //Assert
            Assert.False(string.IsNullOrEmpty(result.Id));
            Assert.True(Expect);

        }


        /// <summary>
        /// expect: get all data and then get first model list should be contain model
        /// </summary>
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

        /// <summary>
        /// expect: return null result for invalid id
        /// </summary>
        [Fact]
        [Trait("ContractService", "GetByNotValidId")]
        public void GetById_ContractObjectNotPassed_ExpectReturnNull()
        {
            //act
            var repository = new ContractService(mockIContractDatabaseSettings.Object, mapperFixture.mockMapper);           
            var contract = repository.Find("");

            // Assert
            Assert.Null(contract);
        }

    }

}
