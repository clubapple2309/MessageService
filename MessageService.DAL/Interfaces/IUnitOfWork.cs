using MessageService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageService.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
	{
		IRepository<Mail> Mails { get; }
		void Save();

	}
}
