using AssetManagement.BusinessLogic.Interfaces;
using AssetManagement.DataAccess;
using AssetManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Services
{
    public class AssetObjectiveService : IAssetObjectiveService
    {
        private readonly ApplicationDbContext _context;

        public AssetObjectiveService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AssetObjective>> GetAll()
        {
            return await _context.AssetObjectives.ToListAsync();
        }

        public async Task<AssetObjective?> GetById(int id)
        {
            return await _context.AssetObjectives.FindAsync(id);
        }

        public async Task Add(AssetObjective assetObjective)
        {
            _context.AssetObjectives.Add(assetObjective);
            await _context.SaveChangesAsync();
        }

        public async Task Update(AssetObjective assetObjective)
        {
            _context.Entry(assetObjective).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var assetObjective = await _context.AssetObjectives.FindAsync(id);
            if (assetObjective != null)
            {
                _context.AssetObjectives.Remove(assetObjective);
                await _context.SaveChangesAsync();
            }
        }
    }
}
