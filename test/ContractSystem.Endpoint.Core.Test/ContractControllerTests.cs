using System;
using System.Collections.Generic;
using System.Linq;
using ContractSystem.Domain.Interfaces;
using ContractSystem.Domain.Model;
using ContractSystem.Endpoint.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;


namespace ContractSystem.Endpoint.Core.Test
{
    public class ContractControllerTests
    {
        private Mock<IContractService> mockRepo;


        [Fact]
        [Trait("ContractController", "GetAll")]
        public void GetAll_ReturnsAViewResult_WithAListOfContractModel()
        {
            // Arrange
            var mockRepo = new Mock<IContractService>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(GetTestcontracts());
            var controller = new ContractController(mockRepo.Object);

            // Act
            var result = controller.GetContract();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<ContractModel>>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ContractModel>>(result.Value);
            Assert.Equal(2, model.Count());
        }

        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [Trait("ContractController", "GetById")]
        public void GetById_ReturnsAViewResult_WithAContractModel(string id)
        {
            // Arrange            
            var mockRepo = new Mock<IContractService>();
            mockRepo.Setup(repo => repo.Find(id))
                .Returns(GetTestcontracts().FirstOrDefault(x => x.Id == id));
            var controller = new ContractController(mockRepo.Object);

            // Act
            var result = controller.GetContract(id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ContractModel>>(result);
            Assert.IsAssignableFrom<ContractModel>(result.Value);

        }

        [Theory]
        [InlineData("0")]
        [Trait("ContractController", "GetByIdNotFound")]
        public void GetById_ReturnsAViewResult_ShouldNotFound(string id)
        {
            // Arrange            
            var mockRepo = new Mock<IContractService>();
            mockRepo.Setup(repo => repo.Find(id))
                .Returns(It.IsAny<ContractModel>());
            var controller = new ContractController(mockRepo.Object);

            // Act
            var result = controller.GetContract(id);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }


        [Fact]
        [Trait("ContractController", "ContractPostIsValid")]
        public void ContractPost_ReturnsARedirectAndAddContract_WhenModelStateIsValid()
        {
            // Arrange      
            var contract = new ContractModel()
            {
                Id = "dsf87sdf89sd7f",
                BrokerAgentName = "BrokerAgentName",
                BrokerCompanyName = "BrokerCompanyName",
                CustomerName = "CustomerName",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
            };

            mockRepo = new Mock<IContractService>();
            mockRepo.Setup(repo => repo.Add(contract)).Returns(contract);

            // act
            var result = new ContractController(mockRepo.Object).PostContract(contract);

            // Assert
            var redirectToActionResult = (CreatedAtActionResult)Assert.IsType<ActionResult<ContractModel>>(result).Result;
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("GetContract", redirectToActionResult.ActionName);
            // Assert.Contains(result.Value, mockRepo.Object.GetAll());
            mockRepo.Verify();

        }

        [Fact]
        [Trait("ContractController", "ContractPostIsInValid")]
        public void ContractPost_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var contract = new ContractModel();

            var mockRepo = new Mock<IContractService>();
            mockRepo.Setup(repo => repo.Add(contract))
               .Returns(contract);
            var controller = new ContractController(mockRepo.Object);
            controller.ModelState.AddModelError("CustomerName", "Required");


            // Act
            var result = controller.PostContract(contract);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        private List<ContractModel> GetTestcontracts()
        {
            var contracts = new List<ContractModel>();
            contracts.Add(new ContractModel()
            {
                Id = "1",
                CustomerName = "Mohammad"
            });
            contracts.Add(new ContractModel()
            {
                Id = "2",
                CustomerName = "alireza"
            });
            return contracts;
        }


    }
}
