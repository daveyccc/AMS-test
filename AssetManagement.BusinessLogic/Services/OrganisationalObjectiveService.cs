using AssetManagement.BusinessLogic.Interfaces;
using AssetManagement.DataAccess;
using AssetManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Services
{
    public class OrganisationalObjectiveService : IOrganisationalObjectiveService
    {
        private readonly ApplicationDbContext _context;

        public OrganisationalObjectiveService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrganisationalObjective>> GetAll()
        {
            return await _context.OrganisationalObjectives.Include(o => o.AssetObjectives).ToListAsync();
        }

        public async Task<OrganisationalObjective?> GetById(int id)
        {
            return await _context.OrganisationalObjectives.Include(o => o.AssetObjectives).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task Add(OrganisationalObjective objective)
        {
            _context.OrganisationalObjectives.Add(objective);
            await _context.SaveChangesAsync();
        }

        public async Task Update(OrganisationalObjective objective)
        {
            _context.Entry(objective).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var objective = await _context.OrganisationalObjectives.FindAsync(id);
            if (objective != null)
            {
                _context.OrganisationalObjectives.Remove(objective);
                await _context.SaveChangesAsync();
            }
        }
    }
}
