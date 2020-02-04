using System;
using System.Collections.Generic;
using System.Text;
using ContractSystem.DAL.MongoDb.Services;
using ContractSystem.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ContractSystem.IocConfig.Content
{
    public static class ContentServicesRegistry
    {
        public static void AddCustomContentServices(this IServiceCollection services)
        {
            services.AddTransient<IContractService, ContractService>();
        }
    }
}
