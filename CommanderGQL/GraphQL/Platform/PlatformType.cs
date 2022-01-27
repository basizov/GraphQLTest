using CommanderGQL.Data;

namespace CommanderGQL.GraphQL.Platform;

public class PlatformType : ObjectType<Data.Entities.Platform>
{
	protected override void Configure(IObjectTypeDescriptor<Data.Entities.Platform> descriptor)
	{
		descriptor.Description("Represents any software or service that has a command line interface.");
		descriptor.Field(p => p.LicenseKey).Ignore();
		descriptor.Field(p => p.Commands)
			.ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
			.UseDbContext<DataContext>()
			.Description("This is the list of available commands for this platform.");
	}

	private class Resolvers
	{
		public IQueryable<Data.Entities.Command> GetCommands(Data.Entities.Platform platform, [ScopedService] DataContext context) => context.Commands.Where(c => c.PlatformId == platform.Id);
	}
}
