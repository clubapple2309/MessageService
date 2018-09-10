using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.DAL.Entities
{
	public class Mail
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public string Subject { get; set; }
		public string MailBody { get; set; }

		//do t think that need another table for only 1 prop
		public string Recipients { get; set; }
		public bool IsSent { get; set; }
	}
}
