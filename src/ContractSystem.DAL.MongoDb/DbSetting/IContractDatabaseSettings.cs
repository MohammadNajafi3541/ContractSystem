using System;
using System.Collections.Generic;
using System.Text;

namespace ContractSystem.DAL.MongoDb.DbSetting
{
    public interface IContractDatabaseSettings
    {
        string ContractCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
