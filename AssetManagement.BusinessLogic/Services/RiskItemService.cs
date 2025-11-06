using AssetManagement.BusinessLogic.Interfaces;
using AssetManagement.DataAccess;
using AssetManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Services
{
    public class RiskItemService : IRiskItemService
    {
        private readonly ApplicationDbContext _context;

        public RiskItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RiskItem>> GetAll()
        {
            return await _context.RiskItems.ToListAsync();
        }

        public async Task<RiskItem?> GetById(int id)
        {
            return await _context.RiskItems.FindAsync(id);
        }

        public async Task Add(RiskItem riskItem)
        {
            _context.RiskItems.Add(riskItem);
            await _context.SaveChangesAsync();
        }

        public async Task Update(RiskItem riskItem)
        {
            _context.Entry(riskItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var riskItem = await _context.RiskItems.FindAsync(id);
            if (riskItem != null)
            {
                _context.RiskItems.Remove(riskItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
