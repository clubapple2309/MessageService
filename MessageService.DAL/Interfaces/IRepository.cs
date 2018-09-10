using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageService.DAL.Interfaces
{
	public interface IRepository<T>
		 where T : class
	{
		IQueryable<T> GetAll();

		T Save(T item);

	}
}
