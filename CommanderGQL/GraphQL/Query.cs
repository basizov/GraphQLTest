using CommanderGQL.Data;

namespace CommanderGQL.GraphQL;

public class Query
{
	[UseDbContext(typeof(DataContext))]
	[UseProjection]
	[UseFiltering]
	[UseSorting]
	public IQueryable<Data.Entities.Platform> GetPlatforms([ScopedService] DataContext context) => context.Platforms;

	[UseDbContext(typeof(DataContext))]
	[UseProjection]
	[UseFiltering]
	[UseSorting]
	public IQueryable<Data.Entities.Command> GetCommands([ScopedService] DataContext context) => context.Commands;
}
