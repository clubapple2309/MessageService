using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.BLL.DTO
{
	public class MailDTO
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public string Subject { get; set; }
		public string MailBody { get; set; }
		public string[] Recipients { get; set; }
		public bool IsSent { get; set; }
	}
}
