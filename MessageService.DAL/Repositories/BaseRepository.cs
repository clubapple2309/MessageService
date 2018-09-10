using MessageService.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageService.DAL.Repositories
{
	public abstract class BaseRepository<TEntity> : IRepository<TEntity>
	   where TEntity : class
	{
		protected DbContext Context { get; }

		protected BaseRepository(DbContext context)
		{
			this.Context = context;
		}


		public virtual IQueryable<TEntity> GetAll()
		{
			return this.Context.Set<TEntity>();
		}

		public virtual TEntity Save(TEntity item)
		{
			return	this.Context.Set<TEntity>().Add(item).Entity;
		}


	}

}
