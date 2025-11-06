using AssetManagement.BusinessLogic.Interfaces;
using AssetManagement.DataAccess;
using AssetManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Services
{
    public class AuditFindingService : IAuditFindingService
    {
        private readonly ApplicationDbContext _context;

        public AuditFindingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AuditFinding>> GetAll()
        {
            return await _context.AuditFindings.ToListAsync();
        }

        public async Task<AuditFinding?> GetById(int id)
        {
            return await _context.AuditFindings.FindAsync(id);
        }

        public async Task Add(AuditFinding auditFinding)
        {
            _context.AuditFindings.Add(auditFinding);
            await _context.SaveChangesAsync();
        }

        public async Task Update(AuditFinding auditFinding)
        {
            _context.Entry(auditFinding).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var auditFinding = await _context.AuditFindings.FindAsync(id);
            if (auditFinding != null)
            {
                _context.AuditFindings.Remove(auditFinding);
                await _context.SaveChangesAsync();
            }
        }
    }
}
