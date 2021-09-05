using System;
using System.ComponentModel.DataAnnotations;

namespace HRD.Models
{
    public class EmployeeMovement
    {
        public long Id { get; set; }
        
        [Range(1, long.MaxValue, ErrorMessage = "Необходимо указать сотрудника")]
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Необходимо указать подразделение")]
        public long DivisionId { get; set; }
        public Division Division { get; set; }

        public EmployeeMovementTypes MovementType { get; set; }
        public DateTime Date { get; set; }
    }
}