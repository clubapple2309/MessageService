using MessageService.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MessageService.BLL.DTO;

namespace MessageService.BLL.Services
{
	public class EmailSendService : IEmailSendService
	{
		public bool Send(MailDTO emailMessage)
		{
			//send logic can use MailKit for example
			return true;
		}
	}
}
