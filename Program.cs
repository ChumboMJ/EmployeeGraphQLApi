using EmployeeGraphQLApi.Interfaces;
using EmployeeGraphQLApi.Models;
using EmployeeGraphQLApi.Query;
using EmployeeGraphQLApi.Services;
using GraphQL.Types;
using GraphQL;
using static EmployeeGraphQLApi.Query.EmployeeQuery;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<EmployeeDetailsType>();
builder.Services.AddSingleton<EmployeeQuery>();
builder.Services.AddSingleton<ISchema, EmployeeDetailSchema>();
builder.Services.AddGraphQL(b => b
    .AddAutoSchema<EmployeeQuery>()  // schema
    .AddSystemTextJson());   // serializer

var app = builder.Build();

app.UseGraphQL<ISchema>("/graphql"); //This is the URL to the GraphQL Endpoint
app.UseGraphQLGraphiQL(
    "/ui/graphiql", // This is the URL to access the GraphiQL tool
    new GraphQL.Server.Ui.GraphiQL.GraphiQLOptions { 
        GraphQLEndPoint = "/graphql",
        SubscriptionsEndPoint = "/graphql"
    });

app.UseHttpsRedirection();

app.Run();
