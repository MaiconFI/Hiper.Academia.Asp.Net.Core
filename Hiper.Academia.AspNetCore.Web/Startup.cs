using AutoMapper;
using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Web.Mappers;
using Hiper.Academia.AspNetCore.Repositories.IoC;
using Hiper.Academia.AspNetCore.Services.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Hosting;

namespace Hiper.Academia.AspNetCore.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseMvc()
                .UseApiVersioning();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IHiperAcademiaContext, HiperAcademiaContext>(opt => opt.UseInMemoryDatabase(databaseName: "teste"));
            MigrateDatabase(services);

            services
                .AddMvc(m => { m.EnableEndpointRouting = false; })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddApiVersioning(s =>
            {
                s.DefaultApiVersion = new ApiVersion(1, 0);
                s.ReportApiVersions = true;
                s.AssumeDefaultVersionWhenUnspecified = true;
            });

            IoCServices.Register(services);
            IoCRepositories.Register(services);

            services.AddSingleton(new MapperConfiguration(x => { x.AddProfile(new HiperAcademiaProfile()); }).CreateMapper());
        }

        private void MigrateDatabase(IServiceCollection services)
        {
            using var serviceScope = services.BuildServiceProvider().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<IHiperAcademiaContext>();

            //if (context.AllMigrationsApplied()) return;

            //context.Database.Migrate();
            context.Seed();
        }
    }
}