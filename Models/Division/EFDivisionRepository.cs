using System.Collections.Generic;
using System.Linq;

namespace HRD.Models
{
    public class EFDivisionRepository : IDivisionRepository
    {
        readonly AppDbContext context;
        public EFDivisionRepository(AppDbContext context) => this.context = context;

        public IEnumerable<Division> Divisions => context.Divisions.ToArray();

        public void AddDivision(Division division)
        {
            context.Add(division);
            context.SaveChanges();
        }

        public Division GetDivision(long id) => context.Divisions.Find(id);

        public void UpdateDivision(Division division)
        {
            context.Update(division);
            context.SaveChanges();
        }
    }
}