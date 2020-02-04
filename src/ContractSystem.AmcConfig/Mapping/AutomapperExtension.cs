using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ContractSystem.AmcConfig.Mapping
{
   public static class AutomapperExtension
    {
        public static IServiceCollection AddAutoMapperExtensionService(this IServiceCollection services)
        {

            //config for automapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());

             });


            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            //end config for automapper

            //add automapper service to your project;
            services.AddAutoMapper();

            return services;
        }
    }
}
