using System;
using System.Collections.Generic;
using System.Text;

namespace ContractSystem.DAL.MongoDb.DbSetting
{
    /// <summary>
    /// this class get database setting in startup from appsettings.json file in the endpoint.core project
    /// </summary>
    public class ContractDatabaseSettings : IContractDatabaseSettings
    {
        public string ContractCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

   
}
