using AssetManagement.BusinessLogic.Interfaces;
using AssetManagement.DataAccess;
using AssetManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Services
{
    public class DataAssetService : IDataAssetService
    {
        private readonly ApplicationDbContext _context;

        public DataAssetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DataAsset>> GetAll()
        {
            return await _context.DataAssets.ToListAsync();
        }

        public async Task<DataAsset?> GetById(int id)
        {
            return await _context.DataAssets.FindAsync(id);
        }

        public async Task Add(DataAsset dataAsset)
        {
            _context.DataAssets.Add(dataAsset);
            await _context.SaveChangesAsync();
        }

        public async Task Update(DataAsset dataAsset)
        {
            _context.Entry(dataAsset).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var dataAsset = await _context.DataAssets.FindAsync(id);
            if (dataAsset != null)
            {
                _context.DataAssets.Remove(dataAsset);
                await _context.SaveChangesAsync();
            }
        }
    }
}
