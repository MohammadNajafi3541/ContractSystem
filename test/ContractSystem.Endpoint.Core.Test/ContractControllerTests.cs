using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using ContractSystem.Domain.Interfaces;
using ContractSystem.Domain.Model;
using ContractSystem.Endpoint.Core.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using Xunit;


namespace ContractSystem.Endpoint.Core.Test
{
    public class ContractControllerTests
    {
        private Mock<IContractService> mockRepo;

        /// <summary>
        /// get all data from ContractController get action // GET: api/Contract
        /// expect: return 2 object from list
        /// </summary>
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

        /// <summary>
        /// finde model by id from ContractController get by id action  // GET: api/Contract/1
        /// expect: return model from list
        /// </summary>
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

        /// <summary>
        /// finde model by id from ContractController get by id action  // GET: api/Contract/0
        /// expect: can not finde model
        /// </summary>
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

        /// <summary>
        /// add new model to list by call post method  // POST: api/Contract
        /// expect: add model to list and return redirectToActionResult for get model in header
        /// </summary>
        [Fact]
        [Trait("ContractController", "ContractPostIsValid")]
        public void ContractPost_ReturnsARedirectAndAddContract_WhenModelStateIsValid()
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

            mockRepo = new Mock<IContractService>();
            mockRepo.Setup(repo => repo.Add(contract)).Returns(contract);

            // act
            var result = new ContractController(mockRepo.Object).PostContract(contract);
            var redirectToActionResult = (CreatedAtActionResult)Assert.IsType<ActionResult<ContractModel>>(result).Result;

            // Assert
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("GetContract", redirectToActionResult.ActionName);
            mockRepo.Verify();

        }

        /// <summary>
        /// add new model to list by call post method  // POST: api/Contract
        /// expect: add model to list and return BadRequest
        /// </summary> 
        [Fact]
        [Trait("ContractController", "ContractPostIsNotValidDate")]
        public void ContractPost_ReturnsBadRequestResult_WhenEndDateIsNotGreaterThanStartDateModelStateIsInvalid()
        {
            // Arrange      
            var contract = new ContractModel()
            {
                BrokerAgentName = "BrokerAgentName",
                BrokerCompanyName = "BrokerCompanyName",
                CustomerName = "CustomerName",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            };

            mockRepo = new Mock<IContractService>();
            mockRepo.Setup(repo => repo.Add(contract)).Returns(contract);
            var controller = new ContractController(mockRepo.Object);
            controller.ModelState.AddModelError("EndDate", "IsNotValid");


            // Act
            var result = controller.PostContract(contract);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.IsType<SerializableError>(badRequestResult.Value);

        }

        /// <summary>
        /// add new model to list by call post method  // POST: api/Contract
        /// expect: add model to list and return BadRequest
        /// </summary> 
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
