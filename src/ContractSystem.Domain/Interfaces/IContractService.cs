using System;
using System.Collections.Generic;
using System.Text;
using ContractSystem.Domain.Model;

namespace ContractSystem.Domain.Interfaces
{
   public interface IContractService
    {
         List<ContractModel> GetAll();
         ContractModel Find(string id);
        ContractModel Add(ContractModel model);

    }
}
