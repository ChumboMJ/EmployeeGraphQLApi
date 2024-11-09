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
            //TODO: According to VS, Field is obsolete. Possibly use FieldAsync instead - Check if the rest of this class should be "Asyncified".
            Field<ListGraphType<EmployeeDetailsType>> (Name = "Employees", Description = "Get all employees", resolve: context => employeeService.GetEmployees());
            Field<ListGraphType<EmployeeDetailsType>>(Name = "Employee", 
                    Description = "Get employee by Id", 
                    arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "empId" }), 
                    resolve: context => employeeService.GetEmployee(context.GetArgument<int>("empId")));        
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
