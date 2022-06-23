using LearnGraphQL.Schema;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddGraphQLServer().AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL("/graphql");

//app.MapGet("/", () => "Hello World!");

app.Run();
