using FDTE.Entities;
using FDTE.InfraScructure;
using FDTE.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FDTE.Services.Services
{
	public class MarujoService : IMarujoService
	{
		private readonly FdteDbContext _fdteDbContext;

		public MarujoService(FdteDbContext fdteDbContext)
		{
			_fdteDbContext = fdteDbContext;
		}

		public IEnumerable<Marujo> GetAll()
		{
			List<Marujo> marujoList = new List<Marujo>();

			try
			{
				marujoList = _fdteDbContext.Marujo.ToList();
			}
			catch (System.Exception)
			{

				return null;
			}

			return marujoList;
		}

		public bool Create(Marujo model)
		{
			try
			{
				_fdteDbContext.Add(model);
				_fdteDbContext.SaveChanges();
			}
			catch (System.Exception)
			{
				return false;
			}

			return true;
		}

		public bool Update(Marujo model)
		{
			try
			{
				var marujo = _fdteDbContext.Marujo.Single(x => x.ID == model.ID);
				marujo.FirstName = model.FirstName;
				marujo.LastName = model.LastName;

				_fdteDbContext.Update(marujo);
				_fdteDbContext.SaveChanges();
			}
			catch (System.Exception)
			{

				return false;
			}

			return true;
		}

		public bool Delete(int id)
		{
			try
			{
				_fdteDbContext.Entry(new Marujo { ID = id }).State = EntityState.Deleted;
				_fdteDbContext.SaveChanges();
			}
			catch (System.Exception)
			{

				return false;
			}

			return true;
		}

		public Marujo Get(int id)
		{
			var result = new Marujo();
			try
			{
				result = _fdteDbContext.Marujo.Single(x => x.ID == id);
			}
			catch (System.Exception)
			{

				return null;
			}

			return result;
		}
	}
}
