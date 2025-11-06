using AssetManagement.BusinessLogic.Interfaces;
using AssetManagement.DataAccess;
using AssetManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Services
{
    public class AssetService : IAssetService
    {
        private readonly ApplicationDbContext _context;

        public AssetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Asset>> GetAll()
        {
            return await _context.Assets.ToListAsync();
        }

        public async Task<Asset?> GetById(int id)
        {
            return await _context.Assets.FindAsync(id);
        }

        public async Task Add(Asset asset)
        {
            _context.Entry(asset).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task Update(Asset asset)
        {
            _context.Entry(asset).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset != null)
            {
                _context.Assets.Remove(asset);
                await _context.SaveChangesAsync();
            }
        }
    }
}
