using MessageService.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.BLL.Interfaces
{
	public interface IMailService
	{
		IEnumerable<MailDTO> GetAll();
		MailDTO Send(MailDTO mail);
	}
}
