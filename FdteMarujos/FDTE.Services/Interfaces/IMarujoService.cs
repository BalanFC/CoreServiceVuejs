using FDTE.Entities;
using System.Collections.Generic;

namespace FDTE.Services.Interfaces
{
	public interface IMarujoService
	{
		IEnumerable<Marujo> GetAll();
		bool Create(Marujo model);
		bool Update(Marujo model);
		bool Delete(int id);
		Marujo Get(int id);
	}
}
