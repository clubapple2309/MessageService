using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MessageService.Api.Models.Model;
using MessageService.BLL.DTO;

namespace MessageService.Api.Infrastructure
{
	public class AutoMapperProfileConfiguration
	{
		public static void Configure(IMapperConfigurationExpression mapper)
		{
			BLL.Infrastructure.MapperConfiguration.Configure(mapper);

			mapper.CreateMap<MailDTO, MailViewModel>()
				.ReverseMap();
			mapper.CreateMap<MailViewModel,MailDTO>()
				.ReverseMap();
		}
	}
}
