using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ContractSystem.AmcConfig.Mapping
{
   public static class AutomapperExtension
    {
        /// <summary>
        /// this extension class is for adding automapper service to startup. automapper is component for convert class together
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
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
