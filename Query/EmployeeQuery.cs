using EmployeeGraphQLApi.Interfaces;
using EmployeeGraphQLApi.Models;
using GraphQL;
using GraphQL.Types;

namespace EmployeeGraphQLApi.Query
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(IEmployeeService employeeService)
        {
            //This can also be done in an Async Fashion using the ResolveAsync method
            Field<ListGraphType<EmployeeDetailsType>>(Name = "Employees")
                .Description(Description = "Get all employees")
                .Resolve(context => employeeService.GetEmployees());
            Field<ListGraphType<EmployeeDetailsType>>(Name = "Employee")
                .Description(Description = "Get employee by Id")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "empId" }))
                .Resolve(context => employeeService.GetEmployee(context.GetArgument<int>("empId")));        
        }

        public class EmployeeDetailSchema : Schema
        {
            public EmployeeDetailSchema(IServiceProvider serviceProvider) : base(serviceProvider)
            {
                Query = serviceProvider.GetRequiredService<EmployeeQuery>();
            }
        }
    }
}
