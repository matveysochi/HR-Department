using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HRD.Models
{
    public class Employee
    {
        public long Id { get; set; }
        
        [Required(ErrorMessage = "���������� ������� ��� ����������")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "���������� ������� ������� ����������")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "���������� ������� �������� ����������")]
        public string Patronymic { get; set; }
        public IEnumerable<EmployeeMovement> EmployeeMovements { get; set; }
        public override string ToString()
        {
            string initials = "";
            if (!string.IsNullOrWhiteSpace(Name)) initials = $"{Name}.";
            if (!string.IsNullOrWhiteSpace(Patronymic)) initials += $"{Patronymic}.";
            return $"{Surname} {initials}";
        }
    }
}                                                                                                                                                                                                                                                                                                                                              