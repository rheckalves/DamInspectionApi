using DamInspectionApi.Data;
using DamInspectionApi.Models;
using DamInspectionApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamInspectionApi.Repositories
{
    public class DamRepository : CrudRepository<Dam>, IDamRepository
    {
        public DamRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Sobrescrevendo o GetAllAsync para incluir Inspections
        public override async Task<IEnumerable<Dam>> GetAllAsync()
        {
            return await _context.Dams.Include(d => d.Inspections).ToListAsync();
        }
    }
}
