using System;
using System.Collections.Generic; 
using System.Text;
using AutoMapper;
using ContractSystem.DAL.MongoDb.DataModel;
using ContractSystem.Domain.Model;

namespace ContractSystem.AmcConfig.Mapping
{
    public class AutoMapperProfileConfiguration : Profile
    {

        public AutoMapperProfileConfiguration() : this("AppProfile")
        {

        }

        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {

            #region Contract
            CreateMap<Contract, ContractModel>();
            CreateMap<ContractModel, Contract>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            #endregion

        }
    }

}
