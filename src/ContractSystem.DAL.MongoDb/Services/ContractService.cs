using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ContractSystem.DAL.MongoDb.DataModel;
using ContractSystem.DAL.MongoDb.DbSetting;
using ContractSystem.Domain.Interfaces;
using ContractSystem.Domain.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ContractSystem.DAL.MongoDb.Services
{
    /// <summary>
    /// this is the contract service which receive request from api and doing our CRUD 
    /// in this class constractive we have two interface 
    /// IContractDatabaseSettings: this set the mongo db setting this setting come from appsettings.json from endpoint project and in endpoint project startup.cs we set them
    /// and also we have an ContractMongoDbBaseService that is the base for service in this class constractor we set database settings
    /// </summary>
    public class ContractService : ContractMongoDbBaseService<Contract>, IContractService
    {

        public ContractService(IContractDatabaseSettings settings, IMapper mapper)
            : base(settings, mapper)
        {

        }

        /// <summary>
        /// this method add new contract to database
        /// at  first with mapper we convert our contractModel to contact beacuse we should insert contract to mongodb
        /// at  end we return an contract model whit new id value that saved in databse 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>ContractModel</returns>

        public ContractModel Add(ContractModel model)
        {
            var entity = _mapper.Map<Contract>(model);
                 _contract.InsertOne(entity);
            return _mapper.Map<ContractModel>(entity);
        }

        /// <summary>
        /// this method fide a contract by id in database and after convert to contractmodel return this
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ContractModel</returns>
        public ContractModel Find(string id)
        {
            try
            {
               
                    var entity = _contract.Find<Contract>(c => c.Id == id).FirstOrDefault();
                return _mapper.Map<ContractModel>(entity);              

            }
            catch (Exception ex)
            {

                return null;
            }

        }

        /// <summary>
        /// this method read all contract from database and convert to contract model and return them
        /// </summary>
        /// <returns>List<ContractModel></returns>
        public List<ContractModel> GetAll()
        {
            var list = _contract.Find(c => true).ToList();
            return _mapper.Map<List<Contract>, List<ContractModel>>(list);
        }


    }
}
