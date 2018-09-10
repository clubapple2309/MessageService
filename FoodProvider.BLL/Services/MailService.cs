using MessageService.BLL.DTO;
using MessageService.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MessageService.DAL.Interfaces;
using AutoMapper;
using MessageService.DAL.Entities;
using System.Linq;

namespace MessageService.BLL.Services
{
	class MailService : IMailService
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IEmailSendService _emailSendService;

		public MailService(IUnitOfWork uow, IMapper mapper, IEmailSendService emailSendService)
		{
			_mapper = mapper;
			_unitOfWork = uow;
			_emailSendService = emailSendService;
		}
		public IEnumerable<MailDTO> GetAll()
		{
			return _mapper.Map<IQueryable<Mail>, IEnumerable<MailDTO>>(_unitOfWork.Mails.GetAll());
		}

		public MailDTO Send(MailDTO mail)
		{
			mail.IsSent = _emailSendService.Send(mail);
			var newMail = _unitOfWork.Mails.Save(_mapper.Map<MailDTO, Mail>(mail));
			_unitOfWork.Save();

			return _mapper.Map<Mail, MailDTO>(newMail);
		}


		public void Dispose() => _unitOfWork.Dispose();
	}
}
