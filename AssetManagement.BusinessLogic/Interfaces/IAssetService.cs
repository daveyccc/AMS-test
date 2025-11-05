using AssetManagement.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Interfaces
{
    public interface IAssetService
    {
        Task<List<Asset>> GetAll();
        Task<Asset?> GetById(int id);
        Task Add(Asset asset);
        Task Update(Asset asset);
        Task Delete(int id);
    }
}
