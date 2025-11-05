using AssetManagement.BusinessLogic.Interfaces;
using AssetManagement.DataAccess;
using AssetManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Services
{
    public class PredictiveActionService : IPredictiveActionService
    {
        private readonly ApplicationDbContext _context;

        public PredictiveActionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PredictiveAction>> GetAll()
        {
            return await _context.PredictiveActions.ToListAsync();
        }

        public async Task<PredictiveAction?> GetById(int id)
        {
            return await _context.PredictiveActions.FindAsync(id);
        }

        public async Task Add(PredictiveAction predictiveAction)
        {
            _context.PredictiveActions.Add(predictiveAction);
            await _context.SaveChangesAsync();
        }

        public async Task Update(PredictiveAction predictiveAction)
        {
            _context.Entry(predictiveAction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var predictiveAction = await _context.PredictiveActions.FindAsync(id);
            if (predictiveAction != null)
            {
                _context.PredictiveActions.Remove(predictiveAction);
                await _context.SaveChangesAsync();
            }
        }
    }
}
