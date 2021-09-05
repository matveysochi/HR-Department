using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRD.Models
{
    public class Division
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Необходимо указать код подразделения")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Необходимо указать наименование подразделения")]
        public string Name { get; set; }
        public IEnumerable<DivisionMovement> DivisionMovements { get; set; }
        public IEnumerable<DivisionMovement> SubdivisionMovements { get; set; }

        public override string ToString()
        {
            return $"{Code}.{Name}";
        }
    }
}