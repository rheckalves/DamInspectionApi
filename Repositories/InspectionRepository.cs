using DamInspectionApi.Models;
using DamInspectionApi.Repositories.Interfaces;
using DamInspectionApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamInspectionApi.Repositories
{
    public class InspectionRepository : CrudRepository<Inspection>, IInspectionRepository
    {
        public InspectionRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Sobrescrevendo o método GetAllAsync para incluir a entidade Dam
        public override async Task<IEnumerable<Inspection>> GetAllAsync()
        {
            return await _context.Inspections.Include(i => i.Dam).ToListAsync();
        }
    }
}
