using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper.Configuration;
using ContractSystem.DAL.MongoDb.DbSetting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ContractSystem.IocConfig.Base
{
    public static class ContextServicesRegistry
    {
       public static void AddCustomContextServices(this IServiceCollection services)
        {
            services.AddSingleton<IContractDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ContractDatabaseSettings>>().Value);
        }
    }
}
