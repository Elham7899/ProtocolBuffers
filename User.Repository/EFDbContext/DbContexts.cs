using Microsoft.EntityFrameworkCore;
using Models;
using User.Repository.Mappings;

namespace User.Repository.EFDbContext;

public class DbContexts : DbContext
{
	public DbSet<Users> Users { get; set; }

	public DbContexts(DbContextOptions options) : base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMapping).Assembly);

		base.OnModelCreating(modelBuilder);
	}
}
