using endpoint_impl.voicecommerce.stages.sale;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace endpointWebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public delegate SalePostPipelineStageBase MyServiceResolver(SalePostPipelineStageBase type);

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // BIND APP SETTINGS
            //var appConfig = services.AddConfig<AppConfig>(Configuration.GetSection(ConfigDefaults.AppConfigName));

            //ConfigureDataService(services);
            //services.AddScoped<ISalePostSetupContext, SalePostSetupContext>();
            //services.AddScoped<ISalePostFailedSaleCreation, SalePostFailedSaleCreation>(); 
            //services.AddScoped<SalePostPipelineStage, SalePostSetupContext>();
            //services.AddScoped<SalePostPipelineStage, SalePostFailedSaleCreation>();

            //From below in configure services in startup
            services.AddTransient<SalePostSetupContext>();
            services.AddTransient<SalePostFailedSaleCreation>();
            services.AddTransient<MyServiceResolver>(serviceProvider => type =>
            {
                switch (type)
                {
                    case SalePostSetupContext s:
                        return serviceProvider.GetService<SalePostFailedSaleCreation>();
                    case SalePostFailedSaleCreation f:
                        return serviceProvider.GetService<SalePostTransactionSetup>();
                    default:
                        throw new Exception("Cannot Resolve Dependencies");
                }
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            //app.UseMiddleware<SalePostSetupContext>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

        private void ConfigureDataService(object services)
        {
        }
    }
}
