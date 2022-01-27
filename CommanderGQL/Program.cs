using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opt => opt
	.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"))
	.UseSnakeCaseNamingConvention()
);
builder.Services.AddGraphQLServer()
	.AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

await app.RunAsync();
