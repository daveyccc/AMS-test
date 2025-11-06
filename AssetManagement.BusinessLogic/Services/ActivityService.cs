using AssetManagement.BusinessLogic.Interfaces;
using AssetManagement.DataAccess;
using AssetManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Services
{
    public class ActivityService : IActivityService
    {
        private readonly ApplicationDbContext _context;

        public ActivityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Activity>> GetAll()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task<Activity?> GetById(int id)
        {
            return await _context.Activities.FindAsync(id);
        }

        public async Task Add(Activity activity)
        {
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Activity activity)
        {
            _context.Entry(activity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Activity>> GetByAssetObjectiveId(int assetObjectiveId)
        {
            return await _context.Activities
                .Where(a => a.AssetObjectiveId == assetObjectiveId)
                .ToListAsync();
        }
    }
}
