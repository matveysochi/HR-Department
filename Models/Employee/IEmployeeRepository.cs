using System.Collections.Generic;

namespace HRD.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Employees { get; }
        Employee GetEmployee(long id);
        void AddEmployee (Employee employee);
        void UpdateEmployee(Employee employee);
    }
}