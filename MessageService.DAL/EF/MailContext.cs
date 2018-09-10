using System;
using Microsoft.EntityFrameworkCore;
using MessageService.DAL.Entities;

namespace MessageService.DAL
{
    public class MailContext : DbContext
	{
		public DbSet<Mail> Mails { get; set; }

		public MailContext(DbContextOptions<MailContext> options)
			: base(options)
		{
		}

	}
}
