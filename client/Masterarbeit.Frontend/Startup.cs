using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Masterarbeit.Frontend.App;
using Masterarbeit.Frontend.AzureAccess;
using Masterarbeit.Frontend.Contracts;
using Masterarbeit.Frontend.DatabaseAccess;
using Masterarbeit.Frontend.MAML.DatabaseAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApiClient = Masterarbeit.Frontend.MAML.DatabaseAccess.WebApiClient;

namespace Masterarbeit.Frontend
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.Configure<DatabaseSettings>(Configuration.GetSection("Database"));
            services.Configure<MAMLSettings>(Configuration.GetSection("MAML"));

            services.AddTransient<FixedWordInteractor>();
            services.AddTransient<FixedWordApiClient>();

            services.AddTransient<ImageInteractor>();
            services.AddTransient<ImageWebApiClient>();
            services.AddTransient<OcrAccess>();
            services.AddTransient<HttpClient>();

            services.AddTransient<WebApiClient>();
            services.AddTransient<DatabaseAccess.WebApiClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
