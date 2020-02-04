using ContractSystem.AmcConfig.Mapping;
using ContractSystem.DAL.MongoDb.DbSetting;
using ContractSystem.Domain.Model;
using ContractSystem.Domain.Validation;
using ContractSystem.IocConfig.Base;
using ContractSystem.IocConfig.Content;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ContractSystem.Endpoint.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<ContractDatabaseSettings>(Configuration.GetSection(nameof(ContractDatabaseSettings)));
            services.AddCustomContextServices();
            services.AddAutoMapperExtensionService();
            services.AddCustomContentServices();
            services.AddControllers().AddNewtonsoftJson().AddFluentValidation();
            services.AddTransient<IValidator<ContractModel>,ContractModelValidator>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contract API", Version = "v1" });
            });

            services.AddApiVersioning(
                 options =>
                 {
                     options.ReportApiVersions = true;
                     options.ApiVersionReader = new HeaderApiVersionReader("api-version");
                     options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                     options.AssumeDefaultVersionWhenUnspecified = true;
                     options.ReportApiVersions = true;
                 });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contract API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
