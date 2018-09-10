using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MessageService.BLL.Interfaces;
using MessageService.BLL.Services;
using MessageService.DAL.Repositories;
using MessageService.DAL.Interfaces;

namespace MessageService.BLL.Infrastructure
{
	public class DIConfiguration
	{
		public static void ConfigureDI(IServiceCollection services)
		{

			services.AddTransient<IMailService, MailService>();
			services.AddTransient<IEmailSendService, EmailSendService>();
			services.AddScoped<IUnitOfWork, EFUnitOfWork>();

		}
	}
}
