using AssetManagement.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Interfaces
{
    public interface IAssetObjectiveService
    {
        Task<List<AssetObjective>> GetAll();
        Task<AssetObjective?> GetById(int id);
        Task Add(AssetObjective assetObjective);
        Task Update(AssetObjective assetObjective);
        Task Delete(int id);
    }
}
