using EmployeeGraphQLApi.Models;

namespace EmployeeGraphQLApi.Interfaces
{
    public interface IEmployeeService
    {
        public List<EmployeeDetails> GetEmployees();
        public List<EmployeeDetails> GetEmployee(int empId);
        public List<EmployeeDetails> GetEmployeeByDepartment(int deptId);
    }
}
