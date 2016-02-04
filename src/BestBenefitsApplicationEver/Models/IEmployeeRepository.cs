using System.Collections.Generic;

namespace BestBenefitsApplicationEver.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Employee> GetAllEmployeesWithDependents();
        void AddEmployee(Employee newEmployee);
        bool SaveAll();
        void AddDependent(int employeeId, Dependent newDependent);
        Employee GetEmployeesWithDependentsById(int employeeId);
        void EditEmployee(Employee editEmployee);
        void DeleteEmployee(int employeeId);
    }
}