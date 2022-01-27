namespace CommanderGQL.GraphQL;

public class Subscription
{
	[Subscribe]
	[Topic]
	public Data.Entities.Platform OnPlatformAdded([EventMessage] Data.Entities.Platform platform) => platform;
}
