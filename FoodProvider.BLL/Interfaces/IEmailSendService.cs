using MessageService.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.BLL.Interfaces
{
	public interface IEmailSendService
	{
		bool Send(MailDTO emailMessage);
	}
}
