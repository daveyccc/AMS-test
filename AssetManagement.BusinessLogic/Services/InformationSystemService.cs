using AssetManagement.BusinessLogic.Interfaces;
using AssetManagement.DataAccess;
using AssetManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Services
{
    public class InformationSystemService : IInformationSystemService
    {
        private readonly ApplicationDbContext _context;

        public InformationSystemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<InformationSystem>> GetAll()
        {
            return await _context.InformationSystems.Include(i => i.DataAssets).ToListAsync();
        }

        public async Task<InformationSystem?> GetById(int id)
        {
            return await _context.InformationSystems.Include(i => i.DataAssets).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task Add(InformationSystem informationSystem)
        {
            _context.InformationSystems.Add(informationSystem);
            await _context.SaveChangesAsync();
        }

        public async Task Update(InformationSystem informationSystem)
        {
            _context.Entry(informationSystem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var informationSystem = await _context.InformationSystems.FindAsync(id);
            if (informationSystem != null)
            {
                _context.InformationSystems.Remove(informationSystem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
