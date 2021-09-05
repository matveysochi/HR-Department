using System;
using System.ComponentModel.DataAnnotations;

namespace HRD.Models
{
    public class DivisionMovement
    {
        public long Id { get; set; }
        
        [Range(1, long.MaxValue, ErrorMessage = "Необходимо указать подразделение")]
        public long DivisionId { get; set; }
        public Division Division { get; set; }
        public long? ParentDivisionId { get; set; }
        public Division ParentDivision { get; set; }
        public DivisionMovementTypes MovementType { get; set; }
        public DateTime Date { get; set; }
    }
}