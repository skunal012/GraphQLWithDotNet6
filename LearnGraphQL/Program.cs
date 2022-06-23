using LearnGraphQL.Schema;
using LearnGraphQL.Schema.Mutations;
using LearnGraphQL.Schema.Subscriptions;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>();

builder.Services.AddInMemorySubscriptions();

var app = builder.Build();

app.UseWebSockets();
app.MapGraphQL("/graphql");

//app.MapGet("/", () => "Hello World!");

app.Run();
