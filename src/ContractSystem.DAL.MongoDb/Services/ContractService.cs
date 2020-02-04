using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ContractSystem.DAL.MongoDb.DataModel;
using ContractSystem.DAL.MongoDb.DbSetting;
using ContractSystem.Domain.Interfaces;
using ContractSystem.Domain.Model;
using MongoDB.Driver;

namespace ContractSystem.DAL.MongoDb.Services
{
    public class ContractService : IContractService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Contract> _contract;

       
        public ContractService(IContractDatabaseSettings settings, IMapper mapper)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _contract = database.GetCollection<Contract>(settings.ContractCollectionName);
            _mapper = mapper;
        }

        public ContractModel Add(ContractModel model)
        {
            var entity = _mapper.Map<Contract>(model);
            _contract.InsertOne(entity);
            return _mapper.Map<ContractModel>(entity);
        }

        public ContractModel Find(string id)
        {
            try
            {
                var entity = _contract.Find<Contract>(c => c.Id == id).FirstOrDefault();
                return _mapper.Map<ContractModel>(entity);
            }
            catch (Exception)
            {

                return null;
            }

        }

        public  List<ContractModel> GetAll()
        {
            var list = _contract.Find(c => true).ToList();
            return _mapper.Map<List<Contract>, List<ContractModel>>(list);
        }


    }
}
