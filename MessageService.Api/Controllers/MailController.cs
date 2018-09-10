using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MessageService.Api.Models.Response;
using MessageService.Api.Models.Model;
using MessageService.BLL.Interfaces;
using MessageService.BLL.DTO;
using AutoMapper;

namespace MessageService.Api.Controllers
{
	[Route("api/mail")]
	public class MailController : Controller
	{
		private readonly IMailService _mailService;
		private readonly IMapper _mapper;

		public MailController(IMailService mailService, IMapper mapper)
		{
			_mailService = mailService;
			_mapper = mapper;
		}

		[HttpGet]
		public JsonResponse GetMail()
		{
			var mail = _mapper.Map<IEnumerable<MailDTO>, IEnumerable<MailViewModel>>(_mailService.GetAll());
			return JsonResponse.GetSuccessResult(
					data: mail
				);
		}

		[HttpPost]
		public JsonResponse Send([FromBody]MailViewModel mailModel)
		{
			var result = _mailService.Send(_mapper.Map<MailViewModel, MailDTO>(mailModel));

			//can return JsonResponse.GetFailedResult
			return JsonResponse.GetSuccessResult(
					data: _mapper.Map<MailDTO, MailViewModel>(result)
				);
		}
	}
}
