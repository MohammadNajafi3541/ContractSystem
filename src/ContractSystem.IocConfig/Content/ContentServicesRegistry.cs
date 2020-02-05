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
        /// <summary>
        /// this is an extension class for injecting our custom interface  to our custom service in endpoint.core startup
        /// </summary>
        /// <param name="services"></param>
        public static void AddCustomContentServices(this IServiceCollection services)
        {
            services.AddScoped<IContractService, ContractService>();
        }
    }
}
