using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BestBenefitsApplicationEver.Database;
using Microsoft.Data.Entity;

namespace BestBenefitsApplicationEver.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.OrderBy(x => x.Name).ToList();
        }
        public IEnumerable<Employee> GetAllEmployeesWithDependents()
        {
            return _context.Employees
                .Include(x => x.Dependents)
                .OrderBy(x => x.EmployeeId)
                .ToList();
        }

        public void AddEmployee(Employee newEmployee)
        {
            _context.Add(newEmployee);
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public Employee GetEmployeesWithDependentsById(int employeeId)
        {
            return _context.Employees
                .Include(x => x.Dependents)
                .FirstOrDefault(x => x.EmployeeId == employeeId);
        }
        public void EditEmployee(Employee editEmployee)
        {
            _context.Update(editEmployee);
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = _context.Employees
                .Include(x => x.Dependents)
                .FirstOrDefault(x => x.EmployeeId == employeeId);
            _context.Remove(employee);
        }

        public void AddDependent(int employeeId, Dependent newDependent)
        {
            var employeeToAddDependent = GetEmployeesWithDependentsById(employeeId);
            employeeToAddDependent.Dependents.Add(newDependent);
            _context.Dependents.Add(newDependent);
        }
    }

}