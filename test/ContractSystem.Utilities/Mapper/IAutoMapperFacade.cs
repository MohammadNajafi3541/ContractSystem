using System;
using System.Collections.Generic;
using System.Text;

namespace ContractSystem.Utilities.Mapper
{
    public interface IAutoMapperFacade
    {
        TOutput Map<TInput, TOutput>(TInput input);
    }

}
