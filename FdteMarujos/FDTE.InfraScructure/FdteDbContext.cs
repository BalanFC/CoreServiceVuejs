using Microsoft.EntityFrameworkCore;
using FDTE.Entities;

namespace FDTE.InfraScructure
{
	public class FdteDbContext: DbContext
	{
		public DbSet<Marujo> Marujo { get; set; }

		public FdteDbContext(DbContextOptions<FdteDbContext> options)
		 : base(options)
		{
		}
	}

	
}
