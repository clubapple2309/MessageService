using AutoMapper;
using MessageService.BLL.DTO;
using MessageService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.BLL.Infrastructure
{
	public class MapperConfiguration
	{
		public static void Configure(IMapperConfigurationExpression mapper)
		{

			mapper.CreateMap<MailDTO, Mail>().ForMember(dest => dest.Recipients, m => m.MapFrom(src => String.Join(",", src.Recipients)));

			mapper.CreateMap<Mail, MailDTO>().ForMember(dest => dest.Recipients, m => m.MapFrom(src => src.Recipients.Split(',', StringSplitOptions.None)));

		}

	}
}
