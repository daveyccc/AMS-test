using AssetManagement.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Interfaces
{
    public interface IActivityService
    {
        Task<List<Activity>> GetAll();
        Task<Activity?> GetById(int id);
        Task Add(Activity activity);
        Task Update(Activity activity);
        Task Delete(int id);
        Task<List<Activity>> GetByAssetObjectiveId(int assetObjectiveId);
    }
}
