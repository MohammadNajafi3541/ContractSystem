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
        /// <summary>
        /// this extension class is for adding  class mapps to startup. automapper is component for convert class together
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            // These codes are used to introduce classes to the automapper
            #region Contract
            CreateMap<Contract, ContractModel>();
            CreateMap<ContractModel, Contract>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            #endregion

        }
    }

}
