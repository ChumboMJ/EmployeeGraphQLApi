using EmployeeGraphQLApi.Interfaces;
using EmployeeGraphQLApi.Models;

namespace EmployeeGraphQLApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        // Hard-coded Employee and Department data
        // TODO: Replace this with data from a database
        private List<Employee> employees = new List<Employee>
        {
            new Employee(1, "John", 30, 1),
            new Employee(2, "Ash", 25, 2),
            new Employee(3, "Misty", 22, 2),
            new Employee(4, "Tim", 28, 2),
            new Employee(5, "Brock", 27, 3),
            new Employee(6, "Jessie", 26, 3),
            new Employee(7, "James", 25, 3),
            new Employee(8, "Gary", 24, 3)
        };

        private List<Department> departments = new List<Department>
        {
            new Department(1, "HR"),
            new Department(2, "IT"),
            new Department(3, "Finance")
        };

        public List<EmployeeDetails> GetEmployee(int empId)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeDetails> GetEmployeeByDepartment(int deptId)
        {
            return employees.Where(e => e.DeptId == deptId).Select(e => new EmployeeDetails
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                DeptName = departments.FirstOrDefault(d => d.Id == e.DeptId)?.Name
            }).ToList();
        }

        public List<EmployeeDetails> GetEmployees()
        {
            return employees.Select(e => new EmployeeDetails {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                DeptName = departments.FirstOrDefault(d => d.Id == e.DeptId)?.Name
            }).ToList();
        }
    }
}
