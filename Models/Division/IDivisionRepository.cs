using System.Collections.Generic;

namespace HRD.Models
{
    public interface IDivisionRepository
    {
        IEnumerable<Division> Divisions { get; }
        Division GetDivision(long id);
        void AddDivision (Division employee);
        void UpdateDivision(Division employee);
    }
}