using MessageService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.DAL.Repositories
{
	public class MailRepository : BaseRepository<Mail>
	{
		public MailRepository(DbContext context)
			: base(context)
		{
		}
	}
}
