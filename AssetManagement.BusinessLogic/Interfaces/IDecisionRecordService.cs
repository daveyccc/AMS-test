using AssetManagement.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Interfaces
{
    public interface IDecisionRecordService
    {
        Task<List<DecisionRecord>> GetAll();
        Task<DecisionRecord?> GetById(int id);
        Task Add(DecisionRecord decisionRecord);
        Task Update(DecisionRecord decisionRecord);
        Task Delete(int id);
    }
}
