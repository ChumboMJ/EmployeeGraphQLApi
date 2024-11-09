using GraphQL.Types;

namespace EmployeeGraphQLApi.Models
{
    public record EmployeeModel(int Id, string Name, int Age, int DeptId);

    public record Department(int Id, string Name);

    public class EmployeeDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string DeptName { get; set; }
    }

    public class EmployeeDetailsType : ObjectGraphType<EmployeeDetails>
    {
        public EmployeeDetailsType()
        {
            Field(x => x.Id).Description("Employee Id");
            Field(x => x.Name).Description("Employee Name");
            Field(x => x.Age).Description("Employee Age");
            Field(x => x.DeptName).Description("Department Name");
        }
    }
}
