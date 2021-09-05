using System.Collections.Generic;

namespace HRD.Models
{
    public interface IDivisionMovementRepository
    {
        IEnumerable<DivisionMovement> DivisionMovements { get; }
        DivisionMovement GetDivisionMovement(long id);
        void AddDivisionMovement(DivisionMovement divisionMovement);
        void UpdateDivisionMovement(DivisionMovement divisionMovement);
    }
}