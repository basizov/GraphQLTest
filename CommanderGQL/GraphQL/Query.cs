using CommanderGQL.Data;
using CommanderGQL.Data.Entities;

namespace CommanderGQL.GraphQL;

public class Query
{
	public IQueryable<Platform> GetPlatforms([Service] DataContext context) => context.Platforms;
}
