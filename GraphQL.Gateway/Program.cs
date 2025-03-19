using GraphQL.Gateway.Mutation;
using GraphQL.Gateway.Query;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("ConsumptionService", client =>
{
    client.BaseAddress = new Uri("http://localhost:5152/"); // Consumption Service API URL
});

builder.Services.AddHttpClient("TestService", client =>
{
    client.BaseAddress = new Uri("http://localhost:5221/"); // Test Service API URL
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
