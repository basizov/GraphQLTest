using CommanderGQL.Data.Entities;
using CommanderGQL.Data.FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data;

public class DataContext : DbContext
{
	public DbSet<Platform> Platforms => Set<Platform>();

	public DataContext(DbContextOptions<DataContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new PlatformConfiguration());
		base.OnModelCreating(modelBuilder);
	}
}
