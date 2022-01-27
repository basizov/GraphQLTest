using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using CommanderGQL.GraphQL.Command;
using CommanderGQL.GraphQL.Platform;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<DataContext>(opt => opt
	.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"))
	.UseSnakeCaseNamingConvention()
);
builder.Services.AddGraphQLServer()
	.AddQueryType<Query>()
	.AddMutationType<Mutation>()
	.AddSubscriptionType<Subscription>()
	.AddType<PlatformType>()
	.AddType<CommandType>()
	.AddFiltering()
	.AddSorting()
	.AddProjections()
	.AddInMemorySubscriptions();

var app = builder.Build();

app.UseWebSockets();
app.MapGraphQL();
app.UseGraphQLVoyager(new VoyagerOptions
{
	GraphQLEndPoint = "/graphql"
}, "/graphql-voyager");

await app.RunAsync();
