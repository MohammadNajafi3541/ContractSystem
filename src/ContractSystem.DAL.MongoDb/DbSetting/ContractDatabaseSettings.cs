using System;
using System.Collections.Generic;
using System.Text;

namespace ContractSystem.DAL.MongoDb.DbSetting
{
    public class ContractDatabaseSettings : IContractDatabaseSettings
    {
        public string ContractCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

   
}
