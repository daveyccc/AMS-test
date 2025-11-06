using AssetManagement.BusinessLogic.Interfaces;
using AssetManagement.DataAccess;
using AssetManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Services
{
    public class DecisionRecordService : IDecisionRecordService
    {
        private readonly ApplicationDbContext _context;

        public DecisionRecordService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DecisionRecord>> GetAll()
        {
            return await _context.DecisionRecords.ToListAsync();
        }

        public async Task<DecisionRecord?> GetById(int id)
        {
            return await _context.DecisionRecords.FindAsync(id);
        }

        public async Task Add(DecisionRecord decisionRecord)
        {
            _context.DecisionRecords.Add(decisionRecord);
            await _context.SaveChangesAsync();
        }

        public async Task Update(DecisionRecord decisionRecord)
        {
            _context.Entry(decisionRecord).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var decisionRecord = await _context.DecisionRecords.FindAsync(id);
            if (decisionRecord != null)
            {
                _context.DecisionRecords.Remove(decisionRecord);
                await _context.SaveChangesAsync();
            }
        }
    }
}
