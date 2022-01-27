using CommanderGQL.Data.Entities;
using CommanderGQL.Data.FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data;

public class DataContext : DbContext
{
	public DbSet<Platform> Platforms => Set<Platform>();
	public DbSet<Command> Commands => Set<Command>();

	public DataContext(DbContextOptions<DataContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new PlatformConfiguration());
		modelBuilder.ApplyConfiguration(new CommandConfiguration());
		base.OnModelCreating(modelBuilder);
	}
}
