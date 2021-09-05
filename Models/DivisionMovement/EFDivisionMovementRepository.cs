using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HRD.Models
{
    public class EFDivisionMovementRepository : IDivisionMovementRepository
    {
        readonly AppDbContext context;
        public EFDivisionMovementRepository(AppDbContext context) => this.context = context;

        public IEnumerable<DivisionMovement> DivisionMovements => context.DivisionMovements
            .Include(m => m.Division)
            .Include(m => m.ParentDivision)
            .ToArray();

        public void AddDivisionMovement(DivisionMovement divisionMovement)
        {
            context.Add(divisionMovement);
            context.SaveChanges();
        }

        public DivisionMovement GetDivisionMovement(long id) => context.DivisionMovements.Find(id);

        public void UpdateDivisionMovement(DivisionMovement divisionMovement)
        {
            context.Update(divisionMovement);
            context.SaveChanges();
        }
    }
}