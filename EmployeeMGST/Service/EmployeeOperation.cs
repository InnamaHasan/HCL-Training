
using EmployeeMGST.Models;
using EmployeeMGST.Operations;

namespace EmployeeMGST.Service
{
    public class EmployeeOperation : IEmployeeOperation
    {
        List<Employee> employees = new List<Employee>();
        int IEmployeeOperation.Add(Employee employee)
        {
            employees.Add(employee);
            return 1;
        }

        int IEmployeeOperation.DeleteEmployee(int id)
        {
            Employee emp = employees.Find(a => a.Id == id);
            employees.Remove(emp);
            return 1;
        }



        Employee IEmployeeOperation.GetEmployeeById(int id)
        {
            var emp = employees.Find(a => a.Id == id);
            return emp;
        }


        List<Employee> IEmployeeOperation.GetEmployees()
        {
            // List<Employee> employees1 = employees;
            // return employees1;
            return employees;
        }


        List<Employee> IEmployeeOperation.SearchByAge(int age)
        {
            List<Employee> empAge = employees.Where(a=>a.Age >= age).ToList();
            return empAge;
        }

        Employee IEmployeeOperation.UpdateEmployee(Employee employee, int id)
        {
            Employee existingEmployee = employees.Find(e => e.Id == id);
            if(existingEmployee == null) return null;
            existingEmployee.Name = employee.Name;
            existingEmployee.Age = employee.Age;
            return existingEmployee;

        }
    }
}