using System.Collections.Generic;

namespace HRD.Models
{
    public interface IEmployeeMovementRepository
    {
        IEnumerable<EmployeeMovement> EmployeeMovements { get; }
        EmployeeMovement GetEmployeeMovement(long id);
        void AddEmployeeMovement(EmployeeMovement employeeMovement);
        void UpdateEmployeeMovement(EmployeeMovement employeeMovement);
    }
}