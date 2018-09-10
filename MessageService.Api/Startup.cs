using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MessageService.BLL.Infrastructure;
using AutoMapper;
using MessageService.Api.Infrastructure;
using MessageService.DAL;

namespace MessageService.Api
{
    public class Startup
    {
		public IConfiguration Configuration { get; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
						 .SetBasePath(env.ContentRootPath)
						 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
						 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
						 .AddEnvironmentVariables();

			Configuration = builder.Build();
		}


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
			services.AddSingleton((s) => Mapper.Instance);
			Mapper.Initialize(AutoMapperProfileConfiguration.Configure);

			DIConfiguration.ConfigureDI(services);
			SetUpDataBase(services);

		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			app.UseCors(builder => builder.WithOrigins(Configuration["Origin"]).AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

			if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }


		protected virtual void SetUpDataBase(IServiceCollection services)
		{
			var connectionName = Configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<MailContext>(options => options.UseSqlServer(connectionName));
		}
	}
}
