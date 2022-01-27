using CommanderGQL.Data;

namespace CommanderGQL.GraphQL.Command;

public class CommandType : ObjectType<Data.Entities.Command>
{
	protected override void Configure(IObjectTypeDescriptor<Data.Entities.Command> descriptor)
	{
		descriptor.Description("Represents any executable command.");
		descriptor.Field(c => c.Platform)
			.ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
			.UseDbContext<DataContext>()
			.Description("This is the platform to which the command belongs.");
	}

	private class Resolvers
	{
		public Data.Entities.Platform? GetPlatform(Data.Entities.Command command, [ScopedService] DataContext context) => context.Platforms.SingleOrDefault(p => p.Id == command.PlatformId);
	}
}
