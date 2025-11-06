using AssetManagement.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Interfaces
{
    public interface IAuditFindingService
    {
        Task<List<AuditFinding>> GetAll();
        Task<AuditFinding?> GetById(int id);
        Task Add(AuditFinding auditFinding);
        Task Update(AuditFinding auditFinding);
        Task Delete(int id);
    }
}
