using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ContractSystem.Utilities.Mapper
{
    public class AutoMapperFacade : IAutoMapperFacade
    {
        private readonly MapperConfiguration mapperConfiguration;
        public AutoMapperFacade(params Profile[] profiles)
        {
            mapperConfiguration = new MapperConfiguration(c=> {

                foreach (var item in profiles)
                {
                    c.AddProfile(item);
                }
            });

        }

        public TOutput Map<TInput, TOutput>(TInput input)
        {
            return mapperConfiguration.CreateMapper().Map<TOutput>(input);
        }
    }
}
