using CommanderGQL.Data;
using CommanderGQL.GraphQL.Command;
using CommanderGQL.GraphQL.Platform;
using HotChocolate.Subscriptions;

namespace CommanderGQL.GraphQL;

public class Mutation
{
	[UseDbContext(typeof(DataContext))]
	public async Task<AddPlatformPayload> CreatePlatformAsync(
		AddPlatformInput input,
		[ScopedService] DataContext context,
		[Service] ITopicEventSender eventSender,
		CancellationToken cancellationToken
	)
	{
		var newPlatform = new Data.Entities.Platform
		{
			Name = input.Name
		};
		
		context.Platforms.Add(newPlatform);
		await context.SaveChangesAsync(cancellationToken);
		await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), newPlatform, cancellationToken);
		return new AddPlatformPayload(newPlatform);
	}

	[UseDbContext(typeof(DataContext))]
	public async Task<AddCommandPayload> CreateCommandAsync(AddCommandInput input, [ScopedService] DataContext context)
	{
		var newCommand = new Data.Entities.Command
		{
			HowTo = input.HowTo,
			CommandLine = input.CommandLine,
			PlatformId = input.PlatformId
		};
		
		context.Commands.Add(newCommand);
		await context.SaveChangesAsync();
		return new AddCommandPayload(newCommand);
	}
}
