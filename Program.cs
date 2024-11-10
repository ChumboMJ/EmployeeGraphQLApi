using EmployeeGraphQLApi.Interfaces;
using EmployeeGraphQLApi.Models;
using EmployeeGraphQLApi.Query;
using EmployeeGraphQLApi.Services;
using GraphQL.Types;
using GraphQL;
using static EmployeeGraphQLApi.Query.EmployeeQuery;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<EmployeeDetailsType>();
builder.Services.AddSingleton<EmployeeQuery>();
builder.Services.AddSingleton<ISchema, EmployeeDetailSchema>();
builder.Services.AddGraphQL(b => b
    .AddAutoSchema<EmployeeQuery>()  // schema
    .AddSystemTextJson());   // serializer

var app = builder.Build();

// Register the GraphQL endpint, including playground (similar to Swagger for GraphQL)
app.UseGraphQL<ISchema>("/graphql"); //This is the URL to the GraphQL Endpoint
app.UseGraphQLPlayground(
    "/", // This is the URL to access the playground
    new GraphQL.Server.Ui.Playground.PlaygroundOptions
    {
        GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
        SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
    });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
