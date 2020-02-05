using System;
using System.Collections.Generic;
using System.Text;

namespace ContractSystem.DAL.MongoDb.DbSetting
{
    /// <summary>
    /// this interface is for inject to ContractDatabaseSettings
    /// ContractDatabaseSettings class get database setting in startup from appsettings.json file in the endpoint.core project
    /// </summary>
    public interface IContractDatabaseSettings
    {
        string ContractCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
