using MessageService.DAL.Entities;
using MessageService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.DAL.Repositories
{
	public class EFUnitOfWork : IUnitOfWork
	{
		private bool disposed = false;

		private MailContext _db;
		private MailRepository mailRepository;


		public EFUnitOfWork(MailContext db)
		{
			_db = db;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_db.Dispose();
				}
				disposed = true;
			}
		}

		public void Save() => _db.SaveChanges();

		public IRepository<Mail> Mails => mailRepository ?? (mailRepository = new MailRepository(_db));

	
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
