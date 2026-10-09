using EmployeeMGST.Models;

namespace EmployeeMGST.Operations
{
    // All function are blocking (Apply Task parallel library)
    interface IEmployeeOperation // Operations folder
    {
        int Add(Employee employee);
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int id); // Apply DTO with projection query

        List<Employee> SearchByAge(int age);
        Employee UpdateEmployee(Employee employee, int id);
        int DeleteEmployee(int id);
    }
}