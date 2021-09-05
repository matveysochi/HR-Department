using System.Collections.Generic;
using System.Linq;

namespace HRD.Models
{
    public class EFEmployeeRepository: IEmployeeRepository
    {
        readonly AppDbContext context;
        public EFEmployeeRepository(AppDbContext context) => this.context = context;

        public IEnumerable<Employee> Employees => context.Employees.ToArray();

        public void AddEmployee(Employee employee)
        {
            context.Add(employee);
            context.SaveChanges();
        }

        public Employee GetEmployee(long id) => context.Employees.Find(id);

        public void UpdateEmployee(Employee employee)
        {
            context.Update(employee);
            context.SaveChanges();

        }
    }
}