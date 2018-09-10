using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MessageService.Api.Models.Model
{
    public class MailViewModel
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
