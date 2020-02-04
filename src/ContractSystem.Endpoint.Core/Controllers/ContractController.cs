using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContractSystem.Domain.Interfaces;
using ContractSystem.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace ContractSystem.Endpoint.Core.Controllers
{
    [Route("api/Contract")]
    [ApiVersion("1.0")]
    public class ContractController : Controller
    {
        private readonly IContractService contractService;

         
        public ContractController(IContractService contractService)
        {
            this.contractService = contractService;
        }

        // GET: api/Contract
        [HttpGet]
        public ActionResult<IEnumerable<ContractModel>> GetContract()
        {
            return contractService.GetAll();
        }

        // GET: api/Contract/5
        [HttpGet("{id}")]
        public ActionResult<ContractModel> GetContract(string id)
        {
            var contract = contractService.Find(id);

            if (contract == null)
                return NotFound();

            return contract;
        }

        // POST: api/Contract
        [HttpPost]
        public ActionResult<ContractModel> PostContract([FromBody]ContractModel contract)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newContract = contractService.Add(contract);

            return CreatedAtAction("GetContract", new { id = newContract.Id }, newContract);
        }
    }
     
}