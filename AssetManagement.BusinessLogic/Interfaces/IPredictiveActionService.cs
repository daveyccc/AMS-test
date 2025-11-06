using AssetManagement.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Interfaces
{
    public interface IPredictiveActionService
    {
        Task<List<PredictiveAction>> GetAll();
        Task<PredictiveAction?> GetById(int id);
        Task Add(PredictiveAction predictiveAction);
        Task Update(PredictiveAction predictiveAction);
        Task Delete(int id);
    }
}
