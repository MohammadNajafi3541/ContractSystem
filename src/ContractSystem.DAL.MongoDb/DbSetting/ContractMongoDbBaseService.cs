using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace ContractSystem.DAL.MongoDb.DbSetting
{
    /// <summary>
    /// this is base class for contract mongodb we use this to do not to repeat codes in every service
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ContractMongoDbBaseService<TEntity> 
        where TEntity : class
    {

        public IMongoCollection<TEntity> _contract;
        public IMapper _mapper;

        public ContractMongoDbBaseService(IContractDatabaseSettings settings, IMapper mapper)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _contract = database.GetCollection<TEntity>(settings.ContractCollectionName);
            _mapper = mapper;
        }

    }


}
