using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HRD.Models
{
    public class EFEmployeeMovementRepository : IEmployeeMovementRepository
    {
        readonly AppDbContext context;
        public EFEmployeeMovementRepository(AppDbContext context) => this.context = context;

        public IEnumerable<EmployeeMovement> EmployeeMovements => context.EmployeeMovements
            .Include(m => m.Employee)
            .Include(m => m.Division)
            .ToArray();

        public void AddEmployeeMovement(EmployeeMovement employeeMovement)
        {
            context.Add(employeeMovement);
            context.SaveChanges();
        }

        public EmployeeMovement GetEmployeeMovement(long id) => context.EmployeeMovements.Find(id);

        public void UpdateEmployeeMovement(EmployeeMovement employeeMovement)
        {
            context.Update(employeeMovement);
            context.SaveChanges();

        }
    }
}