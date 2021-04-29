using Marketplace.ClassifiedAd;
using Marketplace.Domain.ClassifiedAd;
using Marketplace.Domain.Shared;
using Marketplace.Domain.UserProfile;
using Marketplace.Framework;
using Marketplace.Infrastructure;
using Marketplace.UserProfile;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var store = new DocumentStore
            {
                Urls = new[] { "http://localhost:8080" },
                Database = "Marketplace_Chapter8",
                Conventions =
                {
                    FindIdentityProperty = m => m.Name == "_databaseId"
                }
            };

            store.Initialize();

            var purgomalumClient = new PurgomalumClient();

            services.AddSingleton<ICurrencyLookup, FixedCurrencyLookup>();
            services.AddScoped(c => store.OpenAsyncSession());
            services.AddScoped<IUnitOfWork, RavenDbUnitOfWork>();
            services.AddScoped<IClassifiedAdRepository, ClassifiedAdRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<ClassifiedAdsApplicationService>();
            services.AddScoped(c =>
                new UserProfileApplicationService(
                    c.GetService<IUserProfileRepository>(),
                    c.GetService<IUnitOfWork>(),
                    text => purgomalumClient.CheckForProfanity(text).
                    GetAwaiter().GetResult()));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClassifiedAds", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClassifiedAds V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
