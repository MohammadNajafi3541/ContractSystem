using System;
using System.Collections.Generic;
using System.Text;
using ContractSystem.Domain.Model;

namespace ContractSystem.Domain.Interfaces
{
    /// <summary>
    /// this class is for injecting to contractserivce that have intraction with contract table  in contractmongodb 
    /// </summary>
   public interface IContractService
    {
         List<ContractModel> GetAll();
         ContractModel Find(string id);
        ContractModel Add(ContractModel model);

    }
}
